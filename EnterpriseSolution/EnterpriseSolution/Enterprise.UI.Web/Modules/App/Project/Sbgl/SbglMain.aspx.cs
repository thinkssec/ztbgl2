using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis;
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;

namespace Enterprise.UI.Web.Modules.App.Project
{
    /// <summary>
    /// 设备管理运行主页面
    /// </summary>
    public partial class SbglMain : BasePage
    {
        /// <summary>
        /// EasyUi tree Json
        /// </summary>
        public string TreeHtml { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitTree();
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitTree()
        {
            Lbl_Info.Text = string.Format("∠欢迎您!{0}∠今天是：{1}∠农历：{2}", 
                userModel.UNAME, DateTime.Now.ToString("yyyy-MM-dd") + "&nbsp;&nbsp;" 
                + CommonTool.WeekName(DateTime.Now.DayOfWeek.ToString()), 
                ChineseDate.GetChineseDateTime(DateTime.Now));
        }
        
    }
}