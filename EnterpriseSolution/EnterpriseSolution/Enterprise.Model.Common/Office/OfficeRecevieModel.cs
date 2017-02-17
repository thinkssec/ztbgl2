using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Office
{
    /// <summary>
    /// 公文签收记录
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-27 21:01:29
    /// </summary>
    [Serializable]
    public class OfficeRecevieModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual string ORID
			{
				get;
				set;
			}

			/// <summary>
			///公文记录编号
			/// </summary>
			public virtual string OID
			{
				get;
				set;
			}

			/// <summary>
			///签收时间
			/// </summary>
			public virtual DateTime? ORTIME
			{
				get;
				set;
			}

			/// <summary>
			///签收人
			/// </summary>
			public virtual int? ORUSERID
			{
				get;
				set;
			}

        #endregion
    }

}
