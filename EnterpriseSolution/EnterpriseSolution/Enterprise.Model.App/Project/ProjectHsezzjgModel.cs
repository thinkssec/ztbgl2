using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// HSE组织机构
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/20 11:34:29
    /// </summary>
    [Serializable]
    public class ProjectHsezzjgModel : AppSuperModel
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
			///联系方式
			/// </summary>
			public virtual string LXFS
			{
				get;
				set;
			}

			/// <summary>
			///姓名
			/// </summary>
			public virtual string XM
			{
				get;
				set;
			}

			/// <summary>
			///职务
			/// </summary>
			public virtual string ZW
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
			///职责
			/// </summary>
			public virtual string ZZ
			{
				get;
				set;
			}

        #endregion
    }

}
