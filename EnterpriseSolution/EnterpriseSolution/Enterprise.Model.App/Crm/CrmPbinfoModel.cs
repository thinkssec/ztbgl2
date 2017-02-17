using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// �ҷ���λ��Ϣ��
	/// ������:����������
	/// ����ʱ��:	2014/3/31 17:15:59
    /// </summary>
    [Serializable]
    public class CrmPbinfoModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��λ����
			/// </summary>
			public virtual string PBBM
			{
				get;
				set;
			}

			/// <summary>
			///�ʱ�
			/// </summary>
			public virtual string POSTCODE
			{
				get;
				set;
			}

			/// <summary>
			///ͨѶ��ַ
			/// </summary>
			public virtual string ADDR
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual string LBBH
			{
				get;
				set;
			}

			/// <summary>
			///����������ϵ��֤֤��
			/// </summary>
			public virtual string ZLZS
			{
				get;
				set;
			}

			/// <summary>
			///˰��ǼǺ�
			/// </summary>
			public virtual string SWDJH
			{
				get;
				set;
			}

			/// <summary>
			///��Ӫ��Χ
			/// </summary>
			public virtual string JYFW
			{
				get;
				set;
			}

			/// <summary>
			///����֤��
			/// </summary>
			public virtual string RWZH
			{
				get;
				set;
			}

			/// <summary>
			///��֯��������֤
			/// </summary>
			public virtual string ZZJGDMZ
			{
				get;
				set;
			}

			/// <summary>
			///����֤
			/// </summary>
			public virtual string ZZZS
			{
				get;
				set;
			}

			/// <summary>
			///���֤
			/// </summary>
			public virtual string XKZS
			{
				get;
				set;
			}

			/// <summary>
			///����������
			/// </summary>
			public virtual string FDDBR
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///Ӫҵִ�պ�
			/// </summary>
			public virtual string YYZZH
			{
				get;
				set;
			}

			/// <summary>
			///�绰
			/// </summary>
			public virtual string PHONE
			{
				get;
				set;
			}

			/// <summary>
			///��λ����
			/// </summary>
			public virtual string PBMC
			{
				get;
				set;
			}

			/// <summary>
			///��ϵ��
			/// </summary>
			public virtual string CONTACTS
			{
				get;
				set;
			}

			/// <summary>
			///��ǰ״̬: 1=��Ч 0=��Ч
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

        #endregion
    }

}
