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
    /// �ļ���:  OfficeDocumentData.cs
    /// ��������: ���ݲ�-������ת�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-27 21:01:29
    /// </summary>
    public class OfficeDocumentData : IOfficeDocumentData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(OfficeDocumentData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<OfficeDocumentModel> GetList()
        {
            IList<OfficeDocumentModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<OfficeDocumentModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<OfficeDocumentData> db = new ORMDataAccess<OfficeDocumentData>())
                {
                    list = db.Query<OfficeDocumentModel>("from OfficeDocumentModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(OfficeDocumentData), false);
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
        public IList<OfficeDocumentModel> GetList(string hql)
        {
            IList<OfficeDocumentModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<OfficeDocumentModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<OfficeDocumentData> db = new ORMDataAccess<OfficeDocumentData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<OfficeDocumentModel>("from OfficeDocumentModel");
                    }
                    else
                    {
                        list = db.Query<OfficeDocumentModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(OfficeDocumentData), false);
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
        public OfficeDocumentModel GetModelById(string id)
        {
            return GetList("from OfficeDocumentModel p where p.ODID = '" + id + "'").FirstOrDefault();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(OfficeDocumentModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<OfficeDocumentData> db = new ORMDataAccess<OfficeDocumentData>())
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
