using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// �쳣֪ͨ��
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:19:27
    /// </summary>
    [Serializable]
    public class ExcInformModel : BasisSuperModel
    {
        
			/// <summary>
			///֪ͨ��ID
			/// </summary>
			public virtual string EXC_INFORMID
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�ID
			/// </summary>
			public virtual string EXC_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///�쳣֪ͨ����
			/// </summary>
			public virtual string EXC_TOROLE
			{
				get;
				set;
			}

			/// <summary>
			///֪ͨ��������
			/// </summary>
			public virtual int? EXC_RECIPIENTS
			{
				get;
				set;
			}

			/// <summary>
			///��¼ID
			/// </summary>
			public virtual string EXC_RECORDID
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
			///�쳣ԭ��
			/// </summary>
			public virtual string EXC_CAUSE
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? EXC_REACTIONTIME
			{
				get;
				set;
			}

			/// <summary>
			///֪ͨ��״̬:�Ѵ��� δ���� ������
			/// </summary>
			public virtual string EXC_INFORMSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///�쳣֪ͨ��ʽ
			/// </summary>
			public virtual string EXC_BYMODE
			{
				get;
				set;
			}

    }

}
