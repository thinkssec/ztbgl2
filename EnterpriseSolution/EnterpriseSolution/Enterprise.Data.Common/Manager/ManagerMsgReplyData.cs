using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Manager;

namespace Enterprise.Data.Common.Manager
{

    /// <summary>
    /// �ļ���:  ManagerMsgreplyData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/27 17:55:12
    /// </summary>
    public class ManagerMsgReplyData : IManagerMsgReplyData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ManagerMsgReplyData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgReplyModel> GetList()
        {
            IList<ManagerMsgReplyModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ManagerMsgreplyModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ManagerMsgReplyData> db = new ORMDataAccess<ManagerMsgReplyData>())
                {
                    list = db.Query<ManagerMsgReplyModel>("from ManagerMsgReplyModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ManagerMsgreplyData), true);
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
        public IList<ManagerMsgReplyModel> GetList(string hql)
        {
            IList<ManagerMsgReplyModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ManagerMsgReplyData> db = new ORMDataAccess<ManagerMsgReplyData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<ManagerMsgReplyModel>("from ManagerMsgReplyModel");
                    }
                    else
					{
                        list = db.Query<ManagerMsgReplyModel>(hql);
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
        public bool Execute(ManagerMsgReplyModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ManagerMsgReplyData> db = new ORMDataAccess<ManagerMsgReplyData>())
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
    }
}
