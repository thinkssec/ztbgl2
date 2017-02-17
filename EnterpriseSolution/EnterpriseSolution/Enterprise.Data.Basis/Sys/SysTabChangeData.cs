using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Component.Cache;

namespace Enterprise.Data.Basis.Sys
{

    /// <summary>
    /// 文件名:  SysTabChangeData.cs
    /// 功能描述: 数据层-数据表更新记录表数据访问方法实现类
    /// 创建人：qw
    /// 创建日期: 2013.1.24
    /// </summary>
    public class SysTabChangeData : ISysTabChangeData
    {

        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SysTabChangeData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysTabChangeModel> GetList()
        {
            IList<SysTabChangeModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<SysTabChangeModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysTabChangeData> db = new ORMDataAccess<SysTabChangeData>())
                {
                    list = db.Query<SysTabChangeModel>("from SysTabChangeModel");
                    
                    ////数据存入缓存系统
                    //MyCacheItemRefreshAction refreshAction =
                    //    new MyCacheItemRefreshAction(typeof(SysTabChangeData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }


        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysTabChangeModel model)
        {
            bool isResult = true;

            //using (ORMDataAccess<SysTabChangeData> db = new ORMDataAccess<SysTabChangeData>())
            //{
            //    if (model.DB_Option_Action == WebKeys.InsertAction)
            //    {
            //        db.Insert(model);
            //    }
            //    else if (model.DB_Option_Action == WebKeys.UpdateAction)
            //    {
            //        db.Update(model);
            //    }
            //    else if (model.DB_Option_Action == WebKeys.DeleteAction)
            //    {
            //        db.Delete(model);
            //    }
            //}

            //清空相关的缓存
            //CacheHelper.RemoveCacheForClassKey(cacheClassKey);

            return isResult;
        }

    }
}
