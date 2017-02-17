using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Manager
{
    /// <summary>
    /// 领导信箱实体类
    /// </summary>
    public class ManagerMsgModel:CommonSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///自动编号
        /// </summary>
        public virtual int MSGID
        {
            get;
            set;
        }

        /// <summary>
        ///留言标题
        /// </summary>
        public virtual string MSGTITLE
        {
            get;
            set;
        }

        /// <summary>
        ///是否匿名
        /// </summary>
        public virtual int? MSGISANONYMOUS
        {
            get;
            set;
        }

        /// <summary>
        ///是否可见
        /// </summary>
        public virtual int? MSGISSHOW
        {
            get;
            set;
        }

        /// <summary>
        ///留言时间
        /// </summary>
        public virtual DateTime? MSGCREATETIME
        {
            get;
            set;
        }

        /// <summary>
        ///留言人IP地址
        /// </summary>
        public virtual string MSGFIP
        {
            get;
            set;
        }

        /// <summary>
        ///留言人
        /// </summary>
        public virtual int MSGFUSER
        {
            get;
            set;
        }

        /// <summary>
        ///留言所给用户
        /// </summary>
        public virtual int MSGTUSER
        {
            get;
            set;
        }

        /// <summary>
        ///留言内容
        /// </summary>
        public virtual string MSGCONTENT
        {
            get;
            set;
        }

        #endregion
    }
}
