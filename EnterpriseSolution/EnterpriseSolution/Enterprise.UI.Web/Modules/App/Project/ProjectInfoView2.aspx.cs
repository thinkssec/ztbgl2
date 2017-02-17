using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Project;
using Enterprise.Service.App.Project;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.UI.Web.Modules.App.Project
{
    public partial class ProjectInfoView2 : Enterprise.Service.Basis.BasePage
    {
        public string ckId = (string)Utility.sink("ProjectId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string ckdId = (string)Utility.sink("FID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string lb = (string)Utility.sink("Lb", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        private ProjectInfoService service = new ProjectInfoService();
        private ProjectFwsService dservice = new ProjectFwsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                OnStart();
                OnCommand();
            }
        }

        /// <summary>
        /// 控制按钮
        /// </summary>
        private void OnCommand()
        {
            //添加操作按钮
            ProjectInfoService ppps = new ProjectInfoService();
            ProjectInfoModel ppp = ppps.GetList().FirstOrDefault(f => f.PROJID == ProjectId);
            ProjectPszjService ps=new ProjectPszjService();
            bool t = false;
            //List<ProjectPszjModel> l= ps.GetList().Where(w => w.PROJID == ProjectId && w.LB == 5&&w.PERSONID==this.userModel.USERID.ToRequestString()).ToList();
            //t = l.Count > 0;
            //if (this.userModel.USERID != ppp.SUBMITTER&&!t) {
            //    Tb_MENU.Visible = false;
            //}

            SysUserService suer = new SysUserService();
            SysDutyService sd = new SysDutyService();
            SysDutyModel dm = sd.GetList().Where(p => p.DNAME == "招投标管理办公室").FirstOrDefault();
            SysUserDutyService Service = new SysUserDutyService();
            IList<SysUserDutyModel> dutylist = null;
            if (dm != null) dutylist = Service.GetList().Where(p => p.DUTYID == dm.DUTYID && p.USERID == this.userModel.USERID).ToList();
            if (dutylist == null || dutylist.Count == 0)
            {
                UL_BZ.Visible = false;
            }
            else
            {
                UL_BZ.Visible = true;
            }
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            int deptId = 0;
            OnBindData();
            
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ProjectInfoView2.aspx?Cmd=Delete2&FID={0}&PROJID={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id,Hid_CKID.Value);
            return btnStrs;
        }
        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            UC_Shenhe_Show.ShowAuditInfos(ckId);
            var q = service.GetList().FirstOrDefault(p => p.PROJID == ckId);
            Hid_CKID.Value = ckId;
            if (q != null)
            {

                Lb_PROJNAME.Text = q.PROJNAME;
                Lb_PROJINCOME.Text = q.PROJINCOME.ToRequestString();
                //Txt_PROJCONTENT.Text = q.PROJCONTENT.ToRequestString();
                Lb_PROJCONTENT.Text = q.PROJCONTENT.ToRequestString();
                Txt_BZ.Text = q.BZ;
                Lb_PHONE.Text = q.PHONE;
                Lb_NKBSJ.Text = q.NKBSJSTR.ToRequestString();
                Lb_NKBDD.Text = q.NKBDD;
                Ddl_KIND.SelectedValue = q.KINDID.ToRequestString();
                Rad_ZBFS.SelectedValue = q.ZBFS.ToRequestString();
                Ddl_ZJLY.SelectedValue = q.ZJLY;
                Txt_SCFJ.DBValue = q.FVIEWNAMES.ToRequestString();
                Txt_SCFJ.Text = q.FNAMES.ToRequestString();
                //Lb_SUBMITTER.Text = SysUserService.GetUserName(q.SUBMITTER.Value);
                //single_RcvUsers.UserSelectValue = q.SHR.ToRequestString();
                Lb_SUBMIT.Text = SysUserService.GetUserName(q.SUBMITTER.Value)+"/"+q.SUBMITDATE.ToDateTime();
                H_Fj.Attributes.Add("onclick", "openwin('openwin','/Modules/App/Project/ZbglFjxx.aspx?fjstr=" + q.FVIEWNAMES + "','400','300')");

                //var lll = dservice.GetList().Where(p => p.PROJID == Hid_CKID.Value&&p.STATUS!=-2).OrderByDescending(o => o.STATUS).ToList();
                string sql = "select a.fid,a.projid,b.crmname crminfo,a.bz,a.status ,a.* from APP_PROJECT_FWS a,APP_CRM_INFO b where a.CRMINFO=b.INFOID and a.projid='" + ckId + "' and a.status<>-2";
                var lll = dservice.GetListBySQL(sql).ToList();
                GridView1.DataSource = lll;
                GridView1.DataBind();
                //lb_Dept.Text = SysDepartmentService.GetDepartMentName((int)q.CREATEDEPT);

                //end
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            var Model = service.GetList().FirstOrDefault(p => p.PROJID == ckId);
            if (Model == null)
            {
                Model = new ProjectInfoModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                Model.PROJID = ckId;
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            Model.FNAMES = Txt_SCFJ.Text;
            Model.FVIEWNAMES = Txt_SCFJ.DBValue;
            if (UL_BZ.Visible == true)
                Model.BZ = Txt_BZ.Text;
            bool isOk = service.Execute(Model);

            if (isOk)
            {

            }
            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ProjectInfoView2.aspx?ProjectId=" + ckId);

        }

        
    }
}