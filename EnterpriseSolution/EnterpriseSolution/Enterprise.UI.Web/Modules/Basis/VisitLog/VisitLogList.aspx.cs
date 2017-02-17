using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.UI.Web.Modules.Basis.VisitLog
{
    public partial class VisitLogList : Enterprise.Service.Basis.BasePage
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
            SysVisitLogService vlSer = new SysVisitLogService();
            var query = vlSer.GetList().OrderByDescending(p=>p.VLLOGINTIME).ToList();
            AspNetPager1.RecordCount = query.Count;
            AspNetPager1.PageSize = 15;
            GridView1.DataSource = query.Skip(AspNetPager1.StartRecordIndex - 1).Take(AspNetPager1.PageSize).ToList();
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            OnStart();
        }

        /// <summary>
        /// 分页控件-页面变化事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            OnStart();
        }
    }
}