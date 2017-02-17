using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Publicize
{
    /// <summary>
    /// 文章栏目表
	/// 创建人:代码生成器
	/// 创建时间:	2014/2/8 10:32:29
    /// </summary>
    [Serializable]
    public class PublicizeKindModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///栏目ID
			/// </summary>
			public virtual string LMID
			{
				get;
				set;
			}

			/// <summary>
			///栏目备注
			/// </summary>
			public virtual string LMBZ
			{
				get;
				set;
			}

			/// <summary>
			///栏目名称
			/// </summary>
			public virtual string LMMC
			{
				get;
				set;
			}

			/// <summary>
			///栏目序号
			/// </summary>
			public virtual int? LMXH
			{
				get;
				set;
			}

        #endregion
    }

}
