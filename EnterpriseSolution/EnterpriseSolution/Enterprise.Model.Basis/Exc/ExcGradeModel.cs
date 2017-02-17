using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// �쳣�ȼ���
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:19:24
    /// </summary>
    [Serializable]
    public class ExcGradeModel : BasisSuperModel
    {
        
			/// <summary>
			///�쳣�ȼ���ʶ
			/// </summary>
			public virtual string EXC_MARKER
			{
				get;
				set;
			}

			/// <summary>
			///�쳣�ȼ�����
			/// </summary>
			public virtual string EXC_GADE
			{
				get;
				set;
			}

			/// <summary>
			///�쳣�ȼ�����
			/// </summary>
			public virtual string EXC_GADEDESC
			{
				get;
				set;
			}

    }

}
