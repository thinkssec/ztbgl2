using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 访问日志
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:14
    /// </summary>
    [Serializable]
    public class SysVisitLogModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual string VLID
			{
				get;
				set;
			}

			/// <summary>
			///用户编号
			/// </summary>
			public virtual int? VLLOGINUSERID
			{
				get;
				set;
			}

			/// <summary>
			///登录时间
			/// </summary>
			public virtual DateTime? VLLOGINTIME
			{
				get;
				set;
			}

			/// <summary>
			///登录ip地址
			/// </summary>
			public virtual string VLLOGINIP
			{
				get;
				set;
			}

			/// <summary>
			///最后访问url
			/// </summary>
			public virtual string VLURL
			{
				get;
				set;
			}

			/// <summary>
			///停留时间
			/// </summary>
			public virtual int? VLTIMESPAN
			{
				get;
				set;
			}

        #endregion
    }

}
