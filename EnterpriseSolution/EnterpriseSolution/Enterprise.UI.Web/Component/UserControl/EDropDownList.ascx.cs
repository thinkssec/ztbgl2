using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Component.UserControl
{
    public partial class EDropDownList : System.Web.UI.UserControl
    {

        public string DataUrl { get; set; }

        public string Text { get { return txtc.Text; } set { txtc.Text = value; } }

        public bool Required { get; set; }

        //add by qw 2014.3.4 增加附加条件
        /// <summary>
        /// 附加参数
        /// </summary>
        public string Addition { get; set; }
        //end

        protected void Page_Load(object sender, EventArgs e)
        {            
            
        }
        
    }
}