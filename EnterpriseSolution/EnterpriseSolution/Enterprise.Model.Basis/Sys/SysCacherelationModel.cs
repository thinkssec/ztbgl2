using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 缓存关联关系表
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:12
    /// </summary>
    [Serializable]
    public class SysCacherelationModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///关系ID
			/// </summary>
			public virtual string CACHEID
			{
				get;
				set;
			}

			/// <summary>
			///主缓存名称
			/// </summary>
			public virtual string CACHENAME
			{
				get;
				set;
			}

			/// <summary>
			///关联缓存名称
			/// </summary>
			public virtual string INFLCACHENAME
			{
				get;
				set;
			}

			/// <summary>
			///有效标志
			/// </summary>
			public virtual string ISVALID
			{
				get;
				set;
			}

        #endregion
    }

}
