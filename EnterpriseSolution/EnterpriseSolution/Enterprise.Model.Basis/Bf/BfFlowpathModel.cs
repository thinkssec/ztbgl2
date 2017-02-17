using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// �ڵ���ת��
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:51
    /// </summary>
    [Serializable]
    public class BfFlowpathModel : BasisSuperModel
    {
        
			/// <summary>
			///��ת·����ID
			/// </summary>
			public virtual string BF_PATHID
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
			///��ʼ�ڵ���
			/// </summary>
			public virtual string BF_STARTNODE
			{
				get;
				set;
			}

			/// <summary>
			///��ת·������
			/// </summary>
			public virtual string BF_PATHNAME
			{
				get;
				set;
			}

			/// <summary>
			///ȱʡ��ת·��
			/// </summary>
			public virtual string BF_DEFAULTPATH
			{
				get;
				set;
			}

			/// <summary>
			///��һ�ڵ���
			/// </summary>
			public virtual string BF_PREVNODE
			{
				get;
				set;
			}

			/// <summary>
			///ҵ�����汾
			/// </summary>
			public virtual int BF_VERSION
			{
				get;
				set;
			}

			/// <summary>
			///�����ڵ���
			/// </summary>
			public virtual string BF_ENDNODE
			{
				get;
				set;
			}

			/// <summary>
			///��һ�ڵ���
			/// </summary>
			public virtual string BF_NEXTNODE
			{
				get;
				set;
			}

    }

}
