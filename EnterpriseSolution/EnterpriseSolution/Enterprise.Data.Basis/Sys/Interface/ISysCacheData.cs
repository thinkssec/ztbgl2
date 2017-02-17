using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  ISysCacheData.cs
    /// 功能描述: 数据层-缓存表数据访问接口
    /// 创建人：qw
    /// 创建日期: 2013.1.24
    /// </summary>
    public interface ISysCacheData : IDataBasis<SysCacheModel>
    {
        /// <summary>
        /// 获取当前数据库用户的所有触发器名称
        /// </summary>
        /// <param name="owner">所有者</param>
        /// <returns></returns>
        IList<string> GetUserTriggers();

        /// <summary>
        /// 执行基于SQL的原生操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);
    }

}
