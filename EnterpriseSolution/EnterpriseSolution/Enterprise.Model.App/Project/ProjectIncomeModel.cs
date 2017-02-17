using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目合同收入
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:20
    /// </summary>
    [Serializable]
    public class ProjectIncomeModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///合同编号
			/// </summary>
			public virtual string CONTRACTID
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
			///项目合同收入
			/// </summary>
			public virtual decimal? INCOMEVALUE
			{
				get;
				set;
			}

        #endregion
    }

}
