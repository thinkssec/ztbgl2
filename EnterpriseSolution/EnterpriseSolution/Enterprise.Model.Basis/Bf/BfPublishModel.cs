using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 业务流发布表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:56
    /// </summary>
    [Serializable]
    public class BfPublishModel : BasisSuperModel
    {
        
			/// <summary>
			///业务流ID
			/// </summary>
			public virtual string BF_ID
			{
				get;
				set;
			}

			/// <summary>
			///业务流版本
			/// </summary>
			public virtual int BF_VERSION
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string BF_SCRIPT
			{
				get;
				set;
			}

			/// <summary>
			///发布日期
			/// </summary>
			public virtual DateTime? BF_PUBDATE
			{
				get;
				set;
			}

			/// <summary>
			///当前状态:1=启用 0=废弃
			/// </summary>
			public virtual int? BF_STATUS
			{
				get;
				set;
			}

			/// <summary>
			///修改日期
			/// </summary>
			public virtual DateTime? BF_MODDATE
			{
				get;
				set;
			}

			/// <summary>
			///发布标志 1=发布 0=未发布
			/// </summary>
			public virtual int? BF_PUBSIGN
			{
				get;
				set;
            }


            #region 外键关联对象

            /// <summary>
            /// 业务流基础表--对象实例  
            /// </summary>
            public virtual BfBaseModel BfBase { get; set; }

            #endregion

    }

}
