using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Modules.Demo
{
    public partial class UserDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //赋值
                //tb_USERID.UserSelectValue = "664";
                tb_USERID.DeptSelectValue = "144";

                //

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            //取值
            string deptId = tb_USERID.DeptSelectValue;
            string userId = tb_USERID.UserSelectValue;                        
            tb_USERID.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(tttt.Text);
        }
    }
}