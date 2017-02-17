using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// �ְ����뵥��
	/// ������:����������
	/// ����ʱ��:	2013/12/11 11:28:02
    /// </summary>
    [Serializable]
    public class CrmFbreqformModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�ְ����뵥ID
			/// </summary>
			public virtual string REQID
			{
				get;
				set;
			}

			/// <summary>
			///�ְ����
			/// </summary>
			public virtual decimal FBJE
			{
				get;
				set;
			}

			/// <summary>
			///�ְ����
			/// </summary>
			public virtual string FBBH
			{
				get;
				set;
			}

			/// <summary>
			///��ְ�����
			/// </summary>
			public virtual string FBGZ
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ���
			/// </summary>
			public virtual int? BP
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? SQR
			{
				get;
				set;
			}

			/// <summary>
			///�ְ�����
			/// </summary>
			public virtual string FBFA
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
			///����
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? SQRQ
			{
				get;
				set;
			}

			/// <summary>
			///���״̬ 0:δ��� 1�����ͨ�� 2�����δͨ��
			/// </summary>
			public virtual int? SHZT
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? SHRQ
			{
				get;
				set;
			}

			/// <summary>
			///���㹤����
			/// </summary>
			public virtual string GZL
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
			///���뵥λ
			/// </summary>
			public virtual int SQDW
			{
				get;
				set;
			}

            /// <summary>
            ///ѡ��ְ���ID
            /// </summary>
            public virtual string FBSID
            {
                get;
                set;
            }
        #endregion
    }

}
