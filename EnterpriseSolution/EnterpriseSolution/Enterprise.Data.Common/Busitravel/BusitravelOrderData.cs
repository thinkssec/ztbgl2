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
    /// �ļ���:  BusitravelOrderData.cs
    /// ��������: ���ݲ�-�����������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-6-24 20:24:41
    /// </summary>
    public class BusitravelOrderData : IBusitravelOrderData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BusitravelOrderData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelOrderModel> GetList()
        {
            IList<BusitravelOrderModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<BusitravelOrderModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelOrderData> db = new ORMDataAccess<BusitravelOrderData>())
                {
                    list = db.Query<BusitravelOrderModel>("from BusitravelOrderModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(BusitravelOrderData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                    //}
                }
            }
            return list;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<BusitravelOrderModel> GetList(string hql)
        {
            IList<BusitravelOrderModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<BusitravelOrderModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelOrderData> db = new ORMDataAccess<BusitravelOrderData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BusitravelOrderModel>("from BusitravelOrderModel");
                    }
                    else
                    {
                        list = db.Query<BusitravelOrderModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(BusitravelOrderData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = new object[]{ hql };
                    //CacheHelper.Add(cacheClassKey + "_GetList_" + hql, list, refreshAction);
                    //}
                }
            }
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelOrderModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BusitravelOrderData> db = new ORMDataAccess<BusitravelOrderData>())
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
