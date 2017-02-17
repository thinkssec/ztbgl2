using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Supervise
{
    /// <summary>
    /// ���������
	/// ������:����������
	/// ����ʱ��:	2013/3/13 15:23:41
    /// </summary>
    [Serializable]
    public class SuperviseInfoModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///����ID
			/// </summary>
			public virtual string DBID
			{
				get;
				set;
			}

			/// <summary>
			///�����쵼ID
			/// </summary>
			public virtual int? FZLD
			{
				get;
				set;
			}

			/// <summary>
			///�����´�ʱ��
			/// </summary>
			public virtual string XDSJ
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string DBBH
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string DBBT
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual string DBSJ
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string DBNR
			{
				get;
				set;
			}

			/// <summary>
			///���ʱ��
			/// </summary>
			public virtual string YQWCSJ
			{
				get;
				set;
			}
            
            /// <summary>
            /// ������
            /// </summary>
            public virtual int DBR
            {
                get;
                set;
            }

        #endregion
    }

}
