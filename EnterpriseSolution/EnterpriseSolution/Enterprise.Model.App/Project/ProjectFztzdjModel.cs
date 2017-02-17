using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 图纸登记列表
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/1 14:10:58
    /// </summary>
    [Serializable]
    public class ProjectFztzdjModel : AppSuperModel
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
			///图纸份数
			/// </summary>
			public virtual int? TZFS
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
			///接收人
			/// </summary>
			public virtual int? JSR
			{
				get;
				set;
			}

			/// <summary>
			///折合1#图量
			/// </summary>
			public virtual decimal? ZHTZL
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
			///接收时间
			/// </summary>
			public virtual DateTime? JSSJ
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
