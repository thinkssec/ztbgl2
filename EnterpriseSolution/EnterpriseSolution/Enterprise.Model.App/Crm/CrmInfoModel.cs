using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// ������
	/// ������:����������
	/// ����ʱ��:	2015/12/21 10:17:56
    /// </summary>
    [Serializable]
    public class CrmInfoModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��Ϣ��ID
			/// </summary>
			public virtual string INFOID
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string CRMNAME
			{
				get;
				set;
			}

			/// <summary>
			///��ַ
			/// </summary>
			public virtual string CRMADDR
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string CRMSERIAL
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string CRMPROPERTY
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string CRMKIND
			{
				get;
				set;
			}

			/// <summary>
			///ά����
			/// </summary>
			public virtual int? CRMUSER
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? ADDDATE
			{
				get;
				set;
			}

			/// <summary>
			///�ʺ�
			/// </summary>
			public virtual string ZHANGH
			{
				get;
				set;
			}

			/// <summary>
			///˰��
			/// </summary>
			public virtual string SHUIH
			{
				get;
				set;
			}

			/// <summary>
			/// 
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///�����ļ�����
			/// </summary>
			public virtual string FNAMES
			{
				get;
				set;
			}

			/// <summary>
			///������������
			/// </summary>
			public virtual string FVIEWNAMES
			{
				get;
				set;
			}

			/// <summary>
			///֤����
			/// </summary>
			public virtual string ZSBH
			{
				get;
				set;
			}

			/// <summary>
			///ί��������
			/// </summary>
			public virtual string KEY5
			{
				get;
				set;
			}

			/// <summary>
			///���֤��
			/// </summary>
			public virtual string KEY6
			{
				get;
				set;
			}

			/// <summary>
			///�绰
			/// </summary>
			public virtual string KEY7
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string KEY8
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string KEY9
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string KEY10
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string KEY11
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string KEY12
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string KEY13
			{
				get;
				set;
			}

        #endregion
    }

}
