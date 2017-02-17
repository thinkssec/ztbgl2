using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目人员动态表
    /// 创建人:代码生成器
    /// 创建时间:	2014/6/19 15:35:17
    /// </summary>
    [Serializable]
    public class ProjectMbrattendanceModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///人员动态ID
        /// </summary>
        public virtual string ID
        {
            get;
            set;
        }

        /// <summary>
        ///记录日期
        /// </summary>
        public virtual DateTime? JLRQ
        {
            get;
            set;
        }

        /// <summary>
        ///-1=上岗 0=出勤 1=调离 2=出差 3=请假
        /// </summary>
        public virtual int? RYDT
        {
            get;
            set;
        }

        /// <summary>
        ///情况说明
        /// </summary>
        public virtual string MEMO
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
        ///项目组成员表ID
        /// </summary>
        public virtual string MEMBERID
        {
            get;
            set;
        }

        /// <summary>
        ///成员姓名
        /// </summary>
        public virtual string MBRNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 成员性质
        /// 职工,辅助
        /// </summary>
        public virtual string MBRPROPERTY
        {
            get;
            set;
        }

        #endregion

    }

}
