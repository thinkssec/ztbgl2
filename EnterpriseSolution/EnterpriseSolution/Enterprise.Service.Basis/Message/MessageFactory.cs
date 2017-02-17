using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model.Basis.Message;

namespace Enterprise.Service.Basis.Message
{
    /// <summary>
    /// 消息服务实例工厂
    /// </summary>
    public class MessageFactory
    {

        /// <summary>
        /// 创建消息服务
        /// </summary>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static IMService Creator(MessageType msgType)
        {
            IMService messageSrv = null;
            switch (msgType)
            {
                case MessageType.即时消息:
                    messageSrv = new MsgService();
                    break;
                case MessageType.手机短信:
                    messageSrv = new SmsService();
                    break;
                case MessageType.电子邮件:
                    messageSrv = new EmailService();
                    break;
                default:
                    break;
            }
            return messageSrv;
        }
        
    }
}
