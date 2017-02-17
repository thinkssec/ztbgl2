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
    /// �ļ���:  WebmailInboxerrorData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/18 9:28:02
    /// </summary>
    public class WebmailInboxerrorData : IWebmailInboxerrorData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(WebmailInboxerrorData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<WebmailInboxerrorModel> GetList()
        {
            IList<WebmailInboxerrorModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<WebmailInboxerrorModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailInboxerrorData> db = new ORMDataAccess<WebmailInboxerrorData>())
                {
                    list = db.Query<WebmailInboxerrorModel>("from WebmailInboxerrorModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(WebmailInboxerrorData), true);
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
        public bool Execute(WebmailInboxerrorModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<WebmailInboxerrorData> db = new ORMDataAccess<WebmailInboxerrorData>())
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
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <param name="hql"></param>
        /// <returns></returns>
        public IList<WebmailInboxerrorModel> GetList(string hql)
        {
            IList<WebmailInboxerrorModel> list = null;

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailInboxerrorData> db = new ORMDataAccess<WebmailInboxerrorData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<WebmailInboxerrorModel>("from WebmailInboxerrorModel");
                    }
                    else
                    {
                        list = db.Query<WebmailInboxerrorModel>(hql);
                    }
                }
            }
            return list;
        }
    }
}
