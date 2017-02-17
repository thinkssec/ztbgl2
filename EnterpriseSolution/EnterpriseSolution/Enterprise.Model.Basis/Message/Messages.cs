using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Message
{
    /// <summary>
    /// 消息类
    /// 创建人: 乔巍
    /// 创建时间: 2013-11-4
    /// </summary>
    [Serializable]
    public class Messages
    {

        #region 属性


        /// <summary>
        ///ID
        /// </summary>
        public string MSG_ID
        {
            get;
            set;
        }

        /// <summary>
        ///关联对象ID
        /// </summary>
        public string MSG_OBJECTID
        {
            get;
            set;
        }

        /// <summary>
        ///消息标题
        /// </summary>
        public string MSG_TITLE
        {
            get;
            set;
        }

        /// <summary>
        ///消息内容
        /// </summary>
        public string MSG_TEXT
        {
            get;
            set;
        }

        /// <summary>
        ///接收者
        ///即时消息：mujianrong
        ///电子邮件：abc@abc.com
        ///手机短信：13888888888
        /// </summary>
        public string MSG_RECEIVER
        {
            get;
            set;
        }

        /// <summary>
        ///发送者
        /// </summary>
        public string MSG_SENDER
        {
            get;
            set;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType MSG_TYPE
        {
            get;
            set;
        }

        /// <summary>
        ///消息状态
        /// </summary>
        public MessageStatus MSG_STATUS
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        即时消息 = 0,
        手机短信 = 1,
        电子邮件 = 2
    }

    /// <summary>
    /// 消息状态
    /// </summary>
    public enum MessageStatus
    {
        已发送 = 1,
        未发送 = 0,
        已失败 = -1,
        已读取 = 2,
        未读取 = -2
    }

}
