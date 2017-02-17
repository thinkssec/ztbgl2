using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ������ļ�
	/// ������:����������
	/// ����ʱ��:	2013/12/1 14:10:57
    /// </summary>
    [Serializable]
    public class ProjectFztswjModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�ļ�ID
			/// </summary>
			public virtual string WJID
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
			///��׼״̬
			/// </summary>
			public virtual string WJZT
			{
				get;
				set;
			}

			/// <summary>
			///�ļ���
			/// </summary>
			public virtual string WJH
			{
				get;
				set;
			}

			/// <summary>
			///����ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

        #endregion
    }

}
