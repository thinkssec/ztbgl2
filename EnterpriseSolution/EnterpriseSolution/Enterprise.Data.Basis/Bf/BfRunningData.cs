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
    /// �ļ���:  BfRunningData.cs
    /// ��������: ���ݲ�-ҵ�������б����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:57
    /// </summary>
    public class BfRunningData : IBfRunningData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfRunningData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfRunningModel> GetList()
        {
            IList<BfRunningModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfRunningModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfRunningData> db = new ORMDataAccess<BfRunningData>())
                {
                    list = db.Query<BfRunningModel>("from BfRunningModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfRunningData), true);
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
        /// ����ID���ز�ѯ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BfRunningModel GetModelById(string id)
        {
            BfRunningModel model = null;

            using (ORMDataAccess<BfRunningData> db = new ORMDataAccess<BfRunningData>())
            {
                model = db.Query<BfRunningModel>("from BfRunningModel p where p.BF_RUNID='" + id + "'").FirstOrDefault();
            }

            return model;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetList(string hql)
        {
            IList<BfRunningModel> list = null;

            if (WebKeys.EnableCaching)
            {
                list = (IList<BfRunningModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfRunningData> db = new ORMDataAccess<BfRunningData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BfRunningModel>("from BfRunningModel");
                    }
                    else
                    {
                        list = db.Query<BfRunningModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BfRunningData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = new object[] { hql };
                        CacheHelper.Add(cacheClassKey + "_GetList_" + hql, list, refreshAction);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// ����ʵ��ID�������ݼ���
        /// </summary>
        /// <param name="instanceId">ʵ��ID</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetListByInstanceId(string instanceId)
        {
            IList<BfRunningModel> list = null;

            if (WebKeys.EnableCaching)
            {
                list = (IList<BfRunningModel>)CacheHelper.GetCache(cacheClassKey + "_GetListByInstanceId_" + instanceId);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfRunningData> db = new ORMDataAccess<BfRunningData>())
                {
                    list = db.Query<BfRunningModel>("from BfRunningModel p where p.BF_INSTANCEID='" + instanceId + "'");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BfRunningData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetListByInstanceId";
                        refreshAction.Parameters = new object[] { instanceId };
                        CacheHelper.Add(cacheClassKey + "_GetListByInstanceId_" + instanceId, list, refreshAction);
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
        public bool Execute(BfRunningModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfRunningData> db = new ORMDataAccess<BfRunningData>())
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

            if (WebKeys.EnableCaching)
            {
                //�����صĻ���
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
            }

            return isResult;
        }

        /// <summary>
        /// ����������ѯ�������
        /// </summary>
        /// <param name="sql">ԭ��SQL</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetListBySQL(string sql)
        {
            IList<BfRunningModel> list = null;

            using (ORMDataAccess<BfRunningData> db = new ORMDataAccess<BfRunningData>())
            {
                list = db.QueryBySQL<BfRunningModel>(sql, typeof(BfRunningModel));
            }

            return list;
        }

    }
}
