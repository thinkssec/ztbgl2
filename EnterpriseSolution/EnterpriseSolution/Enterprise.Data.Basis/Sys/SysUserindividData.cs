using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Data.Basis.Sys
{

    /// <summary>
    /// 文件名:  SysUserindividData.cs
    /// 功能描述: 数据层-个性化设置表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2013-7-3 11:42:29
    /// </summary>
    public class SysUserindividData : ISysUserindividData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SysUserindividData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserindividModel> GetList()
        {
            IList<SysUserindividModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysUserindividModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysUserindividData> db = new ORMDataAccess<SysUserindividData>())
                {
                    list = db.Query<SysUserindividModel>("from SysUserindividModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(SysUserindividData), false);
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
        /// 获取指定ID的数据
        /// </summary>
        /// <returns></returns>
        public SysUserindividModel GetModelById(int id)
        {
            SysUserindividModel model = null;
            if (WebKeys.EnableCaching)
            {
                model = (SysUserindividModel)CacheHelper.GetCache(cacheClassKey + "_GetModelById_" + id);
            }
            if (model == null)
            {
                using (ORMDataAccess<SysUserindividData> db = new ORMDataAccess<SysUserindividData>())
                {
                    model = db.Query<SysUserindividModel>(
                        "from SysUserindividModel p where p.USERID='" + id + "'").FirstOrDefault();

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(SysUserindividData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetModelById";
                        refreshAction.Parameters = new object[] { id };
                        CacheHelper.Add(cacheClassKey + "_GetModelById_" + id, model, refreshAction);
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysUserindividModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SysUserindividData> db = new ORMDataAccess<SysUserindividData>())
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
                else if (model.DB_Option_Action == WebKeys.InsertOrUpdateAction)
                {
                    db.InsertOrUpdate(model);
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
