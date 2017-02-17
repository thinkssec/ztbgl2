using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目下达表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:21
    /// </summary>
    [Serializable]
    public class ProjectOrderModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///下达表ID
			/// </summary>
			public virtual string ORDID
			{
				get;
				set;
			}

			/// <summary>
			///单位ID
			/// </summary>
			public virtual int DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///项目负责人
			/// </summary>
			public virtual int? MANAGERID
			{
				get;
				set;
			}

			/// <summary>
			///下达时间
			/// </summary>
			public virtual DateTime? ORDDATE
			{
				get;
				set;
			}

			/// <summary>
			///是否接受:0=不接受 1=接受
			/// </summary>
			public virtual int? ISACCEPT
			{
				get;
				set;
			}

			/// <summary>
			///运行流程 0=简易 1=全流程
			/// </summary>
			public virtual int? FLOWTYPE
			{
				get;
				set;
			}

			/// <summary>
			///确认日期
			/// </summary>
			public virtual DateTime? APTDATE
			{
				get;
				set;
			}

			/// <summary>
			///任务内容
			/// </summary>
			public virtual string TASKCONT
			{
				get;
				set;
			}

			/// <summary>
			///确认说明
			/// </summary>
			public virtual string APTEXPLAIN
			{
				get;
				set;
			}

			/// <summary>
			///下达人
			/// </summary>
			public virtual int? ORDMANID
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
