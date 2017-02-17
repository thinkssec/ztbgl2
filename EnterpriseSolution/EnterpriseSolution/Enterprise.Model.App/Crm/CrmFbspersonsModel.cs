using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// �ְ�����ϵ�˱�
	/// ������:����������
	/// ����ʱ��:	2013/12/11 11:28:04
    /// </summary>
    [Serializable]
    public class CrmFbspersonsModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�ְ�����ϵ��ID
			/// </summary>
			public virtual string PERID
			{
				get;
				set;
			}

			/// <summary>
			///ְ��
			/// </summary>
			public virtual string DUTY
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string NAME
			{
				get;
				set;
			}

			/// <summary>
			///�Ա�
			/// </summary>
			public virtual string SEX
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
			///��ע
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///�ְ���ID
			/// </summary>
			public virtual string FBSID
			{
				get;
				set;
			}

			/// <summary>
			///������ϵ��ʽ
			/// </summary>
			public virtual string OTHER
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

        #endregion
    }

}
