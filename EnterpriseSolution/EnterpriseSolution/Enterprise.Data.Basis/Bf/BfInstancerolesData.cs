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
    /// 文件名:  BfInstancerolesData.cs
    /// 功能描述: 数据层-业务流实例角色表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:54
    /// </summary>
    public class BfInstancerolesData : IBfInstancerolesData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfInstancerolesData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfInstancerolesModel> GetList()
        {
            IList<BfInstancerolesModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfInstancerolesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfInstancerolesData> db = new ORMDataAccess<BfInstancerolesData>())
                {
                    list = db.Query<BfInstancerolesModel>("from BfInstancerolesModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfInstancerolesData), true);
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
        public bool Execute(BfInstancerolesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfInstancerolesData> db = new ORMDataAccess<BfInstancerolesData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    //同一节点中的角色应该具有唯一性
                    BfInstancerolesModel roleModel = GetListByInstanceId(model.BF_INSTANCEID).
                            Where(p => p.BF_NODEID == model.BF_NODEID &&
                                p.BF_OPERATIONTYPE == model.BF_OPERATIONTYPE &&
                                p.BF_ROLENAME == model.BF_ROLENAME && p.USERIDS == model.USERIDS).FirstOrDefault();
                    if (roleModel == null)
                    {
                        db.Insert(model);
                    }
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
        /// 获取指定业务流实例ID下的对应角色数据集合
        /// </summary>
        /// <param name="instanceId">业务流实例ID</param>
        /// <returns></returns>
        public IList<BfInstancerolesModel> GetListByInstanceId(string instanceId)
        {
            IList<BfInstancerolesModel> list = null;

            using (ORMDataAccess<BfInstancerolesData> db = new ORMDataAccess<BfInstancerolesData>())
            {
                list = db.Query<BfInstancerolesModel>("from BfInstancerolesModel c where c.BF_INSTANCEID='" + instanceId + "'");
            }

            return list;
        }

    }
}
