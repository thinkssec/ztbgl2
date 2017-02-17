using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.UI.Web.Modules.Common.Article
{
    /// <summary>
    ///  新闻类信息
    /// </summary>
    public partial class ArticleDisp : Enterprise.Service.Basis.BasePage
    {
        protected string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string ModuleId = (string)Utility.sink("ModuleId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s =SysModuleService.GetModuleName(ModuleId);
                lb_MName.Text = s;
                OnStart();
                OnCommand();
            }
        }

        private void OnCommand()
        {
            //添加操作按钮
            CreateBT.AddButton("edit.gif", Trans("修改"), "ArticleManage.aspx?Moduleid=" + ModuleId + "&Cmd=Edit&Id=" + Id, Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("delete.gif", Trans("删除"), "ArticleManage.aspx?Moduleid=" + ModuleId + "&Cmd=Delete&Id=" + Id, Utility.PopedomType.Delete, HeadMenu1);
            CreateBT.AddButton("back.gif", Trans("返回"), "ArticleList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
        }

        private void OnStart()
        {
            ArticleInfoService aService = new ArticleInfoService();
            var q = aService.ArticleInfoDisp(Id);
            if (q != null)
            {
                lb_User.Text =SysUserService.GetUserName((int)q.AUSER);
                lb_Dept.Text =SysDepartmentService.GetDepartMentName((int)q.ADEPARTMENT);
                lb_Type.Text = q.ATYPE;
                lb_Title.Text = q.ATITLE;
                //lb_TitleRu.Text = q.ATITLERU;
                lb_Content.Text = q.ACONTENT;
                //lb_ContentRu.Text = q.ACONTENTRU;
                lb_Files.Text = ArticleInfoService.ToAttachHtml(q);// ArticleInfoService.GetPDFEnclosureHTML(q);
            }
        }

    }
}