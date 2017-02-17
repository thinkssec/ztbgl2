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
    /// 文件名:  ArticleRecevieData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/28 10:54:45
    /// </summary>
    public class ArticleRecevieData : IArticleRecevieData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ArticleRecevieData).ToString();

        /// <summary>
        /// 获取数据集合
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
                        //数据存入缓存系统
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
        /// 根据条件返回数据集合
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
                         //数据存入缓存系统
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
        /// 执行添加、修改、删除操作
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
                //清空相关的缓存
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
            }

            return isResult;
        }

        #endregion
    }
}
