using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// ����֤��
	/// ������:����������
	/// ����ʱ��:	2013-6-24 20:24:39
    /// </summary>
    [Serializable]
    public class BusitravelCertModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///BID
			/// </summary>
			public virtual string BID
			{
				get;
				set;
			}

			/// <summary>
			///����������
			/// </summary>
			public virtual string MANAGER
			{
				get;
				set;
			}

			/// <summary>
			///������֤��
			/// </summary>
			public virtual string ISSUEDTO
			{
				get;
				set;
			}

			/// <summary>
			///����Ŀ��
			/// </summary>
			public virtual string PURPOSE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string TERM
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string BASIS
			{
				get;
				set;
			}

			/// <summary>
			///���ջ����֤��
			/// </summary>
			public virtual string IDORPASSPORT
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? ISSUEDATE
			{
				get;
				set;
			}

			/// <summary>
			///����ص�
			/// </summary>
			public virtual string DESTINATION
			{
				get;
				set;
			}

			/// <summary>
			///����֤������
			/// </summary>
			public virtual string ISSUEFILE
			{
				get;
				set;
			}

        #endregion
    }

}
