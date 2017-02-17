using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ҵ����ʵ����ɫ��
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:53
    /// </summary>
    [Serializable]
    public class BfInstancerolesModel : BasisSuperModel
    {
        
			/// <summary>
			///ʵ����ɫ��ID
			/// </summary>
			public virtual string BF_INSTANCEROLEID
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
			///��ɫ����
			/// </summary>
			public virtual string BF_ROLENAME
			{
				get;
				set;
			}

			/// <summary>
			///��ɫ����:0=ָ����Ա 1=��̬��ɫ 2=��̬��ɫ 
			/// </summary>
			public virtual int? BF_ROLETYPE
			{
				get;
				set;
			}

			/// <summary>
			///��������:0=������ 1=֪ͨ��
			/// </summary>
			public virtual int? BF_OPERATIONTYPE
			{
				get;
				set;
			}

			/// <summary>
			///�û���Ŵ�
            ///��ʽ��",12,23,"
			/// </summary>
            public virtual string USERIDS
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

    }

}
