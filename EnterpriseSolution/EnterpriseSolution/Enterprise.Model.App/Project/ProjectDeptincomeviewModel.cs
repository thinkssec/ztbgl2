using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
    /// 创建人:代码生成器
    /// 创建时间:	2013/12/10 10:44:41
    /// </summary>
    [Serializable]
    public class ProjectDeptincomeviewModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        /// 部门ID
        /// </summary>
        public virtual int DEPTID
        {
            get;
            set;
        }

        /// <summary>
        /// 年度
        /// </summary>
        public virtual int YEAR
        {
            get;
            set;
        }

        /// <summary>
        ///合同收入
        /// </summary>
        public virtual decimal? HTSR
        {
            get;
            set;
        }

        /// <summary>
        ///回款收入
        /// </summary>
        public virtual decimal? HKSR
        {
            get;
            set;
        }

        /// <summary>
        ///预计收入
        /// </summary>
        public virtual decimal? YJSR
        {
            get;
            set;
        }

        /// <summary>
        ///项目成本
        /// </summary>
        public virtual decimal? XMCB
        {
            get;
            set;
        }

        /// <summary>
        ///项目产值
        /// </summary>
        public virtual decimal? XMCZ
        {
            get;
            set;
        }

        /// <summary>
        ///结算收入
        /// </summary>
        public virtual decimal? JSSR
        {
            get;
            set;
        }

        #endregion
    }

}
