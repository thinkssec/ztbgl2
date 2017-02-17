using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.Basis.Cache
{
    /// <summary>
    /// 系统状态管理页面
    /// </summary>
    public partial class SysState : Enterprise.Service.Basis.BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 重启应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {

            SysUserLoginService logService = new SysUserLoginService();
            logService.UserOut();
            HttpRuntime.UnloadAppDomain();
            CacheHelper.Refresh();
            Response.Clear();
            Global.LoadUrlRoute();
            Utility.ShowMsg(this.Page, "系统提示", "Web应用程序已经重启!", Page.ResolveClientUrl("~/") + "Default.aspx");
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            IDictionaryEnumerator id = HttpRuntime.Cache.GetEnumerator();
            while (id.MoveNext())
            {
                DictionaryEntry abc = id.Entry;
                string Tempstring = (string)id.Key;
                HttpRuntime.Cache.Remove(Tempstring);
            }
            CacheHelper.Refresh();
            Response.Clear();
            Global.LoadUrlRoute();
            Utility.ShowMsg(this.Page, "系统提示", "Web应用程序已经重启!", Page.ResolveClientUrl("~/") + "Default.aspx");
        }
    }
}