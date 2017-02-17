using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Article
{
    /// <summary>
    /// 大文本内容表
    /// 创建人:代码生成器
    /// 创建时间:	2014/2/7 13:50:48
    /// </summary>
    [Serializable]
    public class ArticleClobModel : CommonSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///文本ID
        /// </summary>
        public virtual string ARCID
        {
            get;
            set;
        }

        /// <summary>
        ///其它文字内容
        /// </summary>
        public virtual string ARCCONTENTOTHER
        {
            get;
            set;
        }

        /// <summary>
        ///关联ID
        /// </summary>
        public virtual string ASSOCIATIONID
        {
            get;
            set;
        }

        /// <summary>
        ///中文内容
        /// </summary>
        public virtual string ARCCONTENTCN
        {
            get;
            set;
        }

        /// <summary>
        ///备注说明
        /// </summary>
        public virtual string ARCBZ
        {
            get;
            set;
        }

        #endregion
    }

}
