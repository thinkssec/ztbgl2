using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// �������ϱ�
	/// ������:����������
	/// ����ʱ��:	2013/11/19 10:25:27
    /// </summary>
    [Serializable]
    public class ProjectCompletionModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///���ϱ�ID
			/// </summary>
			public virtual string DATAID
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
			///�汾��
			/// </summary>
			public virtual string VERSION
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
			///ǩ����
			/// </summary>
			public virtual int? SIGNER
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
			///��ע
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual int? APPROVER
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string ATTMENT
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string DATANAME
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
			///��״̬�� 0����� 1���ͬ�� 2��˲�ͬ��
			/// </summary>
			public virtual string CSTATUS
			{
				get;
				set;
			}

            /// <summary>
            /// �����ύ��
            /// </summary>
            public virtual int SUBMITTER
            {
                get;
                set;
            }

        #endregion
    }

}
