using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {

        public SysModuleService SysModuleService { get; set; }       

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadingMenu();
        }

        protected void LoadingMenu()
        {
            SysModuleService = new SysModuleService();
            //add by qw 2014.1.9 start 增加菜单脚本的缓存
            if (string.IsNullOrEmpty(SysModuleService.EasyuiMenuButtonParentHtml) || 
                string.IsNullOrEmpty(SysModuleService.EasyuiMenuButtonChildHtml))
            {
                var q = SysModuleService.GetList().ToList();
                SysModuleService.CreateParentMenu(q, "0");  
            }
            //end
        }

        protected string Trans(string zhcn)
        {
            if (Utility.Language != Utility.LanguageType.zhcn)
            {
                return SysDictionaryService.TranslateTo(zhcn, Utility.Language);
            }
            return zhcn;
        }
    }
}