using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  ISysUserRoleData.cs
    /// 功能描述: 数据层-用户角色表数据访问接口
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public interface ISysUserRoleData : IDataBasis<SysUserRoleModel>
    {
        IList<SysUserRoleModel> GetListByHQL(string hql);

        IList<SysUserRoleModel> GetListBySQL(string sql);
    }
}
