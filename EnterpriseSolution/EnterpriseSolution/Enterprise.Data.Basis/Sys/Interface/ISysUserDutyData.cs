using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  ISysUserDutyData.cs
    /// 功能描述: 数据层-用户职务表数据访问接口
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public interface ISysUserDutyData : IDataBasis<SysUserDutyModel>
    {
        /// <summary>
        /// 获取指定查询条件下的数据集合
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SysUserDutyModel> GetListBySQL(string sql);
    }
}
