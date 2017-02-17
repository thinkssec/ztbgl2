using Enterprise.Service.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Project
{
    /// <summary>
    /// 项目成果交付页面
    /// </summary>
    public partial class ZbglPfbzM2List : BasePage
    {


        #region 初始化参数区

        public ProjectPfmbService Service = new ProjectPfmbService();
        public ProjectInfoService infSrv = new ProjectInfoService();

        public string id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public decimal lost = 0;

        #endregion

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCommand();

            if (!IsPostBack)
            {
                OnCondition();
                BindGrid();
            }
        }



        #region 页面方法区


        private void OnCondition()
        {
            //end
            //执行相应的动作
            if (Cmd == "New")
            {
                doAddAction();
            }
            else if (Cmd == "Edit")
            {
                doUpdAction();
            }
            else if (Cmd == "Delete")
            {
                doDelAction();
            }
        }

        /// <summary>
        /// 绑定命令
        /// </summary>
        private void BindCommand()
        {
            ProjectInfoService ppps = new ProjectInfoService();
            ProjectInfoModel ppp = ppps.GetList().FirstOrDefault(f => f.PROJID == ProjectId);
            //p判断模板管理权限
            if (SysUserPermissionService.CheckPageCode(this.userModel.USERID, 1, "0602", (int)Utility.PopedomType.New) || this.userModel.UADMIN == 1)
            {
                CreateBT.AddButton("new.gif", "新增", "ZbglPfbzM2List.aspx?Cmd=New&ProjectId="+ProjectId, Utility.PopedomType.List, HeadMenu1);
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            }
            else
            {
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            }
            CreateBT.AddButton("back.gif", "返回", "ZbglPfbzList.aspx?ProjectId=" + ProjectId, Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrid()
        {
            IList<ProjectPfmbModel> list = Service.GetList().OrderBy(o => o.MNAME).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        /// <summary>
        /// 添加操作
        /// </summary>
        private void doAddAction()
        {
            //tb_HalfDATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //lb_ProjectName.Text = Enterprise.Service.App.Project.ProjectHalfService.GetProjectName(projectId);
            p1.Visible = true;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        private void doDelAction()
        {
            ProjectPfmbModel memModel = Service.GetList().Where(p=>p.MID==id).FirstOrDefault();
            memModel.DB_Option_Action = WebKeys.DeleteAction;
            Service.Execute(memModel);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        private void doUpdAction()
        {
            ProjectPfmbModel Model = Service.GetList().Where(p => p.MID == id).FirstOrDefault();
            t_MNAME.Text = Model.MNAME;
            t_BZ.Text = Model.BZ;
            //tb_MEMO.Text = Model.MEMO;
            //tb_HalfDATE.Text = Model.DELIVERYDATE.ToDateYMDFormat();
            //tb_RECEIVER.Text = Model.RECEIVER;
            //tb_HalfName.Text = Model.DELIVERYNAME;
            //ddl_OPERATOR.UserSelectValue = Model.OPERATOR.ToRequestString();
            //ddl_OPERATOR.DataBind();
            //Txt_ATTACHMENT.Text = Txt_ATTACHMENT.Value = Model.ATTACHMENT;
            //lb_ProjectName.Text = Enterprise.Service.App.Project.ProjectHalfService.GetProjectName(Model.PROJID);
            p1.Visible = true;
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='ZbglPfbzM2List.aspx?Cmd=Edit&Id={0}&ProjectId={1}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", id,ProjectId);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZbglPfbzM2List.aspx?Cmd=Delete&Id={0}&ProjectId={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>",id,ProjectId);
            return btnStrs;
        }

        #endregion


        #region 事件处理区

        /// <summary>
        /// 分页处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ProjectPfmbModel Model = Service.GetList().Where(p => p.MID == id).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectPfmbModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                Model.MID = Guid.NewGuid().ToString();
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            Model.MNAME = t_MNAME .Text;
            Model.BZ = t_BZ.Text;
            //Model.DELIVERYDATE = tb_HalfDATE.Text.ToDateTimeNullabel();
            //Model.DELIVERYNAME = tb_HalfName.Text;
            //Model.MEMO = tb_MEMO.Text;
            //Model.OPERATOR = ddl_OPERATOR.UserSelectValue.ToInt();
            //Model.RECEIVER = tb_RECEIVER.Text;
            //Model.ATTACHMENT = Txt_ATTACHMENT.DBValue;
            //Model.SUBMITDATE = DateTime.Now;
            bool isOk = Service.Execute(Model);

            if (isOk)
            {
               
            }

            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ZbglPfbzM2List.aspx?ProjectId="+ProjectId);

        }

        #endregion



    }
}