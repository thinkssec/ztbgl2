using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 质量安全检查表
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/26 17:18:02
    /// </summary>
    [Serializable]
    public class ProjectQhsecheckModel : AppSuperModel
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
			///质量得分
			/// </summary>
			public virtual decimal? QUALITYSCORE
			{
				get;
				set;
			}

			/// <summary>
			///检查人
			/// </summary>
			public virtual int? CHECKER
			{
				get;
				set;
			}

			/// <summary>
			///安全环保得分
			/// </summary>
			public virtual decimal? HSESCORE
			{
				get;
				set;
			}

			/// <summary>
			///检查日期
			/// </summary>
			public virtual DateTime? CHECKDATE
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
