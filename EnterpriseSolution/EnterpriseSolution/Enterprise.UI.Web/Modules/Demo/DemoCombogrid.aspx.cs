using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Crm;

namespace Enterprise.UI.Web.Modules.Demo
{
    public partial class DemoCombogrid : System.Web.UI.Page
    {
        public string DId { get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(Ddp_Person.SelectedValue);
           // Response.Write(HiddenField1.Value);
           // Response.Write(DeptSelectValue);
           // Response.Write(Ddp_Person.Text);
            Response.End();
        }
    }
}