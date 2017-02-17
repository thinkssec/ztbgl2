using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Component.UserControl
{
    public partial class CostExamine : System.Web.UI.UserControl
    {

        public string Text { get { return TextBox1.Text; } set { TextBox1.Text = value; } }

        public bool Required { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public string ProjId { get; set; }

        public CostExamine()
        {
            Required = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}