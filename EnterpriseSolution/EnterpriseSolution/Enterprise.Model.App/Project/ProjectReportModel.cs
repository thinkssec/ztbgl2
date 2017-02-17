using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��ⱨ���
	/// ������:����������
	/// ����ʱ��:	2013/11/22 16:48:39
    /// </summary>
    [Serializable]
    public class ProjectReportModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�����ID
			/// </summary>
			public virtual string RPTID
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
			///��ǰ״̬��0=δ��� 1=���ͨ��  2=��˲�ͨ��  3=��ӡ���
			/// </summary>
			public virtual int? PRTSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///�ύ��
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual int? AUDITOR
			{
				get;
				set;
			}

			/// <summary>
			///��д��
			/// </summary>
			public virtual int? WRITER
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string RPTCONTS
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
			///��ע
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///��׼��
			/// </summary>
			public virtual int? APPROVER
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string RPTTYPE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string RPTNAME
			{
				get;
				set;
			}

			/// <summary>
			///У����
			/// </summary>
			public virtual int? PROOFREADER
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? RPTDATE
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

			/// <summary>
			///������
			/// </summary>
			public virtual string RPTBH
			{
				get;
				set;
			}

        #endregion
    }

}
