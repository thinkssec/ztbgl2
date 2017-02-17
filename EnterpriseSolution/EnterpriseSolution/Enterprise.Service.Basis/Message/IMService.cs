using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model.Basis.Message;

namespace Enterprise.Service.Basis.Message
{

    /// <summary>
    /// 消息服务访问接口
    /// </summary>
    public interface IMService
    {
        
        /// <summary>
        /// 获取指定类型的所有消息
        /// </summary>
        /// <param name="msgType">类型</param>
        /// <returns></returns>
        IList<Messages> GetMessagesByType(MessageType msgType);

        /// <summary>
        /// 获取提定类型下对应ID的消息实体
        /// </summary>
        /// <param name="msgId">ID</param>
        /// <param name="msgType">类型</param>
        /// <returns></returns>
        Messages GetMessageByID(string msgId,MessageType msgType);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool SendMessage(Messages model);

        /// <summary>
        /// 清除消息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool DeleteMessage(Messages model);
        
    }
}
