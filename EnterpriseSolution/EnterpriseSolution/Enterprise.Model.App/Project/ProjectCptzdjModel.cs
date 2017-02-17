using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 图纸登记

	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:18
    /// </summary>
    [Serializable]
    public class ProjectCptzdjModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///图纸登记ID
			/// </summary>
			public virtual string TZDJID
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
			public virtual string JSR
			{
				get;
				set;
			}

			/// <summary>
			///折合1#图量
			/// </summary>
			public virtual int? ZHTZL
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
