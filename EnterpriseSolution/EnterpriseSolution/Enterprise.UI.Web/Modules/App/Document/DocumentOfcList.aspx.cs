using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.App.Document;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.App.Document;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Modules.App.Document
{
    public partial class DocumentOfcList :Enterprise.Service.Basis.BasePage
    {

        protected string ModuleId = (string)Utility.sink("ModuleId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void OnCommand()
        {
            string s =SysModuleService.GetModuleName(ModuleId);
            //CreateBT.AddButton("list.gif", this.Trans("查询"), "DocumentOfcList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
            if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.New))
            CreateBT.AddButton("new.gif", this.Trans("发布公文"), "DocumentOfcEdit.aspx?ModuleId=" + ModuleId, Utility.PopedomType.New, HeadMenu1);
            lb_MName.Text = s;
        }

        private void BindGrid()
        {
            OnCommand();
            DocumentOfficialService Service = new DocumentOfficialService();
            var list = new List<DocumentOfficialModel>();
            list = Service.GetList().OrderByDescending(p => p.CREATETIME).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        public void Bt_Search_OnClick(object sender, EventArgs e)
        {
            OnCommand();
            string sType = (string)Utility.sink(s_Type.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            string sKey = (string)Utility.sink(s_Key.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            DocumentOfficialService Service = new DocumentOfficialService();
            var list = Service.GetList().OrderByDescending(p => p.CREATETIME).ToList();
            if (sType == "TITLE")
                list = list.Where(p=>p.TITLE.Contains(sKey)).ToList();
            if (sType == "CONTENT")
                list = list.Where(p => p.CONTENT.Contains(sKey)).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        public string CutString(object str,int length)
        {
            return (str != null) ? str.ToString().CutString(length) : "";
        }
        protected string GetStatus(object obj)
        {
            DocumentOfficialModel model = obj as DocumentOfficialModel;
            string sName = string.Empty;
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            switch (model.STATUS.ToRequestString())
            {
                case "0":
                    sName ="等待"+SysUserService.GetUserName((int) model.RECEVIEUSER)+"签收";
                    break;
                case "1":
                    sName = "已经签收";
                    break;
                case "2":
                    sName = "提交" + SysUserService.GetUserName((int)model.ORGANIZER) + "承办";
                    break;
                case "3":
                    sName = "提交承办结果";
                    break;
            }

            switch (model.SHSTATUS.ToRequestString())
            {

                case "1":
                    sName = "审核通过";
                    break;
                case "2":
                    sName = "审核不通过";
                    break;
            }
            return sName;
        }

        protected string GetURL(object obj)
        {
            DocumentOfficialModel model = obj as DocumentOfficialModel;
            string sName = "<a href=\"DocumentOfcAudit.aspx?Cmd=View&Id=" + model.DOCID + "&ModuleId=" + ModuleId + "\">" + model.TITLE + "</a>";
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            //switch (model.STATUS.ToRequestString())
            //{
            //    case "0":
            //        sName = "<a href=\"DocumentOfcRecv.aspx?Cmd=View&Id=" + model.DOCID + "&ModuleId=" + ModuleId + "\">" + model.TITLE + "</a>";
            //        break;
            //    case "1":
            //        sName = "<a href=\"DocumentOfcRecv.aspx?Cmd=View&Id=" + model.DOCID + "&ModuleId=" + ModuleId + "\">" + model.TITLE + "</a>";
            //        break;
            //    case "2":
            //        sName = "<a href=\"DocumentOfcOrgn.aspx?Cmd=View&Id=" + model.DOCID + "&ModuleId=" + ModuleId + "\">" + model.TITLE + "</a>";
            //        break;
            //    case "3":
            //        sName = "<a href=\"DocumentOfcAudit.aspx?Cmd=View&Id=" + model.DOCID + "&ModuleId=" + ModuleId + "\">" + model.TITLE + "</a>";
            //        break;
            //}

            return sName;
        }
    }
}