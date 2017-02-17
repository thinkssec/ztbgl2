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
    public partial class admin_index : Enterprise.Service.Basis.BasePage
    {
        public ProjectInfoService srv = new ProjectInfoService();
        public ProjectInfoModel project = new ProjectInfoModel();
        public ProjectFwsService fsrv = new ProjectFwsService();
        public ProjectPszjService psrv = new ProjectPszjService();
        public ProjectZjpfService zsrv = new ProjectZjpfService();
        public List<ProjectFwsModel> fwsL = new List<ProjectFwsModel>();
        public List<ProjectPszjModel> pszjL = new List<ProjectPszjModel>();
        public ProjectPszjModel zj = new ProjectPszjModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userModel == null) Response.Redirect("Login.aspx");
            project = srv.GetList().Where(w => w.PROJID == ProjectId).FirstOrDefault();
            if (project == null) Response.Redirect("Login.aspx");
            string sql = string.Format(@"select t.pf||'' key4,s.pf||'' key3,rank() over (order by s.pf desc) key2,a.*
                  from app_project_fws a
                  left join (select sum(pf) pf,crminfo
                               from APP_PROJECT_ZJPF
                              where projid = '{0}'
                                and submitter = {1} group by crminfo) t
                    on a.crminfo = t.crminfo
                    left join (select sum(pf) pf,crminfo
                               from APP_PROJECT_ZJPF
                              where projid = '{0}'  group by crminfo) s
                    on a.crminfo = s.crminfo
                 where a.projid = '{0}' and status<>-2 order by a.px", ProjectId,this.userModel.USERID);
            fwsL = fsrv.GetListBySQL(sql).ToList();
            //fwsL = fsrv.GetList().Where(w => w.PROJID == ProjectId&&w.STATUS!=-2).OrderBy(o=>o.PX).ToList();
            zj = psrv.GetList().Where(w => w.PROJID == ProjectId && w.PERSONID == this.userModel.USERID.ToRequestString() && w.LB <= 3).FirstOrDefault();
            if (Cmd == "Submit") {
                //if (zj != null && zj.STATUS != 0)
                //{
                //    zj.DB_Option_Action = WebKeys.UpdateAction;
                //    zj.STATUS = 0;
                //    if (psrv.Execute(zj)) {
                //        ZbwjService.CreateZjpf(ProjectId,this.userModel.USERID);
                //    }
                //    zsrv.UpdZjpf(ProjectId,this.userModel.USERID,0);
                //}
                ZbwjService.CreateZjpf(ProjectId, this.userModel.USERID);
            }
            pszjL = psrv.GetList().Where(w => w.PROJID == ProjectId&&w.LB<=3).OrderByDescending(o=>o.ROLE).ToList();

        }
    }
}