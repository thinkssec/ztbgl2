using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Publicize
{
    /// <summary>
    /// 宣传报道投稿
    /// 创建人:代码生成器
    /// 创建时间:	2014/2/8 10:32:28
    /// </summary>
    [Serializable]
    public class PublicizeInfoModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///投稿ID
        /// </summary>
        public virtual string PUBID
        {
            get;
            set;
        }

        /// <summary>
        ///发布日期
        /// </summary>
        public virtual DateTime? PUBDATE
        {
            get;
            set;
        }

        /// <summary>
        ///投稿日期
        /// </summary>
        public virtual DateTime? SUBMITDATE
        {
            get;
            set;
        }

        /// <summary>
        ///用户ID
        /// </summary>
        public virtual int USERID
        {
            get;
            set;
        }

        /// <summary>
        ///标题
        /// </summary>
        public virtual string PUBTITLE
        {
            get;
            set;
        }

        /// <summary>
        ///栏目ID
        /// </summary>
        public virtual string LMID
        {
            get;
            set;
        }

        /// <summary>
        ///附件
        /// </summary>
        public virtual string ATTACHMENT
        {
            get;
            set;
        }

        /// <summary>
        ///发布单位
        /// </summary>
        public virtual string PUBDEPT
        {
            get;
            set;
        }

        /// <summary>
        ///审核状态:0=未审核 1=审核通过 2=审核不通过 3=已发布
        /// </summary>
        public virtual int? STATUS
        {
            get;
            set;
        }

        /// <summary>
        ///审核日期
        /// </summary>
        public virtual DateTime? AUDITDATE
        {
            get;
            set;
        }

        /// <summary>
        ///点击次数
        /// </summary>
        public virtual int? CLICKS
        {
            get;
            set;
        }




        /// <summary>
        ///是否推荐到首页，1：推荐 0：不推荐
        /// </summary>
        public virtual string RECOMMEND
        {
            get;
            set;
        }

        /// <summary>
        ///文章缩略图
        /// </summary>
        public virtual string SLT
        {
            get;
            set;
        }

        /// <summary>
        ///是否置顶 0：不置顶 1：置顶
        /// </summary>
        public virtual string ZD
        {
            get;
            set;
        }
        #endregion
    }

}
