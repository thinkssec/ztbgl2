using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model.Basis.Message;
using Enterprise.Data.Basis.Exc;
using Enterprise.Model.Basis.Exc;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Rtx;

namespace Enterprise.Service.Basis.Message
{
    /// <summary>
    /// 即时消息服务
    /// </summary>
    public class MsgService : IMService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExcMessageData dal = new ExcMessageData();

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
            ExcMessageModel eM = dal.GetModelById(msgId);
            if (eM != null)
            {
                model = new Messages();
                model.MSG_ID = eM.EXC_MSGID;
                model.MSG_OBJECTID = eM.EXC_OBJECTID;
                model.MSG_RECEIVER = eM.EXC_MSGRECEIVER;
                model.MSG_TYPE = msgType;
                model.MSG_STATUS = (MessageStatus)Enum.Parse(typeof(MessageStatus), eM.EXC_SENDSTATUS);
                model.MSG_TITLE = eM.EXC_MSGTITLE;
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
            ExcMessageModel eM = new ExcMessageModel();

            eM.DB_Option_Action = WebKeys.InsertAction;
            eM.EXC_MSGID = model.MSG_ID;
            eM.EXC_OBJECTID = model.MSG_OBJECTID;
            eM.EXC_MSGRECEIVER = model.MSG_RECEIVER;
            eM.EXC_SENDSTATUS = MessageStatus.未发送.ToString(); //model.MSG_STATUS.ToString();
            eM.EXC_SENDTIME = DateTime.Now;
            eM.EXC_MSGTITLE = model.MSG_TITLE;
            eM.EXC_MSGTEXT = model.MSG_TEXT;

            //add by qw 2013.11.8 start 此处直接先发送RTX消息
            RtxService.SendRtxMessageByLoginName(model.MSG_RECEIVER, model.MSG_TITLE, model.MSG_TEXT);
            //end

            return dal.Execute(eM);
        }

        /// <summary>
        /// 清除消息
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool DeleteMessage(Messages model)
        {
            ExcMessageModel eM = dal.GetModelById(model.MSG_ID);
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
