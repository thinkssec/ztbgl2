using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  IBfRunningData.cs
    /// 功能描述: 数据层-业务流运行表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:18:58
    /// </summary>
    public interface IBfRunningData : IDataBasis<BfRunningModel>
    {
        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        IList<BfRunningModel> GetList(string hql);

        /// <summary>
        /// 根据ID返回查询结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BfRunningModel GetModelById(string id);

        /// <summary>
        /// 根据实例ID返回数据集合
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        IList<BfRunningModel> GetListByInstanceId(string instanceId);

        /// <summary>
        /// 返回条件查询结果集合
        /// </summary>
        /// <param name="sql">原生SQL</param>
        /// <returns></returns>
        IList<BfRunningModel> GetListBySQL(string sql);

    }
}
