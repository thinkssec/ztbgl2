using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目结算与回款记录表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:24
    /// </summary>
    [Serializable]
    public class ProjectSettlementModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///结算表ID
        /// </summary>
        public virtual string SETTLEID
        {
            get;
            set;
        }

        /// <summary>
        ///结算日期
        /// </summary>
        public virtual DateTime? ACCOUNTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///工作内容
        /// </summary>
        public virtual string CONTENT
        {
            get;
            set;
        }

        /// <summary>
        ///结算类型：1=结算 2=回款
        /// </summary>
        public virtual int? TYPE
        {
            get;
            set;
        }

        /// <summary>
        ///结算区域类型
        /// </summary>
        public virtual string PAYOFFTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///结算金额
        /// </summary>
        public virtual decimal? AMOUNT
        {
            get;
            set;
        }

        /// <summary>
        ///经办人
        /// </summary>
        public virtual string OPERATOR
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
