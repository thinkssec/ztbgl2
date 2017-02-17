using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 退审意见
    /// 创建人:代码生成器
    /// 创建时间:	2013/12/1 14:10:58
    /// </summary>
    [Serializable]
    public class ProjectFztsyjModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///退审ID
        /// </summary>
        public virtual string ID
        {
            get;
            set;
        }

        /// <summary>
        ///文档名称
        /// </summary>
        public virtual string WDMC
        {
            get;
            set;
        }

        /// <summary>
        ///审批人
        /// </summary>
        public virtual int? SPR
        {
            get;
            set;
        }

        /// <summary>
        ///登记日期
        /// </summary>
        public virtual DateTime? DJRQ
        {
            get;
            set;
        }

        /// <summary>
        ///设计单位
        /// </summary>
        public virtual string SJDW
        {
            get;
            set;
        }

        /// <summary>
        ///登记人
        /// </summary>
        public virtual int? DJR
        {
            get;
            set;
        }

        /// <summary>
        ///编号
        /// </summary>
        public virtual string BH
        {
            get;
            set;
        }

        /// <summary>
        ///文档类型
        /// </summary>
        public virtual string WDLX
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

        /// <summary>
        ///附件
        /// </summary>
        public virtual string FJ
        {
            get;
            set;
        }

        /// <summary>
        ///审核状态:0=未审核 1=审核通过 2=审核不通过 3=打印完成
        /// </summary>
        public virtual int? SHZT
        {
            get;
            set;
        }

        /// <summary>
        ///退审日期
        /// </summary>
        public virtual DateTime? TSRQ
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

        /// <summary>
        ///审核意见
        /// </summary>
        public virtual string SHYJ
        {
            get;
            set;
        }

        #endregion


        #region 关联对象

        /// <summary>
        /// 发证退审文件集合
        /// </summary>
        public virtual IList<ProjectFztswjModel> FztswjList
        {
            get;
            set;
        }

        #endregion
    }

}
