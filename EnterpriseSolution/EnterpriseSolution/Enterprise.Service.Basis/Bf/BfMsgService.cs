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
    /// �ļ���:  BfHandledmsgService.cs
    /// ��������: ҵ���߼���-ҵ������Ϣ�����ݴ���
    /// �����ˣ���Ρ
	/// ����ʱ�� ��2013-2-7
    /// </summary>
    public class BfMsgService
    {

        /// <summary>
        /// �õ��Ѵ�����Ϣ�����ݷ�����ʵ��
        /// </summary>
        //private static readonly IBfHandledmsgData handleDal = new BfHandledmsgData();
        /// <summary>
        /// �õ�δ������Ϣ�����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfUnhandledmsgData unhandleDal = new BfUnhandledmsgData();

        //#region �Ѵ�����Ϣ

        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //public IList<BfHandledmsgModel> GetHandleList()
        //{
        //    return handleDal.GetList();
        //}

        ///// <summary>
        ///// ִ����ӡ��޸ġ�ɾ������
        ///// </summary>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //public bool ExecuteHandle(BfHandledmsgModel model)
        //{
        //    return handleDal.Execute(model);
        //}

        //#endregion

        #region δ������Ϣ

        /// <summary>
        /// �����ͬ�Ĵ�����Ϣ
        /// </summary>
        /// <param name="receiveUserId">������</param>
        /// <param name="sender">������</param>
        /// <param name="title">����</param>
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
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfUnhandledmsgModel> GetUnhandleList()
        {
            return unhandleDal.GetList();
        }

        /// <summary>
        /// ��ȡ�����ѯ���������ݼ���
        /// </summary>
        /// <param name="hql">Hibernate��ѯ���</param>
        /// <returns></returns>
        public IList<BfUnhandledmsgModel> GetMsgLstByHQL(string hql)
        {
            return unhandleDal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteUnhandle(BfUnhandledmsgModel model)
        {
            return unhandleDal.Execute(model);
        }

        /// <summary>
        ///  ����IDֵ��ȡΨһ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BfUnhandledmsgModel GetModelById(string id)
        {
            return unhandleDal.GetModelById(id);
        }

        #endregion


        #region ��̬����

        /// <summary>
        /// ������Ϣ��״̬Ϊ��ɣ��Ѷ���
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
        /// ������Ϣ��״̬Ϊָ��״̬
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
        /// ������Ϣ��״̬Ϊ��ɣ��Ѷ���
        /// ���ͬһʵ��ID��������Ϣ
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
        /// ������Ϣ��״̬Ϊ��ɣ��Ѷ���
        /// ר����������Ʊ����Ա
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
