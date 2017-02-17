using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.Common.Article;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Common.Article;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Modules.Common.Article
{
    public partial class ArticleList :Enterprise.Service.Basis.BasePage
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
            CreateBT.AddButton("list.gif", this.Trans("查询"), "ArticleList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
            CreateBT.AddButton("new.gif", this.Trans("发布信息"), "ArticleManage.aspx?ModuleId=" + ModuleId, Utility.PopedomType.New, HeadMenu1);
            lb_MName.Text = s;
        }

        private void BindGrid()
        {
            OnCommand();
            ArticleInfoService aService = new ArticleInfoService();
            var list = new List<ArticleInfoModel>();
            ////HSSE和法律事务、规章制度
            //if (ModuleId == 157 || ModuleId == 153 || ModuleId == 304)
            //{
            //    SysModuleService mService = new SysModuleService();
            //    string swhere = "" + ModuleId;
            //    List<SysModuleModel> mlist = mService.GetList().Where(p => p.MPARENTID == ModuleId).OrderBy(p => p.MORDERBY).ToList();
            //    string cmd = "";
            //    if (mlist.Count > 0)
            //    {
            //        foreach (var var in mlist)
            //        {
            //            swhere += "," + var.MODULEID;
            //        }
            //        cmd = "from ArticleInfoModel p where p.AMODULEID in (" + swhere + ")";
            //    }
            //    else
            //    {
            //        cmd = "from ArticleInfoModel p where p.AMODULEID =" + ModuleId + "";
            //    }
            //    list = aService.ArticleQianshouList(aService.GetList(cmd)).OrderByDescending(p => p.ACREATETIME).ToList();
            //}
            //else
            //{
                list = aService.ArticleQianshouList(aService.GetList("from ArticleInfoModel p where p.AMODULEID='" + ModuleId + "'")).OrderByDescending(p => p.ACREATETIME).ToList();
            //}
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
            string sType = (string)Utility.sink(s_Type.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            string sKey = (string)Utility.sink(s_Key.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            ArticleInfoService aService = new ArticleInfoService();
            var list = aService.ArticleQianshouList(aService.ArticleSearchList(sType, sKey)).Where(p => p.AMODULEID == ModuleId).OrderByDescending(p => p.ACREATETIME).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        public string CutString(object str,int length)
        {
            return (str != null) ? str.ToString().CutString(length) : "";
        }

    }
}