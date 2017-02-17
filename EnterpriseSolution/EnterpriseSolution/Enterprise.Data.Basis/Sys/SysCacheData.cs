using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Component.Cache;
using System.Data;

namespace Enterprise.Data.Basis.Sys
{

    /// <summary>
    /// 文件名:  SysCacheData.cs
    /// 功能描述: 数据层-缓存表数据访问方法实现类
    /// 创建人：qw
    /// 创建日期: 2013.1.24
    /// </summary>
    public class SysCacheData : ISysCacheData
    {

        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SysCacheData).ToString();

        /// <summary>
        /// 获取当前数据库用户的所有触发器名称
        /// </summary>
        /// <param name="owner">所有者</param>
        /// <returns></returns>
        public IList<string> GetUserTriggers()
        {
            IList<string> list = new List<string>();
            using (ORMDataAccess<SysCacheData> db = new ORMDataAccess<SysCacheData>())
            {
                string sql =
                    "SELECT NAME FROM USER_SOURCE WHERE TYPE='TRIGGER' GROUP BY NAME";
                DataSet ds = db.ExecuteDataset(sql);
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] != null)
                        list.Add(row[0].ToString());
                }
            }
            return list;
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysCacheModel> GetList()
        {
            IList<SysCacheModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysCacheModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysCacheData> db = new ORMDataAccess<SysCacheData>())
                {
                    list = db.Query<SysCacheModel>("from SysCacheModel");

                    //list = db.QueryBySQL<SysCacheModel>("select * from BASIS_SYS_CACHE c", typeof(SysCacheModel));

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(SysCacheData), true);
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
        public bool Execute(SysCacheModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SysCacheData> db = new ORMDataAccess<SysCacheData>())
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

        /// <summary>
        /// 执行基于SQL的原生操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSQL(string sql)
        {
            bool isResult = true;

            using (ORMDataAccess<SysCacheData> db = new ORMDataAccess<SysCacheData>())
            {
                isResult = db.ExecuteNonQuery(sql);
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
