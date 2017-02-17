using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 设计备案记录
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/1 14:10:56
    /// </summary>
    [Serializable]
    public class ProjectFzsjbajlModel : AppSuperModel
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
			///文件名称
			/// </summary>
			public virtual string WJMC
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
			///备案时间
			/// </summary>
			public virtual DateTime? BASJ
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
			///备案结果
			/// </summary>
			public virtual string BAJG
			{
				get;
				set;
			}

			/// <summary>
			///经办人
			/// </summary>
			public virtual string JBR
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
