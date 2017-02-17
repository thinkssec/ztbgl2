using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ��������
	/// ������:����������
	/// ����ʱ��:	2013-2-26 15:29:31
    /// </summary>
    [Serializable]
    public class BfTrustusersModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�����ID
			/// </summary>
			public virtual string BF_TRUSTID
			{
				get;
				set;
			}

			/// <summary>
			///ί����
			/// </summary>
			public virtual int? BF_FROMUSER
			{
				get;
				set;
			}

			/// <summary>
			///��ǰ״̬:0=ʧЧ 1=��Ч
			/// </summary>
			public virtual int? BF_TRUSTSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///�����������
			/// </summary>
			public virtual DateTime? BF_TRUSTEND
			{
				get;
				set;
			}

			/// <summary>
			///ί��˵��
			/// </summary>
			public virtual string BF_TRUSTDESC
			{
				get;
				set;
			}

			/// <summary>
			///���쿪ʼ����
			/// </summary>
			public virtual DateTime? BF_TRUSTSTART
			{
				get;
				set;
			}

			/// <summary>
			///ί������
			/// </summary>
			public virtual DateTime? BF_TRUSTDATE
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? BF_TOUSER
			{
				get;
				set;
			}

        #endregion
    }

}
