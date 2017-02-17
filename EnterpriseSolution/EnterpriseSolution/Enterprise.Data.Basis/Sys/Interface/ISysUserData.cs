using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Data.Basis.Sys
{

    /// <summary>
    /// 文件名:  ISysUserData.cs
    /// 功能描述: 数据层-用户表数据访问接口
    /// 创建人：qw
    /// 创建日期: 2013.1.21
    /// </summary>
    public interface ISysUserData : IDataBasis<SysUserModel>
    {
        /// <summary>
        /// 获取查询数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataSet GetDataSetBySQL(string sql);

        /// <summary>
        /// 用户部门组织关系
        /// </summary>
        /// <returns></returns>
        DataSet GetRelationForCombox();

        /// <summary>
        /// 带职务的部门组织关系
        /// </summary>
        /// <returns></returns>
        DataSet GetRelationForCombox_Zhiwu();
    }
}
