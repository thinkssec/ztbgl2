using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 检测任务工作量表
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-5 15:48:24
    /// </summary>
    [Serializable]
    public class ProjectRwgzlModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///任务量表ID
        /// </summary>
        public virtual string RWLID
        {
            get;
            set;
        }

        /// <summary>
        ///废片原因
        /// </summary>
        public virtual string WSFPYY
        {
            get;
            set;
        }

        /// <summary>
        ///结论说明
        /// </summary>
        public virtual string JLSM
        {
            get;
            set;
        }

        /// <summary>
        ///检验时间
        /// </summary>
        public virtual DateTime? JYSJ
        {
            get;
            set;
        }

        /// <summary>
        ///资料归档状态
        /// </summary>
        public virtual int? ZLGDZT
        {
            get;
            set;
        }

        /// <summary>
        ///废片率
        /// </summary>
        public virtual decimal? WSFPL
        {
            get;
            set;
        }

        /// <summary>
        ///完成工作量
        /// </summary>
        public virtual decimal? WCGZL
        {
            get;
            set;
        }

        /// <summary>
        ///废片说明
        /// </summary>
        public virtual string MEMO
        {
            get;
            set;
        }

        /// <summary>
        ///策划表ID
        /// </summary>
        public virtual string CHID
        {
            get;
            set;
        }

        /// <summary>
        ///检验人
        /// </summary>
        public virtual int? JYR
        {
            get;
            set;
        }

        /// <summary>
        ///报验单号
        /// </summary>
        public virtual string JYDH
        {
            get;
            set;
        }

        #endregion

        #region 外键关联

        /// <summary>
        /// 关联的任务策划MODEL
        /// </summary>
        public virtual ProjectRwchModel ProjectRwch
        {
            get;
            set;
        }

        #endregion
    }

}
