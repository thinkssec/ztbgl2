using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ��������
	/// ������:����������
	/// ����ʱ��:	2014/6/19 15:35:19
    /// </summary>
    [Serializable]
    public class ProjectQualityModel : AppSuperModel
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
			///�������
			/// </summary>
			public virtual DateTime? JCRQ
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ������
			/// </summary>
			public virtual string XMFZR
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string JCFJ
			{
				get;
				set;
			}

			/// <summary>
			///��λ����
			/// </summary>
			public virtual string DWMC
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
			///��¼��
			/// </summary>
			public virtual string JLR
			{
				get;
				set;
			}

        #endregion
    }

}
