using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Դ����ƻ���
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:23
    /// </summary>
    [Serializable]
    public class ProjectRequirementModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///����ƻ�ID
			/// </summary>
			public virtual string REQID
			{
				get;
				set;
			}

			/// <summary>
			///��������: 0=�¹� 1=����
			/// </summary>
			public virtual int? REQTYPE
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual decimal BUDGETARY
			{
				get;
				set;
			}

			/// <summary>
			///�ɹ��۸�
			/// </summary>
			public virtual decimal PRICE
			{
				get;
				set;
			}

			/// <summary>
			///�����ص�
			/// </summary>
			public virtual string SUPPLYADDR
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string GOODSNAME
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
			///�������
			/// </summary>
			public virtual string KINDID
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string AUDITID
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? AUDITDATE
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
			///���״̬:0=��ͨ�� 1=ͨ��
			/// </summary>
			public virtual int? AUDITSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? GOODSCOUNT
			{
				get;
				set;
			}

			/// <summary>
			///��λ
			/// </summary>
			public virtual string GOODSUNIT
			{
				get;
				set;
			}

			/// <summary>
			///�����ص�
			/// </summary>
			public virtual string DELIVERYADDR
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? SUPPLYDATE
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

			/// <summary>
			///���
			/// </summary>
			public virtual string GOODSTYPE
			{
				get;
				set;
			}

        #endregion
    }

}
