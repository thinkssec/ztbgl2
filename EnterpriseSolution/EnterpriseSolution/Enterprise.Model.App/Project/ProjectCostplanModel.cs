using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 成本计划表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-7 14:36:27
    /// </summary>
    [Serializable]
    public class ProjectCostplanModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///成本项代码
			/// </summary>
			public virtual string ITEMCODE
			{
				get;
				set;
			}

			/// <summary>
			///项目计划表ID
			/// </summary>
			public virtual string PLANID
			{
				get;
				set;
			}

			/// <summary>
			///金额
			/// </summary>
			public virtual decimal AMOUNT
			{
				get;
				set;
			}

        #endregion

            #region 关联对象

            /// <summary>
            /// 成本代码
            /// </summary>
            public virtual Examine.ExamineCostitemModel ExamineCostitem
            {
                get;
                set;
            }

            #endregion
    }

}
