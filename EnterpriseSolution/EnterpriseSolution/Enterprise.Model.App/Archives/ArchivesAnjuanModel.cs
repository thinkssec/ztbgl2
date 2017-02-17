using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Archives
{
    /// <summary>
    /// 案卷目录表
    /// 创建人:代码生成器
    /// 创建时间:	2014/2/7 13:50:44
    /// </summary>
    [Serializable]
    public class ArchivesAnjuanModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///案卷目录ID
        /// </summary>
        public virtual string AJID
        {
            get;
            set;
        }

        /// <summary>
        ///保存位置
        /// </summary>
        public virtual string AJBCWZ
        {
            get;
            set;
        }

        /// <summary>
        ///年度
        /// </summary>
        public virtual string AJND
        {
            get;
            set;
        }

        /// <summary>
        ///备注
        /// </summary>
        public virtual string AJBZ
        {
            get;
            set;
        }

        /// <summary>
        ///档案号
        /// </summary>
        public virtual string AJDAH
        {
            get;
            set;
        }

        /// <summary>
        ///期限
        /// </summary>
        public virtual int? AJQX
        {
            get;
            set;
        }

        /// <summary>
        ///类别编号
        /// </summary>
        public virtual string ARCLBBH
        {
            get;
            set;
        }

        /// <summary>
        ///题名
        /// </summary>
        public virtual string AJTM
        {
            get;
            set;
        }

        /// <summary>
        ///件数
        /// </summary>
        public virtual int? AJJS
        {
            get;
            set;
        }

        /// <summary>
        ///建档人
        /// </summary>
        public virtual string AJJDR
        {
            get;
            set;
        }

        /// <summary>
        ///建档日期
        /// </summary>
        public virtual DateTime? AJJDRQ
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
    }

}
