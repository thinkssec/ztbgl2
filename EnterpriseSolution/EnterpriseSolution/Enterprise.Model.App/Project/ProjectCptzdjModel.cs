using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ͼֽ�Ǽ�

	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:18
    /// </summary>
    [Serializable]
    public class ProjectCptzdjModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///ͼֽ�Ǽ�ID
			/// </summary>
			public virtual string TZDJID
			{
				get;
				set;
			}

			/// <summary>
			///ͼֽ����
			/// </summary>
			public virtual int? TZFS
			{
				get;
				set;
			}

			/// <summary>
			///ͼֽ����
			/// </summary>
			public virtual string TZMC
			{
				get;
				set;
			}

			/// <summary>
			///���
			/// </summary>
			public virtual string BC
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string JSR
			{
				get;
				set;
			}

			/// <summary>
			///�ۺ�1#ͼ��
			/// </summary>
			public virtual int? ZHTZL
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string DAH
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? JSSJ
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
