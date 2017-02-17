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
    /// 文件名:  ProjectPfbzService.cs
    /// 功能描述: 业务逻辑层-评分标准数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/6/17 22:51:44
    /// </summary>
    public class ProjectPfbzService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IProjectPfbzData dal = new ProjectPfbzData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectPfbzModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectPfbzModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectPfbzModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectPfbzModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
