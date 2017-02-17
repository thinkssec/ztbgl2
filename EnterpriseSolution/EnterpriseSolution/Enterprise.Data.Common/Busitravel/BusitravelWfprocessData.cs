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
    /// �ļ���:  BusitravelWfprocessData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-25 8:12:13
    /// </summary>
    public class BusitravelWfprocessData : IBusitravelWfprocessData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BusitravelWfprocessData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelWfprocessModel> GetList()
        {
            IList<BusitravelWfprocessModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelWfprocessModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelWfprocessData> db = new ORMDataAccess<BusitravelWfprocessData>())
                {
                    list = db.Query<BusitravelWfprocessModel>("from BusitravelWfprocessModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelWfprocessData), false);
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
        public IList<BusitravelWfprocessModel> GetList(string hql)
        {
            IList<BusitravelWfprocessModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelWfprocessModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelWfprocessData> db = new ORMDataAccess<BusitravelWfprocessData>())
                {
                     if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BusitravelWfprocessModel>("from BusitravelWfprocessModel");
                    }
                    else
					{
						list = db.Query<BusitravelWfprocessModel>(hql);
					}

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelWfprocessData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
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
        public bool Execute(BusitravelWfprocessModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BusitravelWfprocessData> db = new ORMDataAccess<BusitravelWfprocessData>())
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
    }
}
