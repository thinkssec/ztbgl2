using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// 出差证明
	/// 创建人:代码生成器
	/// 创建时间:	2013-6-24 20:24:39
    /// </summary>
    [Serializable]
    public class BusitravelCertModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///BID
			/// </summary>
			public virtual string BID
			{
				get;
				set;
			}

			/// <summary>
			///行政部经理
			/// </summary>
			public virtual string MANAGER
			{
				get;
				set;
			}

			/// <summary>
			///本出差证明
			/// </summary>
			public virtual string ISSUEDTO
			{
				get;
				set;
			}

			/// <summary>
			///出差目的
			/// </summary>
			public virtual string PURPOSE
			{
				get;
				set;
			}

			/// <summary>
			///出差期限
			/// </summary>
			public virtual string TERM
			{
				get;
				set;
			}

			/// <summary>
			///依据
			/// </summary>
			public virtual string BASIS
			{
				get;
				set;
			}

			/// <summary>
			///护照或身份证号
			/// </summary>
			public virtual string IDORPASSPORT
			{
				get;
				set;
			}

			/// <summary>
			///开具日期
			/// </summary>
			public virtual DateTime? ISSUEDATE
			{
				get;
				set;
			}

			/// <summary>
			///到达地点
			/// </summary>
			public virtual string DESTINATION
			{
				get;
				set;
			}

			/// <summary>
			///出差证明附件
			/// </summary>
			public virtual string ISSUEFILE
			{
				get;
				set;
			}

        #endregion
    }

}
