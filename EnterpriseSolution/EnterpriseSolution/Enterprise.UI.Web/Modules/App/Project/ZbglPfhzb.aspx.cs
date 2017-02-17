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
using System.Data;

namespace Enterprise.UI.Web.Modules.App.Project
{
    /// <summary>
    /// 项目成果交付页面
    /// </summary>
    public partial class ZbglPfhzb : BasePage
    {


        #region 初始化参数区

        /// <summary>
        /// 成果交付--服务类
        /// </summary>
        public ProjectFwsService Service = new ProjectFwsService();
        public ProjectZjpfService xSrv = new ProjectZjpfService();
        public ProjectPszjService zjSrv = new ProjectPszjService();
        public ProjectInfoService infSrv = new ProjectInfoService();
        public ProjectPfhzService hzSrv = new ProjectPfhzService();
        public List<ProjectFwsModel> fwsL = new List<ProjectFwsModel>();
        public List<ProjectPszjModel> zjL = new List<ProjectPszjModel>();
        public Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
        /// <summary>
        /// 项目ID
        /// </summary>
        public string projectId = (string)Utility.sink("ProjectId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 节点编码
        /// </summary>
        public string nodeCode = (string)Utility.sink("NodeCode", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        public string id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public decimal lost = 0;
        public string ImageStoragePath = "/Modules/Public/Zbwj/";
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
            //    CreateBT.AddButton("new.gif", "新增", "ZbglPfhzb.aspx?Cmd=New&ProjectId=" + projectId + "&NodeCode=" + nodeCode, Utility.PopedomType.List, HeadMenu1);
            //    GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            //}
            //else
            //{
            //    GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            //}
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindGrid()
        {
            fwsL = Service.GetList().Where(p=>p.PROJID==projectId&&p.STATUS!=-2).OrderBy(o=>o.PX).ToList();
            zjL = zjSrv.GetList().Where(p => p.PROJID == projectId&&p.LB<=3).OrderBy(o => o.LB).OrderBy(o => o.ROLE).ToList();

            string sql = "";

            sql = string.Format(@"select *
                                          from (select sum(pf) pf, crminfo, submitter
                                                  from APP_PROJECT_ZJPF
                                                 where projid = '{0}'
                                                 group by crminfo, submitter
                                                union all
                                                select round(avg(pf),1) pj, crminfo, 20000 submitter
                                                  from (select sum(pf) pf, crminfo, submitter
                                                          from APP_PROJECT_ZJPF
                                                         where projid = '{0}'
                                                         group by crminfo, submitter)
                                                 group by crminfo
                                                union all
                                                select rank() over(order by pf desc) pf,
                                                       crminfo,
                                                       10000 submitter
                                                  from (select sum(pf) pf, crminfo, null submitter
                                                          from APP_PROJECT_ZJPF
                                                         where projid = '{0}'
                                                         group by crminfo))", projectId);
            DataSet ds = infSrv.getDsBySql(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                dic.Add(r["SUBMITTER"].ToRequestString() + r["CRMINFO"].ToRequestString(), r["PF"].ToDecimal());
            }

            
            string F = "评分汇总表" + zjL.Count;
            ProjectPfhzModel tM = hzSrv.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();

            if (tM != null)
            {
                Txt_SCFJ.DBValue = tM.FVIEWNAMES.ToRequestString();
                Txt_SCFJ.Text = tM.FNAMES.ToRequestString();
                H_Down.Attributes.Add("href", ImageStoragePath + projectId + "/" + F + ".doc");
                H_Fj.Attributes.Add("onclick", "openwin('openwin','/Modules/App/Project/ZbglFjxx.aspx?fjstr=" + tM.FVIEWNAMES + "','400','300')");
            }
            //Utility.GroupRows(GridView1, 1);
        }

        /// <summary>
        /// 添加操作
        /// </summary>
        private void doAddAction()
        {
            //tb_HalfDATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //lb_ProjectName.Text = Enterprise.Service.App.Project.ProjectHalfService.GetProjectName(projectId);
            p1.Visible = true;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        private void doDelAction()
        {
            ProjectFwsModel memModel = Service.GetList().Where(p=>p.FID==id).FirstOrDefault();
            memModel.DB_Option_Action = WebKeys.DeleteAction;
            Service.Execute(memModel);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        private void doUpdAction()
        {
            ProjectFwsModel Model = Service.GetList().Where(p => p.FID == id).FirstOrDefault();
            //Ddl_LB.SelectedValue = Model.LB.ToRequestString();
            //single_RcvUsers.UserSelectValue = Model.PERSONID.ToRequestString();
            
            p1.Visible = true;
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='ZbglPfhzb.aspx?Cmd=Edit&ProjectId={0}&Id={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", projectId, id, nodeCode);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZbglPfhzb.aspx?Cmd=Delete&ProjectId={0}&Id={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", projectId, id, nodeCode);
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
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ProjectFwsModel model = e.Row.DataItem as ProjectFwsModel;
                TextBox px = (TextBox)e.Row.Cells[2].FindControl("Txt_PX");
                px.Text = model.PX.ToRequestString();
            }
        }
        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {


            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    TextBox px = (TextBox)row.Cells[2].FindControl("Txt_PX");
            //    string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
            //    ProjectFwsModel md = Service.GetList().Where(p => p.FID == str_Id).FirstOrDefault();
            //    md.PX = px.Text.ToInt();
            //    md.DB_Option_Action = WebKeys.UpdateAction;
            //    Service.Execute(md);
            //}
            ProjectPfhzModel Model = hzSrv.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectPfhzModel();
                Model.DB_Option_Action = WebKeys.InsertAction;

                Model.PROJID = projectId;
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            Model.SUBMITTER = this.userModel.USERID;
            Model.SUBMITTIME = DateTime.Now;
            //Model.FNAMES = Hid_SMJ.Value;
            //Model.FVIEWNAMES = "评分汇总表扫描件";
            Model.FNAMES = Txt_SCFJ.Text;
            Model.FVIEWNAMES = Txt_SCFJ.DBValue;
            Model.STATUS = 1;
            bool isOk = hzSrv.Execute(Model);

            if (isOk)
            {
                ZbwjService.CreatePfhz(projectId);
                var pj = infSrv.GetList().Where(w => w.PROJID == projectId).FirstOrDefault();
                if (pj.STATUS < 8)
                {
                    pj.DB_Option_Action = WebKeys.UpdateAction;
                    pj.STATUS = 8;
                    infSrv.Execute(pj);
                }

            }
            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ZbglPfhzb.aspx?ProjectId=" + projectId + "&NodeCode=" + nodeCode);

        }
        protected void BtnSave_Up(object sender, EventArgs e)
        {


            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    TextBox px = (TextBox)row.Cells[2].FindControl("Txt_PX");
            //    string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
            //    ProjectFwsModel md = Service.GetList().Where(p => p.FID == str_Id).FirstOrDefault();
            //    md.PX = px.Text.ToInt();
            //    md.DB_Option_Action = WebKeys.UpdateAction;
            //    Service.Execute(md);
            //}
            ProjectPfhzModel Model = hzSrv.GetList().Where(p => p.PROJID == projectId).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectPfhzModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                Model.PROJID = projectId;
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            Model.SUBMITTER = this.userModel.USERID;
            Model.SUBMITTIME = DateTime.Now;
            //Model.FNAMES = Hid_SMJ.Value;
            //Model.FVIEWNAMES = "评分汇总表扫描件";
            Model.FNAMES = Txt_SCFJ.Text;
            Model.FVIEWNAMES = Txt_SCFJ.DBValue;
            bool isOk = hzSrv.Execute(Model);

            if (isOk)
            {

            }
            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ZbglPfhzb.aspx?ProjectId=" + projectId + "&NodeCode=" + nodeCode);

        }
        #endregion



    }
}