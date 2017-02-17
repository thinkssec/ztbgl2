using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 技术方案
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-5 15:48:19
    /// </summary>
    [Serializable]
    public class ProjectGdjsfaModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///技术方案ID
        /// </summary>
        public virtual string JSFAID
        {
            get;
            set;
        }

        /// <summary>
        ///方案名称
        /// </summary>
        public virtual string FAMC
        {
            get;
            set;
        }

        /// <summary>
        ///版本号
        /// </summary>
        public virtual string BBH
        {
            get;
            set;
        }

        /// <summary>
        ///审批人
        /// </summary>
        public virtual int? SPR
        {
            get;
            set;
        }

        /// <summary>
        ///审核意见稿
        /// </summary>
        public virtual string SHYJG
        {
            get;
            set;
        }

        /// <summary>
        ///校对人
        /// </summary>
        public virtual int? JDR
        {
            get;
            set;
        }

        /// <summary>
        ///审核人
        /// </summary>
        public virtual int? SHR
        {
            get;
            set;
        }

        /// <summary>
        ///编写人
        /// </summary>
        public virtual int? BXR
        {
            get;
            set;
        }

        /// <summary>
        ///上传附件
        /// </summary>
        public virtual string SCFJ
        {
            get;
            set;
        }

        /// <summary>
        ///签发时间
        /// </summary>
        public virtual DateTime? QFRQ
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
        ///质量得分
        /// </summary>
        public virtual decimal? ZLDF
        {
            get;
            set;
        }

        /// <summary>
        ///审核意见
        /// </summary>
        public virtual string SHYJ
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
        ///当前状态：0=未审核 1=审核通过  2=审核不通过  3=打印完成
        /// </summary>
        public virtual int? PRTSTATUS
        {
            get;
            set;
        }

        /// <summary>
        ///提交人
        /// </summary>
        public virtual int? SUBMITTER
        {
            get;
            set;
        }


        #endregion
    }

}
