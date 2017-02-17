using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
    /// <summary>
    /// 文件名:  BfRunningService.cs
    /// 功能描述: 业务逻辑层-业务流运行表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:58
    /// </summary>
    public class BfRunningService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBfRunningData dal = new BfRunningData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfRunningModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 根据实例ID返回数据集合
        /// </summary>
        /// <param name="instanceId">实例ID</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetListByInstanceId(string instanceId)
        {
            return dal.GetListByInstanceId(instanceId);
        }

         /// <summary>
        /// 根据ID返回查询结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BfRunningModel GetModelById(string id)
        {
            return dal.GetModelById(id);
        }
        
        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfRunningModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 返回条件查询结果集合
        /// </summary>
        /// <param name="sql">原生SQL</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

    }

}
