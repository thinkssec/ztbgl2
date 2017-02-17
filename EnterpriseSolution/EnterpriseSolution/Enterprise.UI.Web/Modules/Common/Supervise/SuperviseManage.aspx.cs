using Enterprise.Component.Control;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Modules.Common.Supervise
{
    public partial class SuperviseManage : BasePage
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
            OnCommand();
            BindGrid();
        }

        private void BindGrid()
        {
            Enterprise.Service.Common.Supervise.SuperviseInfoService infoService = new Service.Common.Supervise.SuperviseInfoService();
            string hql = "from SuperviseInfoModel Where DBID is not null ";
            if (t_dbsj.Text != "")
            {
                hql += "and DBSJ like '"+t_dbsj.Text+"%'";
            }           
            if (t_dbnr.Text != "")
            {
                hql += " and DBNR like '%"+t_dbnr.Text+"%'";
            }
            gv.DataSource = infoService.GetList(hql).OrderByDescending(s => s.DBSJ);
            gv.DataBind();
        }


        private void OnCommand()
        {
            CreateBT.AddButton("list.gif", Trans("我的事务"), "SuperviseIndex.aspx", Utility.PopedomType.List, HeadMenu1);
            CreateBT.AddButton("new.gif", Trans("新增督办事务"), "SuperviseEdit.aspx", Utility.PopedomType.New, HeadMenu1);
            CreateBT.AddButton("a.gif", Trans("管理督办事务"), "SuperviseManage.aspx", Utility.PopedomType.Delete, HeadMenu1);  
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string yqwcsj = e.Row.Cells[2].Text;
                e.Row.Cells[1].Text = "<a href='#' onclick=\"load_db('"+e.Row.Cells[4].Text+"');\">"+e.Row.Cells[1].Text+"</a>";
                e.Row.Cells[3].Text = Enterprise.Service.Basis.Sys.SysUserService.GetUserName(e.Row.Cells[3].Text.ToInt());
                e.Row.Cells[4].Text = Enterprise.Service.Common.Supervise.SuperviseProcessService.GetProcess(e.Row.Cells[4].Text,e.Row.Cells[2].Text).ToString();
                bool f = Enterprise.Service.Common.Supervise.SuperviseProcessService.GetState(e.Row.Cells[4].Text.ToDecimal());
                if (f)
                    e.Row.Cells[5].Text = "<img src=\"\\Resources\\Styles\\_img\\right.gif\"/>";
                else
                    e.Row.Cells[5].Text = "<img src=\"\\Resources\\Styles\\_img\\clock.png\"/>";
                if (!f && Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(-1) >= Convert.ToDateTime(yqwcsj))
                {
                    e.Row.BackColor = System.Drawing.Color.Thistle;
                    e.Row.ToolTip = Trans("已超期"); 
                }
            }
        }


        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string dbid = e.Keys[0].ToString();
            Enterprise.Service.Common.Supervise.SuperviseInfoService infoService = new Service.Common.Supervise.SuperviseInfoService();
            infoService.Delete(dbid);
            OnStart();
        }


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lb_Query_Click(object sender, EventArgs e)
        {
            OnStart();
        }
    }
}