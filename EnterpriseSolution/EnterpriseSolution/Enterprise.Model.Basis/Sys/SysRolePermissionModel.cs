using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 角色权限表
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysRolePermissionModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual string RPID
			{
				get;
				set;
			}

			/// <summary>
			///模块编码
			/// </summary>
			public virtual string MCODE
			{
				get;
				set;
			}

			/// <summary>
			///角色编号
			/// </summary>
			public virtual int? ROLEID
			{
				get;
				set;
			}

			/// <summary>
			///权限值
			/// </summary>
			public virtual int? PERMISSIONVALUE
			{
				get;
				set;
			}

        #endregion
    }

}
