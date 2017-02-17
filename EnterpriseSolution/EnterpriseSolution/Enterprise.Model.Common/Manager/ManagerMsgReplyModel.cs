using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Manager
{
    /// <summary>
    /// 领导信箱回复实体
    /// </summary>
    public class ManagerMsgReplyModel:CommonSuperModel
    {
            /// <summary>
			/// 自动编号
			/// </summary>
			public virtual int REPLYID
			{
				get;
				set;
			}

			/// <summary>
			/// 发布信息编号
			/// </summary>
			public virtual int MSGID
			{
				get;
				set;
			}

			/// <summary>
			///  回复内容
			/// </summary>
			public virtual string REPLYCONTENT
			{
				get;
				set;
			}

			/// <summary>
			///  是否显示
			/// </summary>
			public virtual int? REPLYISSHOW
			{
				get;
				set;
			}

			/// <summary>
			///  回复ip地址
			/// </summary>
			public virtual string REPLYIP
			{
				get;
				set;
			}

			/// <summary>
			/// 回复时间
			/// </summary>
            public virtual DateTime? REPLYTIME
			{
				get;
				set;
			}
    }
}
