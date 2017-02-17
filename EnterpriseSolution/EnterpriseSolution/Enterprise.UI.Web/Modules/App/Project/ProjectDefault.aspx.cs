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
    /// 项目运行主界面
    /// </summary>
    public partial class ProjectDefault : BasePage
    {
        /// <summary>
        /// EasyUi tree Json
        /// </summary>
        public string TreeHtml { get; set; }

        /// <summary>
        /// 项目信息MODEL
        /// </summary>
        public ProjectInfoModel ProjectModel { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ProjectModel = ProjectInfoService.GetProjectInfoModel(ProjectId);
                if (ProjectModel == null)
                {
                    ProjectModel = new ProjectInfoModel();
                }
                InitTree();
            }
        }

        /// <summary>
        /// 初始化左侧节点树
        /// </summary>
        public void InitTree()
        {
            ProjectRunningService runingService = new ProjectRunningService();
            TreeHtml = runingService.GetRunningEasyuiTreeHtmlById(ProjectId);
        }

        /// <summary>
        /// 获取当前项目的进度值
        /// </summary>
        /// <returns></returns>
        protected int GetProjectProgressValue()
        {
            return ProjectProgressManageSerivce.GetProjectProgressValue(ProjectId);
        }
        
    }
}