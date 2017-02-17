﻿using Enterprise.Service.Basis;
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
using Enterprise.Service.App.Crm;
using Enterprise.Model.App.Crm;

namespace Enterprise.UI.Web.Modules.App.Project
{
    /// <summary>
    /// 项目成果交付页面
    /// </summary>
    public partial class ZbglFjxx : BasePage
    {


        #region 初始化参数区

        /// <summary>
        /// 成果交付--服务类
        /// </summary>
        public ProjectKbhqdbService Service = new ProjectKbhqdbService();
        public ProjectInfoService infSrv = new ProjectInfoService();
        public string fjhtml = "";
        public string fjstr = (string)Utility.sink("fjstr", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 项目ID
        /// </summary>
        public string projectId = (string)Utility.sink("ProjectId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 节点编码
        /// </summary>
        public string nodeCode = (string)Utility.sink("NodeCode", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
        public string id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public decimal lost = 0;

        ProjectInfoModel inM =null;
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
            //inM = infSrv.GetList().Where(p => p.PROJID == ProjectId).FirstOrDefault(); 
            //if (inM.SUBMITTER==this.userModel.USERID||this.userModel.UADMIN==1)
            //{
            //    CreateBT.AddButton("new.gif", "新增", "ZbglKbhqdb.aspx?Cmd=New&ProjectId=" + projectId + "&NodeCode=" + nodeCode, Utility.PopedomType.List, HeadMenu1);
                
            //}
            //else
            //{
                
            //}
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrid()
        {
            fjhtml = Enterprise.Service.Common.Article.ArticleInfoService.ToAttachHtml2(fjstr);
            
        }

        /// <summary>
        /// 添加操作
        /// </summary>
        private void doAddAction()
        {
            //tb_HalfDATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //lb_ProjectName.Text = Enterprise.Service.App.Project.ProjectHalfService.GetProjectName(projectId);
            //p1.Visible = true;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        private void doDelAction()
        {
            
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        private void doUpdAction()
        {
            ProjectKbhqdbModel Model = Service.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            //Model.P1 = Txt_param_001.Text;
            //Model.P2 = Txt_param_002.Text;
            //Model.P3 = Txt_param_003.Text;
            //Model.P4 = Txt_param_004.Text;
            //Model.P5 = Txt_param_005.Text;

            //Model.P6 = Txt_param_006.Text;
            //Model.P7 = Txt_param_007.Text;
            //Model.P8 = Txt_param_008.Text;
            //Model.P9 = Txt_param_009.Text;
            //Model.LQDD = Txt_param_001.Text;
            Model.SUBMITTER = this.userModel.USERID;
            Model.SUBMITTIME = DateTime.Now;
            Model.DB_Option_Action = WebKeys.UpdateAction;
            Service.Execute(Model);
            //tb_MEMO.Text = Model.MEMO;
            //tb_HalfDATE.Text = Model.DELIVERYDATE.ToDateYMDFormat();
            //tb_RECEIVER.Text = Model.RECEIVER;
            //tb_HalfName.Text = Model.DELIVERYNAME;
            //ddl_OPERATOR.UserSelectValue = Model.OPERATOR.ToRequestString();
            //ddl_OPERATOR.DataBind();
            //Txt_ATTACHMENT.Text = Txt_ATTACHMENT.Value = Model.ATTACHMENT;
            //lb_ProjectName.Text = Enterprise.Service.App.Project.ProjectHalfService.GetProjectName(Model.PROJID);
            //p1.Visible = true;
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='ZbglKbhqdb.aspx?Cmd=Edit&ProjectId={0}&Id={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", projectId, id, nodeCode);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZbglKbhqdb.aspx?Cmd=Delete&ProjectId={0}&Id={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", projectId, id, nodeCode);
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
            
            BindGrid();
        }

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ProjectKbhqdbModel Model = Service.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectKbhqdbModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                
                Model.PROJID = projectId;
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }

            //Model.P1 = Txt_param_001.Text;
            //Model.P2 = Txt_param_002.Text;
            //Model.P3 = Txt_param_003.Text;
            //Model.P4 = Txt_param_004.Text;
            //Model.P5 = Txt_param_005.Text;

            //Model.P6 = Txt_param_006.Text;
            //Model.P7 = Txt_param_007.Text;
            //Model.P8 = Txt_param_008.Text;
            //Model.P9 = Txt_param_009.Text;
            Model.SUBMITTER = this.userModel.USERID;
            Model.SUBMITTIME = DateTime.Now;
            //Model.FNAMES = Txt_SCFJ.Text;
            //Model.FVIEWNAMES = Txt_SCFJ.DBValue;
            bool isOk = Service.Execute(Model);

            if (isOk)
            {
               
            }
            ZbwjService.CreateKbhqdb(projectId);
            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ZbglKbhqdb.aspx?ProjectId=" + projectId + "&NodeCode=" + nodeCode);

        }
        protected void BtnSave_Up(object sender, EventArgs e)
        {
            ProjectKbhqdbModel Model = Service.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectKbhqdbModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                Model.PROJID = projectId;
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            //Model.FNAMES = Txt_SCFJ.Text;
            //Model.FVIEWNAMES = Txt_SCFJ.DBValue;
            bool isOk = Service.Execute(Model);

            if (isOk)
            {

            }
            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ZbglKbhqdb.aspx?ProjectId=" + ProjectId);

        }
        #endregion



    }
}