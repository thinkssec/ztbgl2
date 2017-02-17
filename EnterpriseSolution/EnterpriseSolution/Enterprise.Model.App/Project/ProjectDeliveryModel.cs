using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// �ɹ�������
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:18
    /// </summary>
    [Serializable]
    public class ProjectDeliveryModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�ɹ���ID
			/// </summary>
			public virtual string DELIVERYID
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? DELIVERYDATE
			{
				get;
				set;
			}

			/// <summary>
			///�ɹ�����
			/// </summary>
			public virtual string DELIVERYNAME
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string RECEIVER
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? OPERATOR
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string ATTACHMENT
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///��ĿID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

        #endregion
    }

}
