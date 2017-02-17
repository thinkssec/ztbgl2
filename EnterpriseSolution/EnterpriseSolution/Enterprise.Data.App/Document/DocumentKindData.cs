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
    /// �ļ���:  DocumentKindData.cs
    /// ��������: ���ݲ�-�ĵ���������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/3/6 8:25:02
    /// </summary>
    public class DocumentKindData : IDocumentKindData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(DocumentKindData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentKindModel> GetList()
        {
            IList<DocumentKindModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<DocumentKindModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentKindData> db = new ORMDataAccess<DocumentKindData>())
                {
                    list = db.Query<DocumentKindModel>("from DocumentKindModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(DocumentKindData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
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
        public IList<DocumentKindModel> GetListByHQL(string hql)
        {
            IList<DocumentKindModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<DocumentKindModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentKindData> db = new ORMDataAccess<DocumentKindData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<DocumentKindModel>("from DocumentKindModel");
                    }
                    else
                    {
                        list = db.Query<DocumentKindModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(DocumentKindData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetListByHQL";
                        refreshAction.Parameters = new object[] { hql };
                        CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentKindModel> GetListBySQL(string sql)
        {
            IList<DocumentKindModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<DocumentKindModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentKindData> db = new ORMDataAccess<DocumentKindData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<DocumentKindModel>(sql, typeof(DocumentKindModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(DocumentKindData), false);
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
        /// �������ݼ���
        /// ��˳������򣬲����ݲ㼶��ʾ
        /// </summary>
        /// <returns></returns>
        public IList<DocumentKindModel> GetTreeList()
        {
            IList<DocumentKindModel> treeList = null;
            if (WebKeys.EnableCaching)
            {
                treeList = (IList<DocumentKindModel>)CacheHelper.GetCache(CacheClassKey + "_GetTreeList");
            }
            if (treeList == null || treeList.Count == 0)
            {
                treeList = new List<DocumentKindModel>();
                IList<DocumentKindModel> list = GetList().OrderBy(p => p.LBXH).ToList();
                foreach (DocumentKindModel model in list)
                {
                    DocumentKindModel newM = (DocumentKindModel)CommonTool.Clone(model);
                    newM.LBMC = CommonTool.GenerateBlankSpace(newM.LBXH.Length - 2) + newM.LBMC;
                    treeList.Add(newM);
                }
                if (WebKeys.EnableCaching)
                {
                    //���ݴ��뻺��ϵͳ
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(DocumentKindModel), false);
                    refreshAction.ConstuctParms = null;
                    refreshAction.MethodName = "GetTreeList";
                    refreshAction.Parameters = null;//new object[]{};
                    CacheHelper.Add(CacheClassKey + "_GetTreeList", treeList, refreshAction);
                }
            }
            return treeList;
        }


        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocumentKindModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<DocumentKindData> db = new ORMDataAccess<DocumentKindData>())
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
