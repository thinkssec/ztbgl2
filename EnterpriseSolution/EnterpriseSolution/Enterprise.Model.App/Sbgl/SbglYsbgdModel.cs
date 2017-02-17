using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Sbgl
{
    /// <summary>
    /// 设备维修项目验收报告单
    /// 创建人:代码生成器
    /// 创建时间:2015/4/28 15:01:25
    /// </summary>
    [Serializable]
    public class SbglYsbgdModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///验收报告单ID
        /// </summary>
        public virtual string BGDID
        {
            get;
            set;
        }

        /// <summary>
        ///验收报告批号
        /// </summary>
        public virtual string BGDPH
        {
            get;
            set;
        }

        /// <summary>
        /// 计划表ID
        /// </summary>
        public virtual string JHBID
        {
            get;
            set;
        }

        /// <summary>
        ///设备维修项目名称
        /// </summary>
        public virtual string WXXMMC
        {
            get;
            set;
        }

        /// <summary>
        ///车牌号码
        /// </summary>
        public virtual string CLPH
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
        ///计量单位
        /// </summary>
        public virtual string JLDW
        {
            get;
            set;
        }

        /// <summary>
        ///数量
        /// </summary>
        public virtual int? SL
        {
            get;
            set;
        }

        /// <summary>
        ///所在地点
        /// </summary>
        public virtual string SZDD
        {
            get;
            set;
        }

        /// <summary>
        ///维修工作量描述
        /// </summary>
        public virtual string GZLMS
        {
            get;
            set;
        }

        /// <summary>
        ///开工维修日期
        /// </summary>
        public virtual DateTime? KGRQ
        {
            get;
            set;
        }

        /// <summary>
        ///交付使用日期
        /// </summary>
        public virtual DateTime? JFRQ
        {
            get;
            set;
        }

        /// <summary>
        ///原值
        /// </summary>
        public virtual decimal? SBYZ
        {
            get;
            set;
        }

        /// <summary>
        ///单价
        /// </summary>
        public virtual decimal? SBDJ
        {
            get;
            set;
        }

        /// <summary>
        ///总价
        /// </summary>
        public virtual decimal? SBZJ
        {
            get;
            set;
        }

        /// <summary>
        ///验收意见及备注
        /// </summary>
        public virtual string YSYJBZ
        {
            get;
            set;
        }

        /// <summary>
        ///维修单位
        /// </summary>
        public virtual string WXDW
        {
            get;
            set;
        }

        /// <summary>
        ///审核状态
        /// </summary>
        public virtual int? SHZT
        {
            get;
            set;
        }

        /// <summary>
        ///验收附件
        /// </summary>
        public virtual string YSFJ
        {
            get;
            set;
        }

        #endregion

        #region 关联对象

        /// <summary>
        /// 维修计划表对象
        /// </summary>
        public virtual SbglWxjhbModel WxjhModel
        {
            get;
            set;
        }

        #endregion
    }

}
