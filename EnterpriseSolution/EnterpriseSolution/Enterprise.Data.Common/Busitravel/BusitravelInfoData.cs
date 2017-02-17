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
    /// �ļ���:  BusitravelInfoData.cs
    /// ��������: ���ݲ�-������������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-23 17:52:25
    /// </summary>
    public class BusitravelInfoData : IBusitravelInfoData
    {
        #region ����������

		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BusitravelInfoData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelInfoModel> GetList()
        {
            IList<BusitravelInfoModel> list = null;

            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelInfoData> db = new ORMDataAccess<BusitravelInfoData>())
                {
                    list = db.Query<BusitravelInfoModel>("from BusitravelInfoModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelInfoData), false);
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
        public IList<BusitravelInfoModel> GetList(string hql)
        {
            IList<BusitravelInfoModel> list = null;

            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelInfoData> db = new ORMDataAccess<BusitravelInfoData>())
                {
                     if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BusitravelInfoModel>("from BusitravelInfoModel");
                    }
                    else
					{
						list = db.Query<BusitravelInfoModel>(hql);
					}

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelInfoData), false);
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
        public bool Execute(BusitravelInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BusitravelInfoData> db = new ORMDataAccess<BusitravelInfoData>())
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
        /// ��ȡָ��ID�Ĳ��ü�¼
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public BusitravelInfoModel GetModelById(string bid)
        {
            return GetList("from BusitravelInfoModel p where p.BID = '" + bid + "'").FirstOrDefault();
        }

        #endregion
    }
}
