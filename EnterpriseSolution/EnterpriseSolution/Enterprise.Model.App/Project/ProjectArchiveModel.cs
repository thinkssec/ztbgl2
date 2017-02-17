using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 资料存档表
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-5 15:48:13
    /// </summary>
    [Serializable]
    public class ProjectArchiveModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///资料表ID
        /// </summary>
        public virtual string ARCHIVEID
        {
            get;
            set;
        }

        /// <summary>
        ///核对人
        /// </summary>
        public virtual int? CHECKER
        {
            get;
            set;
        }

        /// <summary>
        ///保存介质
        /// </summary>
        public virtual string ARCHIVEMEDIA
        {
            get;
            set;
        }

        /// <summary>
        ///提交时间
        /// </summary>
        public virtual DateTime? SUBMITDATE
        {
            get;
            set;
        }

        /// <summary>
        ///文档名称
        /// </summary>
        public virtual string ARCHIVENAME
        {
            get;
            set;
        }

        /// <summary>
        ///核对状态
        ///0=未核对 1=已核对
        /// </summary>
        public virtual int? CHECKSTATUS
        {
            get;
            set;
        }

        /// <summary>
        ///核对日期
        /// </summary>
        public virtual DateTime? CHECKDATE
        {
            get;
            set;
        }

        /// <summary>
        ///件数
        /// </summary>
        public virtual int? ARCHIVECOUNT
        {
            get;
            set;
        }

        /// <summary>
        ///页数
        /// </summary>
        public virtual int? ARCHIVEPAGE
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
        ///附件
        /// </summary>
        public virtual string ATTACHMENT
        {
            get;
            set;
        }

        #endregion
    }

}
