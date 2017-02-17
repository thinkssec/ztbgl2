using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Ui
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/12/3 13:48:42
    /// </summary>
    [Serializable]
    public class UiCustomModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///ID����
			/// </summary>
			public virtual string CUSTOMID
			{
				get;
				set;
			}

			/// <summary>
			///UI��������
			/// </summary>
			public virtual string UICONTENT
			{
				get;
				set;
			}

			/// <summary>
			///�û�ID
			/// </summary>
			public virtual string USERID
			{
				get;
				set;
			}

        #endregion
    }

}
