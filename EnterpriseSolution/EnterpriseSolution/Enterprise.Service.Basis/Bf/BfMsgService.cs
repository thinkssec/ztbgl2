using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
    /// <summary>
    /// 文件名:  BfHandledmsgService.cs
    /// 功能描述: 业务逻辑层-业务流消息表数据处理
    /// 创建人：乔巍
	/// 创建时间 ：2013-2-7
    /// </summary>
    public class BfMsgService
    {

        /// <summary>
        /// 得到已处理消息表数据访问类实例
        /// </summary>
        //private static readonly IBfHandledmsgData handleDal = new BfHandledmsgData();
        /// <summary>
        /// 得到未处理消息表数据访问类实例
        /// </summary>
        private static readonly IBfUnhandledmsgData unhandleDal = new BfUnhandledmsgData();

        //#region 已处理消息

        ///// <summary>
        ///// 获取数据集合
        ///// </summary>
        ///// <returns></returns>
        //public IList<BfHandledmsgModel> GetHandleList()
        //{
        //    return handleDal.GetList();
        //}

        ///// <summary>
        ///// 执行添加、修改、删除操作
        ///// </summary>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //public bool ExecuteHandle(BfHandledmsgModel model)
        //{
        //    return handleDal.Execute(model);
        //}

        //#endregion

        #region 未处理消息

        /// <summary>
        /// 清除相同的待办消息
        /// </summary>
        /// <param name="receiveUserId">接收人</param>
        /// <param name="sender">发送人</param>
        /// <param name="title">标题</param>
        /// <param name="msgText">URL</param>
        public void ClearUnhandleMsgIsSame(int receiveUserId, int sender, string title, string msgText)
        {
            string hql = string.Format(
                "from BfUnhandledmsgModel c where c.BF_RECIPIENTS='{0}' and c.BF_ISREAD='0' and c.BF_SENDER='{1}' and c.BF_MSGTEXT like '{2}%' and c.BF_MSGTITLE='{3}'",
                receiveUserId, sender, msgText, title);
            var list = GetMsgLstByHQL(hql);
            foreach (var q in list)
            {
                q.DB_Option_Action = WebKeys.DeleteAction;
                ExecuteUnhandle(q);
            }
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfUnhandledmsgModel> GetUnhandleList()
        {
            return unhandleDal.GetList();
        }

        /// <summary>
        /// 获取满足查询条件的数据集合
        /// </summary>
        /// <param name="hql">Hibernate查询语句</param>
        /// <returns></returns>
        public IList<BfUnhandledmsgModel> GetMsgLstByHQL(string hql)
        {
            return unhandleDal.GetListByHQL(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteUnhandle(BfUnhandledmsgModel model)
        {
            return unhandleDal.Execute(model);
        }

        /// <summary>
        ///  根据ID值获取唯一数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BfUnhandledmsgModel GetModelById(string id)
        {
            return unhandleDal.GetModelById(id);
        }

        #endregion


        #region 静态方法

        /// <summary>
        /// 更新消息的状态为完成（已读）
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public static bool UpdateMsgOver(string msgId) 
        {
            bool isOK = false;

            if (string.IsNullOrEmpty(msgId)) return false;

            BfMsgService msgSrv = new BfMsgService();
            BfUnhandledmsgModel msg = msgSrv.GetModelById(msgId);
            if (msg != null)
            {
                msg.BF_ISREAD = 1;
                msg.BF_DEALTIME = DateTime.Now;
                msg.DB_Option_Action = WebKeys.UpdateAction;
                isOK = msgSrv.ExecuteUnhandle(msg);
            }

            return isOK;
        }


        /// <summary>
        /// 更新消息的状态为指定状态
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public static bool UpdateMsgStatus(string msgId, int status)
        {
            bool isOK = false;

            if (string.IsNullOrEmpty(msgId)) return false;

            BfMsgService msgSrv = new BfMsgService();
            BfUnhandledmsgModel msg = msgSrv.GetModelById(msgId);
            if (msg != null)
            {
                msg.BF_ISREAD = status;
                msg.DB_Option_Action = WebKeys.UpdateAction;
                isOK = msgSrv.ExecuteUnhandle(msg);
            }

            return isOK;
        }


        /// <summary>
        /// 更新消息的状态为完成（已读）
        /// 针对同一实例ID的所有消息
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public static bool UpdateMsgOverForInstanceId(string instanceId)
        {
            bool isOK = false;

            if (string.IsNullOrEmpty(instanceId)) return false;

            BfMsgService msgSrv = new BfMsgService();
            string hql = "from BfUnhandledmsgModel p where p.BF_INSTANCEID='" + instanceId + "'";
            var query = msgSrv.GetMsgLstByHQL(hql);
            foreach (var q in query)
            {
                if (q != null && q.BF_ISREAD == 0)
                {
                    q.BF_ISREAD = 1;
                    q.BF_DEALTIME = DateTime.Now;
                    q.DB_Option_Action = WebKeys.UpdateAction;
                    isOK = msgSrv.ExecuteUnhandle(q);
                }
            }

            return isOK;
        }


        /// <summary>
        /// 更新消息的状态为完成（已读）
        /// 专用于行政部票务人员
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public static bool UpdateMsgOverForRecipient(string instanceId, int recUser)
        {
            bool isOK = false;

            if (string.IsNullOrEmpty(instanceId)) return false;

            BfMsgService msgSrv = new BfMsgService();
            BfUnhandledmsgModel msg = msgSrv.GetMsgLstByHQL("from BfUnhandledmsgModel p where p.BF_INSTANCEID='" 
                + instanceId + "' and p.BF_RECIPIENTS='" + recUser + "'").FirstOrDefault();
            if (msg != null)
            {
                msg.BF_ISREAD = 1;
                msg.BF_DEALTIME = DateTime.Now;
                msg.DB_Option_Action = WebKeys.UpdateAction;
                isOK = msgSrv.ExecuteUnhandle(msg);
            }

            return isOK;
        }

        #endregion

    }

}
