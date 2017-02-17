using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ������ȫ����
	/// ������:����������
	/// ����ʱ��:	2013/11/26 17:18:02
    /// </summary>
    [Serializable]
    public class ProjectQhsecheckModel : AppSuperModel
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
			///�����÷�
			/// </summary>
			public virtual decimal? QUALITYSCORE
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual int? CHECKER
			{
				get;
				set;
			}

			/// <summary>
			///��ȫ�����÷�
			/// </summary>
			public virtual decimal? HSESCORE
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? CHECKDATE
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
