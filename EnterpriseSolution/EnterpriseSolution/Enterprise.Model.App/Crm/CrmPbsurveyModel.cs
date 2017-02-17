using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 乙方单位评价表
	/// 创建人:代码生成器
	/// 创建时间:	2014/3/31 17:16:06
    /// </summary>
    [Serializable]
    public class CrmPbsurveyModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///调查表ID
			/// </summary>
			public virtual string DCID
			{
				get;
				set;
			}

			/// <summary>
			///调查部门
			/// </summary>
			public virtual string DCBM
			{
				get;
				set;
			}

			/// <summary>
			///调查主题
			/// </summary>
			public virtual string DCZT
			{
				get;
				set;
			}

			/// <summary>
			///调查日期
			/// </summary>
			public virtual DateTime? DCRQ
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
			///部门负责人
			/// </summary>
			public virtual string FZR
			{
				get;
				set;
			}

			/// <summary>
			///部门意见
			/// </summary>
			public virtual string BMYJ
			{
				get;
				set;
			}

			/// <summary>
			///单位编码
			/// </summary>
			public virtual string PBBM
			{
				get;
				set;
			}

			/// <summary>
			///部门确认日期
			/// </summary>
			public virtual DateTime? QRRQ
			{
				get;
				set;
			}

			/// <summary>
			///调查人员
			/// </summary>
			public virtual string DCRY
			{
				get;
				set;
			}

			/// <summary>
			///综合得分
			/// </summary>
			public virtual decimal? ZDF
			{
				get;
				set;
			}

        #endregion
    }

}
