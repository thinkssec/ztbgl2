using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Service.Basis.Sys;
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.UI.Web.Mobile
{
    public partial class Site : System.Web.UI.MasterPage
    {

        public string ProjectId = (string)Utility.sink("ProjectId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public ProjectInfoService srv = new ProjectInfoService();
        public ProjectInfoModel project=new ProjectInfoModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadingMenu();
        }

        protected void LoadingMenu()
        {
            
            project = srv.GetList().Where(w=>w.PROJID==ProjectId).FirstOrDefault();

        }

       
    }
}