using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// 文档浏览与下载记录表
	/// 创建人:代码生成器
	/// 创建时间:	2014/3/6 8:25:00
    /// </summary>
    [Serializable]
    public class DocumentDownloadsModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///记录ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///用户姓名
			/// </summary>
			public virtual string USERNAME
			{
				get;
				set;
			}

			/// <summary>
			///下载时间
			/// </summary>
			public virtual DateTime? DOWNLOADDATE
			{
				get;
				set;
			}

			/// <summary>
			///用户ID
			/// </summary>
			public virtual int? USERID
			{
				get;
				set;
			}

			/// <summary>
			///浏览时间
			/// </summary>
			public virtual DateTime? LOOKUPDATE
			{
				get;
				set;
			}

			/// <summary>
			///文档ID
			/// </summary>
			public virtual string DOCID
			{
				get;
				set;
			}

			/// <summary>
			///IP地址
			/// </summary>
			public virtual string IPADDR
			{
				get;
				set;
			}

        #endregion
    }

}
