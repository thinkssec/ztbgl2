using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 任务策划表
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-5 15:48:24
    /// </summary>
    [Serializable]
    public class ProjectRwchModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///策划表ID
        /// </summary>
        public virtual string CHID
        {
            get;
            set;
        }

        /// <summary>
        ///任务权重
        /// </summary>
        public virtual decimal? RWQZ
        {
            get;
            set;
        }

        /// <summary>
        ///单位
        /// </summary>
        public virtual string DW
        {
            get;
            set;
        }

        /// <summary>
        ///计划完成时间
        /// </summary>
        public virtual DateTime? JHWCSJ
        {
            get;
            set;
        }

        /// <summary>
        ///专业名称
        /// </summary>
        public virtual string ZYMC
        {
            get;
            set;
        }

        /// <summary>
        ///本级代码
        /// </summary>
        public virtual string BJDM
        {
            get;
            set;
        }

        /// <summary>
        ///工作内容
        /// </summary>
        public virtual string GZNR
        {
            get;
            set;
        }

        /// <summary>
        ///实际工作量
        /// </summary>
        public virtual decimal? SJGZL
        {
            get;
            set;
        }

        /// <summary>
        ///任务状态：0=未完成 1=已完成
        /// </summary>
        public virtual int? RWZT
        {
            get;
            set;
        }

        /// <summary>
        ///资料归档状态:0=否 1=是
        /// </summary>
        public virtual int? ZLGDZT
        {
            get;
            set;
        }

        /// <summary>
        ///预计工作量
        /// </summary>
        public virtual decimal? YJGZL
        {
            get;
            set;
        }

        /// <summary>
        ///实际完成时间
        /// </summary>
        public virtual DateTime? SJWCSJ
        {
            get;
            set;
        }

        /// <summary>
        ///项目ID
        /// </summary>
        public virtual string PROJID
        {
            get;
            set;
        }

        #endregion


        #region 外键关联

        /// <summary>
        /// 任务工作量集合
        /// </summary>
        public virtual IList<ProjectRwgzlModel> RwgzlList
        {
            get;
            set;
        }

        #endregion
    }

}
