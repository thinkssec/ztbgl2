using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 业务流未处理消息表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:58
    /// </summary>
    [Serializable]
    public class BfUnhandledmsgModel : BasisSuperModel
    {

        #region 代码生成器

        /// <summary>
        ///消息ID
        /// </summary>
        public virtual string BF_MSGID
        {
            get;
            set;
        }

        /// <summary>
        ///发送人登录名
        /// </summary>
        public virtual string BF_SENDERNAME
        {
            get;
            set;
        }

        /// <summary>
        ///结果说明
        /// </summary>
        public virtual string BF_REMARK
        {
            get;
            set;
        }

        /// <summary>
        ///运行表ID
        /// </summary>
        public virtual string BF_RUNID
        {
            get;
            set;
        }

        /// <summary>
        ///消息标题
        /// </summary>
        public virtual string BF_MSGTITLE
        {
            get;
            set;
        }

        /// <summary>
        ///接收人登录名
        /// </summary>
        public virtual string BF_RECIPIENTSNAME
        {
            get;
            set;
        }

        /// <summary>
        ///接收人
        /// </summary>
        public virtual int? BF_RECIPIENTS
        {
            get;
            set;
        }

        /// <summary>
        ///发送人
        /// </summary>
        public virtual int? BF_SENDER
        {
            get;
            set;
        }

        /// <summary>
        ///处理日期
        /// </summary>
        public virtual DateTime? BF_DEALTIME
        {
            get;
            set;
        }

        /// <summary>
        ///实例角色表ID
        /// </summary>
        public virtual string BF_INSTANCEROLEID
        {
            get;
            set;
        }

        /// <summary>
        ///消息内容
        /// </summary>
        public virtual string BF_MSGTEXT
        {
            get;
            set;
        }

        /// <summary>
        ///读取标志:0=未读 1=已读 -1=用户已清理
        /// </summary>
        public virtual int? BF_ISREAD
        {
            get;
            set;
        }

        /// <summary>
        ///处理结果
        /// </summary>
        public virtual int? BF_RESULT
        {
            get;
            set;
        }

        /// <summary>
        ///业务流关联表ID
        /// </summary>
        public virtual string BF_INSTANCEID
        {
            get;
            set;
        }

        /// <summary>
        ///发送日期
        /// </summary>
        public virtual DateTime? BF_SENDTIME
        {
            get;
            set;
        }

        #endregion	

    }

}
