using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/12/4 17:33:31
    /// </summary>
    [Serializable]
    public class ProjectRunninganalyzeviewModel : AppSuperModel
    {
        #region ����������

            /// <summary>
            /// ����
            /// </summary>
            public virtual string XH
            { get; set; }

			/// <summary>
			/// �н�����
			/// </summary>
			public virtual string CJ
			{
				get;
				set;
			}

			/// <summary>
			/// ��ϸ��������
			/// </summary>
			public virtual string DNAME
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ����
			/// </summary>
			public virtual int? SL
			{
				get;
				set;
			}

            /// <summary>
            /// ����ID
            /// </summary>
            public virtual int DEPTID
            {
                get;
                set;
            }
            /// <summary>
            /// ��������ID
            /// </summary>
            public virtual int DPARENTID
            { get; set; }

        #endregion
    }

}
