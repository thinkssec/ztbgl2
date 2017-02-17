using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ҵ�����ڵ��ɫ��
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:55
    /// </summary>
    [Serializable]
    public class BfNoderolesModel : BasisSuperModel
    {
        
			/// <summary>
			///��ɫ��ID
			/// </summary>
			public virtual string BF_ROLEID
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
			///�û����
			/// </summary>
			public virtual int? USERID
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
			///������ID
			/// </summary>
			public virtual string BF_CLSID
			{
				get;
				set;
			}

            #region �����������

            /// <summary>
            /// ��ɫ��ȡ����--����ʵ��  
            /// </summary>
            public virtual BfClsmethodsModel BfClsmethod { get; set; }

            #endregion

    }

}
