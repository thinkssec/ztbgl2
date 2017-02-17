using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Ui
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/4 10:14:11
    /// </summary>
    [Serializable]
    public class UiTabModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///标签ID
			/// </summary>
			public virtual string TABID
			{
				get;
				set;
			}

			/// <summary>
			///标签名称
			/// </summary>
			public virtual string TABNAME
			{
				get;
				set;
			}

			/// <summary>
			///标签内容URL
			/// </summary>
			public virtual string TABURL
			{
				get;
				set;
			}
            /// <summary>
            /// 标签排序
            /// </summary>
            public virtual int? TABPX
            {
                get;
                set;
            }

        #endregion
    }

}
