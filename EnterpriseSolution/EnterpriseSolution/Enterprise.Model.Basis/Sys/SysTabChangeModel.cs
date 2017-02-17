using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 表更改记录
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysTabChangeModel : BasisSuperModel
    {
        #region 代码生成器
        
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
			///变更序号
			/// </summary>
			public virtual int CHANGEID
			{
				get;
				set;
			}

			/// <summary>
			///变更时间
			/// </summary>
			public virtual DateTime CHANGETIME
			{
				get;
				set;
			}

        #endregion
    }

}
