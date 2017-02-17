using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// �쳣�������
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:19:23
    /// </summary>
    [Serializable]
    public class ExcCheckruleModel : BasisSuperModel
    {
        
			/// <summary>
			///����ID
			/// </summary>
			public virtual string EXC_RULEID
			{
				get;
				set;
			}

			/// <summary>
			///��ע˵��
			/// </summary>
			public virtual string EXC_REMARK
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
			///��������
			/// </summary>
			public virtual string EXC_CONDITION
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
			///�쳣�ȼ���ʶ
			/// </summary>
			public virtual string EXC_MARKER
			{
				get;
				set;
			}

			/// <summary>
			///��׼ֵ
			/// </summary>
			public virtual decimal? EXC_STANDARDVALUE
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string EXC_OPERATOR
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
