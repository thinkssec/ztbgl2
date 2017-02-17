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
    /// �ļ���:  BusitravelKzinfoData.cs
    /// ��������: ���ݲ�-�����������뵥���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-6-24 20:24:40
    /// </summary>
    public class BusitravelKzinfoData : IBusitravelKzinfoData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BusitravelKzinfoData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelKzinfoModel> GetList()
        {
            IList<BusitravelKzinfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<BusitravelKzinfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelKzinfoData> db = new ORMDataAccess<BusitravelKzinfoData>())
                {
                    list = db.Query<BusitravelKzinfoModel>("from BusitravelKzinfoModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(BusitravelKzinfoData), false);
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
        public IList<BusitravelKzinfoModel> GetList(string hql)
        {
            IList<BusitravelKzinfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<BusitravelKzinfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelKzinfoData> db = new ORMDataAccess<BusitravelKzinfoData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BusitravelKzinfoModel>("from BusitravelKzinfoModel");
                    }
                    else
                    {
                        list = db.Query<BusitravelKzinfoModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(BusitravelKzinfoData), false);
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
        /// ִ�����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelKzinfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BusitravelKzinfoData> db = new ORMDataAccess<BusitravelKzinfoData>())
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