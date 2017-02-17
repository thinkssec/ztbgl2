using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 技术资料
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:19
    /// </summary>
    [Serializable]
    public class ProjectGdjszlModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///资料ID
			/// </summary>
			public virtual string ZLID
			{
				get;
				set;
			}

			/// <summary>
			///上传日期
			/// </summary>
			public virtual DateTime? SCRQ
			{
				get;
				set;
			}

			/// <summary>
			///审核人
			/// </summary>
			public virtual int? SHR
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
			///上传人
			/// </summary>
			public virtual int? SCR
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
			///附件
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///编制人
			/// </summary>
			public virtual int? BZR
			{
				get;
				set;
			}

			/// <summary>
			///文件类别
			/// </summary>
			public virtual string WJLB
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
