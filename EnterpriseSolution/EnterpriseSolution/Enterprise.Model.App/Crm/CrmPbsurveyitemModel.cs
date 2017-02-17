using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 乙方单位评价内容表
	/// 创建人:代码生成器
	/// 创建时间:	2014/3/31 17:16:09
    /// </summary>
    [Serializable]
    public class CrmPbsurveyitemModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///评价项ID
			/// </summary>
			public virtual string ITEMID
			{
				get;
				set;
			}

			/// <summary>
			///调查评价项
			/// </summary>
			public virtual string ITEMNAME
			{
				get;
				set;
			}

			/// <summary>
			///调查表ID
			/// </summary>
			public virtual string DCID
			{
				get;
				set;
			}

			/// <summary>
			///分项得分
			/// </summary>
			public virtual decimal? ITEMSCORE
			{
				get;
				set;
			}

        #endregion
    }

}
