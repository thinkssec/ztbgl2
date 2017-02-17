using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2015/6/30 1:09:52
    /// </summary>
    [Serializable]
    public class ProjectPbhqdbModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///�����ļ�����
			/// </summary>
			public virtual string FNAMES
			{
				get;
				set;
			}

			/// <summary>
			///������������
			/// </summary>
			public virtual string FVIEWNAMES
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SUBMITTIME
			{
				get;
				set;
			}

        #endregion
    }

}
