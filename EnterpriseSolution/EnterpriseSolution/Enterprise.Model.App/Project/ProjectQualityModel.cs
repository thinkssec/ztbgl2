using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目质量检查表
	/// 创建人:代码生成器
	/// 创建时间:	2014/6/19 15:35:19
    /// </summary>
    [Serializable]
    public class ProjectQualityModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///检查日期
			/// </summary>
			public virtual DateTime? JCRQ
			{
				get;
				set;
			}

			/// <summary>
			///项目负责人
			/// </summary>
			public virtual string XMFZR
			{
				get;
				set;
			}

			/// <summary>
			///检查表附件
			/// </summary>
			public virtual string JCFJ
			{
				get;
				set;
			}

			/// <summary>
			///单位名称
			/// </summary>
			public virtual string DWMC
			{
				get;
				set;
			}

			/// <summary>
			///项目ID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///记录人
			/// </summary>
			public virtual string JLR
			{
				get;
				set;
			}

        #endregion
    }

}
