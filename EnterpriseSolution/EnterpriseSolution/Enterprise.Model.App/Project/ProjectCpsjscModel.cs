using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 设计审查

	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:17
    /// </summary>
    [Serializable]
    public class ProjectCpsjscModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///设计审查ID
			/// </summary>
			public virtual string SJSCID
			{
				get;
				set;
			}

			/// <summary>
			///审查日期
			/// </summary>
			public virtual DateTime? SCRQ
			{
				get;
				set;
			}

			/// <summary>
			///数量
			/// </summary>
			public virtual int? CPSL
			{
				get;
				set;
			}

			/// <summary>
			///审查人
			/// </summary>
			public virtual int? SCR
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
			///附件
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///审查意见
			/// </summary>
			public virtual string SCYJ
			{
				get;
				set;
			}

			/// <summary>
			///产品名称
			/// </summary>
			public virtual string CPMC
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
