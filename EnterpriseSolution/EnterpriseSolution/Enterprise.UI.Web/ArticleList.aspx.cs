using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Enterprise.UI.Web
{
    public partial class ArticleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                
            }
        }

        private void BindGrid()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("类型", typeof(string));
            dt.Columns.Add("标题", typeof(string));
            dt.Columns.Add("单位", typeof(string));
            dt.Columns.Add("时间", typeof(string));

            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "通知公告";
                dr[1] = "长沙警方：陈永洲涉嫌损害商业信誉一案将依法办理";
                dr[2] = "";
                dr[3] = "2013/10/24";
                dt.Rows.Add(dr);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();

        }
    }
}