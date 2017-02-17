using Enterprise.Service.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Sys;
using Enterprise.Service.App.Crm;
using Enterprise.Model.App.Crm;
using System.Data;

namespace Enterprise.UI.Web.Modules.App.Project
{
    /// <summary>
    /// 项目成果交付页面
    /// </summary>
    public partial class ZbglZbjggs : BasePage
    {


        #region 初始化参数区

        /// <summary>
        /// 成果交付--服务类
        /// </summary>
        public ProjectJbjggsService Service = new ProjectJbjggsService();
        public ProjectInfoService infSrv = new ProjectInfoService();
        public List<ProjectFwsModel> fwsL = new List<ProjectFwsModel>();
        public ProjectJbjggsModel tM = new ProjectJbjggsModel();
        public List<ProjectZjpfModel> pfL = new List<ProjectZjpfModel>();
        /// <summary>
        /// 项目ID
        /// </summary>
        public string projectId = (string)Utility.sink("ProjectId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 节点编码
        /// </summary>
        public string id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public decimal lost = 0;

        ProjectInfoModel inM =null;
        #endregion

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCommand();

            if (!IsPostBack)
            {
                OnCondition();
                BindGrid();
            }
        }



        #region 页面方法区


        private void OnCondition()
        {
            //end
            //执行相应的动作
            if (Cmd == "New")
            {
                doAddAction();
            }
            else if (Cmd == "Edit")
            {
                doUpdAction();
            }
            else if (Cmd == "Delete")
            {
                doDelAction();
            }
        }

        /// <summary>
        /// 绑定命令
        /// </summary>
        private void BindCommand()
        {
            //inM = infSrv.GetList().Where(p => p.PROJID == ProjectId).FirstOrDefault(); 
            //if (inM.SUBMITTER==this.userModel.USERID||this.userModel.UADMIN==1)
            //{
            //    CreateBT.AddButton("new.gif", "新增", "ZbglZbjggs.aspx?Cmd=New&ProjectId=" + projectId + "&NodeCode=" + nodeCode, Utility.PopedomType.List, HeadMenu1);
                
            //}
            //else
            //{
                
            //}
            ProjectInfoService ppps = new ProjectInfoService();
            ProjectInfoModel ppp = ppps.GetList().FirstOrDefault(f => f.PROJID == ProjectId);
            ProjectPszjService ps = new ProjectPszjService();
            bool t = false;
            List<ProjectPszjModel> l = ps.GetList().Where(w => w.PROJID == ProjectId && w.LB == 5 && w.PERSONID == this.userModel.USERID.ToRequestString()).ToList();
            t = l.Count > 0;
            if (this.userModel.USERID != ppp.SUBMITTER && !t)
            {
                Tb_MENU.Visible = false;
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrid()
        {
            ProjectFwsService fwsrv = new ProjectFwsService();
            fwsL=fwsrv.GetList().Where(w=>w.PROJID==projectId&&w.STATUS!=-2).ToList();
            inM = infSrv.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();
            tM = Service.GetList().FirstOrDefault(w=>w.PROJID==projectId);
            ProjectPszjService pszjS = new ProjectPszjService();
            string sql = string.Format(@"select *
              from (select avg(pf) pf, crminfo
                      from (select sum(pf) pf, crminfo, submitter
                              from APP_PROJECT_ZJPF t
                             where projid = '{0}'
                             group by submitter, crminfo)
                     group by crminfo)
             order by pf desc", projectId);
            DataSet ds = infSrv.getDsBySql(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ProjectZjpfModel p = new ProjectZjpfModel();
                p.CRMINFO=r["CRMINFO"].ToRequestString();
                p.PF = r["PF"].ToDecimal();
                pfL.Add(p);
            }

            ProjectPszjModel zr = new ProjectPszjModel();
            zr= pszjS.GetList().FirstOrDefault(w => w.PROJID == projectId && w.ROLE == "1");
            List<ProjectPszjModel> wyL = pszjS.GetList().Where(w => w.PROJID == projectId && w.LB <= 3&&w.ROLE!="1").ToList();
            string ImageStoragePath = "/Modules/Public/Zbwj/";
            string F = "中标结果公示";
            if (tM != null)
            {
                    
                H_Down.Attributes.Add("href", ImageStoragePath + projectId + "/" + F+".doc");
                Txt_P005.Text = tM.P1;
                Txt_P008.Text = tM.P2;
                Txt_P009.Text = tM.P3;
                Txt_SCFJ.DBValue = tM.FVIEWNAMES.ToRequestString();
                Txt_SCFJ.Text = tM.FNAMES.ToRequestString();
            }
            else {
                if (inM != null)
                    Txt_P005.Text = inM.PROJCONTENT;               
            }

            if (inM != null)
            {
                Lb_P001.Text = inM.PROJNAME;
                Lb_P002.Text = inM.PROJNUMBER;
                Lb_P003.Text = "中国石油化工股份有限公司天然气川气东送管道分公司";
                Lb_P004.Text = inM.PROJINCOME.ToRequestString();
                Lb_P006.Text = inM.NKBSJ.ToRequestString();
                Lb_P007.Text = inM.NKBDD;

            }
        }

        /// <summary>
        /// 添加操作
        /// </summary>
        private void doAddAction()
        {
            //tb_HalfDATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //lb_ProjectName.Text = Enterprise.Service.App.Project.ProjectHalfService.GetProjectName(projectId);
            //p1.Visible = true;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        private void doDelAction()
        {
            
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        private void doUpdAction()
        {
            ProjectJbjggsModel Model = Service.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            //ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();
            Model.P1 = Txt_P005.Text;
            Model.P2 = Txt_P008.Text;
            Model.P3 = Txt_P009.Text;

            //Model.P1 = Txt_P1.Text;
            //Model.P2 = Txt_P2.Text;
            //Model.P3 = Txt_P3.Text;
            //Model.P4 = Txt_P4.Text;
            //Model.P5 = Txt_P5.Text;
            //Model.P6 = Txt_P6.Text;
            //Model.P7 = Txt_P7.Text;
            //Model.P8 = Txt_P8.Text;
            //Model.P9 = Txt_P9.Text;
            //Model.P10 = Txt_P10.Text;
            //inM.PROJNAME=Txt_PROJNAME.Text;
            //inM.PROJNUMBER = "川气东送"+Txt_P9.Text+"招字第"+Txt_P10.Text+"号";
            //inM.NKBSJ=Txt_NKBSJ.Text.ToDateTime();
            //inM.NKBDD=Txt_NKBDD.Text;
            //Model.P2 = Txt_param_002.Text;
            //Model.P3 = Txt_param_003.Text;
            //Model.P4 = Txt_param_004.Text;
            //Model.P5 = Txt_param_005.Text;

            //Model.P6 = Txt_param_006.Text;
            //Model.P7 = Txt_param_007.Text;
            //Model.P8 = Txt_param_008.Text;
            //Model.P9 = Txt_param_009.Text;
            //Model.LQDD = Txt_param_001.Text;
            Model.SUBMITTER = this.userModel.USERID;
            Model.SUBMITTIME = DateTime.Now;
            Model.DB_Option_Action = WebKeys.UpdateAction;
            Service.Execute(Model);

            //tb_MEMO.Text = Model.MEMO;
            //tb_HalfDATE.Text = Model.DELIVERYDATE.ToDateYMDFormat();
            //tb_RECEIVER.Text = Model.RECEIVER;
            //tb_HalfName.Text = Model.DELIVERYNAME;
            //ddl_OPERATOR.UserSelectValue = Model.OPERATOR.ToRequestString();
            //ddl_OPERATOR.DataBind();
            //Txt_ATTACHMENT.Text = Txt_ATTACHMENT.Value = Model.ATTACHMENT;
            //lb_ProjectName.Text = Enterprise.Service.App.Project.ProjectHalfService.GetProjectName(Model.PROJID);
            //p1.Visible = true;
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='ZbglZbjggs.aspx?Cmd=Edit&ProjectId={0}&Id={1}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", projectId, id);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZbglZbjggs.aspx?Cmd=Delete&ProjectId={0}&Id={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", projectId, id);
            return btnStrs;
        }

        #endregion


        #region 事件处理区

        /// <summary>
        /// 分页处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            BindGrid();
        }

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ProjectJbjggsModel Model = Service.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectJbjggsModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                
                Model.PROJID = projectId;
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }

            //ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();
            //Model.P1 = Txt_P1.Text;
            //Model.P2 = Txt_P2.Text;
            //Model.P3 = Txt_P3.Text;
            //Model.P4 = Txt_P4.Text;
            //Model.P5 = Txt_P5.Text;
            //Model.P6 = Txt_P6.Text;
            //Model.P7 = Txt_P7.Text;
            //Model.P8 = Txt_P8.Text;
            //Model.P9 = Txt_P9.Text;
            //Model.P10 = Txt_P10.Text;
            //inM.PROJNAME = Txt_PROJNAME.Text;
            //inM.PROJNUMBER = "川气东送" + Txt_P9.Text + "招字第" + Txt_P10.Text + "号";
            //inM.NKBSJ = Txt_NKBSJ.Text.ToDateTime();
            //inM.NKBDD = Txt_NKBDD.Text;

            Model.P1 = Txt_P005.Text;
            Model.P2 = Txt_P008.Text;
            Model.P3 = Txt_P009.Text;
            Model.SUBMITTER = this.userModel.USERID;
            Model.SUBMITTIME = DateTime.Now;
            Model.FNAMES = Txt_SCFJ.Text;
            Model.FVIEWNAMES = Txt_SCFJ.DBValue;
            bool isOk = Service.Execute(Model);
            if (isOk)
            {
               
            }
            ZbwjService.CreateZbjggs(projectId);
            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ZbglZbjggs.aspx?ProjectId=" + projectId );

        }

        #endregion



    }
}