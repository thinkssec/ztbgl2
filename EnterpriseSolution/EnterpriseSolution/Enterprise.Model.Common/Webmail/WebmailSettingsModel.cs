using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Webmail
{
    /// <summary>
    /// 邮箱设置
	/// 创建人:代码生成器
	/// 创建时间:	2013/2/18 9:28:03
    /// </summary>
    [Serializable]
    public class WebmailSettingsModel : CommonSuperModel
    {
        
			/// <summary>
			/// 邮箱
			/// </summary>
			public virtual string EMAIL
			{
				get;
				set;
			}

			/// <summary>
			/// 用户id
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			/// 新邮件数量
			/// </summary>
			public virtual int? ISREADY
			{
				get;
				set;
			}

			/// <summary>
			/// SMPT端口
			/// </summary>
			public virtual int SMTPPORT
			{
				get;
				set;
			}

			/// <summary>
			/// 邮箱密码
			/// </summary>
			public virtual string LOGINPASSWORD
			{
				get;
				set;
			}

			/// <summary>
			/// 用户名
			/// </summary>
			public virtual string LOGINNAME
			{
				get;
				set;
			}

			/// <summary>
			/// Smtp服务器
			/// </summary>
			public virtual string SMTPSERVER
			{
				get;
				set;
			}

			/// <summary>
			/// pop端口
			/// </summary>
			public virtual int POPPORT
			{
				get;
				set;
			}

			/// <summary>
			/// 设置正确，状态可用
			/// </summary>
			public virtual int ISENABLE
			{
				get;
				set;
			}

			/// <summary>
			/// pop端口
			/// </summary>
			public virtual string POPSERVER
			{
				get;
				set;
			}

    }

}
