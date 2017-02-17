using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Modules.App.Ui
{
    public partial class Iframe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["url"].ToRequestString();
            Response.Clear();
            Response.Write("<iframe src=\""+url+"\" scrolling=\"no\" width=\"950\" height=\"310\" frameborder=\"0\"></iframe>");
            Response.End();
        }
    }
}