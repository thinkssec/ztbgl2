using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// �ҷ���λ���۱�
	/// ������:����������
	/// ����ʱ��:	2014/3/31 17:16:06
    /// </summary>
    [Serializable]
    public class CrmPbsurveyModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�����ID
			/// </summary>
			public virtual string DCID
			{
				get;
				set;
			}

			/// <summary>
			///���鲿��
			/// </summary>
			public virtual string DCBM
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string DCZT
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? DCRQ
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
			///���Ÿ�����
			/// </summary>
			public virtual string FZR
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string BMYJ
			{
				get;
				set;
			}

			/// <summary>
			///��λ����
			/// </summary>
			public virtual string PBBM
			{
				get;
				set;
			}

			/// <summary>
			///����ȷ������
			/// </summary>
			public virtual DateTime? QRRQ
			{
				get;
				set;
			}

			/// <summary>
			///������Ա
			/// </summary>
			public virtual string DCRY
			{
				get;
				set;
			}

			/// <summary>
			///�ۺϵ÷�
			/// </summary>
			public virtual decimal? ZDF
			{
				get;
				set;
			}

        #endregion
    }

}
