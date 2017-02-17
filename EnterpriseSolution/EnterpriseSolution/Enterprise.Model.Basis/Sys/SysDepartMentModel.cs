using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ��֯����
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:12
    /// </summary>
    [Serializable]
    public class SysDepartMentModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual int DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///��֯��������
			/// </summary>
			public virtual string DNAME
			{
				get;
				set;
			}

            public virtual string DNO
            {
                get;
                set;
            }
            public virtual string DTYPE
            {
                get;
                set;
            }

			/// <summary>
			///�������
			/// </summary>
			public virtual int DPARENTID
			{
				get;
				set;
			}

			/// <summary>
			///�㼶���
			/// </summary>
			public virtual int? DDEPTH
			{
				get;
				set;
			}

			/// <summary>
			///���ڵ�
			/// </summary>
			public virtual int? DROOTID
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? DORDERBY
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual int DMANAGER
			{
				get;
				set;
			}

			/// <summary>
			///�ֹܾ���
			/// </summary>
			public virtual int DHEADERMANAGER
			{
				get;
				set;
			}

        #endregion
    }

}
