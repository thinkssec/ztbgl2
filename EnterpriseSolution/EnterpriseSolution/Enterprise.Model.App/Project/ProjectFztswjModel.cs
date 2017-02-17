using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 退审的文件
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/1 14:10:57
    /// </summary>
    [Serializable]
    public class ProjectFztswjModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///文件ID
			/// </summary>
			public virtual string WJID
			{
				get;
				set;
			}

			/// <summary>
			///文件名称
			/// </summary>
			public virtual string WJMC
			{
				get;
				set;
			}

			/// <summary>
			///批准状态
			/// </summary>
			public virtual string WJZT
			{
				get;
				set;
			}

			/// <summary>
			///文件号
			/// </summary>
			public virtual string WJH
			{
				get;
				set;
			}

			/// <summary>
			///退审ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

        #endregion
    }

}
