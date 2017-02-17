using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ�´��
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:21
    /// </summary>
    [Serializable]
    public class ProjectOrderModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�´��ID
			/// </summary>
			public virtual string ORDID
			{
				get;
				set;
			}

			/// <summary>
			///��λID
			/// </summary>
			public virtual int DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ������
			/// </summary>
			public virtual int? MANAGERID
			{
				get;
				set;
			}

			/// <summary>
			///�´�ʱ��
			/// </summary>
			public virtual DateTime? ORDDATE
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ����:0=������ 1=����
			/// </summary>
			public virtual int? ISACCEPT
			{
				get;
				set;
			}

			/// <summary>
			///�������� 0=���� 1=ȫ����
			/// </summary>
			public virtual int? FLOWTYPE
			{
				get;
				set;
			}

			/// <summary>
			///ȷ������
			/// </summary>
			public virtual DateTime? APTDATE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string TASKCONT
			{
				get;
				set;
			}

			/// <summary>
			///ȷ��˵��
			/// </summary>
			public virtual string APTEXPLAIN
			{
				get;
				set;
			}

			/// <summary>
			///�´���
			/// </summary>
			public virtual int? ORDMANID
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
