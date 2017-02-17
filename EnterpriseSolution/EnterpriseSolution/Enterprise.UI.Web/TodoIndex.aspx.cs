using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.Basis;

namespace Enterprise.UI.Web
{
    public partial class TodoIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnCommand();
            }
        }

        /// <summary>
        /// 命令行
        /// </summary>
        private void OnCommand()
        {
            CreateBT.AddButton("application.png", Trans("我的待办箱"), "TodoIndexBox.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 语言转换方法
        /// </summary>
        /// <param name="zhcn"></param>
        /// <returns></returns>
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