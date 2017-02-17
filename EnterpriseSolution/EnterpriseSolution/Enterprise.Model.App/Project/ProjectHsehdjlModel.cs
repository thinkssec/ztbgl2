using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// HSE班组活动记录
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/20 11:34:27
    /// </summary>
    [Serializable]
    public class ProjectHsehdjlModel : AppSuperModel
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
			///参加人员
			/// </summary>
			public virtual string CJRY
			{
				get;
				set;
			}

			/// <summary>
			///班组会内容
			/// </summary>
			public virtual string BZHNR
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

			/// <summary>
			///活动日期
			/// </summary>
			public virtual DateTime? HDRQ
			{
				get;
				set;
			}
            /// <summary>
            ///活动附件
            /// </summary>
            public virtual string ATTACHMENT
            {
                get;
                set;
            }

        #endregion
    }

}
