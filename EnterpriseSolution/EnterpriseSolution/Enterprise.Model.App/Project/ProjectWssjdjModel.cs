using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 未遂事件登记表
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/20 11:34:31
    /// </summary>
    [Serializable]
    public class ProjectWssjdjModel : AppSuperModel
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
			///发生日期
			/// </summary>
			public virtual DateTime? FSRQ
			{
				get;
				set;
			}

			/// <summary>
			///处理结果
			/// </summary>
			public virtual string CLJG
			{
				get;
				set;
			}

			/// <summary>
			///事件描述
			/// </summary>
			public virtual string SJMS
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
			///事件名称
			/// </summary>
			public virtual string SJMC
			{
				get;
				set;
			}

			/// <summary>
			///责任人
			/// </summary>
			public virtual string ZRR
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
