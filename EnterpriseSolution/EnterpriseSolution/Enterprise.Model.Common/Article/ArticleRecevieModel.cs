using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Article
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/2/28 10:54:44
    /// </summary>
    [Serializable]
    public class ArticleRecevieModel : CommonSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///  自动编号
        /// </summary>
        public virtual string RECEVIEID
        {
            get;
            set;
        }

        /// <summary>
        /// 签收时间
        /// </summary>
        public virtual DateTime? RDATETIME
        {
            get;
            set;
        }

        /// <summary>
        ///  签收人
        /// </summary>
        public virtual int? RUSERID
        {
            get;
            set;
        }

        /// <summary>
        ///  新闻文章编号
        /// </summary>
        public virtual string INFOID
        {
            get;
            set;
        }

        #endregion
    }

}
