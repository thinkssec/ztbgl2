using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 职务表
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysDutyModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual int DUTYID
			{
				get;
				set;
			}

			/// <summary>
			///职务名称
			/// </summary>
			public virtual string DNAME
			{
				get;
				set;
			}

			/// <summary>
			///备注说明
			/// </summary>
			public virtual string DREMARK
			{
				get;
				set;
			}

        #endregion
    }

}
