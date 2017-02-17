using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// 文档库配置表
	/// 创建人:代码生成器
	/// 创建时间:	2014/3/6 8:24:58
    /// </summary>
    [Serializable]
    public class DocumentConfigModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///配置ID
			/// </summary>
			public virtual string PZID
			{
				get;
				set;
			}

			/// <summary>
            ///是否加水印 1=是 0=否
			/// </summary>
			public virtual int? SFJSY
			{
				get;
				set;
			}

			/// <summary>
            ///是否允许下载 1=是 0=否
			/// </summary>
			public virtual int? SFYXXZ
			{
				get;
				set;
			}

			/// <summary>
            ///是否自动转换 1=是 0=否
			/// </summary>
			public virtual int? SFZDZH
			{
				get;
				set;
			}

			/// <summary>
			///下载角色设定
			/// </summary>
			public virtual string XZJSSD
			{
				get;
				set;
			}

			/// <summary>
			///水印文字
			/// </summary>
			public virtual string SYWZ
			{
				get;
				set;
			}

        #endregion
    }

}
