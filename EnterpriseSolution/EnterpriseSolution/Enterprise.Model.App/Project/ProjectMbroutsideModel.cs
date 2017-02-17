using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 外雇员工表
    /// 创建人:代码生成器
    /// 创建时间:	2014/6/19 15:35:18
    /// </summary>
    [Serializable]
    public class ProjectMbroutsideModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///外雇成员表ID
        /// </summary>
        public virtual string MBROUTID
        {
            get;
            set;
        }

        /// <summary>
        ///工作任务
        /// </summary>
        public virtual string PROJTASK
        {
            get;
            set;
        }

        /// <summary>
        ///上岗时间
        /// </summary>
        public virtual DateTime? POSTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///岗位角色
        /// </summary>
        public virtual string POSTROLE
        {
            get;
            set;
        }

        /// <summary>
        ///人员姓名
        /// </summary>
        public virtual string USERNAME
        {
            get;
            set;
        }

        /// <summary>
        ///任务比例
        /// </summary>
        public virtual int? TASKSCALE
        {
            get;
            set;
        }

        /// <summary>
        ///离岗时间
        /// </summary>
        public virtual DateTime? OFFPOSTDATE
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
        ///岗位状态
        /// </summary>
        public virtual int? POSTSTATUS
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

        #region 自定义属性

        /// <summary>
        ///项目组成员表ID
        /// </summary>
        public virtual string MEMBERID
        {
            get 
            { 
                return MBROUTID; 
            }
        }

        #endregion
    }

}
