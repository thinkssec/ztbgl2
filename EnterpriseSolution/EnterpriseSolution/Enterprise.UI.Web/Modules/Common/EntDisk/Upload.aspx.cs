using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
namespace Enterprise.UI.Web.Modules.EntDisk
{
    public partial class Upload : System.Web.UI.Page
    {
        protected string filePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filePath = FileHelper.Decrypt(Request.QueryString["filepath"]);
                fPath_Txt.Text = string.Format("{0}", filePath);
            }
        }
    }
}