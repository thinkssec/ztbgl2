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
    /// �ļ���:  WebmailSettingsData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/18 9:28:04
    /// </summary>
    public class WebmailSettingsData : IWebmailSettingsData
    {
        #region '����������'
        /// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(WebmailSettingsData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<WebmailSettingsModel> GetList()
        {
            IList<WebmailSettingsModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<WebmailSettingsModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailSettingsData> db = new ORMDataAccess<WebmailSettingsData>())
                {
                    list = db.Query<WebmailSettingsModel>("from WebmailSettingsModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(WebmailSettingsData), true);
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
        public IList<WebmailSettingsModel> GetList(string hql)
        {
            IList<WebmailSettingsModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailSettingsData> db = new ORMDataAccess<WebmailSettingsData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<WebmailSettingsModel>("from WebmailSettingsModel");
                    }
                    else
                    {
                        list = db.Query<WebmailSettingsModel>(hql);
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
        public bool Execute(WebmailSettingsModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<WebmailSettingsData> db = new ORMDataAccess<WebmailSettingsData>())
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

        public IList<WebmailSettingsModel> GetListByUserId(int userId)
        {
            IList<WebmailSettingsModel> list = null;
            using (ORMDataAccess<WebmailSettingsData> db = new ORMDataAccess<WebmailSettingsData>())
            {
                list = db.Query<WebmailSettingsModel>("from WebmailSettingsModel c where c.USERID='" + userId + "'");
            }
            return list;
        }        
    }
}
