using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 事务代办表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-26 15:29:31
    /// </summary>
    [Serializable]
    public class BfTrustusersModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///代办表ID
			/// </summary>
			public virtual string BF_TRUSTID
			{
				get;
				set;
			}

			/// <summary>
			///委托人
			/// </summary>
			public virtual int? BF_FROMUSER
			{
				get;
				set;
			}

			/// <summary>
			///当前状态:0=失效 1=有效
			/// </summary>
			public virtual int? BF_TRUSTSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///代办结束日期
			/// </summary>
			public virtual DateTime? BF_TRUSTEND
			{
				get;
				set;
			}

			/// <summary>
			///委托说明
			/// </summary>
			public virtual string BF_TRUSTDESC
			{
				get;
				set;
			}

			/// <summary>
			///代办开始日期
			/// </summary>
			public virtual DateTime? BF_TRUSTSTART
			{
				get;
				set;
			}

			/// <summary>
			///委托日期
			/// </summary>
			public virtual DateTime? BF_TRUSTDATE
			{
				get;
				set;
			}

			/// <summary>
			///代办人
			/// </summary>
			public virtual int? BF_TOUSER
			{
				get;
				set;
			}

        #endregion
    }

}
