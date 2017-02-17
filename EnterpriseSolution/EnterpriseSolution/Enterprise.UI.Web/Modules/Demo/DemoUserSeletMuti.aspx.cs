using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Modules.Demo
{
    public partial class DemoUserSeletMuti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //多选框赋值
                MutiUserSelectControl.Value = "664,665,666,667,668,669,670,671,672,d-122,673,674,675,676,677,686";
                //664,665,666,667,668,669,670,671,672,d-122,673,674,675,676,677,686,d-141,678,679,680
                //664,665,666,667,668,669,670,671,672,d-122,673,674,675,676,677,686,d-141,678,679,680
                //664,665,666,667,668,669,670,671,672
                //664,665,666,667,668,669,670,671,672,673,674,675,676,677,686
                //664,665,666,667,668,669,670,671,672,673,674,675,676,677,686,678,679,680
            }
        }
    }
}