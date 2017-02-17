using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{

    /// <summary>
    /// �ļ���:  DocumentConvertData.cs
    /// ��������: ���ݲ�-�ĵ�ת�������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/3/6 8:25:00
    /// </summary>
    public class DocumentConvertData : IDocumentConvertData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(DocumentConvertData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetList()
        {
            IList<DocumentConvertModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<DocumentConvertModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentConvertData> db = new ORMDataAccess<DocumentConvertData>())
                {
                    list = db.Query<DocumentConvertModel>("from DocumentConvertModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(DocumentConvertData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
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
        public IList<DocumentConvertModel> GetListByHQL(string hql)
        {
            IList<DocumentConvertModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<DocumentConvertModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentConvertData> db = new ORMDataAccess<DocumentConvertData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<DocumentConvertModel>("from DocumentConvertModel");
                    }
                    else
                    {
                        list = db.Query<DocumentConvertModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    //    //���ݴ��뻺��ϵͳ
                    //    CacheItemRefreshAction refreshAction =
                    //        new CacheItemRefreshAction(typeof(DocumentConvertData), false);
                    //    refreshAction.ConstuctParms = null;
                    //    refreshAction.MethodName = "GetListByHQL";
                    //    refreshAction.Parameters = new object[] { hql };
                    //    CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    //}
                }
            }
            return list;
        }


        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetListBySQL(string sql)
        {
            IList<DocumentConvertModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<DocumentConvertModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentConvertData> db = new ORMDataAccess<DocumentConvertData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<DocumentConvertModel>(sql, typeof(DocumentConvertModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(DocumentConvertData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetListBySQL";
                            refreshAction.Parameters = new object[] { sql };
                            CacheHelper.Add(CacheClassKey + "_GetListBySQL_" + sql, list, refreshAction);
                        }
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
        public bool Execute(DocumentConvertModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<DocumentConvertData> db = new ORMDataAccess<DocumentConvertData>())
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
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
            }
            return isResult;
        }

        #endregion
    }
}
