using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// �ʼ��Ѵ����
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:19:25
    /// </summary>
    [Serializable]
    public class ExcHandleemailModel : BasisSuperModel
    {
        
			/// <summary>
			///�ʼ�ID
			/// </summary>
			public virtual string EXC_EMAILID
			{
				get;
				set;
			}

			/// <summary>
			///����״̬:�ѷ���  δ����  ��ʧ��
			/// </summary>
			public virtual string EXC_SENDSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string EXC_SENDEMAIL
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? EXC_SENDTIME
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string EXC_EMAILMESSAGE
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string EXC_SENDER
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string EXC_RECEIVEREMAIL
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string EXC_EMAILTITLE
			{
				get;
				set;
			}

    }

}
