using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Dmgl
{
    /// <summary>
    /// ʩ������
	/// ������:����������
	/// ����ʱ��:	2015/5/17 17:23:42
    /// </summary>
    [Serializable]
    public class DmglSgjdModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string JID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PID
			{
				get;
				set;
			}

			/// <summary>
			///¼��ʱ��
			/// </summary>
			public virtual DateTime? JTIME
			{
				get;
				set;
			}

			/// <summary>
			///ʩ������
			/// </summary>
			public virtual string DETAIL
			{
				get;
				set;
			}

			/// <summary>
			///-2:��ʱ����
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

        #endregion
    }

}
