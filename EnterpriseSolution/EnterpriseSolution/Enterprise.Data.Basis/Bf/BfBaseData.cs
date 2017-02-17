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
    /// 文件名:  BfBaseData.cs
    /// 功能描述: 数据层-业务流基础表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:50
    /// </summary>
    public class BfBaseData : IBfBaseData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfBaseData).ToString();

        //同步
        private static object _synRoot = new Object();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfBaseModel> GetList()
        {
            IList<BfBaseModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfBaseModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfBaseData> db = new ORMDataAccess<BfBaseData>())
                {
                    list = db.Query<BfBaseModel>("from BfBaseModel");
                    
                    //数据存入缓存系统
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BfBaseData), true);
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
        public bool Execute(BfBaseModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfBaseData> db = new ORMDataAccess<BfBaseData>())
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

            //清空相关的缓存
            CacheHelper.RemoveCacheForClassKey(cacheClassKey);

            return isResult;
        }

        /// <summary>
        /// 生成业务流ID
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string GetBF_ID()
        {
            lock (_synRoot)
            {
                int amount = 0;
                string sql =
                    "select Max(substr(bf_id,3,4)) as MaxId from basis_bf_base";
                using (ORMDataAccess<BfBaseData> db = new ORMDataAccess<BfBaseData>())
                {
                    object rr = db.ScalarBySQL(sql);
                    if (rr != null)
                    {
                        int.TryParse(rr.ToString(), out amount);
                    }
                }
                amount++;//自增
                return CommonTool.BuZero_4(amount);
            }
        }

    }
}
