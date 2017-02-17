using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 隐患治理表
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/20 11:34:34
    /// </summary>
    [Serializable]
    public class ProjectYhzlModel : AppSuperModel
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
			///应急措施
			/// </summary>
			public virtual string YJCS
			{
				get;
				set;
			}

			/// <summary>
			///验收时间
			/// </summary>
			public virtual DateTime? YSSJ
			{
				get;
				set;
			}

			/// <summary>
			///责任人
			/// </summary>
			public virtual string ZRY
			{
				get;
				set;
			}

			/// <summary>
			///完成整改时间
			/// </summary>
			public virtual DateTime? WCZGSJ
			{
				get;
				set;
			}

			/// <summary>
			///现状及问题
			/// </summary>
			public virtual string XZJWT
			{
				get;
				set;
			}

			/// <summary>
			///备注
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///隐患名称
			/// </summary>
			public virtual string YHMC
			{
				get;
				set;
			}

			/// <summary>
			///计划整改时间
			/// </summary>
			public virtual DateTime? JHZGSJ
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

        #endregion
    }

}
