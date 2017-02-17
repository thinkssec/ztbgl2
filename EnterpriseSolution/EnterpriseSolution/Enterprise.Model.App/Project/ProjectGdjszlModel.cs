using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��������
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:19
    /// </summary>
    [Serializable]
    public class ProjectGdjszlModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///����ID
			/// </summary>
			public virtual string ZLID
			{
				get;
				set;
			}

			/// <summary>
			///�ϴ�����
			/// </summary>
			public virtual DateTime? SCRQ
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual int? SHR
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
			///�ϴ���
			/// </summary>
			public virtual int? SCR
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
			///����
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? BZR
			{
				get;
				set;
			}

			/// <summary>
			///�ļ����
			/// </summary>
			public virtual string WJLB
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
