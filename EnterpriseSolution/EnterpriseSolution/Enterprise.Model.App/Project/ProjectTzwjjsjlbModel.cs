using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// Ͷ���ļ����ռ�¼��
	/// ������:����������
	/// ����ʱ��:	2015/6/28 1:26:17
    /// </summary>
    [Serializable]
    public class ProjectTzwjjsjlbModel : AppSuperModel
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
