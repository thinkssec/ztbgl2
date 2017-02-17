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
    /// �ļ���:  ArticleInfoData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/28 10:54:44
    /// </summary>
    public class ArticleInfoData : IArticleInfoData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ArticleInfoData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArticleInfoModel> GetList()
        {
            IList<ArticleInfoModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ArticleInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleInfoData> db = new ORMDataAccess<ArticleInfoData>())
                {
                    list = db.Query<ArticleInfoModel>("from ArticleInfoModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ArticleInfoData), false);
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
        public IList<ArticleInfoModel> GetList(string hql)
        {
            IList<ArticleInfoModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ArticleInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleInfoData> db = new ORMDataAccess<ArticleInfoData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<ArticleInfoModel>("from ArticleInfoModel");
                    }
                    else
					{
						list = db.Query<ArticleInfoModel>(hql);
					}

                     if (WebKeys.EnableCaching)
                     {
                         //���ݴ��뻺��ϵͳ
                         CacheItemRefreshAction refreshAction =
                             new CacheItemRefreshAction(typeof(ArticleInfoData), false);
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
        public bool Execute(ArticleInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ArticleInfoData> db = new ORMDataAccess<ArticleInfoData>())
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
