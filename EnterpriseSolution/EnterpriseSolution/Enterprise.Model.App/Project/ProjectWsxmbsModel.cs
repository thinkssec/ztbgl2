using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目报审表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:25
    /// </summary>
    [Serializable]
    public class ProjectWsxmbsModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///报审表ID
			/// </summary>
			public virtual string BSID
			{
				get;
				set;
			}

			/// <summary>
			///文件名称
			/// </summary>
			public virtual string FILENAME
			{
				get;
				set;
			}

			/// <summary>
			///上传日期
			/// </summary>
			public virtual DateTime? UPLOADDATE
			{
				get;
				set;
			}

			/// <summary>
			///文件类型
			/// </summary>
			public virtual string FILETYPE
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
