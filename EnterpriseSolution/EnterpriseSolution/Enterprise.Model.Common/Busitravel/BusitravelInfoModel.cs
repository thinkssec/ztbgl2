using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// 差旅申请表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-23 17:52:25
    /// </summary>
    [Serializable]
    public class BusitravelInfoModel : CommonSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///自动编号
        /// </summary>
        public virtual string BID
        {
            get;
            set;
        }

        /// <summary>
        ///部门编号
        /// </summary>
        public virtual int? DEPTID
        {
            get;
            set;
        }

        /// <summary>
        ///关闭行程
        /// </summary>
        public virtual int? BCLOSE
        {
            get;
            set;
        }

        /// <summary>
        ///申请单创建时间
        /// </summary>
        public virtual DateTime? BCREATETIME
        {
            get;
            set;
        }

        /// <summary>
        ///机票类型
        /// </summary>
        public virtual string BTICKETTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///出差路线
        /// </summary>
        public virtual string BLINE
        {
            get;
            set;
        }

        /// <summary>
        ///用户编号
        /// </summary>
        public virtual int? USERID
        {
            get;
            set;
        }

        /// <summary>
        ///终止时间
        /// </summary>
        public virtual DateTime? BENDTIME
        {
            get;
            set;
        }

        /// <summary>
        ///出差目的地
        /// </summary>
        public virtual string BDESTINATION
        {
            get;
            set;
        }

        /// <summary>
        ///审批列表
        /// </summary>
        public virtual string BCHECKERS
        {
            get;
            set;
        }

        /// <summary>
        ///出差事由
        /// </summary>
        public virtual string BSUBJECT
        {
            get;
            set;
        }

        /// <summary>
        ///关闭时间
        /// </summary>
        public virtual DateTime? BCLOSETIME
        {
            get;
            set;
        }

        /// <summary>
        ///申请单状态
        ///0=未审批 1=审批通过 2=审批不通过
        ///3=已办理票务 4=行程关闭 5=行程取消
        /// </summary>
        public virtual int BSTATE
        {
            get;
            set;
        }

        /// <summary>
        ///起始时间
        /// </summary>
        public virtual DateTime? BSTARTIME
        {
            get;
            set;
        }

        /// <summary>
        /// 目的地类型
        /// 0=哈国 1=中国
        /// </summary>
        public virtual int BDESTYPE
        {
            get;
            set;
        }
        
        #endregion
    }

}
