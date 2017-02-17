using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
namespace Enterprise.UI.Web
{
    public partial class ChangeLanguage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utility.Language ==  Utility.LanguageType.zhcn)
            {
                Utility.Language =  Utility.LanguageType.ru;
            }
            else if (Utility.Language ==  Utility.LanguageType.ru)
            {
                Utility.Language =  Utility.LanguageType.zhcn;
            }
            Response.Redirect("Index.aspx", true);
        }
    }
}