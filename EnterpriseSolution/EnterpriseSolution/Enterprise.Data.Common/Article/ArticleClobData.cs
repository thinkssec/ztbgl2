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
    /// 文件名:  ArticleClobData.cs
    /// 功能描述: 数据层-大文本内容表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2014/2/7 13:50:48
    /// </summary>
    public class ArticleClobData : IArticleClobData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ArticleClobData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ArticleClobModel> GetList()
        {
            IList<ArticleClobModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ArticleClobModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleClobData> db = new ORMDataAccess<ArticleClobData>())
                {
                    list = db.Query<ArticleClobModel>("from ArticleClobModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ArticleClobData), false);
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
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="hql">Nhibernate HQL,如果hql为空 返回所有数据</param>
        /// <returns></returns>
        public IList<ArticleClobModel> GetList(string hql)
        {
            return GetListByHQL(hql);
        }

        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<ArticleClobModel> GetListByHQL(string hql)
        {
            IList<ArticleClobModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ArticleClobModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleClobData> db = new ORMDataAccess<ArticleClobData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ArticleClobModel>("from ArticleClobModel");
                    }
                    else
                    {
                        list = db.Query<ArticleClobModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ArticleClobData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetListByHQL";
                    //refreshAction.Parameters = new object[]{ hql };
                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    //}
                }
            }
            return list;
        }


        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ArticleClobModel> GetListBySQL(string sql)
        {
            IList<ArticleClobModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ArticleClobModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ArticleClobData> db = new ORMDataAccess<ArticleClobData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ArticleClobModel>(sql, typeof(ArticleClobModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ArticleClobData), false);
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
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ArticleClobModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ArticleClobData> db = new ORMDataAccess<ArticleClobData>())
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
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
            }
            return isResult;
        }

        #endregion
    }
}
