using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
    /// 创建人:代码生成器
    /// 创建时间:	2013/12/28 15:34:11
    /// </summary>
    [Serializable]
    public class ProjectDailyviewModel : AppSuperModel
    {
        #region 代码生成器


        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime RQ
        {
            get;
            set;
        }

        /// <summary>
        /// 项目ID
        /// </summary>
        public virtual string PROJID
        {
            get;
            set;
        }

        /// <summary>
        /// 项目当日成本（万元）
        /// </summary>
        public virtual decimal XMCB
        {
            get;
            set;
        }

        /// <summary>
        /// 项目当日产值（万元）
        /// </summary>
        public virtual decimal XMCZ
        {
            get;
            set;
        }

        /// <summary>
        /// 项目当日结算收入（万元）
        /// </summary>
        public virtual decimal JSSR
        {
            get;
            set;
        }

        /// <summary>
        ///  项目当日回款收入（万元）
        /// </summary>
        public virtual decimal HKSR
        {
            get;
            set;
        }

        

        #endregion
    }

}
