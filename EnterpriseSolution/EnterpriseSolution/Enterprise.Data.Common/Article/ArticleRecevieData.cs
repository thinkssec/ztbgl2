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
    /// �ļ���:  ArticleRecevieData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/28 10:54:45
    /// </summary>
    public class ArticleRecevieData : IArticleRecevieData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ArticleRecevieData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArticleRecevieModel> GetList()
        {
            IList<ArticleRecevieModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ArticleRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleRecevieData> db = new ORMDataAccess<ArticleRecevieData>())
                {
                    list = db.Query<ArticleRecevieModel>("from ArticleRecevieModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ArticleRecevieData), false);
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
        public IList<ArticleRecevieModel> GetList(string hql)
        {
            IList<ArticleRecevieModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ArticleRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleRecevieData> db = new ORMDataAccess<ArticleRecevieData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<ArticleRecevieModel>("from ArticleRecevieModel");
                    }
                    else
					{
						list = db.Query<ArticleRecevieModel>(hql);
					}

                     if (WebKeys.EnableCaching)
                     {
                         //���ݴ��뻺��ϵͳ
                         CacheItemRefreshAction refreshAction =
                             new CacheItemRefreshAction(typeof(ArticleRecevieData), false);
                         refreshAction.ConstuctParms = null;
                         refreshAction.MethodName = "GetList";
                         refreshAction.Parameters = new object[]{ hql };
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
        public bool Execute(ArticleRecevieModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ArticleRecevieData> db = new ORMDataAccess<ArticleRecevieData>())
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
