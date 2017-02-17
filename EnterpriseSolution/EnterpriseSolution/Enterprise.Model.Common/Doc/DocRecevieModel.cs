using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Doc
{
    /// <summary>
    /// 通用文章查看表
	/// 创建人:代码生成器
	/// 创建时间:	2013/2/26 15:10:23
    /// </summary>
    [Serializable]
    public class DocRecevieModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual int RID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? RTIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? RUSERID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? DID
			{
				get;
				set;
			}

        #endregion
    }

}
