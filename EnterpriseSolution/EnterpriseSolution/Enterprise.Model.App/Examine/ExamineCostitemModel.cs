using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// 成本费用项目表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-7 14:36:26
    /// </summary>
    [Serializable]
    public class ExamineCostitemModel : AppSuperModel
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
			///成本项名称
			/// </summary>
			public virtual string ITEMNAME
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
			///顺序号
			/// </summary>
			public virtual int? ITEMORDER
			{
				get;
				set;
			}

			/// <summary>
			///依据
			/// </summary>
			public virtual string ACCORDINGTO
			{
				get;
				set;
			}

        #endregion
    }

}
