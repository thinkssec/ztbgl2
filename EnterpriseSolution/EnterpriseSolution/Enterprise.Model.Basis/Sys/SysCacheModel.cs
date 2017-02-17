using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 缓存管理
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:12
    /// </summary>
    [Serializable]
    public class SysCacheModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///缓存名称
			/// </summary>
			public virtual string CACHENAME
			{
				get;
				set;
			}

			/// <summary>
			///用户名
			/// </summary>
			public virtual string USERNAME
			{
				get;
				set;
			}

			/// <summary>
			///表名称
			/// </summary>
			public virtual string TABLENAME
			{
				get;
				set;
			}

			/// <summary>
			///描述说明
			/// </summary>
			public virtual string CACHEDESCRIBE
			{
				get;
				set;
			}

        #endregion
    }

}
