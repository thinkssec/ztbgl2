using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Bf;
using Enterprise.Component.Cache;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  BfInstancesData.cs
    /// 功能描述: 数据层-业务流实例表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:55
    /// </summary>
    public class BfInstancesData : IBfInstancesData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfInstancesData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfInstancesModel> GetList()
        {
            IList<BfInstancesModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfInstancesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfInstancesData> db = new ORMDataAccess<BfInstancesData>())
                {
                    list = db.Query<BfInstancesModel>("from BfInstancesModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfInstancesData), true);
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
        /// 根据ID获取对应数据
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public BfInstancesModel GetModelById(string instanceId)
        {
            BfInstancesModel model = null;

            using (ORMDataAccess<BfInstancesData> db = new ORMDataAccess<BfInstancesData>())
            {
                model = db.Query<BfInstancesModel>("from BfInstancesModel p where p.BF_INSTANCEID='" 
                    + instanceId + "'").FirstOrDefault();
            }

            return model;
        }


        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfInstancesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfInstancesData> db = new ORMDataAccess<BfInstancesData>())
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

    }
}
