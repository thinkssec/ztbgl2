using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 字典表
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysDictionaryModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual string DID
			{
				get;
				set;
			}

			/// <summary>
			///中文名称
			/// </summary>
			public virtual string ZWMC
			{
				get;
				set;
			}

			/// <summary>
			///语种
			/// </summary>
			public virtual string YZ
			{
				get;
				set;
			}

			/// <summary>
			///对应名称
			/// </summary>
			public virtual string DYMC
			{
				get;
				set;
			}

			/// <summary>
			///所属组别
			/// </summary>
			public virtual string SSZB
			{
				get;
				set;
			}

        #endregion
    }

}
