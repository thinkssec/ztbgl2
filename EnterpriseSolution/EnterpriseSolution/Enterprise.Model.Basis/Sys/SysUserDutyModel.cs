using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 用户职务对应关系
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:14
    /// </summary>
    [Serializable]
    public class SysUserDutyModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual string UDID
			{
				get;
				set;
			}

			/// <summary>
			///用户编号
			/// </summary>
			public virtual int? USERID
			{
				get;
				set;
			}

			/// <summary>
			///职务编号
			/// </summary>
			public virtual int? DUTYID
			{
				get;
				set;
			}

        #endregion
    }

}
