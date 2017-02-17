using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// ��������
	/// ������:����������
	/// ����ʱ��:	2013-6-24 20:24:41
    /// </summary>
    [Serializable]
    public class BusitravelOrderModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///BID
			/// </summary>
			public virtual string BID
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual string ORDERFILE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string ZHCN_ORDER
			{
				get;
				set;
			}

			/// <summary>
			///ǩ������
			/// </summary>
			public virtual DateTime? SIGNDATE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string RU_ORDER
			{
				get;
				set;
			}

			/// <summary>
			///ǩ����
			/// </summary>
			public virtual string SIGNER
			{
				get;
				set;
			}

			/// <summary>
			///Ӣ������
			/// </summary>
			public virtual string EN_ORDER
			{
				get;
				set;
			}

        #endregion
    }

}
