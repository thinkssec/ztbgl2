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
    /// 文件名:  ProjectCarService.cs
    /// 功能描述: 业务逻辑层-项目车辆表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2014/6/19 15:35:14
    /// </summary>
    public class ProjectCarService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IProjectCarData dal = new ProjectCarData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCarModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCarModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectCarModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectCarModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 根据项目ID获取车辆信息集合
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectCarModel> GetListByProjectId(string projId)
        {
            return dal.GetListByHQL("from ProjectCarModel c where c.PROJID='" + projId + "' order by c.JLRQ desc");
        }
    }

}
