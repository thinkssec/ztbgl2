using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Meeting
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/3/1 15:50:38
    /// </summary>
    [Serializable]
    public class MeetingRecevieModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			/// �Զ����
			/// </summary>
			public virtual int MRID
			{
				get;
				set;
			}

			/// <summary>
			/// ǩ��ʱ��
			/// </summary>
			public virtual DateTime? MRTIME
			{
				get;
				set;
			}

			/// <summary>
			/// ǩ����Ա
			/// </summary>
			public virtual int? MRUSERID
			{
				get;
				set;
			}

			/// <summary>
			/// ������
			/// </summary>
			public virtual int? MID
			{
				get;
				set;
			}

        #endregion
    }

}
