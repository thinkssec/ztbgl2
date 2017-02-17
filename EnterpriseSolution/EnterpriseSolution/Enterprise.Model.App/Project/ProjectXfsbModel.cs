using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// �����豸�б�
	/// ������:����������
	/// ����ʱ��:	2013/11/20 11:34:33
    /// </summary>
    [Serializable]
    public class ProjectXfsbModel : AppSuperModel
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
			///���
			/// </summary>
			public virtual string GG
			{
				get;
				set;
			}

			/// <summary>
			///�豸����
			/// </summary>
			public virtual string SBMC
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? QYRQ
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? SL
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
			///������
			/// </summary>
			public virtual string ZRR
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
