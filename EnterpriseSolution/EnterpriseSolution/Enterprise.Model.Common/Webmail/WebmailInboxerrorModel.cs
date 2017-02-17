using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Webmail
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/2/18 9:28:02
    /// </summary>
    [Serializable]
    public class WebmailInboxerrorModel : CommonSuperModel
    {
        
			/// <summary>
			/// 邮件ID
			/// </summary>
			public virtual string MESSAGEID
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
