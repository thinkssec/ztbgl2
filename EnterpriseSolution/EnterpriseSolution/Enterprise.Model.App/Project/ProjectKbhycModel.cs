using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2015/6/30 23:45:23
    /// </summary>
    [Serializable]
    public class ProjectKbhycModel : AppSuperModel
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

			/// <summary>
			///
			/// </summary>
			public virtual string P1
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P4
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P5
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P6
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P7
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P8
			{
				get;
				set;
			}

        #endregion
    }

}
