using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
namespace Enterprise.UI.Web.Modules.Basis.Dictionary
{
    public partial class DictionaryList : Enterprise.Service.Basis.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateBT.AddButton("new.gif", Trans("新增"), "DictionaryManage.aspx?Cmd=New", Utility.PopedomType.New, HeadMenu1);
                OnStart();
            }
        }

        private void OnStart()
        {
            SysDictionaryService dSer = new SysDictionaryService();
            var list = dSer.GetList().OrderBy(p => p.ZWMC);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

    }
}