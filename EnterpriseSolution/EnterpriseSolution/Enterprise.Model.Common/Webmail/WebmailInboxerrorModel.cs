using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Webmail
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/2/18 9:28:02
    /// </summary>
    [Serializable]
    public class WebmailInboxerrorModel : CommonSuperModel
    {
        
			/// <summary>
			/// �ʼ�ID
			/// </summary>
			public virtual string MESSAGEID
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAIL
			{
				get;
				set;
			}

    }

}
