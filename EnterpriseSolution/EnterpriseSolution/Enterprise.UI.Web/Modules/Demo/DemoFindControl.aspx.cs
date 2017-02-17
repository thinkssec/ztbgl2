using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Modules.Demo
{
    public partial class DemoFindControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateTextBox();
            }
        }

        private void CreateTextBox()
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    TextBox tb = new TextBox();
            //    tb.ID = "TextBox" + i.ToString();
            //    p1.Controls.Add(tb);
            //}

            //TableRow tr = new TableRow();
            ////table><tr>
            //TableCell tc = new TableCell();
            ////tr.Controls(

            //tr.Cells.Add(tc);
            //table1.Rows.Add(tr);

            foreach (var q in p1.Controls)
            {
                var t = q.GetType().Name;
                if (t == "TextBox")
                {
                    TextBox tb = (TextBox)q;
                    tb.Text = "1";
                }
            }
            

        }
    }
}