using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 质量安全检查项目
    /// 创建人:代码生成器
    /// 创建时间:	2013/11/26 17:18:03
    /// </summary>
    [Serializable]
    public class ProjectQhsecheckitemModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///ITEM标识
        /// </summary>
        public virtual string ITEMID
        {
            get;
            set;
        }

        /// <summary>
        /// 关联检查表ID
        /// </summary>
        public virtual string ID
        {
            get;
            set;
        }

        /// <summary>
        ///内容
        /// </summary>
        public virtual string CHECKCONTS
        {
            get;
            set;
        }

        /// <summary>
        ///类型名称
        /// </summary>
        public virtual string TYPENAME
        {
            get;
            set;
        }

        /// <summary>
        ///备注
        /// </summary>
        public virtual string MEMO
        {
            get;
            set;
        }

        /// <summary>
        ///标准分值
        /// </summary>
        public virtual int? STANDARD
        {
            get;
            set;
        }

        /// <summary>
        ///得分
        /// </summary>
        public virtual decimal? SCORE
        {
            get;
            set;
        }

        #endregion
    }

}
