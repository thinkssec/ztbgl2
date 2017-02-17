using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 角色表
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysRoleModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual int RID
			{
				get;
				set;
			}

			/// <summary>
			///角色名称
			/// </summary>
			public virtual string RNAME
			{
				get;
				set;
			}

			/// <summary>
			///角色类型
			/// </summary>
			public virtual string RTYPE
			{
				get;
				set;
			}

			/// <summary>
			///角色备注
			/// </summary>
			public virtual string RREMARK
			{
				get;
				set;
			}

        #endregion
    }

}
