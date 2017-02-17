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
    public class MeetingInfoModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			/// 自动编号
			/// </summary>
			public virtual int MEETINGID
			{
				get;
				set;
			}

			/// <summary>
			///  会议地点
			/// </summary>
			public virtual string MADDRESS
			{
				get;
				set;
			}

			/// <summary>
			/// 内容
			/// </summary>
			public virtual string MCONTENT
			{
				get;
				set;
			}

			/// <summary>
			/// 发布人
			/// </summary>
			public virtual int? MUSER
			{
				get;
				set;
			}

			/// <summary>
			/// 会议文件
			/// </summary>
			public virtual string MFILES
			{
				get;
				set;
			}

			/// <summary>
			/// 主持人
			/// </summary>
			public virtual string MZCR
			{
				get;
				set;
			}

			/// <summary>
			/// 创建时间
			/// </summary>
			public virtual DateTime? MCREATETIME
			{
				get;
				set;
			}

			/// <summary>
			/// 参与人员
			/// </summary>
			public virtual string MUSERS
			{
				get;
				set;
			}

			/// <summary>
			/// 发布部门
			/// </summary>
			public virtual int? MDEPARTMENT
			{
				get;
				set;
			}

			/// <summary>
			///  会议内容俄文
			/// </summary>
			public virtual string MCONTENTRU
			{
				get;
				set;
			}

			/// <summary>
			/// 会议主题俄文
			/// </summary>
			public virtual string MTITLERU
			{
				get;
				set;
			}

			/// <summary>
			/// 发布时间
			/// </summary>
			public virtual DateTime? MTIME
			{
				get;
				set;
			}

			/// <summary>
			/// 会议主题
			/// </summary>
			public virtual string MTITLE
			{
				get;
				set;
			}

			/// <summary>
			/// 发布人
			/// </summary>
			public virtual int? MUSERID
			{
				get;
				set;
			}

        #endregion
    }

}
