using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Sbgl
{
    /// <summary>
    /// 设备基础台账表
    /// 创建人:代码生成器
    /// 创建时间:2015/4/28 15:01:25
    /// </summary>
    [Serializable]
    public class SbglTzModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///设备自编号
        /// </summary>
        public virtual string SBBH
        {
            get;
            set;
        }

        /// <summary>
        ///设备名称
        /// </summary>
        public virtual string SBMC
        {
            get;
            set;
        }

        /// <summary>
        ///设备类型
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
        public virtual string CLPH
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
        /// 安装地点
        /// </summary>
        public virtual string AZDD
        {
            get;
            set;
        }

        /// <summary>
        ///出厂日期
        /// </summary>
        public virtual DateTime? CCRQ
        {
            get;
            set;
        }

        /// <summary>
        ///投用日期
        /// </summary>
        public virtual DateTime? TCRQ
        {
            get;
            set;
        }

        /// <summary>
        ///使用单位
        /// </summary>
        public virtual string SYDW
        {
            get;
            set;
        }

        /// <summary>
        ///保管人
        /// </summary>
        public virtual string BGR
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
        ///登记时间
        /// </summary>
        public virtual DateTime? DJSJ
        {
            get;
            set;
        }

        /// <summary>
        ///登记人
        /// </summary>
        public virtual string DJR
        {
            get;
            set;
        }

        /// <summary>
        /// 设备状态
        /// </summary>
        public virtual int? SBZT
        {
            get;
            set;
        }

        #endregion
    }

}
