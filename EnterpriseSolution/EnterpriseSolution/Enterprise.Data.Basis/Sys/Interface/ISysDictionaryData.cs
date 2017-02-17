using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  ISysUserData.cs
    /// 功能描述: 数据层-字典表数据访问接口
    /// 创建人：qw
    /// 创建日期: 2013.1.21
    /// </summary>
    public interface ISysDictionaryData : IDataBasis<SysDictionaryModel>
    {
        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        IList<SysDictionaryModel> GetListByZwmc(string zwmc);
    }

}
