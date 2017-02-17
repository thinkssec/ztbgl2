using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// 文档库类别
	/// 创建人:代码生成器
	/// 创建时间:	2014/3/6 8:25:02
    /// </summary>
    [Serializable]
    public class DocumentKindModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///类别编号
			/// </summary>
			public virtual string LBBH
			{
				get;
				set;
			}

			/// <summary>
			///类别名称
			/// </summary>
			public virtual string LBMC
			{
				get;
				set;
			}

			/// <summary>
			///类别序号
			/// </summary>
			public virtual string LBXH
			{
				get;
				set;
			}

			/// <summary>
			///上级编号
			/// </summary>
			public virtual string SJBH
			{
				get;
				set;
			}

        #endregion
    }

}
