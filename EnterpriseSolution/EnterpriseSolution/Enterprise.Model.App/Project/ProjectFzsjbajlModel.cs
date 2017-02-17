using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ʊ�����¼
	/// ������:����������
	/// ����ʱ��:	2013/12/1 14:10:56
    /// </summary>
    [Serializable]
    public class ProjectFzsjbajlModel : AppSuperModel
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
			///�ļ�����
			/// </summary>
			public virtual string WJMC
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? BASJ
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string BAJG
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string JBR
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
