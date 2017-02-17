using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// �����Ϣ��
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:14
    /// </summary>
    [Serializable]
    public class ProjectCheckModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�����Ϣ��ID
			/// </summary>
			public virtual string CHECKID
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
			///������
			/// </summary>
			public virtual string CHECKOPINION
			{
				get;
				set;
			}

			/// <summary>
			///����ID
			/// </summary>
			public virtual string ASSOCIATEDID
			{
				get;
				set;
			}

			/// <summary>
			///���״̬
            ///0=δ��� 1=�����
			/// </summary>
			public virtual int? CHECKSTATUS
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
			///��������
			/// </summary>
			public virtual DateTime? SENDDATE
			{
				get;
				set;
			}

			/// <summary>
			///��˽��
            ///0=��ͬ�� 1=ͬ�� 2=�޸ĺ�ͬ��
			/// </summary>
			public virtual int? CHECKRESULT
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
			public virtual int? SENDER
			{
				get;
				set;
			}

			/// <summary>
			///��˴���
			/// </summary>
			public virtual int? CHECKORDER
			{
				get;
				set;
			}

            /// <summary>
            /// ��˸���
            /// </summary>
            public virtual string CHECKATTCH
            {
                get;
                set;
            }
            /// <summary>
            /// ���
            /// </summary>
            public virtual int? CHECKSCORE
            {
                get;
                set;
            }

        #endregion
    }


    /// <summary>
    /// ��˽��
    /// 0=��ͬ�� 1=ͬ�� 2=�޸ĺ�ͬ��
    /// </summary>
    public enum CheckResultType
    {
        ��ͬ�� = 0,
        ͬ�� = 1,
        �޸ĺ�ͬ�� = 2
    }

}
