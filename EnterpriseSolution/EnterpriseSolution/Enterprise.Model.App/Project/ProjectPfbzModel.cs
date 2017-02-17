using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ���ֱ�׼
	/// ������:����������
	/// ����ʱ��:	2015/6/18 0:22:46
    /// </summary>
    [Serializable]
    public class ProjectPfbzModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string BZID
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ����
			/// </summary>
			public virtual string XMMC
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string PBFX
			{
				get;
				set;
			}

			/// <summary>
			///��ֵ
			/// </summary>
			public virtual decimal? FZ
			{
				get;
				set;
			}

			/// <summary>
			///���ֱ�׼
			/// </summary>
			public virtual string PFBZ
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual decimal? PF
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? XH
			{
				get;
				set;
			}

        #endregion
    }

}
