using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 分包合同表
    /// 创建人:代码生成器
    /// 创建时间:	2013/12/11 11:28:00
    /// </summary>
    [Serializable]
    public class CrmFbcontractModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///分包合同ID
        /// </summary>
        public virtual string FBHTID
        {
            get;
            set;
        }

        /// <summary>
        ///分包合同附件
        /// </summary>
        public virtual string HTFJ
        {
            get;
            set;
        }

        /// <summary>
        ///合同分包商
        /// </summary>
        public virtual string HTFBS
        {
            get;
            set;
        }

        /// <summary>
        ///合同结束日期
        /// </summary>
        public virtual DateTime? HTJSRQ
        {
            get;
            set;
        }

        /// <summary>
        ///合同编号
        /// </summary>
        public virtual string HTBH
        {
            get;
            set;
        }

        /// <summary>
        ///合同状态:0=未审核 1=审核通过 2=审核不通过
        /// </summary>
        public virtual int? HTZT
        {
            get;
            set;
        }

        /// <summary>
        ///经办日期
        /// </summary>
        public virtual DateTime? JBRQ
        {
            get;
            set;
        }

        /// <summary>
        ///关联系统ID
        /// </summary>
        public virtual string GLXTID
        {
            get;
            set;
        }

        /// <summary>
        ///合同起始日期
        /// </summary>
        public virtual DateTime? HTQSRQ
        {
            get;
            set;
        }

        /// <summary>
        ///合同金额
        /// </summary>
        public virtual decimal HTJE
        {
            get;
            set;
        }

        /// <summary>
        ///经办人
        /// </summary>
        public virtual int? JBR
        {
            get;
            set;
        }

        /// <summary>
        ///分包联系人ID
        /// </summary>
        public virtual string PERID
        {
            get;
            set;
        }

        /// <summary>
        ///合同名称
        /// </summary>
        public virtual string FBHTNAME
        {
            get;
            set;
        }

        #endregion
    }

}
