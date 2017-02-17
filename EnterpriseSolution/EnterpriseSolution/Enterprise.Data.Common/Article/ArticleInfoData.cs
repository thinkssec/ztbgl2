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
    /// 文件名:  ArticleInfoData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/28 10:54:44
    /// </summary>
    public class ArticleInfoData : IArticleInfoData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ArticleInfoData).ToString();

        /// <summary>
        /// 获取数据集合
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
                        //数据存入缓存系统
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
        /// 根据条件返回数据集合
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
                         //数据存入缓存系统
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
        /// 执行添加、修改、删除操作
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
                //清空相关的缓存
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
            }

            return isResult;
        }

        #endregion
    }
}
