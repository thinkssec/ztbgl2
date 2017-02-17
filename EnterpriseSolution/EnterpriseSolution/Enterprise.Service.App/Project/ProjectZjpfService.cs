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
    /// 文件名:  ProjectZjpfService.cs
    /// 功能描述: 业务逻辑层-评分标准数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/7/3 12:43:12
    /// </summary>
    public class ProjectZjpfService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IProjectZjpfData dal = new ProjectZjpfData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectZjpfModel model)
        {
            return dal.Execute(model);
        }

        public void CreateZjpf(string[] bzid, string[] df, string projid, int userid,string crminfo)
        {
            dal.CreateZjpf(bzid, df, projid, userid, crminfo);
        }

        public void CreateZjpf(string[] bzid, string[] df, string projid, int userid)
        {
            dal.CreateZjpf(bzid, df, projid, userid);
        }
        public void UpdZjpf(string projid, int userid, int status)
        {
            dal.UpdZjpf(projid, userid, status);
        }
        #endregion
    }

}
