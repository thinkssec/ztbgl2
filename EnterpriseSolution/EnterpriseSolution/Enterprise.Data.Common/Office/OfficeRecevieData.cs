using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Office;

namespace Enterprise.Data.Common.Office
{

    /// <summary>
    /// 文件名:  OfficeRecevieData.cs
    /// 功能描述: 数据层-公文签收记录数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-27 21:01:29
    /// </summary>
    public class OfficeRecevieData : IOfficeRecevieData
    {
        #region 代码生成器

		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(OfficeRecevieData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<OfficeRecevieModel> GetList()
        {
            IList<OfficeRecevieModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<OfficeRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<OfficeRecevieData> db = new ORMDataAccess<OfficeRecevieData>())
                {
                    list = db.Query<OfficeRecevieModel>("from OfficeRecevieModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(OfficeRecevieData), false);
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
        public IList<OfficeRecevieModel> GetList(string hql)
        {
            IList<OfficeRecevieModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<OfficeRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<OfficeRecevieData> db = new ORMDataAccess<OfficeRecevieData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<OfficeRecevieModel>("from OfficeRecevieModel");
                    }
                    else
                    {
                        list = db.Query<OfficeRecevieModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(OfficeRecevieData), false);
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
        ///  根据ID值获取唯一数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OfficeRecevieModel GetModelById(string id)
        {
            return GetList("from OfficeRecevieModel p where p.ORID = '" + id + "'").FirstOrDefault();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(OfficeRecevieModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<OfficeRecevieData> db = new ORMDataAccess<OfficeRecevieData>())
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
