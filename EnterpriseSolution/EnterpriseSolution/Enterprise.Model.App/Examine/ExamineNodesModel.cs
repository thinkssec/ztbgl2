using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// 检验流程节点表
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-5 15:48:10
    /// </summary>
    [Serializable]
    public class ExamineNodesModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///节点编码
        /// </summary>
        public virtual string NODECODE
        {
            get;
            set;
        }

        /// <summary>
        ///节点编号
        /// </summary>
        public virtual string NODEBH
        {
            get;
            set;
        }

        /// <summary>
        ///节点权值
        /// </summary>
        public virtual int? NODEVALUE
        {
            get;
            set;
        }

        /// <summary>
        ///是否关键节点
        /// </summary>
        public virtual int? KEYNODE
        {
            get;
            set;
        }

        /// <summary>
        ///节点名称
        /// </summary>
        public virtual string NODENAME
        {
            get;
            set;
        }

        /// <summary>
        ///动作参数
        /// </summary>
        public virtual string NODEPARAM
        {
            get;
            set;
        }

        /// <summary>
        ///添加日期
        /// </summary>
        public virtual DateTime? ADDDATE
        {
            get;
            set;
        }

        /// <summary>
        ///节点路径
        /// </summary>
        public virtual string NODEPATH
        {
            get;
            set;
        }

        /// <summary>
        ///检验类型ID
        /// </summary>
        public virtual int KINDID
        {
            get;
            set;
        }

        /// <summary>
        ///节点图标
        /// </summary>
        public virtual string NODEICON
        {
            get;
            set;
        }

        /// <summary>
        ///节点状态：0=不可见 1=可见 2=废弃
        /// </summary>
        public virtual int? NODESTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// WEB映射路径
        /// </summary>
        public virtual string WEBURL
        {
            get;
            set;
        }

        /// <summary>
        /// WEB路径参数
        /// </summary>
        public virtual string WEBPARAM
        {
            get;
            set;
        }

        #endregion
    }

}
