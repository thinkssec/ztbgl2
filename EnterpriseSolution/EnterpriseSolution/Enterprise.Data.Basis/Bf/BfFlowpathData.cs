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
    /// 文件名:  BfFlowpathData.cs
    /// 功能描述: 数据层-节点流转表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:52
    /// </summary>
    public class BfFlowpathData : IBfFlowpathData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfFlowpathData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfFlowpathModel> GetList()
        {
            IList<BfFlowpathModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfFlowpathModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfFlowpathData> db = new ORMDataAccess<BfFlowpathData>())
                {
                    list = db.Query<BfFlowpathModel>("from BfFlowpathModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfFlowpathData), false);
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
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfFlowpathModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfFlowpathData> db = new ORMDataAccess<BfFlowpathData>())
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
                else if (model.DB_Option_Action == "DeleteByBF_ID_VERSION")
                {
                    IList<BfFlowpathModel> deleteList = GetList().
                        Where(p => p.BF_ID == model.BF_ID && p.BF_VERSION == model.BF_VERSION).ToList();
                    foreach (var q in deleteList)
                    {
                        db.Delete(q);
                    }
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
