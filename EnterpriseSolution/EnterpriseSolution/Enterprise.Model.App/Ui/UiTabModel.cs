using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Ui
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/12/4 10:14:11
    /// </summary>
    [Serializable]
    public class UiTabModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��ǩID
			/// </summary>
			public virtual string TABID
			{
				get;
				set;
			}

			/// <summary>
			///��ǩ����
			/// </summary>
			public virtual string TABNAME
			{
				get;
				set;
			}

			/// <summary>
			///��ǩ����URL
			/// </summary>
			public virtual string TABURL
			{
				get;
				set;
			}
            /// <summary>
            /// ��ǩ����
            /// </summary>
            public virtual int? TABPX
            {
                get;
                set;
            }

        #endregion
    }

}
