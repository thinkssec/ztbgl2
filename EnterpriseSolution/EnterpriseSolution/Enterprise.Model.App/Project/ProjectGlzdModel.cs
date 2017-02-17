using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ�����ƶ�
	/// ������:����������
	/// ����ʱ��:	2014/6/21 17:32:40
    /// </summary>
    [Serializable]
    public class ProjectGlzdModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�����ƶ�ID
			/// </summary>
			public virtual string GLZDID
			{
				get;
				set;
			}

			/// <summary>
			///�ƶ�����
			/// </summary>
			public virtual string INSTITUTIONNAME
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
			///��������
			/// </summary>
			public virtual DateTime? PUBLISHDATE
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? CZR
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
