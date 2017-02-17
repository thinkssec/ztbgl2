using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.UI.Web.Manage.ZhiWu
{
    public partial class Index : Enterprise.Service.Basis.BasePage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            CreateBT.AddButton("new.gif", Trans("新增"), "DutyManage.aspx?Cmd=New", Utility.PopedomType.New, HeadMenu1);
            SysDutyService zwService = new SysDutyService();
            var list = zwService.GetList();
            GridView1.DataSource = list.OrderBy(p=>p.DREMARK);
            GridView1.DataBind();
        }
    }
}