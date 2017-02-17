using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Article
{
    /// <summary>
    /// 文档下载管理
	/// 创建人:代码生成器
	/// 创建时间:	2013-5-16 17:44:16
    /// </summary>
    [Serializable]
    public class ArticleDownloadModel : CommonSuperModel
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
        ///文件名称
        /// </summary>
        public virtual string FILENAME
        {
            get;
            set;
        }

        /// <summary>
        ///人员账号
        /// </summary>
        public virtual string ULOGIN
        {
            get;
            set;
        }

        /// <summary>
        ///文档ID
        /// </summary>
        public virtual string ARTICLEID
        {
            get;
            set;
        }

        /// <summary>
        ///备注
        /// </summary>
        public virtual string BZ
        {
            get;
            set;
        }

        /// <summary>
        ///下载日期
        /// </summary>
        public virtual DateTime XZRQ
        {
            get;
            set;
        }

        /// <summary>
        ///IP地址
        /// </summary>
        public virtual string UIP
        {
            get;
            set;
        }

        #endregion
    }

}
