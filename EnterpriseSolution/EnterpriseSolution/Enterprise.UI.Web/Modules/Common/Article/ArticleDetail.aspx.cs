using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.Common.Article
{
    /// <summary>
    /// 文章信息记录查看
    /// </summary>
    public partial class ArticleDetail : Enterprise.Service.Basis.BasePage
    {
        protected string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                OnStart();
                OnRefreshRecevie();
            }
        }

        /// <summary>
        /// 初始化数据内容
        /// </summary>
        private void OnStart()
        {
            ArticleInfoService aService = new ArticleInfoService();
            var q = aService.ArticleInfoDisp(Id);
            if (q != null)
            {
                lb_Title.Text = Page.Title = q.ATITLE;
                //lb_TitleRu.Text = q.ATITLERU;
                lb_Dept.Text =SysDepartmentService.GetDepartMentName((int)q.ADEPARTMENT);
                lb_User.Text =SysUserService.GetUserName((int)q.ACREATEUSER);
                lb_CreateTime.Text = q.ARELEASETIME.Value.ToShortDateString();
                lb_Content.Text = q.ACONTENT;
                //lb_ContentRu.Text = q.ACONTENTRU;
                lb_Content0.Text = q.ACONTENT;
                //lb_ContentRu0.Text = q.ACONTENTRU;
                //lb_Files.Text = ArticleInfoService.GetPDFEnclosureHTML(q);
                lb_Files.Text = ArticleInfoService.ToAttachHtml(q);

                //lb_Files.Text = q.AFVIEWNAMES.ToAttachHtml();
                //s_ru_and_cn.Visible = true;
                //s_cn.Visible = false;
                //s_ru.Visible = false;
            }
        }

        /// <summary>
        /// 绑定签收人
        /// </summary>
        private void OnRefreshRecevie()
        {
            ArticleRecevieService arService = new ArticleRecevieService();
            List<ArticleRecevieModel> recevieList = arService.GetList("from ArticleRecevieModel p where p.INFOID='" + Id + "'").ToList();
            if (!recevieList.Exists(p => p.RUSERID == Utility.Get_UserId))
            { 
                ArticleRecevieModel entity = new ArticleRecevieModel();
                entity.RECEVIEID = CommonTool.GetPkId();
                entity.INFOID = Id;
                entity.RUSERID = Utility.Get_UserId;
                entity.RDATETIME = DateTime.Now;
                entity.DB_Option_Action = WebKeys.InsertAction;
                arService.Execute(entity);
            }
        }
    }
}