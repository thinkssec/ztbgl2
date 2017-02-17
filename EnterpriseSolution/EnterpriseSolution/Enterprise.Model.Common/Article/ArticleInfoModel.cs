using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Article
{
    /// <summary>
    /// 通知新闻类信息表
    /// 创建人:代码生成器
    /// 创建时间:	2013/4/18 9:51:26
    /// </summary>
    [Serializable]
    public class ArticleInfoModel : CommonSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///自动编号
        /// </summary>
        public virtual string ARTICLEID
        {
            get;
            set;
        }

        /// <summary>
        ///发布部门
        /// </summary>
        public virtual int? ADEPARTMENT
        {
            get;
            set;
        }

        /// <summary>
        ///发布人
        /// </summary>
        public virtual int? AUSER
        {
            get;
            set;
        }

        /// <summary>
        ///类型
        /// </summary>
        public virtual string ATYPE
        {
            get;
            set;
        }

        /// <summary>
        ///中文标题
        /// </summary>
        public virtual string ATITLE
        {
            get;
            set;
        }

        /// <summary>
        ///俄文标题
        /// </summary>
        public virtual string ATITLERU
        {
            get;
            set;
        }

        /// <summary>
        ///发布时间
        /// </summary>
        public virtual DateTime? ARELEASETIME
        {
            get;
            set;
        }

        /// <summary>
        ///有效时间
        /// </summary>
        public virtual DateTime? AINVALIDTIME
        {
            get;
            set;
        }

        /// <summary>
        ///签收人
        /// </summary>
        public virtual string ARECEVIEUSER
        {
            get;
            set;
        }

        /// <summary>
        ///创建人
        /// </summary>
        public virtual int? ACREATEUSER
        {
            get;
            set;
        }

        /// <summary>
        ///创建时间
        /// </summary>
        public virtual DateTime? ACREATETIME
        {
            get;
            set;
        }

        /// <summary>
        ///栏目编号
        /// </summary>
        public virtual string AMODULEID
        {
            get;
            set;
        }

        /// <summary>
        ///中文内容
        /// </summary>
        public virtual string ACONTENT
        {
            get;
            set;
        }

        /// <summary>
        ///俄文内容
        /// </summary>
        public virtual string ACONTENTRU
        {
            get;
            set;
        }

        /// <summary>
        ///版本号
        /// </summary>
        public virtual string AVERSION
        {
            get;
            set;
        }

        /// <summary>
        ///批准日期
        /// </summary>
        public virtual DateTime? APPROVALDATE
        {
            get;
            set;
        }

        /// <summary>
        ///生效日期
        /// </summary>
        public virtual DateTime? AISSUEDATE
        {
            get;
            set;
        }

        /// <summary>
        ///制度类型 0=新加 1=修订
        /// </summary>
        public virtual string ASYSTEMTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///附件保存名称
        /// </summary>
        public virtual string AFVIEWNAMES
        {
            get;
            set;
        }

        /// <summary>
        ///附件文件名称
        /// </summary>
        public virtual string AFNAMES
        {
            get;
            set;
        }

        #endregion
    }

}
