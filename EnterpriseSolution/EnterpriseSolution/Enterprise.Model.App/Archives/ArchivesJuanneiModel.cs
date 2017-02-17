using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Archives
{
    /// <summary>
    /// 卷内目录表
    /// 创建人:代码生成器
    /// 创建时间:	2014/2/7 13:50:45
    /// </summary>
    [Serializable]
    public class ArchivesJuanneiModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///卷内目录ID
        /// </summary>
        public virtual string JNID
        {
            get;
            set;
        }

        /// <summary>
        ///文件名称
        /// </summary>
        public virtual string JNWJMC
        {
            get;
            set;
        }

        /// <summary>
        ///页号
        /// </summary>
        public virtual int? JNYH
        {
            get;
            set;
        }

        /// <summary>
        ///备注
        /// </summary>
        public virtual string JNBZ
        {
            get;
            set;
        }

        /// <summary>
        ///日期
        /// </summary>
        public virtual DateTime? JNRQ
        {
            get;
            set;
        }

        /// <summary>
        ///案卷目录ID
        /// </summary>
        public virtual string AJID
        {
            get;
            set;
        }

        /// <summary>
        ///相关单位
        /// </summary>
        public virtual string JNXGDW
        {
            get;
            set;
        }

        /// <summary>
        ///文号
        /// </summary>
        public virtual string JNWH
        {
            get;
            set;
        }

        /// <summary>
        ///附件
        /// </summary>
        public virtual string JNFJ
        {
            get;
            set;
        }

        #endregion
    }

}
