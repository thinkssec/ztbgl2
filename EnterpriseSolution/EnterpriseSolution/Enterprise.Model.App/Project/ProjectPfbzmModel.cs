using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 评分标准模板
	/// 创建人:代码生成器
	/// 创建时间:	2015/7/23 23:38:31
    /// </summary>
    [Serializable]
    public class ProjectPfbzmModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string BZID
			{
				get;
				set;
			}

			/// <summary>
			///项目名称
			/// </summary>
			public virtual string XMMC
			{
				get;
				set;
			}

			/// <summary>
			///评标分项
			/// </summary>
			public virtual string PBFX
			{
				get;
				set;
			}

			/// <summary>
			///分值
			/// </summary>
			public virtual decimal? FZ
			{
				get;
				set;
			}

			/// <summary>
			///评分标准
			/// </summary>
			public virtual string PFBZ
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual decimal? PF
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string MID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///排序
			/// </summary>
			public virtual int? XH
			{
				get;
				set;
			}

        #endregion
    }

}
