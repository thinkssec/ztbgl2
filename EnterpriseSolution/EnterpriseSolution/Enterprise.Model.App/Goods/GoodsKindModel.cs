using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Goods
{
    /// <summary>
    /// 物资类别表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:11
    /// </summary>
    [Serializable]
    public class GoodsKindModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///物资类别
			/// </summary>
			public virtual string KINDID
			{
				get;
				set;
			}

			/// <summary>
			///类别名称
			/// </summary>
			public virtual string KINDNAME
			{
				get;
				set;
			}

        #endregion
    }

}
