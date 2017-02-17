using System;
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
    /// 文件名:  SysModuleData.cs
    /// 功能描述: 数据层-模块表数据访问方法实现类
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysModuleData:ISysModuleData
    {

        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SysModuleData).ToString();


        /// <summary>
        /// 数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysModuleModel> GetList()
        {
            IList<SysModuleModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysModuleModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysModuleData> db = new ORMDataAccess<SysModuleData>())
                {
                    list = db.Query<SysModuleModel>("from SysModuleModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(SysModuleData), true);
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
        /// 操作方法
        /// </summary>
        /// <param name="t">实体类</param>
        /// <returns></returns>
        public bool Execute(SysModuleModel t)
        {
            bool isResult = true;

            using (ORMDataAccess<SysModuleData> db = new ORMDataAccess<SysModuleData>())
            {
                if (t.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(t);
                }
                else if (t.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(t);
                }
                else if (t.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(t);
                }
                else if (t.DB_Option_Action == "UpdatemDelete")
                {
                    var q = GetList().Where(p => p.MODULEID == t.MODULEID).FirstOrDefault();
                    if (q != null)
                    {
                        q.MDELETE = t.MDELETE;
                        db.Update(q);
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
