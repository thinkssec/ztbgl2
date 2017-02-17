using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model.Basis.Message;
using Enterprise.Data.Basis.Exc;
using Enterprise.Model.Basis.Exc;
using Enterprise.Component.Infrastructure;

namespace Enterprise.Service.Basis.Message
{

    /// <summary>
    /// 手机短信消息服务
    /// </summary>
    public class SmsService : IMService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExcSmsData dal = new ExcSmsData();

        #region 接口实现部分

        /// <summary>
        /// 获取指定类型的所有消息
        /// </summary>
        /// <param name="msgType">类型</param>
        /// <returns></returns>
        public IList<Messages> GetMessagesByType(MessageType msgType)
        {
            throw new NotImplementedException("未实现GetMessagesByType方法!");
        }

        /// <summary>
        /// 获取提定类型下对应ID的消息实体
        /// </summary>
        /// <param name="msgId">ID</param>
        /// <param name="msgType">类型</param>
        /// <returns></returns>
        public Messages GetMessageByID(string msgId, MessageType msgType)
        {
            Messages model = null;
            ExcSmsModel eM = dal.GetModelById(msgId);
            if (eM != null)
            {
                model = new Messages();
                model.MSG_ID = eM.EXC_SMSID;
                model.MSG_OBJECTID = eM.EXC_OBJECTID;
                model.MSG_RECEIVER = eM.EXC_RECEIVENUM;
                model.MSG_SENDER = eM.EXC_SENDER;
                model.MSG_TYPE = msgType;
                model.MSG_STATUS = (MessageStatus)Enum.Parse(typeof(MessageStatus), eM.EXC_SENDSTATUS);
                model.MSG_TITLE = "短信";
                model.MSG_TEXT = eM.EXC_MSGTEXT;
            }
            return model;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool SendMessage(Messages model)
        {
            ExcSmsModel eM = new ExcSmsModel();

            eM.DB_Option_Action = WebKeys.InsertAction;
            eM.EXC_SMSID = model.MSG_ID;
            eM.EXC_OBJECTID = model.MSG_OBJECTID;
            eM.EXC_RECEIVENUM = model.MSG_RECEIVER;
            eM.EXC_SENDSTATUS = MessageStatus.未发送.ToString();//model.MSG_STATUS.ToString();
            eM.EXC_SENDTIME = DateTime.Now;
            eM.EXC_MSGTEXT = model.MSG_TEXT;

            return dal.Execute(eM);
        }

        /// <summary>
        /// 清除消息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool DeleteMessage(Messages model)
        {
            ExcSmsModel eM = dal.GetModelById(model.MSG_ID);
            if (eM != null)
            {
                eM.DB_Option_Action = WebKeys.DeleteAction;
            }
            return dal.Execute(eM);
        }

        #endregion

        #region 专有部分


        #endregion
    }

}
