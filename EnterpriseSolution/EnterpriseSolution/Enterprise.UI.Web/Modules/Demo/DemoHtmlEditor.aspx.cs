using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Modules.Demo
{
    public partial class DemoHtmlEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始赋值
            //if (!IsPostBack)
            //{ EHtmlEditor.Text = "aaa";  }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write(EHtmlEditor.Value+"<br/>");
            //Response.Write(EHtmlEditor1.Value);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Write(EHtmlEditor.Value + "<br/>");
            //Response.Write(EHtmlEditor1.Value);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //Response.Write(EHtmlEditor.Value + "<br/>");            
        }

        protected void BtnSave_Click1(object sender, EventArgs e)
        {
            Enterprise.Component.Infrastructure.Utility.ShowMsg(this.Page,"HTML编辑器的值为:"+EHtmlEditor.Text); 
        }
    }
}