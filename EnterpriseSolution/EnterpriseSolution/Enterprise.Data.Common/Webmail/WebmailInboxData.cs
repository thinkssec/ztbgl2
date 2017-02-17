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
    /// �ļ���:  WebmailInboxData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/18 9:28:01
    /// </summary>
    public class WebmailInboxData : IWebmailInboxData
    {
        #region '����������'
        /// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(WebmailInboxData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetList()
        {
            IList<WebmailInboxModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<WebmailInboxModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
                {
                    list = db.Query<WebmailInboxModel>("from WebmailInboxModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(WebmailInboxData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetList(string hql)
        {
            IList<WebmailInboxModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<WebmailInboxModel>("from WebmailInboxModel");
                    }
                    else
                    {
                        list = db.Query<WebmailInboxModel>(hql);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailInboxModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
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

        #endregion

        #region '��չ����'
        /// <summary>
        /// ��ȡ�ռ����е�һ���ʼ�
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetListById(string Id)
        {
            IList<WebmailInboxModel> list = null;
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                list = db.Query<WebmailInboxModel>("from WebmailInboxModel c where c.MESSAGEID='" + Id + "'");
            }
            return list;
        }

        /// <summary>
        /// ��ȡ�ռ����е�һ���ʼ�
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetListByEmail(string email)
        {
            IList<WebmailInboxModel> list = null;
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                list = db.Query<WebmailInboxModel>("from WebmailInboxModel c where c.EMAIL='" + email + "'");
            }
            return list;
        }

        /// <summary>
        /// ɾ������ʼ�
        /// Sorry ����SQL��֪����ôд
        /// </summary>
        /// <param name="messageIds"></param>
        public void SetDelelted(List<string> messageIds)
        {
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                db.ExecuteNonQuery("update common_webmail_inbox set isdelete=1 where messageid in " + messageIds.ToInSQLString(), null);
            }
        }


        /// <summary>
        /// ������ʼ����Ϊ�Ѷ�
        /// </summary>
        /// <param name="messageIds"></param>
        public void SetReaded(List<string> messageIds)
        {
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                db.ExecuteNonQuery("update common_webmail_inbox set readed=1 where messageid in " + messageIds.ToInSQLString(), null);      
            }
        }

        #endregion


        /// <summary>
        /// �������ʼ�����֪ͨ���û�
        /// </summary>
        public void SendNoticeToUsers()
        {
            
        }
    }
}
