using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// ר�ҿ�
	/// ������:����������
	/// ����ʱ��:	2015/6/22 1:09:39
    /// </summary>
    [Serializable]
    public class CrmPersonModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string PERSONID
			{
				get;
				set;
			}

			/// <summary>
			///��Ϣ��ID
			/// </summary>
			public virtual int? DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///��ϵ��
			/// </summary>
			public virtual string PERSONNAME
			{
				get;
				set;
			}

			/// <summary>
			///��ϵ�绰
			/// </summary>
			public virtual string PHONE
			{
				get;
				set;
			}

			/// <summary>
			///�ֻ�
			/// </summary>
			public virtual string MOBILEPHONE
			{
				get;
				set;
			}

			/// <summary>
			///�����ʼ�
			/// </summary>
			public virtual string EMAIL
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SEX
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string HOMETOWN
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? BIRTHDAY
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string DEPTNAME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string DEPTDUTY
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SCHOOL
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string ADDRESS
			{
				get;
				set;
			}

			/// <summary>
			///��������1
			/// </summary>
			public virtual string POSTCODE
			{
				get;
				set;
			}

			/// <summary>
			///���ȼ�
			/// </summary>
			public virtual int MAIN
			{
				get;
				set;
			}

			/// <summary>
			///1:������ί2������ί 3������ί 4������
			/// </summary>
			public virtual int LB
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? USRID
			{
				get;
				set;
			}

			/// <summary>
			///1:ɾ��
			/// </summary>
			public virtual int? DEL
			{
				get;
				set;
			}

        #endregion
    }

}
