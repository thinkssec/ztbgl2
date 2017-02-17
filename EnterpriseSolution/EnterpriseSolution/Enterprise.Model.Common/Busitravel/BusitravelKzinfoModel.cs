using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// 哈国出差申请单
    /// 创建人:代码生成器
    /// 创建时间:	2013-6-24 20:24:40
    /// </summary>
    [Serializable]
    public class BusitravelKzinfoModel : CommonSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///BID
        /// </summary>
        public virtual string BID
        {
            get;
            set;
        }

        /// <summary>
        ///申请部门
        /// </summary>
        public virtual int? DEPTID
        {
            get;
            set;
        }

        /// <summary>
        ///驻留结束时间
        /// </summary>
        public virtual DateTime? STAYEND
        {
            get;
            set;
        }

        /// <summary>
        ///行程方式
        /// </summary>
        public virtual string AIRTICKET
        {
            get;
            set;
        }

        /// <summary>
        ///申请人
        /// </summary>
        public virtual int? USERID
        {
            get;
            set;
        }

        /// <summary>
        ///出差人数
        /// </summary>
        public virtual int? PEOPLENUM
        {
            get;
            set;
        }

        /// <summary>
        ///入驻酒店名称
        /// </summary>
        public virtual string HOTELNAME
        {
            get;
            set;
        }

        /// <summary>
        ///取消行程日期
        /// </summary>
        public virtual DateTime? BCLOSEDATE
        {
            get;
            set;
        }

        /// <summary>
        ///驻留起始时间
        /// </summary>
        public virtual DateTime? STAYSTART
        {
            get;
            set;
        }

        /// <summary>
        ///目的地
        /// </summary>
        public virtual string DESTINATION
        {
            get;
            set;
        }

        /// <summary>
        ///酒店房间类型
        /// </summary>
        public virtual string ROOMTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///订票类型
        /// </summary>
        public virtual string CATEGORY
        {
            get;
            set;
        }

        /// <summary>
        ///付款方式
        /// </summary>
        public virtual string PAYMENT
        {
            get;
            set;
        }

        /// <summary>
        ///出差目的
        /// </summary>
        public virtual string PURPOSE
        {
            get;
            set;
        }

        /// <summary>
        ///途经地点
        /// </summary>
        public virtual string ONROUTE
        {
            get;
            set;
        }

        /// <summary>
        ///申请日期
        /// </summary>
        public virtual DateTime? APPLDATED
        {
            get;
            set;
        }

        /// <summary>
        ///审批状态
        ///0=未审批 1=审批通过 2=审批不通过
        ///3=已办理票务 4=行程关闭 5=行程取消
        /// </summary>
        public virtual int? BSTATE
        {
            get;
            set;
        }

        /// <summary>
        ///接送方式
        /// </summary>
        public virtual string TRANSFER
        {
            get;
            set;
        }

        /// <summary>
        /// 表单语言类型
        /// </summary>
        public virtual string BLANG
        {
            get;
            set;
        }

        #endregion
    }

}
