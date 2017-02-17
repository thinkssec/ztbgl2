using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
    /// 创建人:代码生成器
    /// 创建时间:	2014/1/21 8:41:37
    /// </summary>
    [Serializable]
    public class ProjectFztzlviewModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        /// 审图人
        /// </summary>
        public virtual int? STR
        {
            get;
            set;
        }

        /// <summary>
        /// 年月
        /// egg.2014-01
        /// </summary>
        public virtual string NY
        {
            get;
            set;
        }

        /// <summary>
        /// 图纸量
        /// </summary>
        public virtual decimal? TZL
        {
            get;
            set;
        }

        #endregion
    }

}
