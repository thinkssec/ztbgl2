using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Vote
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/3/1 10:30:49
    /// </summary>
    [Serializable]
    public class VoteItemModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///  自动编号
			/// </summary>
			public virtual int VITEMID
			{
				get;
				set;
			}

			/// <summary>
			/// 标题
			/// </summary>
			public virtual string VITEMTITLE
			{
				get;
				set;
			}

			/// <summary>
			///  编号
			/// </summary>
			public virtual string VITEMCODE
			{
				get;
				set;
			}

			/// <summary>
			/// 说明
			/// </summary>
			public virtual string VITEMREMARK
			{
				get;
				set;
			}

			/// <summary>
			/// 投票编号
			/// </summary>
			public virtual string VID
			{
				get;
				set;
			}

        #endregion
    }

}
