using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Service.Basis;
using Enterprise.Model.App.Document;
using Enterprise.Service.App.Document;
using Enterprise.Component.Control;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Document
{
    public partial class DocumentEditAndView : BasePage
    {
        string DkindId = (string)Utility.sink("DkindId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string DId = (string)Utility.sink("DId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        DocumentProjService DPservice = new DocumentProjService();
        DocumentKindService Kservice = new DocumentKindService();
        DocumentConfigService DcService = new DocumentConfigService();
        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {
                OnBindDDl();
                OnCondition();
            }

        }

        /// <summary>
        /// 绑定类别的下拉菜单
        /// </summary>
        private void OnBindDDl()
        {
            IList<DocumentKindModel> list = Kservice.GetTreeList();
            Ddl_Leibie.DataSource = list;
            Ddl_Leibie.DataTextField = "LBMC";
            Ddl_Leibie.DataValueField = "LBBH";
            Ddl_Leibie.DataBind();
        }

        /// <summary>
        /// 增加返回按钮
        /// </summary>
        private void OnCommand()
        {
            CreateBT.AddButton("back.gif", "返回", "DocunmentList.aspx?DkindId=" + DkindId, Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 根据条件呈现页面信息
        /// </summary>
        private void OnCondition()
        {
            if (Cmd == "New")
            {
                Ddl_DOCSTATUS.Enabled = true;
                Tb_DOCSAVEDATE.Text = DateTime.Now.ToDateYMDFormat();
                Panel_Edit.Visible = true;
                Panel_Detail.Visible = false;
                Panel_XMID.Visible = false;
            }
            if (Cmd == "Edit")
            {
                Ddl_DOCSTATUS.Enabled = true;
                Panel_Edit.Visible = true;
                Panel_Detail.Visible = false;
                Panel_XMID.Visible = false;
                DocumentProjModel DPmode = DPservice.GetSingle(DId);
                //Tb_DOCADDUSER.Text = DPmode.DOCADDUSER;
                Tb_DOCNAME.Text = DPmode.DOCNAME;
                Tb_DOCOVERVIEW.Text = DPmode.DOCOVERVIEW;
                Tb_DOCPATH.Text = Tb_DOCPATH.Value = DPmode.DOCPATH;
                //Tb_DOCPATH.DBValue = DPmode.DOCPATH;
                Tb_DOCQUARRY.Text = DPmode.DOCQUARRY;
                Tb_DOCSAVEDATE.Text = DPmode.DOCSAVEDATE.ToDateYMDFormat();
                Tb_DOCWRITER.Text = DPmode.DOCWRITER;
                ///Start：项目编号不为必填项，项目存档时自动带出 Edit by zy 
                //Tb_PROJID.Text = DPmode.PROJID;
                ///End
                Ddl_Leibie.SelectedValue = DPmode.LBBH;
                Ddl_DOCSTATUS.SelectedValue = DPmode.DOCSTATUS.ToRequestString();
            }
            if (Cmd == "View")
            {
                Panel_Edit.Visible = false;
                Panel_Detail.Visible = true;
                Panel_XMID.Visible = false;
                DocumentProjModel DPmode = DPservice.GetSingle(DId);
                if (DPmode != null)
                {
                    Lb_DOCADDUSER.Text = DPmode.DOCADDUSER;
                    Lb_DOCNAME.Text = DPmode.DOCNAME;
                    Lb_DOCOVERVIEW.Text = DPmode.DOCOVERVIEW;
                    Lb_DOCQUARRY.Text = DPmode.DOCQUARRY;
                    Lb_DOCSAVEDATE.Text = DPmode.DOCSAVEDATE.ToDateYMDFormat();
                    Lb_DOCSTATUS.Text = DocumentProjService.GetDOCSTATUS(DPmode.DOCSTATUS.ToInt());
                    Lb_DOCWRITER.Text = DPmode.DOCWRITER;
                    ///Add by zy 14.3.17 sta
                    Lb_ZXLL.Text = DocumentProjService.ToAttachHtml(DPmode, "View");
                    Lb_XZ.Text = DocumentProjService.ToAttachHtml(DPmode, "DownLoad");
                    ///end
                    Lb_LBBH.Text = DocumentKindService.GetKindName(DPmode.LBBH);
                    if (!string.IsNullOrEmpty(DPmode.PROJID))
                    {
                        Panel_XMID.Visible = true;
                        Lb_PROJMH.Text = DPmode.ProjectInfo.PROJNAME;
                    }
                }
            }
        }

        /// <summary>
        /// 提交保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtnEdit_Click(object sender, EventArgs e)
        {
            bool isok = false;
            DocumentProjModel Mod = DPservice.GetSingle(DId);
            if (Mod == null)
            {
                Mod = new DocumentProjModel();
                Mod.DB_Option_Action = WebKeys.InsertAction;
                Mod.DOCID = "DId" + CommonTool.GetPkId();
            }
            else
            {
                Mod.DB_Option_Action = WebKeys.UpdateAction;
            }
            // Mod.DOCADDUSER = Tb_DOCADDUSER.Text;
            Mod.DOCADDUSER = SysUserService.GetUserName(Utility.Get_UserId);
            Mod.DOCNAME = Tb_DOCNAME.Text;
            Mod.DOCOVERVIEW = Tb_DOCOVERVIEW.Text;
            //Mod.DOCPATH = Tb_DOCPATH.DBValue;
            Mod.DOCPATH = Tb_DOCPATH.Value;
            Mod.DOCQUARRY = Tb_DOCQUARRY.Text;
            Mod.DOCSAVEDATE = Tb_DOCSAVEDATE.Text.ToDateTime();
            Mod.DOCSTATUS = Ddl_DOCSTATUS.SelectedValue.ToInt();
            Mod.DOCWRITER = Tb_DOCWRITER.Text;
            Mod.LBBH = Ddl_Leibie.SelectedValue;
            ///start：项目编号不为必填项，项目存档时自动带出 Edit by zy 
            // Mod.PROJID = Tb_PROJID.Text;
            ///关联表ID暂时还没有用到
            // Mod.ASSOCIATIONID = Tb_PROJID.Text;
            ///end
            isok = DPservice.Execute(Mod);
            Utility.ShowMsg(this.Page, "系统提示", ((isok) ? "操作成功!" : "操作失败!!!"), "DocunmentList.aspx?DkindId=" + Ddl_Leibie.SelectedValue);
        }
    }
}