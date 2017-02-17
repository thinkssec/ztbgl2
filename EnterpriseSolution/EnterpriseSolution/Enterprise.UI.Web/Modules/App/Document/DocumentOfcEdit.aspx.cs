using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Document;
using Enterprise.Service.App.Document;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
namespace Enterprise.UI.Web.Modules.App.Document
{
    public partial class DocumentOfcEdit : Enterprise.Service.Basis.BasePage
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
            CreateBT.AddButton("back.gif", Trans("返回"), "DocumentOfcList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            int deptId = 0;
            lb_User.Text =SysUserService.GetUserName(Utility.Get_UserId, out deptId);
            lb_Dept.Text =SysDepartmentService.GetDepartMentName(deptId);
            t_Time.Text = DateTime.Now.ToDateYMDFormat();
            if (Cmd == "Edit")
            {
                OnBindData();
            }
            else if (Cmd == "Delete")
            {
                DocumentOfficialService aService = new DocumentOfficialService();
                var q = aService.GetList().FirstOrDefault(p=>p.DOCID==Id);
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
                    Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "DocumentOfcList.aspx?ModuleId=" + ModuleId);
                }
            }
        }

        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            DocumentOfficialService aService = new DocumentOfficialService();
            var q = aService.GetList().FirstOrDefault(p=>p.DOCID==Id);
            if (q != null)
            {
                t_Title.Text = q.TITLE;
                t_Content.Text = q.CONTENT;
                single_RcvUsers.UserSelectValue = q.RECEVIEUSER.ToRequestString();
                lb_User.Text = SysUserService.GetUserName((int)q.CREATEUSER);
                //多附件初始化
                t_Time.Text = q.RELEASETIME.ToDateYMDFormat();
                tb_AFVIewNames.DBValue = q.FVIEWNAMES;
                lb_Dept.Text = SysDepartmentService.GetDepartMentName((int)q.CREATEDEPT);

                //end
            }
        }
        private string sendMessageToRecv(DocumentOfficialModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                model.DOCID,//和项目关联的消息
                model.RECEVIEUSER.Value,//接收人
                this.userModel,//当前用户
                string.Format("{0}-新公文发布，需要您进行签收!", model.TITLE),//消息标题
                string.Format("/Modules/App/Document/DocumentOfcRecv.aspx?Cmd=Recv&Id={0}", model.DOCID),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
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
                DocumentOfficialService aService = new DocumentOfficialService();
                DocumentOfficialModel entity = new DocumentOfficialModel();
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = "Insert";
                    entity.DOCID = CommonTool.GetGuidKey();
                    entity.CREATEUSER = Utility.Get_UserId;
                    entity.CREATETIME = DateTime.Now;
                    entity.CREATEDEPT =SysUserService.GetUserDeptId(Utility.Get_UserId);
                }
                else if (Cmd == "Edit")
                {
                    entity = aService.GetList().FirstOrDefault(p=>p.DOCID==Id);
                    entity.DB_Option_Action = "Update";
                }

                entity.RECEVIEUSER = single_RcvUsers.UserSelectValue.ToInt();
                entity.RELEASETIME = t_Time.Text.ToDateTime();
                entity.TITLE = t_Title.Text;
                entity.CONTENT = t_Content.Text;
                if (string.IsNullOrEmpty(entity.CONTENT))
                {
                    entity.CONTENT = "&nbsp;";
                }
                entity.FNAMES = tb_AFVIewNames.Text;
                entity.FVIEWNAMES = tb_AFVIewNames.DBValue;
                entity.STATUS = 0;
                if (aService.Execute(entity))
                {
                    BfMsgService bs = new BfMsgService();
                    var l = bs.GetUnhandleList().Where(p=>p.BF_INSTANCEID==entity.DOCID);
                    foreach (var q in l)
                    {
                        q.DB_Option_Action = WebKeys.DeleteAction;
                        bs.ExecuteUnhandle(q);
                    }
                    sendMessageToRecv(entity);
                }
               
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "DocumentOfcList.aspx?ModuleId=" + ModuleId);
        }

    }
}