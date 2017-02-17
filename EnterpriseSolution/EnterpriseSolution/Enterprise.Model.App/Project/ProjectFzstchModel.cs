using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 审图策划
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/1 14:10:57
    /// </summary>
    [Serializable]
    public class ProjectFzstchModel : AppSuperModel
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
			///审图状态:0=未完成 1=已完成
			/// </summary>
			public virtual int? STZT
			{
				get;
				set;
			}

			/// <summary>
			///本级代码
			/// </summary>
			public virtual string BJDM
			{
				get;
				set;
			}

			/// <summary>
			///图纸名称
			/// </summary>
			public virtual string TZMC
			{
				get;
				set;
			}

			/// <summary>
			///版次
			/// </summary>
			public virtual string BC
			{
				get;
				set;
			}

			/// <summary>
			///预计完成时间
			/// </summary>
			public virtual DateTime? YJWCSJ
			{
				get;
				set;
			}

			/// <summary>
			///审图人
			/// </summary>
			public virtual int? STR
			{
				get;
				set;
			}

			/// <summary>
			///折合1#图纸量
			/// </summary>
            public virtual decimal? ZHTZL
			{
				get;
				set;
			}

			/// <summary>
			///实际完成时间
			/// </summary>
			public virtual DateTime? SJWCSJ
			{
				get;
				set;
			}

			/// <summary>
			///档案号
			/// </summary>
			public virtual string DAH
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
