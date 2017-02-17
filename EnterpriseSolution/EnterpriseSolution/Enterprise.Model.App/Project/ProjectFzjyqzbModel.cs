using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 检验前准备
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/1 14:10:54
    /// </summary>
    [Serializable]
    public class ProjectFzjyqzbModel : AppSuperModel
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
			///报验单号
			/// </summary>
			public virtual string BYDH
			{
				get;
				set;
			}

			/// <summary>
			///介质类型
			/// </summary>
			public virtual string JZLX
			{
				get;
				set;
			}

			/// <summary>
			///审查人员
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
			///检验日期
			/// </summary>
			public virtual DateTime? JYRQ
			{
				get;
				set;
			}

			/// <summary>
			///是否留存
			/// </summary>
			public virtual int? SFLC
			{
				get;
				set;
			}

			/// <summary>
			///文件类型
			/// </summary>
			public virtual string WJLX
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
