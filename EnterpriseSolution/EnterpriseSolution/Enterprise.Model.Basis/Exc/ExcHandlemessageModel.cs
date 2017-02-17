using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// ��ʱ��Ϣ�Ѵ����
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:19:26
    /// </summary>
    [Serializable]
    public class ExcHandlemessageModel : BasisSuperModel
    {
        
			/// <summary>
			///��ϢID
			/// </summary>
			public virtual string EXC_MSGID
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
			///����״̬:�ѷ���  δ����  ��ʧ��
			/// </summary>
			public virtual string EXC_SENDSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string EXC_MSGRECEIVER
			{
				get;
				set;
			}

			/// <summary>
			///��Ϣ����
			/// </summary>
			public virtual string EXC_MSGTITLE
			{
				get;
				set;
			}

			/// <summary>
			///��Ϣ����
			/// </summary>
			public virtual string EXC_MSGTEXT
			{
				get;
				set;
			}

    }

}
