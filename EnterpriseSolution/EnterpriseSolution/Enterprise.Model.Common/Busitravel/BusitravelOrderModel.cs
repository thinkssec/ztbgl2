using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// 出差命令
	/// 创建人:代码生成器
	/// 创建时间:	2013-6-24 20:24:41
    /// </summary>
    [Serializable]
    public class BusitravelOrderModel : CommonSuperModel
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
			///命令附件
			/// </summary>
			public virtual string ORDERFILE
			{
				get;
				set;
			}

			/// <summary>
			///中文命令
			/// </summary>
			public virtual string ZHCN_ORDER
			{
				get;
				set;
			}

			/// <summary>
			///签发日期
			/// </summary>
			public virtual DateTime? SIGNDATE
			{
				get;
				set;
			}

			/// <summary>
			///俄文命令
			/// </summary>
			public virtual string RU_ORDER
			{
				get;
				set;
			}

			/// <summary>
			///签发人
			/// </summary>
			public virtual string SIGNER
			{
				get;
				set;
			}

			/// <summary>
			///英文命令
			/// </summary>
			public virtual string EN_ORDER
			{
				get;
				set;
			}

        #endregion
    }

}
