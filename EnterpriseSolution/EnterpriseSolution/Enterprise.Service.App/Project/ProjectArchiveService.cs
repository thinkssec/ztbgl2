using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Project;
using Enterprise.Model.App.Project;

namespace Enterprise.Service.App.Project
{
	
    /// <summary>
    /// 文件名:  ProjectArchiveService.cs
    /// 功能描述: 业务逻辑层-资料存档表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-11-5 15:48:13
    /// </summary>
    public class ProjectArchiveService
    {

        #region 代码生成器

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IProjectArchiveData dal = new ProjectArchiveData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectArchiveModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectArchiveModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectArchiveModel model)
        {
            return dal.Execute(model);
        }

        #endregion

        #region 自定义方法区

        /// <summary>
        /// 根据项目ID获取数据集合
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IList<ProjectArchiveModel> GetListByProjectId(string projectId)
        {
            return dal.GetListByHQL("from ProjectArchiveModel p where p.PROJID='" + projectId + "'");
        }

        /// <summary>
        /// 根据项目ID获取数据集合
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public ProjectArchiveModel GetListSingle(string archiveId)
        {
            return dal.GetListByHQL("from ProjectArchiveModel p where p.ARCHIVEID='" + archiveId + "'").FirstOrDefault();
        }

        #endregion
    }

}
