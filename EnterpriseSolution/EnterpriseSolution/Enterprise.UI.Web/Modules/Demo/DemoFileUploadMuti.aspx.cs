using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enterprise.UI.Web.Modules.Demo
{
    public partial class DemoFileUploadMuti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //上传控件赋值
                PopWinUploadMuti.Text = "通知文件.doc|规章制度.xls";
                PopWinUploadMuti.Value = "2013123123.doc|20141231231.jpg";

                PopWinUploadMuti1.Text = "通知文件.doc";
                PopWinUploadMuti1.Value = "2013123123.doc";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //上传控件取值
            string s1 = PopWinUploadMuti.Value;
            string s2 = PopWinUploadMuti.Text;
            Response.Write("<br/>第一个控件的值是：" + s1 + "<br/>第1个控件的文本是：" + s2);

            string s3 = PopWinUploadMuti1.Value;
            string s4 = PopWinUploadMuti1.Text;
            Response.Write("<br/>第2个控件的值是：" + s3 + "<br/>第2个控件的文本是：" + s4);

        }
    }
}