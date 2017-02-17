using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// HSE������¼
	/// ������:����������
	/// ����ʱ��:	2013/11/20 11:34:27
    /// </summary>
    [Serializable]
    public class ProjectHsehdjlModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///�μ���Ա
			/// </summary>
			public virtual string CJRY
			{
				get;
				set;
			}

			/// <summary>
			///���������
			/// </summary>
			public virtual string BZHNR
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string MEMO
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

			/// <summary>
			///�����
			/// </summary>
			public virtual DateTime? HDRQ
			{
				get;
				set;
			}
            /// <summary>
            ///�����
            /// </summary>
            public virtual string ATTACHMENT
            {
                get;
                set;
            }

        #endregion
    }

}
