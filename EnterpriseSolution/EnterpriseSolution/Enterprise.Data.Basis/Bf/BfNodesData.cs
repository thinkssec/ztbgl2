using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Bf;
using Enterprise.Component.Cache;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  BfNodesData.cs
    /// ��������: ���ݲ�-ҵ�����ڵ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:56
    /// </summary>
    public class BfNodesData : IBfNodesData
    {
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfNodesData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfNodesModel> GetList()
        {
            IList<BfNodesModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfNodesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfNodesData> db = new ORMDataAccess<BfNodesData>())
                {
                    list = db.Query<BfNodesModel>("from BfNodesModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfNodesData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
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
        public bool Execute(BfNodesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfNodesData> db = new ORMDataAccess<BfNodesData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(model);
                }
                else if (model.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(model);
                }
                else if (model.DB_Option_Action == WebKeys.InsertOrUpdateAction)
                {
                    db.InsertOrUpdate(model);
                }
                else if (model.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(model);
                }
                else if (model.DB_Option_Action == "DeleteByBF_ID_VERSION")
                {
                    IList<BfNodesModel> deleteList = GetList().
                        Where(p => p.BF_ID == model.BF_ID && p.BF_VERSION == model.BF_VERSION).ToList();
                    foreach (var q in deleteList)
                    {
                        db.Delete(q);
                    }
                }
            }

            if (WebKeys.EnableCaching)
            {
                //�����صĻ���
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
            }

            return isResult;
        }


        /// <summary>
        /// ����ҵ����ID�Ͱ汾�Ż�ȡ���нڵ���Ϣ����
        /// </summary>
        /// <param name="bf_id">ҵ����ID</param>
        /// <param name="bf_version">ҵ�����汾</param>
        /// <returns></returns>
        public IList<BfNodesModel> GetListById_Version(string bf_id, int bf_version)
        {
            IList<BfNodesModel> list = null;

            using (ORMDataAccess<BfNodesData> db = new ORMDataAccess<BfNodesData>())
            {
                list = db.Query<BfNodesModel>("from BfNodesModel c where c.BF_ID='" + bf_id + "' and c.BF_VERSION='" + bf_version + "'");
            }

            return list;
        }

    }
}
