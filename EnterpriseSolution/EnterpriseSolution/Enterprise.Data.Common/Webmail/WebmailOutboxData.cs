using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Data.Common.Webmail
{

    /// <summary>
    /// �ļ���:  WebmailOutboxData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/18 9:28:03
    /// </summary>
    public class WebmailOutboxData : IWebmailOutboxData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(WebmailOutboxData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetList()
        {
            IList<WebmailOutboxModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<WebmailOutboxModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailOutboxData> db = new ORMDataAccess<WebmailOutboxData>())
                {
                    list = db.Query<WebmailOutboxModel>("from WebmailOutboxModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(WebmailOutboxData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailOutboxModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<WebmailOutboxData> db = new ORMDataAccess<WebmailOutboxData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(model);
                }
                else if (model.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(model);
                }
                else if (model.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(model);
                }
            }

            //�����صĻ���
            CacheHelper.RemoveCacheForClassKey(cacheClassKey);

            return isResult;
        }


        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetList(string hql)
        {
            IList<WebmailOutboxModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailOutboxData> db = new ORMDataAccess<WebmailOutboxData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<WebmailOutboxModel>("from WebmailOutboxModel");
                    }
                    else
                    {
                        list = db.Query<WebmailOutboxModel>(hql);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// �����������ƻ�ȡ���ݼ���
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetListByEmail(string email)
        {
            return GetList("from WebmailOutboxModel c where c.EMAIL='" + email + "' order by c.SENDTIME desc");
        }


        /// <summary>
        /// ����ɾ���ʼ�
        /// </summary>
        /// <param name="messageIds"></param>
        public void Delete(List<string> messageIds)
        {
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                db.ExecuteNonQuery("delete from common_webmail_outbox where messageid in " + messageIds.ToInSQLString(), null);
            }
        }

        /// <summary>
        /// �����ط��ʼ�
        /// </summary>
        /// <param name="Ids"></param>
        public void ReSend(List<string> messageIds)
        {
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                db.ExecuteNonQuery("update common_webmail_outbox set SENDSUCCESS=-1 where messageid in " + messageIds.ToInSQLString(), null);
            }
        }

        /// <summary>
        /// ����ID��ȡ�ʼ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetListById(int id)
        {
            return GetList("from WebmailOutboxModel c where c.MESSAGEID=" + id);
        }
    }
}
