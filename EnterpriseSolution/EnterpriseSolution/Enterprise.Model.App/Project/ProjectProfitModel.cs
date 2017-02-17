using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 产值登记表
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/14 18:32:36
    /// </summary>
    [Serializable]
    public class ProjectProfitModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///产值表ID
        /// </summary>
        public virtual string PROFITID
        {
            get;
            set;
        }

        /// <summary>
        ///工程进度
        /// </summary>
        public virtual decimal? PROGRESS
        {
            get;
            set;
        }

        /// <summary>
        ///累计产值
        /// </summary>
        public virtual decimal? SUMVALUE
        {
            get;
            set;
        }

        /// <summary>
        ///完成产值
        /// </summary>
        public virtual decimal COMPLETEVALUE
        {
            get;
            set;
        }

        /// <summary>
        ///外包产值
        /// </summary>
        public virtual decimal OUTSOURCEVALUE
        {
            get;
            set;
        }

        /// <summary>
        ///开始时间
        /// </summary>
        public virtual DateTime? STARTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///日期
        /// </summary>
        public virtual DateTime? CHECKDATE
        {
            get;
            set;
        }

        /// <summary>
        ///结束时间
        /// </summary>
        public virtual DateTime? ENDDATE
        {
            get;
            set;
        }

        /// <summary>
        ///周期
        /// </summary>
        public virtual string PERIOD
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
        ///顺序号
        /// </summary>
        public virtual int? ORDERBY
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
