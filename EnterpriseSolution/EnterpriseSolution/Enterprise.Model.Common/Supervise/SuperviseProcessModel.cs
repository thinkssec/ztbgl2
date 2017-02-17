using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Supervise
{
    /// <summary>
    /// ����������ȼ��
	/// ������:����������
	/// ����ʱ��:	2013/3/13 15:23:42
    /// </summary>
    [Serializable]
    public class SuperviseProcessModel : CommonSuperModel
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
			///������ID
			/// </summary>
			public virtual string BLRID
			{
				get;
				set;
			}

			/// <summary>
			///�ϱ�ʱ��
			/// </summary>
			public virtual string YQSBSJ
			{
				get;
				set;
			}

			/// <summary>
			///��ǰ����
			/// </summary>
			public virtual decimal DQJD
			{
				get;
				set;
			}

			/// <summary>
			///ʵ���ϱ�ʱ��
			/// </summary>
			public virtual string SJSBSJ
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

            /// <summary>
            /// �Ƿ�����
            /// </summary>
            public virtual decimal FLAG
            { get; set; }

        #endregion
    }

}
