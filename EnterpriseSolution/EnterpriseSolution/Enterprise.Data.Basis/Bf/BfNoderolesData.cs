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
    /// 文件名:  BfNoderolesData.cs
    /// 功能描述: 数据层-业务流节点角色表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:55
    /// </summary>
    public class BfNoderolesData : IBfNoderolesData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfNoderolesData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfNoderolesModel> GetList()
        {
            IList<BfNoderolesModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfNoderolesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfNoderolesData> db = new ORMDataAccess<BfNoderolesData>())
                {
                    list = db.Query<BfNoderolesModel>("from BfNoderolesModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfNoderolesData), false);
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
        public bool Execute(BfNoderolesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfNoderolesData> db = new ORMDataAccess<BfNoderolesData>())
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
                else if (model.DB_Option_Action == "DeleteByRoleType")
                {
                    List<BfNoderolesModel> delList = GetList().
                        Where(p => p.BF_ID == model.BF_ID && p.BF_VERSION == model.BF_VERSION && 
                            p.BF_NODEID == model.BF_NODEID && p.BF_OPERATIONTYPE == model.BF_OPERATIONTYPE && 
                            p.BF_ROLETYPE == model.BF_ROLETYPE).ToList();
                    foreach (BfNoderolesModel delModel in delList)
                    {
                        db.Delete(delModel);
                    }
                }
                else if (model.DB_Option_Action == "DeleteByBF_ID_VERSION")
                {
                    List<BfNoderolesModel> delList = GetList().
                        Where(p => p.BF_ID == model.BF_ID && p.BF_VERSION == model.BF_VERSION).ToList();
                    foreach (BfNoderolesModel delModel in delList)
                    {
                        db.Delete(delModel);
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
        /// 根据业务流ID和版本号获取所有角色信息集合
        /// </summary>
        /// <param name="bf_id">业务流ID</param>
        /// <param name="bf_version">业务流版本</param>
        /// <returns></returns>
        public IList<BfNoderolesModel> GetListById_Version(string bf_id, int bf_version)
        {
            IList<BfNoderolesModel> list = null;

            using (ORMDataAccess<BfNoderolesData> db = new ORMDataAccess<BfNoderolesData>())
            {
                list = db.Query<BfNoderolesModel>("from BfNoderolesModel c where c.BF_ID='" + bf_id + "' and c.BF_VERSION='" + bf_version + "'");
            }

            return list;
        }

    }
}
