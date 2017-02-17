using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Data.Basis.Sys
{	

    /// <summary>
    /// 文件名:  ISysCacherelationData.cs
    /// 功能描述: 数据层-缓存关联关系表数据访问接口
    /// 创建人：代码生成器
    /// 创建时间：2015/3/17 14:20:12
    /// </summary>
    public interface ISysCacherelationData : IDataBasis<SysCacherelationModel>
    {
        #region 代码生成器

        /// <summary>
        /// 根据主键获取唯一记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SysCacherelationModel GetSingle(string key);

        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        IList<SysCacherelationModel> GetListByHQL(string hql);

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SysCacherelationModel> GetListBySQL(string sql);

        /// <summary>
        /// 执行基于SQL的原生操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);
        
        #endregion
    }

}
