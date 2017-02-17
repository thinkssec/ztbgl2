using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Archives
{
    /// <summary>
    /// 案卷类别表
    /// 创建人:代码生成器
    /// 创建时间:	2014/2/7 13:50:45
    /// </summary>
    [Serializable]
    public class ArchivesKindModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///类别编号
        /// </summary>
        public virtual string ARCLBBH
        {
            get;
            set;
        }

        /// <summary>
        ///上级编号
        /// </summary>
        public virtual string ARCSJBH
        {
            get;
            set;
        }

        /// <summary>
        ///类别名称
        /// </summary>
        public virtual string ARCLBMC
        {
            get;
            set;
        }

        /// <summary>
        ///类别序号
        /// </summary>
        public virtual int? ARCLBXH
        {
            get;
            set;
        }

        #endregion
    }

}
