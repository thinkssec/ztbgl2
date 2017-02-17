using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Project;
using Enterprise.Service.App.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Mobile
{
    public partial class Project : Enterprise.Service.Basis.BasePage
    {
        //public string ProjectId = (string)Utility.sink("ProjectId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public List<ProjectInfoModel> mL=new List<ProjectInfoModel>();
        public ProjectInfoService srv = new ProjectInfoService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userModel == null) Response.Redirect("Login.aspx");
            string sql = @"select distinct a.* from app_project_info a , app_project_pszj b where a.projid=b.projid and a.status>=3 and b.personid='" + this.userModel.USERID + "' and b.lb<=3 and a.STATUS<>12 and a.status<>8 order by submitdate desc";
            mL=srv.GetListBySQL(sql).ToList();
        }
    }
}