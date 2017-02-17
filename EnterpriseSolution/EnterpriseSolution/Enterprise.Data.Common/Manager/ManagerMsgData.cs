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
    /// �ļ���:  ManagerMsgData.cs
    /// ��������: ���ݲ�-�쵼�������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/27 17:55:12
    /// </summary>
    public class ManagerMsgData : IManagerMsgData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ManagerMsgData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgModel> GetList()
        {
            IList<ManagerMsgModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ManagerMsgModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ManagerMsgData> db = new ORMDataAccess<ManagerMsgData>())
                {
                    list = db.Query<ManagerMsgModel>("from ManagerMsgModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ManagerMsgData), true);
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
        public IList<ManagerMsgModel> GetList(string hql)
        {
            IList<ManagerMsgModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ManagerMsgData> db = new ORMDataAccess<ManagerMsgData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<ManagerMsgModel>("from ManagerMsgModel");
                    }
                    else
					{
						list = db.Query<ManagerMsgModel>(hql);
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
        public bool Execute(ManagerMsgModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ManagerMsgData> db = new ORMDataAccess<ManagerMsgData>())
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
