using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 图纸交付记录列表
    /// 创建人:代码生成器
    /// 创建时间:	2013/12/1 14:10:59
    /// </summary>
    [Serializable]
    public class ProjectFztzjfjlModel : AppSuperModel
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
        public virtual string WJMC
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
        ///附件
        /// </summary>
        public virtual string FJ
        {
            get;
            set;
        }

        /// <summary>
        ///交付时间
        /// </summary>
        public virtual DateTime? JFSJ
        {
            get;
            set;
        }

        /// <summary>
        ///接收人
        /// </summary>
        public virtual string JSR
        {
            get;
            set;
        }

        /// <summary>
        ///份数
        /// </summary>
        public virtual int? FS
        {
            get;
            set;
        }

        /// <summary>
        ///经办人
        /// </summary>
        public virtual int? JBR
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

        /// <summary>
        ///版次
        /// </summary>
        public virtual string BC
        {
            get;
            set;
        }

        /// <summary>
        ///档案号
        /// </summary>
        public virtual string DAH
        {
            get;
            set;
        }

        #endregion
    }

}
