using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ�����
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:25
    /// </summary>
    [Serializable]
    public class ProjectWsxmbsModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�����ID
			/// </summary>
			public virtual string BSID
			{
				get;
				set;
			}

			/// <summary>
			///�ļ�����
			/// </summary>
			public virtual string FILENAME
			{
				get;
				set;
			}

			/// <summary>
			///�ϴ�����
			/// </summary>
			public virtual DateTime? UPLOADDATE
			{
				get;
				set;
			}

			/// <summary>
			///�ļ�����
			/// </summary>
			public virtual string FILETYPE
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string ATTACHMENT
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

        #endregion
    }

}
