using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/4 17:33:31
    /// </summary>
    [Serializable]
    public class ProjectRunninganalyzeviewModel : AppSuperModel
    {
        #region 代码生成器

            /// <summary>
            /// 主键
            /// </summary>
            public virtual string XH
            { get; set; }

			/// <summary>
			/// 承接类型
			/// </summary>
			public virtual string CJ
			{
				get;
				set;
			}

			/// <summary>
			/// 详细部门名称
			/// </summary>
			public virtual string DNAME
			{
				get;
				set;
			}

			/// <summary>
			///项目数量
			/// </summary>
			public virtual int? SL
			{
				get;
				set;
			}

            /// <summary>
            /// 部门ID
            /// </summary>
            public virtual int DEPTID
            {
                get;
                set;
            }
            /// <summary>
            /// 父级部门ID
            /// </summary>
            public virtual int DPARENTID
            { get; set; }

        #endregion
    }

}
