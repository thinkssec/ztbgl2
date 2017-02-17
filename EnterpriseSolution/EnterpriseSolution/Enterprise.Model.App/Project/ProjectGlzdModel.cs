using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目管理制度
	/// 创建人:代码生成器
	/// 创建时间:	2014/6/21 17:32:40
    /// </summary>
    [Serializable]
    public class ProjectGlzdModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///管理制度ID
			/// </summary>
			public virtual string GLZDID
			{
				get;
				set;
			}

			/// <summary>
			///制度名称
			/// </summary>
			public virtual string INSTITUTIONNAME
			{
				get;
				set;
			}

			/// <summary>
			///附件
			/// </summary>
			public virtual string ATTACHMENT
			{
				get;
				set;
			}

			/// <summary>
			///发布日期
			/// </summary>
			public virtual DateTime? PUBLISHDATE
			{
				get;
				set;
			}

			/// <summary>
			///操作人
			/// </summary>
			public virtual int? CZR
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
