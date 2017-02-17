using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model.Basis.Sys;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目组成员表
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-5 15:48:20
    /// </summary>
    [Serializable]
    public class ProjectMemberModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///项目组成员表ID
        /// </summary>
        public virtual string MEMBERID
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
        ///任务比例
        /// </summary>
        public virtual int? TASKSCALE
        {
            get;
            set;
        }

        /// <summary>
        ///用户ID
        /// </summary>
        public virtual int USERID
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
        ///岗位状态：0=离岗 1=在岗 2=待岗
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

        #region 外键关联

        /// <summary>
        /// 关联用户MODEL
        /// </summary>
        public virtual SysUserModel UserModel
        {
            get;
            set;
        }

        /// <summary>
        /// 关联项目MODEL
        /// </summary>
        public virtual ProjectInfoModel ProjectModel
        { get; set; }

        #endregion

       
    }

    /// <summary>
    /// 项目组成员角色
    /// </summary>
    public enum PM_ROLENAME
    {
        项目负责人,
        技术负责人,
        设计审查负责人,
        检验工程师,
        设备管理员,
        检验员,
        安全员,
        审图员,
        资料员,
        司机
    }

}
