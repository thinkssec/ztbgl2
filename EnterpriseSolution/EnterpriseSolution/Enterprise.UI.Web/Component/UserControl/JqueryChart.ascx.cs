using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Component.UserControl
{
    public partial class JqueryChart : System.Web.UI.UserControl
    {

        public ChartType ChartType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public enum ChartType
    {
        PieRenderer,
        BarRenderer,
        Line
    }
}