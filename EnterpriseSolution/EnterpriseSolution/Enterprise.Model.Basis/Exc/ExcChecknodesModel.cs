using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// �쳣���ڵ��
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:19:21
    /// </summary>
    [Serializable]
    public class ExcChecknodesModel : BasisSuperModel
    {
        
			/// <summary>
			///�ڵ�ID
			/// </summary>
			public virtual string EXC_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�˳���
			/// </summary>
			public virtual int? EXC_NODEORDER
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ㽨������
			/// </summary>
			public virtual DateTime? EXC_CREATEDATE
			{
				get;
				set;
			}

			/// <summary>
			///ҵ����ID
			/// </summary>
			public virtual string BF_ID
			{
				get;
				set;
			}

			/// <summary>
			///��ǰ�ڵ���
			/// </summary>
			public virtual string BF_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�����
			/// </summary>
			public virtual string EXC_NODEDESC
			{
				get;
				set;
			}

			/// <summary>
			///�쳣�ٽ�ʱ��:3,1
			/// </summary>
			public virtual string EXC_CRITICALTIME
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�����
			/// </summary>
			public virtual string EXC_NODECHECKER
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�����
			/// </summary>
			public virtual string EXC_NODENAME
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ����
			/// </summary>
			public virtual string EXC_NODECODE
			{
				get;
				set;
			}

			/// <summary>
			///ҵ�����汾
			/// </summary>
			public virtual int? BF_VERSION
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�������
			/// </summary>
			public virtual string EXC_NODEPRINCIPAL
			{
				get;
				set;
			}

    }

}
