using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 专家评审
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/1 14:10:59
    /// </summary>
    [Serializable]
    public class ProjectFzzjpsModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///文档名称
			/// </summary>
			public virtual string WDMC
			{
				get;
				set;
			}

			/// <summary>
			///参加人员
			/// </summary>
			public virtual string CJRY
			{
				get;
				set;
			}

			/// <summary>
			///登记人
			/// </summary>
			public virtual int? DJR
			{
				get;
				set;
			}

			/// <summary>
			///文档类型
			/// </summary>
			public virtual string WDLX
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
			///评审地点
			/// </summary>
			public virtual string PSDD
			{
				get;
				set;
			}

			/// <summary>
			///评审时间
			/// </summary>
			public virtual DateTime? PSSJ
			{
				get;
				set;
			}

			/// <summary>
			///登记日期
			/// </summary>
			public virtual DateTime? DJRQ
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
			///审核意见
			/// </summary>
			public virtual string SHYJ
			{
				get;
				set;
			}

        #endregion
    }

}
