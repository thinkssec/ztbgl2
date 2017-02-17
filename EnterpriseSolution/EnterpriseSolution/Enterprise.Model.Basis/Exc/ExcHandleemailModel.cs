using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// 邮件已处理表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:19:25
    /// </summary>
    [Serializable]
    public class ExcHandleemailModel : BasisSuperModel
    {
        
			/// <summary>
			///邮件ID
			/// </summary>
			public virtual string EXC_EMAILID
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
			///发送邮箱
			/// </summary>
			public virtual string EXC_SENDEMAIL
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
			///邮箱内容
			/// </summary>
			public virtual string EXC_EMAILMESSAGE
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
			///接收邮箱
			/// </summary>
			public virtual string EXC_RECEIVEREMAIL
			{
				get;
				set;
			}

			/// <summary>
			///邮箱标题
			/// </summary>
			public virtual string EXC_EMAILTITLE
			{
				get;
				set;
			}

    }

}
