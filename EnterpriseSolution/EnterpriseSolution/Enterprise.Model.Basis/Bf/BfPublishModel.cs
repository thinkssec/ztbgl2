using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ҵ����������
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:56
    /// </summary>
    [Serializable]
    public class BfPublishModel : BasisSuperModel
    {
        
			/// <summary>
			///ҵ����ID
			/// </summary>
			public virtual string BF_ID
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
			///
			/// </summary>
			public virtual string BF_SCRIPT
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? BF_PUBDATE
			{
				get;
				set;
			}

			/// <summary>
			///��ǰ״̬:1=���� 0=����
			/// </summary>
			public virtual int? BF_STATUS
			{
				get;
				set;
			}

			/// <summary>
			///�޸�����
			/// </summary>
			public virtual DateTime? BF_MODDATE
			{
				get;
				set;
			}

			/// <summary>
			///������־ 1=���� 0=δ����
			/// </summary>
			public virtual int? BF_PUBSIGN
			{
				get;
				set;
            }


            #region �����������

            /// <summary>
            /// ҵ����������--����ʵ��  
            /// </summary>
            public virtual BfBaseModel BfBase { get; set; }

            #endregion

    }

}
