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

namespace Enterprise.UI.Web.Modules.App.Project
{
    /// <summary>
    /// 项目成果交付页面
    /// </summary>
    public partial class ZbwjEdit : BasePage
    {


        #region 初始化参数区

        /// <summary>
        /// 成果交付--服务类
        /// </summary>
        public ProjectZbwjService Service = new ProjectZbwjService();
        public ProjectInfoService infSrv = new ProjectInfoService();
        public ProjectPszjService psSrv = new ProjectPszjService();
        /// <summary>
        /// 项目ID
        /// </summary>
        public string projectId = (string)Utility.sink("ProjectId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 节点编码
        /// </summary>
        public string nodeCode = (string)Utility.sink("NodeCode", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public List<ProjectPszjModel> fwsL = new List<ProjectPszjModel>();
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
            //    CreateBT.AddButton("new.gif", "新增", "ZbwjEdit.aspx?Cmd=New&ProjectId=" + projectId + "&NodeCode=" + nodeCode, Utility.PopedomType.List, HeadMenu1);
                
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
            ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();
            ProjectZbwjModel tM = Service.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();
            //ProjectPszjModel m = psSrv.GetList().Where(w => w.PROJID == projectId && w.LB == 6).FirstOrDefault();
            string ImageStoragePath = "/Modules/Public/Zbwj/";
            string F = "川气东送管道招标文件";
            if (tM != null)
            {
                //Txt_param_001.Text = tM.LQDD;
                //Txt_param_001.Text = tM.P1;
                //Txt_param_002.Text = tM.P2;
                //Txt_param_003.Text = tM.P3;
                //Txt_param_005.Text = tM.P5;
                //Txt_param_006.Text = tM.P6;
                //Txt_param_004.Text = tM.P4;
                //Txt_param_008.Text = tM.P8;
                //Txt_param_009.Text = tM.P9;
                //H_Down.Attributes.Add("visible", "true");
                Txt_PROJNAME.Text = inM.PROJNAME;
                Txt_NKBSJ.Text = inM.NKBSJ.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
                Txt_NKBDD.Text = inM.NKBDD;
                Txt_P91.Text = tM.P9;
                Txt_P101.Text = tM.P10;
                Txt_P8.Text = tM.P8;
                Txt_P1.Text = tM.P1;
                Txt_P2.Text = tM.P2;
                Txt_P3.Text = tM.P3;
                Txt_P4.Text = tM.P4;
                Txt_P5.Text = tM.P5;
                Txt_P6.Text = tM.P6;
                Txt_P7.Text = tM.P7;
                Txt_Z1.Text = tM.Z1;
                Txt_Z2.Text = tM.Z2;
                Txt_Z3.Text = tM.Z3;
                Txt_Z4.Text = tM.Z4;
                Txt_Z5.Text = tM.Z5;
                Txt_Z6.Text = tM.Z6;
                //Txt_SCFJ.DBValue = tM.FVIEWNAMES.ToRequestString();
                //Txt_SCFJ.Text = tM.FNAMES.ToRequestString();    
                H_Down.Attributes.Add("href", ImageStoragePath + projectId + "/" + F + ".doc");
            }
            else {
                if (inM != null)
                {
                    Txt_PROJNAME.Text = inM.PROJNAME;
                    Txt_NKBSJ.Text = inM.NKBSJ.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
                    Txt_NKBDD.Text = inM.NKBDD;
                    Txt_P1.Text = "年月日至年月日  8：00-17：00";
                    //Txt_P9.Text = DateTime.Now.Year+"";
                    Txt_P8.Text = inM.PROJCONTENT;
                    Txt_Z6.Text = "湖北省武汉市东湖新技术开发区光谷大道126号";
                    //Txt_P10.Text=
                    //ProjectBhService bhSrv = new ProjectBhService();
                    ////string sql = "select sys_guid() xid,year,xh+1 xh,lpad(xh+1,'4','0') bh,projid from app_project_bh where year=" + Txt_P9.Text + " order by xh desc";
                    //string sql = @"select xid,year,xh,lpad(xh,'4','0') bh,projid,1 rk from app_project_bh where year=" + DateTime.Now.Year + " and projid='" + ProjectId + "' union select * from (select sys_guid()||'' xid,year,xh+1 xh,lpad(xh+1,'4','0') bh,projid,2 rk from app_project_bh where year=" + Txt_P9.Text + " order by xh desc) order by rk,xh desc";
                    //ProjectBhModel bh = new ProjectBhModel();
                    //bh = bhSrv.GetListBySQL(sql).FirstOrDefault();
                    //Txt_P10.Text = bh.BH.ToRequestString();
                }
                //Txt_param_004.Text = DateTime.Now.Year.ToRequestString();
                //Txt_param_005.Text = DateTime.Now.Month.ToRequestString();
                //Txt_param_006.Text = DateTime.Now.Day.ToRequestString();
            }
            
            //Lb_PNAME.Text = inM.PROJNAME;
            //Lb_PNUMBER.Text = inM.PROJNUMBER;
            //Lb_P001.Text = inM.NKBDD;
            //Lb_P002.Text = inM.NKBSJ.ToRequestString() ;
            //Lb_SUBMITTER.Text = SysUserService.GetUserName(inM.SUBMITTER.Value);
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
            ProjectZbwjModel Model = Service.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();
            Model.P1 = Txt_P1.Text;
            Model.P2 = Txt_P2.Text;
            Model.P3 = Txt_P3.Text;
            Model.P4 = Txt_P4.Text;
            Model.P5 = Txt_P5.Text;
            Model.P6 = Txt_P6.Text;
            Model.P7 = Txt_P7.Text;
            Model.P8 = Txt_P8.Text;
            Model.P9 = Txt_P91.Text;
            Model.P10 = Txt_P101.Text;
            Model.Z1 = Txt_Z1.Text;
            Model.Z2 = Txt_Z2.Text;
            Model.Z3 = Txt_Z3.Text;
            Model.Z4 = Txt_Z4.Text;
            Model.Z5 = Txt_Z5.Text;
            Model.Z6 = Txt_Z6.Text;
            inM.PROJNAME=Txt_PROJNAME.Text;
            inM.PROJNUMBER = "川气东送"+Txt_P91.Text+"招字第"+Txt_P101.Text+"号";
            inM.NKBSJ=Txt_NKBSJ.Text.ToDateTime();
            inM.NKBDD=Txt_NKBDD.Text;
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
            inM.DB_Option_Action = WebKeys.UpdateAction;
            infSrv.Execute(inM);
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
            btnStrs += string.Format("<a href='ZbwjEdit.aspx?Cmd=Edit&ProjectId={0}&Id={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", projectId, id, nodeCode);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZbwjEdit.aspx?Cmd=Delete&ProjectId={0}&Id={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", projectId, id, nodeCode);
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
            ProjectZbwjModel Model = Service.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectZbwjModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                
                Model.PROJID = projectId;
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }

            ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();
            Model.P1 = Txt_P1.Text;
            Model.P2 = Txt_P2.Text;
            Model.P3 = Txt_P3.Text;
            Model.P4 = Txt_P4.Text;
            Model.P5 = Txt_P5.Text;
            Model.P6 = Txt_P6.Text;
            Model.P7 = Txt_P7.Text;
            Model.P8 = Txt_P8.Text;
            Model.P9 = Txt_P91.Text;
            Model.P10 = Txt_P101.Text;
            Model.Z1 = Txt_Z1.Text;
            Model.Z2 = Txt_Z2.Text;
            Model.Z3 = Txt_Z3.Text;
            Model.Z4 = Txt_Z4.Text;
            Model.Z5 = Txt_Z5.Text;
            Model.Z6 = Txt_Z6.Text;
            inM.PROJNAME = Txt_PROJNAME.Text;
            inM.PROJNUMBER = "川气东送" + Txt_P91.Text + "招字第" + Txt_P101.Text + "号";
            inM.NKBSJ = Txt_NKBSJ.Text.ToDateTime();
            inM.NKBDD = Txt_NKBDD.Text;
            
            
            Model.SUBMITTER = this.userModel.USERID;
            Model.SUBMITTIME = DateTime.Now;
            //Model.FNAMES = Txt_SCFJ.Text;
            //Model.FVIEWNAMES = Txt_SCFJ.DBValue;
            bool isOk = Service.Execute(Model);
            inM.DB_Option_Action = WebKeys.UpdateAction;
            infSrv.Execute(inM);
            if (isOk)
            {
               
            }
            ZbwjService.CreateZbwj(projectId);
            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ZbwjEdit.aspx?ProjectId=" + projectId + "&NodeCode=" + nodeCode);

        }

        #endregion



    }
}