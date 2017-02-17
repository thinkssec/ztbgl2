using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Goods;

namespace Enterprise.Data.App.Goods
{

    /// <summary>
    /// 文件名:  GoodsDeviceData.cs
    /// 功能描述: 数据层-设备电子档案数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-11-5 15:48:11
    /// </summary>
    public class GoodsDeviceData : IGoodsDeviceData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(GoodsDeviceData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<GoodsDeviceModel> GetList()
        {
            IList<GoodsDeviceModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<GoodsDeviceModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<GoodsDeviceData> db = new ORMDataAccess<GoodsDeviceData>())
                {
                    list = db.Query<GoodsDeviceModel>("from GoodsDeviceModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(GoodsDeviceData), false);
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
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<GoodsDeviceModel> GetListByHQL(string hql)
        {
            IList<GoodsDeviceModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<GoodsDeviceModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<GoodsDeviceData> db = new ORMDataAccess<GoodsDeviceData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<GoodsDeviceModel>("from GoodsDeviceModel");
			}
			else
			{
				list = db.Query<GoodsDeviceModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////数据存入缓存系统
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(GoodsDeviceData), false);
	                    //refreshAction.ConstuctParms = null;
	                    //refreshAction.MethodName = "GetList";
	                    //refreshAction.Parameters = new object[]{ hql };
	                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
			    //}
                }
            }
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(GoodsDeviceModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<GoodsDeviceData> db = new ORMDataAccess<GoodsDeviceData>())
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
