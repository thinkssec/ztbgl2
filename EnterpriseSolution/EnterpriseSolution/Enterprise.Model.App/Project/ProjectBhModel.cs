using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2015/7/26 13:56:59
    /// </summary>
    [Serializable]
    public class ProjectBhModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string XID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int YEAR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? XH
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string BH
			{
				get;
				set;
			}

        #endregion
    }

}
