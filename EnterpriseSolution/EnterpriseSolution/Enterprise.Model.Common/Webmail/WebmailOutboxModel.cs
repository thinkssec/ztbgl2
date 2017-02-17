using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Webmail
{
    /// <summary>
    /// 发件箱
	/// 创建人:代码生成器
	/// 创建时间:	2013/2/18 9:28:03
    /// </summary>
    [Serializable]
    public class WebmailOutboxModel : CommonSuperModel
    {
        
			/// <summary>
			/// 邮件ID
			/// </summary>
			public virtual int MESSAGEID
			{
				get;
				set;
			}

			/// <summary>
			/// 发送时间
			/// </summary>
			public virtual DateTime? SENDTIME
			{
				get;
				set;
			}

			/// <summary>
			/// 主题
			/// </summary>
			public virtual string EMAILSUBJECT
			{
				get;
				set;
			}

			/// <summary>
			/// 附件
			/// </summary>
			public virtual string EMAILATTACHMENTS
			{
				get;
				set;
			}

			/// <summary>
			/// 内容
			/// </summary>
			public virtual string EMAILBODY
			{
				get;
				set;
			}

			/// <summary>
			///抄送
			/// </summary>
			public virtual string EMAILCC
			{
				get;
				set;
			}

			/// <summary>
			/// 接收人
			/// </summary>
			public virtual string EMAILTO
			{
				get;
				set;
			}

			/// <summary>
			/// 邮箱
			/// </summary>
			public virtual string EMAIL
			{
				get;
				set;
			}

			/// <summary>
            /// 发送状态 -1未发送 0发送中 1发送成功 2发送失败
			/// </summary>
			public virtual int SENDSUCCESS
			{
				get;
				set;
			}

    }

}
