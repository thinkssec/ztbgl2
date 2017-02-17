using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Ui
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/3 13:48:42
    /// </summary>
    [Serializable]
    public class UiCustomModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///ID主键
			/// </summary>
			public virtual string CUSTOMID
			{
				get;
				set;
			}

			/// <summary>
			///UI定制内容
			/// </summary>
			public virtual string UICONTENT
			{
				get;
				set;
			}

			/// <summary>
			///用户ID
			/// </summary>
			public virtual string USERID
			{
				get;
				set;
			}

        #endregion
    }

}
