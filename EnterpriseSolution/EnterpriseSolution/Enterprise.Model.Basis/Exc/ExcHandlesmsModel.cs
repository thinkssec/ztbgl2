using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// 短信已处理表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:19:26
    /// </summary>
    [Serializable]
    public class ExcHandlesmsModel : BasisSuperModel
    {
        
			/// <summary>
			///短息ID
			/// </summary>
			public virtual string EXC_SMSID
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
			///接收号码
			/// </summary>
			public virtual string EXC_RECEIVENUM
			{
				get;
				set;
			}

			/// <summary>
			///发送者
			/// </summary>
			public virtual string EXC_SENDER
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
			///消息内容
			/// </summary>
			public virtual string EXC_MSGTEXT
			{
				get;
				set;
			}

    }

}
