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
    /// 文件名:  BfPublishData.cs
    /// 功能描述: 数据层-业务流发布表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:57
    /// </summary>
    public class BfPublishData : IBfPublishData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfPublishData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfPublishModel> GetList()
        {
            IList<BfPublishModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfPublishModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfPublishData> db = new ORMDataAccess<BfPublishData>())
                {
                    list = db.Query<BfPublishModel>("from BfPublishModel");
                    
                    //数据存入缓存系统
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BfPublishData), false);
                    refreshAction.ConstuctParms = null;
                    refreshAction.MethodName = "GetList";
                    refreshAction.Parameters = null;//new object[]{};
                    CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfPublishModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfPublishData> db = new ORMDataAccess<BfPublishData>())
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
                else if (model.DB_Option_Action == "DeleteByBF_ID")
                {
                    List<BfPublishModel> delList = GetList().Where(p => p.BF_ID == model.BF_ID).ToList();
                    foreach (BfPublishModel delM in delList)
                    {
                        db.Delete(delM);
                    }
                }
            }

            if (WebKeys.EnableCaching)
            {
                //清空相关的缓存
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
                CacheHelper.RemoveCacheForClassKey(BfNodesData.cacheClassKey);
            }

            return isResult;
        }

    }
}
