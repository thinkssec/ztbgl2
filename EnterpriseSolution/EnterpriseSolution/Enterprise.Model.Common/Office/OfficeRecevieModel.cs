using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Office
{
    /// <summary>
    /// ����ǩ�ռ�¼
	/// ������:����������
	/// ����ʱ��:	2013-2-27 21:01:29
    /// </summary>
    [Serializable]
    public class OfficeRecevieModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual string ORID
			{
				get;
				set;
			}

			/// <summary>
			///���ļ�¼���
			/// </summary>
			public virtual string OID
			{
				get;
				set;
			}

			/// <summary>
			///ǩ��ʱ��
			/// </summary>
			public virtual DateTime? ORTIME
			{
				get;
				set;
			}

			/// <summary>
			///ǩ����
			/// </summary>
			public virtual int? ORUSERID
			{
				get;
				set;
			}

        #endregion
    }

}
