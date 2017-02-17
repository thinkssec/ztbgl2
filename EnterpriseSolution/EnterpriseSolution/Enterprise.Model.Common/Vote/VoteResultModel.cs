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
    public class VoteResultModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///  自动编号
			/// </summary>
			public virtual int VRESULTID
			{
				get;
				set;
			}

			/// <summary>
			/// 项编号
			/// </summary>
			public virtual int? VITEMID
			{
				get;
				set;
			}

			/// <summary>
			///  项
			/// </summary>
			public virtual string VITEMCODE
			{
				get;
				set;
			}

			/// <summary>
			///  人员编号
			/// </summary>
			public virtual int? VRESULTUSERID
			{
				get;
				set;
			}

			/// <summary>
			///  时间
			/// </summary>
			public virtual DateTime? VRESULTTIME
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
