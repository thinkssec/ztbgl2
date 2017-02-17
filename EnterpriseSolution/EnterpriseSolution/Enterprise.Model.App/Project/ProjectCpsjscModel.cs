using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ������

	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:17
    /// </summary>
    [Serializable]
    public class ProjectCpsjscModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///������ID
			/// </summary>
			public virtual string SJSCID
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? SCRQ
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? CPSL
			{
				get;
				set;
			}

			/// <summary>
			///�����
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
			public virtual string SCYJ
			{
				get;
				set;
			}

			/// <summary>
			///��Ʒ����
			/// </summary>
			public virtual string CPMC
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
