using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ҵ�������б�
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:57
    /// </summary>
    [Serializable]
    public class BfRunningModel : BasisSuperModel
    {
        
			/// <summary>
			///���б�ID
			/// </summary>
			public virtual string BF_RUNID
			{
				get;
				set;
			}

			/// <summary>
			///��ת·����ID
			/// </summary>
			public virtual string BF_PATHID
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? BF_RUNDATE
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
			///����״̬:0=δ���� 1=������
			/// </summary>
			public virtual int? BF_RUNSTATUS
			{
				get;
				set;
			}

			/// <summary>
            ///��һ�����б�ID
			/// </summary>
			public virtual string PARENT_BF_RUNID
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string BF_RUNDESC
			{
				get;
				set;
			}


            #region �����������

            /// <summary>
            /// ҵ����ʵ������  
            /// </summary>
            public virtual BfInstancesModel BfInstance { get; set; }

            /// <summary>
            /// ��ת·��--����  
            /// </summary>
            public virtual BfFlowpathModel BfFlowpath { get; set; }

            #endregion

    }

}
