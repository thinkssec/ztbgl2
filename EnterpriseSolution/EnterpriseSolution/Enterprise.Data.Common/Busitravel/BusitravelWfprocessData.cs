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
    /// 文件名:  BusitravelWfprocessData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-25 8:12:13
    /// </summary>
    public class BusitravelWfprocessData : IBusitravelWfprocessData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BusitravelWfprocessData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelWfprocessModel> GetList()
        {
            IList<BusitravelWfprocessModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelWfprocessModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelWfprocessData> db = new ORMDataAccess<BusitravelWfprocessData>())
                {
                    list = db.Query<BusitravelWfprocessModel>("from BusitravelWfprocessModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelWfprocessData), false);
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
        public IList<BusitravelWfprocessModel> GetList(string hql)
        {
            IList<BusitravelWfprocessModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelWfprocessModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelWfprocessData> db = new ORMDataAccess<BusitravelWfprocessData>())
                {
                     if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BusitravelWfprocessModel>("from BusitravelWfprocessModel");
                    }
                    else
					{
						list = db.Query<BusitravelWfprocessModel>(hql);
					}

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelWfprocessData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
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
        public bool Execute(BusitravelWfprocessModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BusitravelWfprocessData> db = new ORMDataAccess<BusitravelWfprocessData>())
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
