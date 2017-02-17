using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//personal
using Enterprise.Service.Basis;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web
{
    /// <summary>
    /// 主页面
    /// </summary>
	public partial class Default : BasePage
	{
        
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                //load menu html
                
            }
        }

        #region 专用方法

        /// <summary>
        /// 实现交流论坛的同步登录
        /// </summary>
        /// <returns></returns>
        protected string GetBBSVerifyUrl()
        {
            //SysModuleService moduleSrv = new SysModuleService();
            //var m = moduleSrv.ModuleDisp("121");
            //if (m != null)
            //{
            //    return m.MURL + SysUserService.GetBBSVerifyUrl(userModel);
            //}
            //else
            //{
            //    return "#";
            //}
            return "";
        }

        /// <summary>
        /// 获取员工的生日
        /// </summary>
        /// <returns></returns>
        protected string GetBirthday()
        {
            string str = string.Empty;
            SysUserService uService = new SysUserService();
            var query = uService.GetList().Where(p => p.UBIRTHDAY.ToString("MM-dd") == DateTime.Now.ToString("MM-dd"));
            str += Trans("今天是：") + "" + DateTime.Now.ToString("yyyy-MM-dd") + "&nbsp;&nbsp;";
            str += Trans(CommonTool.WeekName(DateTime.Now.DayOfWeek.ToString())) + "&nbsp;&nbsp;";
            if (query.Count() > 0)
            {
                str += string.Format("<span>" + Trans("祝"));
                foreach (var var in query)
                {
                    str += string.Format("&nbsp;&nbsp;<font color=\"red\">{0}</font>&nbsp;&nbsp;", var.UNAME);
                }
                str += Trans("生日快乐") + "!</span>";
            }
            return str;
        }

        #endregion
    }
}