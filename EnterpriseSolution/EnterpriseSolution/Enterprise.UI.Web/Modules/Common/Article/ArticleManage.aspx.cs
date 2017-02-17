using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
namespace Enterprise.UI.Web.Modules.Common.Article
{
    public partial class ArticleManage : Enterprise.Service.Basis.BasePage
    {
        protected string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string ModuleId = (string)Utility.sink("ModuleId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string odId = (string)Utility.sink("odId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s =SysModuleService.GetModuleName(ModuleId);
                lb_MName.Text = s;
                OnStart();
                OnCommand();
            }
        }

        /// <summary>
        /// 控制按钮
        /// </summary>
        private void OnCommand()
        {
            //添加操作按钮
            CreateBT.AddButton("back.gif", Trans("返回"), "ArticleList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            int deptId = 0;
            lb_User.Text =SysUserService.GetUserName(Utility.Get_UserId, out deptId);
            lb_Dept.Text =SysDepartmentService.GetDepartMentName(deptId);
            if (Cmd == "Edit")
            {
                OnBindData();
            }
            else if (Cmd == "Delete")
            {
                ArticleInfoService aService = new ArticleInfoService();
                var q = aService.ArticleInfoDisp(Id);
                if (q != null)
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        aService.Execute(q);
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ArticleList.aspx?ModuleId=" + ModuleId);
                }
            }
        }

        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            ArticleInfoService aService = new ArticleInfoService();
            var q = aService.ArticleInfoDisp(Id);
            if (q != null)
            {
                ListItem li = t_Type.Items.FindByValue(q.ATYPE);
                if (li != null)
                {
                    li.Selected = true;
                }
                t_Time.Text = q.AINVALIDTIME.Value.ToShortDateString();
                t_Title.Text = q.ATITLE;
                t_TitleRu.Text = q.ATITLERU;
                t_Content.Text = q.ACONTENT;
                muti_RcvUsers.Value = q.ARECEVIEUSER;
                //多附件初始化
                
                tb_AFVIewNames.DBValue = q.AFVIEWNAMES;
                
                //end
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                ArticleInfoService aService = new ArticleInfoService();
                ArticleInfoModel entity = new ArticleInfoModel();
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = "Insert";
                    entity.ARTICLEID = CommonTool.GetGuidKey();
                    entity.ARELEASETIME = DateTime.Now;
                    entity.ACREATEUSER = Utility.Get_UserId;
                    entity.ACREATETIME = DateTime.Now;
                    entity.AMODULEID = ModuleId;
                    entity.ADEPARTMENT =SysUserService.GetUserDeptId(Utility.Get_UserId);
                    entity.AUSER = Utility.Get_UserId;
                }
                else if (Cmd == "Edit")
                {
                    entity = aService.ArticleInfoDisp(Id);
                    ModuleId = entity.AMODULEID;
                    entity.DB_Option_Action = "Update";
                }
                entity.ATYPE = (string)Utility.sink(t_Type.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.AINVALIDTIME = (DateTime)Utility.sink(t_Time.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Date);
                entity.ATITLE = (string)Utility.sink(t_Title.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                //entity.ATITLERU = (string)Utility.sink(t_TitleRu.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.ACONTENT = t_Content.Text;
                // (string)Utility.sink(t_Contentcn.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                //entity.ACONTENTRU = (string)Utility.sink(t_ContentRu.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                if (string.IsNullOrEmpty(entity.ACONTENT))
                {
                    entity.ACONTENT = "&nbsp;";
                }
                if (string.IsNullOrEmpty(entity.ACONTENTRU))
                {
                    entity.ACONTENTRU = "&nbsp;";
                }
                //by pengwei 改为上传用户控件
                entity.AFNAMES = tb_AFVIewNames.Text;
                entity.AFVIEWNAMES = tb_AFVIewNames.DBValue;
                //签收范围 改为用户控件
                entity.ARECEVIEUSER = muti_RcvUsers.Value;                       
                aService.Execute(entity);
                //if (entity.DB_Option_Action == WebKeys.InsertAction)
                //{
                //    Enterprise.Service.Basis.Rtx.RtxService.
                //        SendRtxMessageServices(entity.ARECEVIEUSER, this.Trans("办公事务") + " - " + SysModuleService.GetModuleName(ModuleId), this.Trans("发布新内容") + "：" + entity.ATITLE + "\r\n" + entity.ATITLERU);
                //}
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ArticleList.aspx?ModuleId=" + ModuleId);
        }

    }
}