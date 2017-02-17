using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Article;

namespace Enterprise.Data.Common.Article
{

    /// <summary>
    /// �ļ���:  ArticleDownloadData.cs
    /// ��������: ���ݲ�-�ĵ����ع������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-5-16 17:44:17
    /// </summary>
    public class ArticleDownloadData : IArticleDownloadData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ArticleDownloadData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArticleDownloadModel> GetList()
        {
            IList<ArticleDownloadModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ArticleDownloadModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleDownloadData> db = new ORMDataAccess<ArticleDownloadData>())
                {
                    list = db.Query<ArticleDownloadModel>("from ArticleDownloadModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ArticleDownloadData), false);
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
        public IList<ArticleDownloadModel> GetList(string hql)
        {
            IList<ArticleDownloadModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<ArticleDownloadModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleDownloadData> db = new ORMDataAccess<ArticleDownloadData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ArticleDownloadModel>("from ArticleDownloadModel");
                    }
                    else
                    {
                        list = db.Query<ArticleDownloadModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    //    //���ݴ��뻺��ϵͳ
                    //    CacheItemRefreshAction refreshAction =
                    //        new CacheItemRefreshAction(typeof(ArticleDownloadData), false);
                    //    refreshAction.ConstuctParms = null;
                    //    refreshAction.MethodName = "GetList";
                    //    refreshAction.Parameters = new object[] { hql };
                    //    CacheHelper.Add(cacheClassKey + "_GetList_" + hql, list, refreshAction);
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
        public bool Execute(ArticleDownloadModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ArticleDownloadData> db = new ORMDataAccess<ArticleDownloadData>())
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
