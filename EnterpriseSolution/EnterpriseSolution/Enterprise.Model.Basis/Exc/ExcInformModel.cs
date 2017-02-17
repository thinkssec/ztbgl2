using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// 异常通知单
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:19:27
    /// </summary>
    [Serializable]
    public class ExcInformModel : BasisSuperModel
    {
        
			/// <summary>
			///通知单ID
			/// </summary>
			public virtual string EXC_INFORMID
			{
				get;
				set;
			}

			/// <summary>
			///节点ID
			/// </summary>
			public virtual string EXC_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///异常通知对象
			/// </summary>
			public virtual string EXC_TOROLE
			{
				get;
				set;
			}

			/// <summary>
			///通知单接收人
			/// </summary>
			public virtual int? EXC_RECIPIENTS
			{
				get;
				set;
			}

			/// <summary>
			///记录ID
			/// </summary>
			public virtual string EXC_RECORDID
			{
				get;
				set;
			}

			/// <summary>
			///发送时间
			/// </summary>
			public virtual DateTime? EXC_SENDTIME
			{
				get;
				set;
			}

			/// <summary>
			///异常原因
			/// </summary>
			public virtual string EXC_CAUSE
			{
				get;
				set;
			}

			/// <summary>
			///反馈时间
			/// </summary>
			public virtual DateTime? EXC_REACTIONTIME
			{
				get;
				set;
			}

			/// <summary>
			///通知单状态:已处理 未处理 已作废
			/// </summary>
			public virtual string EXC_INFORMSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///异常通知方式
			/// </summary>
			public virtual string EXC_BYMODE
			{
				get;
				set;
			}

    }

}
