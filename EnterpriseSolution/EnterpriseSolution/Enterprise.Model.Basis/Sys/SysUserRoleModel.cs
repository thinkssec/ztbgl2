using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 用户角色对应表
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:14
    /// </summary>
    [Serializable]
    public class SysUserRoleModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual string RELATIONID
			{
				get;
				set;
			}

			/// <summary>
			///用户编号
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///角色编号
			/// </summary>
			public virtual int ROLEID
			{
				get;
				set;
			}

        #endregion
    }

}
