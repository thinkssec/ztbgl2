using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Sbgl
{
    /// <summary>
    /// 设备维修计划表
    /// 创建人:代码生成器
    /// 创建时间:2015/4/28 15:01:25
    /// </summary>
    [Serializable]
    public class SbglWxjhbModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///计划表ID
        /// </summary>
        public virtual string JHBID
        {
            get;
            set;
        }

        /// <summary>
        ///设备维修批号
        /// </summary>
        public virtual string SBWXPH
        {
            get;
            set;
        }

        /// <summary>
        ///使用单位
        /// </summary>
        public virtual string SBSYDW
        {
            get;
            set;
        }

        /// <summary>
        ///维修设备类型
        /// </summary>
        public virtual string SBLX
        {
            get;
            set;
        }

        /// <summary>
        ///规格型号
        /// </summary>
        public virtual string GGXH
        {
            get;
            set;
        }

        /// <summary>
        ///车辆牌号
        /// </summary>
        public virtual string CLXH
        {
            get;
            set;
        }

        /// <summary>
        ///自编号
        /// </summary>
        public virtual string SBBH
        {
            get;
            set;
        }

        /// <summary>
        ///设备原值
        /// </summary>
        public virtual decimal? SBYZ
        {
            get;
            set;
        }

        /// <summary>
        ///设备净值
        /// </summary>
        public virtual decimal? SBJZ
        {
            get;
            set;
        }

        /// <summary>
        ///安装地点
        /// </summary>
        public virtual string AZDD
        {
            get;
            set;
        }

        /// <summary>
        ///投产日期
        /// </summary>
        public virtual DateTime? TCRQ
        {
            get;
            set;
        }

        /// <summary>
        ///运行时间或行驶里程
        /// </summary>
        public virtual string YXSJLC
        {
            get;
            set;
        }

        /// <summary>
        ///上次修理日期
        /// </summary>
        public virtual DateTime? SCXLRQ
        {
            get;
            set;
        }

        /// <summary>
        ///预计送修日期
        /// </summary>
        public virtual DateTime? SXRQ
        {
            get;
            set;
        }

        /// <summary>
        ///维修内容
        /// </summary>
        public virtual string SBWXNR
        {
            get;
            set;
        }

        /// <summary>
        ///预计维修费用
        /// </summary>
        public virtual decimal? YJWXFY
        {
            get;
            set;
        }

        /// <summary>
        ///建议维修单位
        /// </summary>
        public virtual string JYWXDW
        {
            get;
            set;
        }

        /// <summary>
        ///维修申请状态
        /// </summary>
        public virtual int? SQZT
        {
            get;
            set;
        }

        /// <summary>
        ///填表人
        /// </summary>
        public virtual string TBR
        {
            get;
            set;
        }

        /// <summary>
        ///填表日期
        /// </summary>
        public virtual DateTime? TBRQ
        {
            get;
            set;
        }

        /// <summary>
        ///备注
        /// </summary>
        public virtual string BZ
        {
            get;
            set;
        }

        #endregion

        #region 自定义属性

        /// <summary>
        /// 送修的年份和月份
        /// </summary>
        public virtual string SXNY
        {
            get
            {
                return (SXRQ != null) ? SXRQ.Value.ToString("yyyy-MM") : "";
            }
        }

        #endregion

    }

}
