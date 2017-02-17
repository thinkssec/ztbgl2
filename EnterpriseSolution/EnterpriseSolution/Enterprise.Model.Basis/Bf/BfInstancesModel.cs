using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ҵ����ʵ����
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:54
    /// </summary>
    [Serializable]
    public class BfInstancesModel : BasisSuperModel
    {
        
			/// <summary>
			///ҵ����������ID
			/// </summary>
			public virtual string BF_INSTANCEID
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
			///������
			/// </summary>
			public virtual string BF_FOUNDER
			{
				get;
				set;
			}

			/// <summary>
            /// ˵��
			/// </summary>
			public virtual string BF_DESCRIBE
			{
				get;
				set;
			}

			/// <summary>
			///״ֵ̬: 0=���� 3=��ֹ 2=��ͣ 1=����
			/// </summary>
			public virtual int? BF_STATUSVALUE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? BF_CDATE
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


            #region �����������

            /// <summary>
            /// ҵ����������--����ʵ��  
            /// </summary>
            public virtual BfPublishModel BfPublish { get; set; }


            private IList<BfInstancerolesModel> _BfInstanceroles = new List<BfInstancerolesModel>();
            /// <summary>
            /// ҵ����ʵ����ɫ����
            /// </summary>
            public virtual IList<BfInstancerolesModel> BfInstanceroles
            {
                get { return _BfInstanceroles; }
                set { _BfInstanceroles = value; }
            }

            #endregion

    }

}
