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
    public partial class ZbglPfbzMEdit : BasePage
    {


        #region 初始化参数区

        /// <summary>
        /// 成果交付--服务类
        /// </summary>
        public ProjectPfbzmService Service = new ProjectPfbzmService();
        public ProjectInfoService infSrv = new ProjectInfoService();
        public string mId = (string)Utility.sink("MID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

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
            Hid_MID.Value = mId;
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
            if (SysUserPermissionService.CheckPageCode(this.userModel.USERID, 1, "0602", (int)Utility.PopedomType.New))
            {
                CreateBT.AddButton("new.gif", "新增", "ZbglPfbzMEdit.aspx?Cmd=New&MID=" + mId, Utility.PopedomType.List, HeadMenu1);
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            }
            else {
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            }
            CreateBT.AddButton("back.gif", "返回", "ZbglPfbzMList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrid()
        {
            IList<ProjectPfbzmModel> list = Service.GetList().Where(p => p.MID == Hid_MID.Value).OrderBy(o => o.XH).OrderBy(o => o.XMMC).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
            ProjectPfbzmModel Model = Service.GetList().Where(p => p.BZID == id).FirstOrDefault();
            lost = 100 - list.Sum(c=>c.FZ).Value;
            if (Model != null)
                lost = lost + Model.FZ.Value;
            t_FZ.Attributes.Add("max",lost+"");
            Utility.GroupRows(GridView1, 1);
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
            ProjectPfbzmModel memModel = Service.GetList().Where(p=>p.BZID==id).FirstOrDefault();
            memModel.DB_Option_Action = WebKeys.DeleteAction;
            Service.Execute(memModel);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        private void doUpdAction()
        {
            ProjectPfbzmModel Model = Service.GetList().Where(p => p.BZID == id).FirstOrDefault();
            Ddl_XMMC.SelectedValue = Model.XMMC;
            t_FZ.Text = Model.FZ.ToRequestString();
            t_PBFX.Text = Model.PBFX;
            t_PFBZ.Text = Model.PFBZ;
            t_XH.Text = Model.XH.ToRequestString();
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
            btnStrs += string.Format("<a href='ZbglPfbzMEdit.aspx?Cmd=Edit&MID={0}&Id={1}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", Hid_MID.Value, id);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZbglPfbzMEdit.aspx?Cmd=Delete&MID={0}&Id={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", Hid_MID.Value, id);
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
            ProjectPfbzmModel Model = Service.GetList().Where(p => p.BZID == id).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectPfbzmModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                Model.BZID = Guid.NewGuid().ToString();
                Model.MID = Hid_MID.Value;
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            Model.PBFX = t_PBFX.Text;
            Model.FZ = t_FZ.Text.ToDecimal();
            Model.PFBZ = t_PFBZ.Text;
            Model.MID = Hid_MID.Value;
            Model.XH = t_XH.Text.ToInt();
            Model.XMMC = Ddl_XMMC.SelectedValue;
            //Model.DELIVERYDATE = tb_HalfDATE.Text.ToDateTimeNullabel();
            //Model.DELIVERYNAME = tb_HalfName.Text;
            //Model.MEMO = tb_MEMO.Text;
            //Model.OPERATOR = ddl_OPERATOR.UserSelectValue.ToInt();
            //Model.RECEIVER = tb_RECEIVER.Text;
            //Model.ATTACHMENT = Txt_ATTACHMENT.DBValue;
            //Model.SUBMITDATE = DateTime.Now;
            Model.SUBMITTER = this.userModel.USERID;
            bool isOk = Service.Execute(Model);

            if (isOk)
            {
               
            }

            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ZbglPfbzMEdit.aspx?MID=" + Hid_MID.Value);

        }

        #endregion



    }
}