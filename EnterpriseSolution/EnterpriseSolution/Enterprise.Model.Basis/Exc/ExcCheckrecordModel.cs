using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// �쳣����¼��
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:19:22
    /// </summary>
    [Serializable]
    public class ExcCheckrecordModel : BasisSuperModel
    {
        
			/// <summary>
			///��¼ID
			/// </summary>
			public virtual string EXC_RECORDID
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
			///ҵ����������ID
			/// </summary>
			public virtual string BF_INSTANCEID
			{
				get;
				set;
			}

			/// <summary>
			///�쳣״̬:�Ѵ��� δ���� ������ ��ʧЧ �����  
			/// </summary>
			public virtual string EXC_STATUS
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ����ʱ��
			/// </summary>
			public virtual DateTime? EXC_FINISHTIME
			{
				get;
				set;
			}

			/// <summary>
			///�쳣���ʱ��
			/// </summary>
			public virtual DateTime? EXC_CHECKTIME
			{
				get;
				set;
			}

    }

}
