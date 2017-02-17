using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Meeting
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/3/1 15:50:38
    /// </summary>
    [Serializable]
    public class MeetingRecevieModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			/// 自动编号
			/// </summary>
			public virtual int MRID
			{
				get;
				set;
			}

			/// <summary>
			/// 签收时间
			/// </summary>
			public virtual DateTime? MRTIME
			{
				get;
				set;
			}

			/// <summary>
			/// 签收人员
			/// </summary>
			public virtual int? MRUSERID
			{
				get;
				set;
			}

			/// <summary>
			/// 会议编号
			/// </summary>
			public virtual int? MID
			{
				get;
				set;
			}

        #endregion
    }

}
