using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2015/7/8 22:25:41
    /// </summary>
    [Serializable]
    public class ProjectZbtzsModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
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
			public virtual int? SUBMITTER
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
			///�����б��ļ���ֹʱ��
			/// </summary>
			public virtual string P1
			{
				get;
				set;
			}

			/// <summary>
			///�б��ļ������ֹʱ��
			/// </summary>
			public virtual string P2
			{
				get;
				set;
			}

			/// <summary>
			///�б��ļ�����
			/// </summary>
			public virtual string P3
			{
				get;
				set;
			}

			/// <summary>
			///Ͷ����Ч��
			/// </summary>
			public virtual string P4
			{
				get;
				set;
			}

			/// <summary>
			///Ͷ�걣֤��
			/// </summary>
			public virtual string P5
			{
				get;
				set;
			}

			/// <summary>
			///Ͷ���ļ����� ����
			/// </summary>
			public virtual string P6
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string P7
			{
				get;
				set;
			}

			/// <summary>
			///�б귶Χ
			/// </summary>
			public virtual string P8
			{
				get;
				set;
			}

			/// <summary>
			///�б���1
			/// </summary>
			public virtual string P9
			{
				get;
				set;
			}

			/// <summary>
			///�б���2
			/// </summary>
			public virtual string P10
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P11
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P12
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string P13
			{
				get;
				set;
			}

        #endregion
    }

}
