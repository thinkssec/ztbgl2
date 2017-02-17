using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Webmail
{
    /// <summary>
    /// 邮件收件箱
	/// 创建人:代码生成器
	/// 创建时间:	2013/2/18 9:28:01
    /// </summary>
    [Serializable]
    public class WebmailInboxModel : CommonSuperModel
    {
        
			/// <summary>
			/// MessageID
			/// </summary>
			public virtual string MESSAGEID
			{
				get;
				set;
			}

			/// <summary>
			/// 邮件内容
			/// </summary>
			public virtual string EMAILCONTENT
			{
				get;
				set;
			}

			/// <summary>
			/// 标识
			/// </summary>
			public virtual int FLAGED
			{
				get;
				set;
			}

			/// <summary>
			/// 已读
			/// </summary>
			public virtual int READED
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
			/// 来自
			/// </summary>
			public virtual string EMAILFROM
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
			/// 大小
			/// </summary>
			public virtual decimal EMAILSIZE
			{
				get;
				set;
			}

			/// <summary>
			/// 已删除
			/// </summary>
			public virtual int? ISDELETE
			{
				get;
				set;
			}

			/// <summary>
			/// 时间
			/// </summary>
			public virtual DateTime EMAILDATE
			{
				get;
				set;
			}

			/// <summary>
			/// 收件人地址
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

    }

}
