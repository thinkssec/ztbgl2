using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Data.Common.Busitravel
{

    /// <summary>
    /// �ļ���:  BusitravelSummaryData.cs
    /// ��������: ���ݲ�-����������ܱ����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-6-24 20:24:42
    /// </summary>
    public class BusitravelSummaryData : IBusitravelSummaryData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BusitravelSummaryData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelSummaryModel> GetList()
        {
            IList<BusitravelSummaryModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelSummaryModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelSummaryData> db = new ORMDataAccess<BusitravelSummaryData>())
                {
                    list = db.Query<BusitravelSummaryModel>("from BusitravelSummaryModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelSummaryData), false);
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
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<BusitravelSummaryModel> GetList(string hql)
        {
            IList<BusitravelSummaryModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelSummaryModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelSummaryData> db = new ORMDataAccess<BusitravelSummaryData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BusitravelSummaryModel>("from BusitravelSummaryModel");
                    }
                    else
                    {
                        list = db.Query<BusitravelSummaryModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelSummaryData), false);
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
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelSummaryModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BusitravelSummaryData> db = new ORMDataAccess<BusitravelSummaryData>())
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

        #endregion


        #region ����ͳ��

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<BusitravelSummaryModel> GetListBySQL(string sql)
        {
            IList<BusitravelSummaryModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelSummaryModel>)CacheHelper.GetCache(cacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelSummaryData> db = new ORMDataAccess<BusitravelSummaryData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<BusitravelSummaryModel>(sql, typeof(BusitravelSummaryModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BusitravelSummaryData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetListBySQL";
                            refreshAction.Parameters = new object[] { sql };
                            CacheHelper.Add(cacheClassKey + "_GetListBySQL_" + sql, list, refreshAction);
                        }
                    }
                }
            }
            return list;
        }

        #endregion
    }
}
