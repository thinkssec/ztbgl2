using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Office;

namespace Enterprise.Data.Common.Office
{

    /// <summary>
    /// �ļ���:  OfficeRecevieData.cs
    /// ��������: ���ݲ�-����ǩ�ռ�¼���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-27 21:01:29
    /// </summary>
    public class OfficeRecevieData : IOfficeRecevieData
    {
        #region ����������

		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(OfficeRecevieData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<OfficeRecevieModel> GetList()
        {
            IList<OfficeRecevieModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<OfficeRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<OfficeRecevieData> db = new ORMDataAccess<OfficeRecevieData>())
                {
                    list = db.Query<OfficeRecevieModel>("from OfficeRecevieModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(OfficeRecevieData), false);
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
        public IList<OfficeRecevieModel> GetList(string hql)
        {
            IList<OfficeRecevieModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<OfficeRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<OfficeRecevieData> db = new ORMDataAccess<OfficeRecevieData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<OfficeRecevieModel>("from OfficeRecevieModel");
                    }
                    else
                    {
                        list = db.Query<OfficeRecevieModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(OfficeRecevieData), false);
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
        ///  ����IDֵ��ȡΨһ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OfficeRecevieModel GetModelById(string id)
        {
            return GetList("from OfficeRecevieModel p where p.ORID = '" + id + "'").FirstOrDefault();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(OfficeRecevieModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<OfficeRecevieData> db = new ORMDataAccess<OfficeRecevieData>())
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
