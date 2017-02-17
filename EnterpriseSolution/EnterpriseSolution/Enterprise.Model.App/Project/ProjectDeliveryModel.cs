using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 成果交付表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:18
    /// </summary>
    [Serializable]
    public class ProjectDeliveryModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///成果表ID
			/// </summary>
			public virtual string DELIVERYID
			{
				get;
				set;
			}

			/// <summary>
			///交付时间
			/// </summary>
			public virtual DateTime? DELIVERYDATE
			{
				get;
				set;
			}

			/// <summary>
			///成果名称
			/// </summary>
			public virtual string DELIVERYNAME
			{
				get;
				set;
			}

			/// <summary>
			///接收人
			/// </summary>
			public virtual string RECEIVER
			{
				get;
				set;
			}

			/// <summary>
			///经办人
			/// </summary>
			public virtual int? OPERATOR
			{
				get;
				set;
			}

			/// <summary>
			///附件
			/// </summary>
			public virtual string ATTACHMENT
			{
				get;
				set;
			}

			/// <summary>
			///备注
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///项目ID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

        #endregion
    }

}
