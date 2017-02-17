using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// �ҷ���λ�������ݱ�
	/// ������:����������
	/// ����ʱ��:	2014/3/31 17:16:09
    /// </summary>
    [Serializable]
    public class CrmPbsurveyitemModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///������ID
			/// </summary>
			public virtual string ITEMID
			{
				get;
				set;
			}

			/// <summary>
			///����������
			/// </summary>
			public virtual string ITEMNAME
			{
				get;
				set;
			}

			/// <summary>
			///�����ID
			/// </summary>
			public virtual string DCID
			{
				get;
				set;
			}

			/// <summary>
			///����÷�
			/// </summary>
			public virtual decimal? ITEMSCORE
			{
				get;
				set;
			}

        #endregion
    }

}
