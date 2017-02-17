using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Model.App.Examine;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 费用记录表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:16
    /// </summary>
    [Serializable]
    public class ProjectCostModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///费用记录ID
        /// </summary>
        public virtual string COSTID
        {
            get;
            set;
        }

        /// <summary>
        ///支出日期
        /// </summary>
        public virtual DateTime? COSTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///操作人
        /// </summary>
        public virtual string OPERATER
        {
            get;
            set;
        }

        /// <summary>
        ///票据审核人
        /// </summary>
        public virtual string PRETRIAL
        {
            get;
            set;
        }

        /// <summary>
        ///支出说明
        /// </summary>
        public virtual string EXPLAIN
        {
            get;
            set;
        }

        /// <summary>
        ///是否有发票
        /// </summary>
        public virtual int? ISBILL
        {
            get;
            set;
        }

        /// <summary>
        ///金额
        /// </summary>
        public virtual decimal AMOUNT
        {
            get;
            set;
        }

        /// <summary>
        ///操作日期
        /// </summary>
        public virtual DateTime? OPERATEDATE
        {
            get;
            set;
        }

        /// <summary>
        ///票据张数
        /// </summary>
        public virtual int? TICKETS
        {
            get;
            set;
        }

        /// <summary>
        ///科目代号
        /// </summary>
        public virtual string COSTCODE
        {
            get;
            set;
        }

        /// <summary>
        ///经办人
        /// </summary>
        public virtual int? PROCESSOR
        {
            get;
            set;
        }

        /// <summary>
        ///记录状态
        /// </summary>
        public virtual int? STATUS
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


        #region 外键关联

        /// <summary>
        ///成本科目MODEL
        /// </summary>
        public virtual ExamineCostModel ExamineCostInfo
        {
            get;
            set;
        }

        #endregion
    }

}
