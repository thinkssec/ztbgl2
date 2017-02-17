using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ���ֱ�׼
	/// ������:����������
	/// ����ʱ��:	2015/7/3 12:43:12
    /// </summary>
    [Serializable]
    public class ProjectZjpfModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string PFID
			{
				get;
				set;
			}

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

			/// <summary>
			///
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SUBMITTIME
			{
				get;
				set;
			}

			/// <summary>
			///�����ļ�����
			/// </summary>
			public virtual string FNAMES
			{
				get;
				set;
			}

			/// <summary>
			///������������
			/// </summary>
			public virtual string FVIEWNAMES
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string CRMINFO
			{
				get;
				set;
			}

        #endregion
    }

}
