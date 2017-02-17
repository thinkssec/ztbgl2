using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目计划表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:21
    /// </summary>
    [Serializable]
    public class ProjectPlanModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///项目计划表ID
			/// </summary>
			public virtual string PLANID
			{
				get;
				set;
			}

			/// <summary>
			///审核状态：-1=审核中 0=不通过 1=通过 2=同意变更
			/// </summary>
			public virtual int? AUDITSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///项目概况
			/// </summary>
			public virtual string PROJSURVEY
			{
				get;
				set;
			}

			/// <summary>
			///质量计划
			/// </summary>
			public virtual string QUALITYPLAN
			{
				get;
				set;
			}

			/// <summary>
			///安全预案
			/// </summary>
			public virtual string PREPAREDNESS
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
			///审核日期
			/// </summary>
			public virtual DateTime? AUDITDATE
			{
				get;
				set;
			}

        #endregion

        /// <summary>
        /// 成本计划
        /// </summary>
            public virtual IList<Model.App.Project.ProjectCostplanModel> ProjectCostPlans
            {
                get;
                set;
            }
            
    }

}
