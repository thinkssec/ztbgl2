using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// ��Ŀ�ְ���ͬ����
	/// ������:����������
	/// ����ʱ��:	2013/12/11 11:28:01
    /// </summary>
    [Serializable]
    public class CrmFbhtjeModel : AppSuperModel
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
			///�ְ���ͬID
			/// </summary>
			public virtual string FBHTID
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ��̯���
			/// </summary>
			public virtual decimal HTFTJE
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
