using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ͼֽ�Ǽ��б�
	/// ������:����������
	/// ����ʱ��:	2013/12/1 14:10:58
    /// </summary>
    [Serializable]
    public class ProjectFztzdjModel : AppSuperModel
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
			public virtual int? JSR
			{
				get;
				set;
			}

			/// <summary>
			///�ۺ�1#ͼ��
			/// </summary>
			public virtual decimal? ZHTZL
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
