using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Crm;
using Enterprise.Model.App.Project;
using Enterprise.Service.App.Crm;
using Enterprise.Service.App.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Mobile
{
    public partial class zjdf2 : Enterprise.Service.Basis.BasePage
    {
        public ProjectInfoService srv = new ProjectInfoService();
        public ProjectInfoModel project = new ProjectInfoModel();
        public CrmInfoService csrv = new CrmInfoService();
        public ProjectFwsService fwsrv = new ProjectFwsService();
        public CrmInfoModel crm = new CrmInfoModel();
        public ProjectPfbzService psrv = new ProjectPfbzService();
        public List<ProjectPfbzModel> pfbzL = new List<ProjectPfbzModel>();
        public List<ProjectZjpfModel> pL = new List<ProjectZjpfModel>();
        public ProjectZjpfService fsrv = new ProjectZjpfService();
        public List<ProjectFwsModel> fwsL = new List<ProjectFwsModel>();
        public ProjectPszjService pssrv = new ProjectPszjService();
        public Dictionary<string, List<ProjectZjpfModel>> dic1 = new Dictionary<string, List<ProjectZjpfModel>>();
        public string CrmInfo = (string)Utility.sink("CrmInfo", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userModel == null) Response.Redirect("Login.aspx");
            //zj = pssrv.GetList().Where(w => w.PROJID == ProjectId && w.PERSONID == this.userModel.USERID.ToRequestString() && w.LB <= 3).FirstOrDefault();
            ProjectPfhzService hzSrv = new ProjectPfhzService();
            ProjectPfhzModel Model = hzSrv.GetList().Where(p => p.PROJID == ProjectId).FirstOrDefault();
            if (Model != null)
            {
                if (Model.STATUS == 1)
                {
                    Btn_SAVE.Visible = false;
                }
            }
            if (!IsPostBack)
            {
                BindGrid();
            }

            
        }
        private void BindGrid()
        {
            project = srv.GetList().Where(w => w.PROJID == ProjectId).FirstOrDefault();
            //if (string.IsNullOrEmpty(CrmInfo)) {
            //    fws = fwsrv.GetList().Where(w => w.PROJID == ProjectId&&w.STATUS!=-2).OrderBy(o=>o.PX).FirstOrDefault();
            //    CrmInfo = fws.CRMINFO;
            //}
            //crm = csrv.GetList().Where(w => w.INFOID == CrmInfo).FirstOrDefault();
            //fws = fwsrv.GetList().Where(w => w.CRMINFO == CrmInfo && w.PROJID == ProjectId && w.STATUS != -2).OrderBy(o => o.PX).FirstOrDefault();
            fwsL = fwsrv.GetList().Where(p => p.PROJID == ProjectId && p.STATUS != -2).OrderBy(o => o.PX).ToList();
            string sql = "";
            foreach (var fws in fwsL) { 
                sql = string.Format(@"select sys_guid()||'' pfid,t.crminfo,t.submitter, t.submittime, t.fnames, t.fviewnames, t.status,t.pf,a.*
                                  from app_project_pfbz a
                                  left join (select *
                                               from APP_PROJECT_ZJPF
                                              where crminfo = '{0}'
                                                and projid = '{1}'
                                                and submitter = {2}) t
                                    on a.bzid = t.bzid
                                 where a.projid = '{1}'  order by a.xmmc,a.xh", fws.CRMINFO, ProjectId, this.userModel.USERID);
                pL = fsrv.GetListBySQL(sql).ToList();
                dic1.Add(fws.CRMINFO,pL);
            }

            sql = string.Format(@"select a.*
                                          from app_project_pfbz a                                          
                                         where a.projid = '{0}'  order by a.xmmc,a.xh", ProjectId);
            pfbzL = psrv.GetListBySQL(sql).ToList();

        }

        protected void Btn_SAVE_Click(object sender, EventArgs e)
        {
            string[] bzid = Request["Hid_BZID"].Split(',') ;
            string[] df = Request["Txt_PF"].Split(',');
            //List<ProjectZjpfModel> zjpf = fsrv.GetList().Where(w => w.PROJID == ProjectId&&w.SUBMITTER==this.userModel.USERID&&w.CRMINFO==CrmInfo).ToList();
            //if (zjpf.Count == 0) {
            //}
            //zj = pssrv.GetList().Where(w => w.PROJID == ProjectId && w.PERSONID == this.userModel.USERID.ToRequestString() && w.LB <= 3).FirstOrDefault();

            ProjectPfhzService hzSrv = new ProjectPfhzService();
            ProjectPfhzModel Model = hzSrv.GetList().Where(p => p.PROJID == ProjectId).FirstOrDefault();
            if (Model == null || Model.STATUS != 1)
            {
                fsrv.CreateZjpf(bzid, df, ProjectId, this.userModel.USERID);
            }
            //if (zj !=null) {
            //    if (zj.STATUS > -1)
            //    {
            //        //Btn_SAVE.Visible = false;
            //    }
            //    else { 
            //        fsrv.CreateZjpf(bzid,df,ProjectId,this.userModel.USERID);
            //        //zj.DB_Option_Action = WebKeys.UpdateAction;
            //        //zj.STATUS = -1;
            //        //pssrv.Execute(zj);
            //    }
            //}
            Response.Redirect("zjdf2.aspx?ProjectId=" + ProjectId + "&CrmInfo=" + CrmInfo);

        }

        protected void Btn_PRE_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(CrmInfo))
            //{
            //    fws = fwsrv.GetList().Where(w => w.PROJID == ProjectId && w.STATUS != -2).OrderBy(o => o.PX).FirstOrDefault();
            //    CrmInfo = fws.CRMINFO;
            //}
            //ProjectFwsModel cur = fwsrv.GetList().Where(w => w.CRMINFO == CrmInfo && w.PROJID == ProjectId).FirstOrDefault();
            //var l = fwsrv.GetList().Where(w => w.PROJID == ProjectId && w.PX < cur.PX && w.STATUS != -2).OrderBy(o => o.PX);
            //if (l == null || l.Count() == 0) {
            //    BindGrid();
            //    return;
            //};
            //ProjectFwsModel pre = l.Last();
            //Response.Redirect("zjdf2.aspx?ProjectId=" + ProjectId + "&CrmInfo=" + pre.CRMINFO);
        }

        protected void Btn_NEXT_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(CrmInfo))
            //{
            //    fws = fwsrv.GetList().Where(w => w.PROJID == ProjectId && w.STATUS != -2).OrderBy(o => o.PX).FirstOrDefault();
            //    CrmInfo = fws.CRMINFO;
            //}
            //ProjectFwsModel cur = fwsrv.GetList().Where(w => w.CRMINFO == CrmInfo && w.PROJID == ProjectId).FirstOrDefault();
            //var l = fwsrv.GetList().Where(w => w.PROJID == ProjectId && w.PX > cur.PX && w.STATUS != -2).OrderBy(o => o.PX);
            //if (l == null || l.Count() == 0)
            //{
            //    BindGrid();
            //    return;
            //}
            //ProjectFwsModel next = l.First();
            //Response.Redirect("zjdf2.aspx?ProjectId=" + ProjectId + "&CrmInfo=" + next.CRMINFO);
        }
    }
}