using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// �б��ļ����
	/// ������:����������
	/// ����ʱ��:	2015/7/24 21:48:45
    /// </summary>
    [Serializable]
    public class ProjectZbwjshModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string RPTID
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
			///������
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SUBMITDATE
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
			///���״̬ 0=δ��� 1=���ͨ�� 2=��˲�ͨ��
			/// </summary>
			public virtual int? CHECKSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ����״̬: -1=��ʱ���棻0�ύ���  1 �����ͨ�� 2����˲�ͨ�� 7:׼������ 8 �������
			/// </summary>
			public virtual int? STATUS
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
			public virtual int? PRTSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string RPTNAME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string ATTACHMENT
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SPR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SHBM
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPBM
			{
				get;
				set;
			}

        #endregion
    }

}
