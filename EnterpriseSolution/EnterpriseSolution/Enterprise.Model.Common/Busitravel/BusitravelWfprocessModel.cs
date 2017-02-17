using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// ��������������¼��
	/// ������:����������
	/// ����ʱ��:	2013-2-25 8:12:13
    /// </summary>
    [Serializable]
    public class BusitravelWfprocessModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///������Ȩ�����Ա
			/// </summary>
			public virtual int? PUSERID
			{
				get;
				set;
			}

			/// <summary>
			///�Զ����
			/// </summary>
			public virtual string PID
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ����
			/// </summary>
			public virtual int? PISCHECK
			{
				get;
				set;
			}

			/// <summary>
			///���б�ID
			/// </summary>
			public virtual string RUNID
			{
				get;
				set;
			}

			/// <summary>
			///���ʱ��
			/// </summary>
			public virtual DateTime? PTIME
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string PWFTYPE
			{
				get;
				set;
			}

			/// <summary>
			///��˽���
			/// </summary>
			public virtual int? PRESULT
			{
				get;
				set;
			}

			/// <summary>
			///ʵ��ID
			/// </summary>
			public virtual string WFID
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual int? PUSERORDERBY
			{
				get;
				set;
			}

			/// <summary>
			///���������Ա
			/// </summary>
			public virtual int? PUSERID_REAL
			{
				get;
				set;
			}

			/// <summary>
			///���˵��
			/// </summary>
			public virtual string PREMARK
			{
				get;
				set;
			}

        #endregion
    }

}
