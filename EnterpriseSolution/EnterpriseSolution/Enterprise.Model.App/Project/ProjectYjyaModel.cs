using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 应急预案
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/20 11:34:35
    /// </summary>
    [Serializable]
    public class ProjectYjyaModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///预案ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///参加人员
			/// </summary>
			public virtual string CJRY
			{
				get;
				set;
			}

			/// <summary>
			///演练内容
			/// </summary>
			public virtual string YLNR
			{
				get;
				set;
			}

			/// <summary>
			///演练时间
			/// </summary>
			public virtual DateTime? YLSJ
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
			///预案附件
			/// </summary>
			public virtual string YAFJ
			{
				get;
				set;
			}

			/// <summary>
			///应急预案
			/// </summary>
			public virtual string YJYA
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
			///演练地点
			/// </summary>
			public virtual string YLDD
			{
				get;
				set;
			}

        #endregion
    }

}
