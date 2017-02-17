using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Component.UserControl
{
    public partial class MutiUserSelectControl : System.Web.UI.UserControl
    {
        public string Text { get { return tb_Muti.Text; } set {tb_Muti.Text=value;} }

        public bool Muti { get; set; }

        public bool Required { get; set; }

        public string Value { get { return tb_Muti_Value.Value; } set { tb_Muti_Value.Value = value; } }

        public bool DisplaySelect { get; set; }

        

        public MutiUserSelectControl()
        {
            Muti = true;
            Required = false;
            DisplaySelect = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}