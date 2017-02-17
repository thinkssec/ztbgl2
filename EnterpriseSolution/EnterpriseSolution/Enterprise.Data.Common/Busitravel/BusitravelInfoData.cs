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
    /// 文件名:  BusitravelInfoData.cs
    /// 功能描述: 数据层-差旅申请表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-23 17:52:25
    /// </summary>
    public class BusitravelInfoData : IBusitravelInfoData
    {
        #region 代码生成器

		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BusitravelInfoData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelInfoModel> GetList()
        {
            IList<BusitravelInfoModel> list = null;

            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelInfoData> db = new ORMDataAccess<BusitravelInfoData>())
                {
                    list = db.Query<BusitravelInfoModel>("from BusitravelInfoModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelInfoData), false);
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
        public IList<BusitravelInfoModel> GetList(string hql)
        {
            IList<BusitravelInfoModel> list = null;

            if (WebKeys.EnableCaching)
            {
                list = (IList<BusitravelInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BusitravelInfoData> db = new ORMDataAccess<BusitravelInfoData>())
                {
                     if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BusitravelInfoModel>("from BusitravelInfoModel");
                    }
                    else
					{
						list = db.Query<BusitravelInfoModel>(hql);
					}

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BusitravelInfoData), false);
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
        public bool Execute(BusitravelInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BusitravelInfoData> db = new ORMDataAccess<BusitravelInfoData>())
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


        /// <summary>
        /// 获取指定ID的差旅记录
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public BusitravelInfoModel GetModelById(string bid)
        {
            return GetList("from BusitravelInfoModel p where p.BID = '" + bid + "'").FirstOrDefault();
        }

        #endregion
    }
}
