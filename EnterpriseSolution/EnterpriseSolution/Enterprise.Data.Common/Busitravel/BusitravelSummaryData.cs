using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Data.Common.Busitravel
{

    /// <summary>
    /// 文件名:  BusitravelSummaryData.cs
    /// 功能描述: 数据层-出差情况汇总表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2013-6-24 20:24:42
    /// </summary>
    public class BusitravelSummaryData : IBusitravelSummaryData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BusitravelSummaryData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelSummaryModel> GetList()
        {
            IList<BusitravelSummaryModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelSummaryModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelSummaryData> db = new ORMDataAccess<BusitravelSummaryData>())
                {
                    list = db.Query<BusitravelSummaryModel>("from BusitravelSummaryModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelSummaryData), false);
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
        public IList<BusitravelSummaryModel> GetList(string hql)
        {
            IList<BusitravelSummaryModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelSummaryModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelSummaryData> db = new ORMDataAccess<BusitravelSummaryData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BusitravelSummaryModel>("from BusitravelSummaryModel");
                    }
                    else
                    {
                        list = db.Query<BusitravelSummaryModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelSummaryData), false);
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
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelSummaryModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BusitravelSummaryData> db = new ORMDataAccess<BusitravelSummaryData>())
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


        #region 出差统计

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<BusitravelSummaryModel> GetListBySQL(string sql)
        {
            IList<BusitravelSummaryModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelSummaryModel>)CacheHelper.GetCache(cacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelSummaryData> db = new ORMDataAccess<BusitravelSummaryData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<BusitravelSummaryModel>(sql, typeof(BusitravelSummaryModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BusitravelSummaryData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetListBySQL";
                            refreshAction.Parameters = new object[] { sql };
                            CacheHelper.Add(cacheClassKey + "_GetListBySQL_" + sql, list, refreshAction);
                        }
                    }
                }
            }
            return list;
        }

        #endregion
    }
}
