using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目质量管理表
	/// 创建人:代码生成器
	/// 创建时间:	2014/6/21 17:32:39
    /// </summary>
    [Serializable]
    public class ProjectZlglModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///上传人
			/// </summary>
			public virtual int? SCR
			{
				get;
				set;
			}

			/// <summary>
			///质量名称
			/// </summary>
			public virtual string ZLNAME
			{
				get;
				set;
			}

			/// <summary>
			///质量管理ID
			/// </summary>
			public virtual string ZLID
			{
				get;
				set;
			}

			/// <summary>
			///检查日期
			/// </summary>
			public virtual DateTime? CHECKDATE
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
			///备注
			/// </summary>
			public virtual string MEMO
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
