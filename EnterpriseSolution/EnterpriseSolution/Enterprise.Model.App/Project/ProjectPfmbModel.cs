using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2015/7/23 23:38:32
    /// </summary>
    [Serializable]
    public class ProjectPfmbModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string MID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string MNAME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

        #endregion
    }

}
