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
    /// 文件名:  BfNodesData.cs
    /// 功能描述: 数据层-业务流节点表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:56
    /// </summary>
    public class BfNodesData : IBfNodesData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfNodesData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfNodesModel> GetList()
        {
            IList<BfNodesModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfNodesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfNodesData> db = new ORMDataAccess<BfNodesData>())
                {
                    list = db.Query<BfNodesModel>("from BfNodesModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfNodesData), false);
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
        public bool Execute(BfNodesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfNodesData> db = new ORMDataAccess<BfNodesData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(model);
                }
                else if (model.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(model);
                }
                else if (model.DB_Option_Action == WebKeys.InsertOrUpdateAction)
                {
                    db.InsertOrUpdate(model);
                }
                else if (model.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(model);
                }
                else if (model.DB_Option_Action == "DeleteByBF_ID_VERSION")
                {
                    IList<BfNodesModel> deleteList = GetList().
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


        /// <summary>
        /// 根据业务流ID和版本号获取所有节点信息集合
        /// </summary>
        /// <param name="bf_id">业务流ID</param>
        /// <param name="bf_version">业务流版本</param>
        /// <returns></returns>
        public IList<BfNodesModel> GetListById_Version(string bf_id, int bf_version)
        {
            IList<BfNodesModel> list = null;

            using (ORMDataAccess<BfNodesData> db = new ORMDataAccess<BfNodesData>())
            {
                list = db.Query<BfNodesModel>("from BfNodesModel c where c.BF_ID='" + bf_id + "' and c.BF_VERSION='" + bf_version + "'");
            }

            return list;
        }

    }
}
