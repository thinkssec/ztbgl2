using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Supervise
{
    /// <summary>
    /// 督办事务进度检查
	/// 创建人:代码生成器
	/// 创建时间:	2013/3/13 15:23:42
    /// </summary>
    [Serializable]
    public class SuperviseProcessModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///督办ID
			/// </summary>
			public virtual string DBID
			{
				get;
				set;
			}

			/// <summary>
			///办理人ID
			/// </summary>
			public virtual string BLRID
			{
				get;
				set;
			}

			/// <summary>
			///上报时间
			/// </summary>
			public virtual string YQSBSJ
			{
				get;
				set;
			}

			/// <summary>
			///当前进度
			/// </summary>
			public virtual decimal DQJD
			{
				get;
				set;
			}

			/// <summary>
			///实际上报时间
			/// </summary>
			public virtual string SJSBSJ
			{
				get;
				set;
			}

			/// <summary>
			///备注
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

            /// <summary>
            /// 是否提醒
            /// </summary>
            public virtual decimal FLAG
            { get; set; }

        #endregion
    }

}
