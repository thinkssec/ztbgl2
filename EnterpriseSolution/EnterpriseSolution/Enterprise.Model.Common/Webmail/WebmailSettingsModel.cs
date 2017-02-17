using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Webmail
{
    /// <summary>
    /// ��������
	/// ������:����������
	/// ����ʱ��:	2013/2/18 9:28:03
    /// </summary>
    [Serializable]
    public class WebmailSettingsModel : CommonSuperModel
    {
        
			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAIL
			{
				get;
				set;
			}

			/// <summary>
			/// �û�id
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			/// ���ʼ�����
			/// </summary>
			public virtual int? ISREADY
			{
				get;
				set;
			}

			/// <summary>
			/// SMPT�˿�
			/// </summary>
			public virtual int SMTPPORT
			{
				get;
				set;
			}

			/// <summary>
			/// ��������
			/// </summary>
			public virtual string LOGINPASSWORD
			{
				get;
				set;
			}

			/// <summary>
			/// �û���
			/// </summary>
			public virtual string LOGINNAME
			{
				get;
				set;
			}

			/// <summary>
			/// Smtp������
			/// </summary>
			public virtual string SMTPSERVER
			{
				get;
				set;
			}

			/// <summary>
			/// pop�˿�
			/// </summary>
			public virtual int POPPORT
			{
				get;
				set;
			}

			/// <summary>
			/// ������ȷ��״̬����
			/// </summary>
			public virtual int ISENABLE
			{
				get;
				set;
			}

			/// <summary>
			/// pop�˿�
			/// </summary>
			public virtual string POPSERVER
			{
				get;
				set;
			}

    }

}
