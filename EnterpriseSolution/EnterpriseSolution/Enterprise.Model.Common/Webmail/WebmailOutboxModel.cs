using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Webmail
{
    /// <summary>
    /// ������
	/// ������:����������
	/// ����ʱ��:	2013/2/18 9:28:03
    /// </summary>
    [Serializable]
    public class WebmailOutboxModel : CommonSuperModel
    {
        
			/// <summary>
			/// �ʼ�ID
			/// </summary>
			public virtual int MESSAGEID
			{
				get;
				set;
			}

			/// <summary>
			/// ����ʱ��
			/// </summary>
			public virtual DateTime? SENDTIME
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAILSUBJECT
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAILATTACHMENTS
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAILBODY
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string EMAILCC
			{
				get;
				set;
			}

			/// <summary>
			/// ������
			/// </summary>
			public virtual string EMAILTO
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

			/// <summary>
            /// ����״̬ -1δ���� 0������ 1���ͳɹ� 2����ʧ��
			/// </summary>
			public virtual int SENDSUCCESS
			{
				get;
				set;
			}

    }

}
