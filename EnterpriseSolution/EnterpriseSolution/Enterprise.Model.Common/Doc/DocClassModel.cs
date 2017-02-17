using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Doc
{
    /// <summary>
    /// 通用文章分类模型
	/// 创建人:代码生成器
	/// 创建时间:	2013/2/26 15:10:23
    /// </summary>
    [Serializable]
    public class DocClassModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///分类ID
			/// </summary>
			public virtual int CLASSID
			{
				get;
				set;
			}

			/// <summary>
			///发布权限 如果为空所有人都能发布
			/// </summary>
			public virtual string CLASSPUBROLES
			{
				get;
				set;
			}

			/// <summary>
			///外部链接URL
			/// </summary>
			public virtual string CLASSURL
			{
				get;
				set;
			}

			/// <summary>
			///访问权限 如果为空所有人都能访问
			/// </summary>
			public virtual string CLASSVIEWROLES
			{
				get;
				set;
			}

			/// <summary>
			///特殊标记
			/// </summary>
			public virtual int? CLASSFLAG
			{
				get;
				set;
			}

			/// <summary>
			///分类名称
			/// </summary>
			public virtual string CLASSNAME
			{
				get;
				set;
			}

			/// <summary>
			///排序
			/// </summary>
			public virtual int? CLASSORDERBY
			{
				get;
				set;
			}

        #endregion
    }

}
