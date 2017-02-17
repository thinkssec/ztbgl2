using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// 即时消息已处理表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:19:26
    /// </summary>
    [Serializable]
    public class ExcHandlemessageModel : BasisSuperModel
    {
        
			/// <summary>
			///消息ID
			/// </summary>
			public virtual string EXC_MSGID
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
			///发送状态:已发送  未发送  已失败
			/// </summary>
			public virtual string EXC_SENDSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///接收者
			/// </summary>
			public virtual string EXC_MSGRECEIVER
			{
				get;
				set;
			}

			/// <summary>
			///消息标题
			/// </summary>
			public virtual string EXC_MSGTITLE
			{
				get;
				set;
			}

			/// <summary>
			///消息内容
			/// </summary>
			public virtual string EXC_MSGTEXT
			{
				get;
				set;
			}

    }

}
