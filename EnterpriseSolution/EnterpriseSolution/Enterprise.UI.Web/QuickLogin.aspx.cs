using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web
{
    public partial class QuickLogin : System.Web.UI.Page
    {
        //接收验证参数
        protected string user = (string)Utility.sink("user", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string cmd = (string)Utility.sink("Cmd", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string articleId = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmd) && !string.IsNullOrEmpty(user))
            {
                //先解密传递过后的参数
                user = DESEncrypt.Decrypt(user);
                cmd = DESEncrypt.Decrypt(cmd);
                SysUserService uService = new SysUserService();
                var userModel = uService.GetList().Where(p => p.ULOGINNAME == user).FirstOrDefault();
                if (userModel != null && userModel.USTATUS == 0)
                {
                    SysUserLoginService logingSrv = new SysUserLoginService();
                    logingSrv.Signin(userModel);
                    switch (cmd)
                    {
                        case "1"://Default.aspx
                            Response.Redirect("Default.aspx", true);
                            break;
                        case "2"://TodoIndex.aspx
                            Response.Redirect("TodoIndexBox.aspx", true);
                            break;
                        case "3"://Modules/Common/Article/ArticleDetail.aspx?
                            Response.Redirect("/Modules/Common/Article/ArticleDetail.aspx?Id=" + articleId, true);
                            break;
                    }
                }
            }
            else
            {
                Response.Write("参数不全!");
                Response.End();
            }
        }
    }
}