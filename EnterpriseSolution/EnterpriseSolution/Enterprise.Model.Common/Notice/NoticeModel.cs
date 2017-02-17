using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Notice
{
    /// <summary>
    /// 角色表实体类
    /// </summary>
    [Serializable]
    public class NoticeModel:CommonSuperModel
    {

        /// <summary>
        /// 自动编号
        /// </summary>
        public virtual int NOTEID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string NTITLE { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public virtual string NREMARK { get; set; }

        /// <summary>
        /// 是否提醒 0不需要提醒 1需要提醒
        /// </summary>
        public virtual int NISREMIND { get; set; }

        /// <summary>
        /// 提醒人员
        /// </summary>
        public virtual string NREMINDUSERS { get; set; }

        /// <summary>
        /// 设置提醒时间
        /// </summary>
        public virtual DateTime NREMINDTIME { get; set; }

        /// <summary>
        /// 设置提醒方式
        /// 暂用于提醒标志：已提醒
        /// </summary>
        public virtual string NREMINDTYPE { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public virtual int NUSERID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime NCREATETIME { get; set; }

    }
}
