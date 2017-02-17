using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using Enterprise.Component.Cache;

namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  MyCacheManager.cs
    /// 功能描述: 业务逻辑层-用于监控数据表的变化并将事件通知缓存系统
    /// 创建人：qw
    /// 创建日期: 2013.1.24
    /// </summary>
    public class MyCacheManager
    {
        /// <summary>
        /// 数据表缓存集合
        /// </summary>
        public static Hashtable CacheItemHash = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 数据表缓存名称前缀
        /// </summary>
        public static string CachePrefix = WebKeys.CacheItemKey + "Enterprise.Data.";
        /// <summary>
        /// 服务类实例
        /// </summary>
        private static readonly SysCacheService sysCacheSrv = new SysCacheService();

        /// <summary>
        /// 检测当前的数据表是否有效
        /// 如果失效，则清空缓存
        /// </summary>
        /// <param name="tables"></param>
        public static void CheckAvailability(IList<SysTabChangeModel> tables)
        {
            foreach (SysTabChangeModel table in tables)
            {
                string key = table.USERNAME + "_" + table.TABLENAME;
                if (CacheItemHash.ContainsKey(key))
                {
                    TableCacheSubject tableSubject = CacheItemHash[key] as TableCacheSubject;
                    if (tableSubject.CheckState(table))
                    {
                        //状态改变，通知所有观察者
                        tableSubject.Notify();
                        tableSubject.Table = table;
                        //重新保存
                        CacheItemHash[key] = tableSubject;
                    }
                }
            }
        }

        /// <summary>
        /// 加载所有数据的缓存信息,用于实现数据表自更新后的动态同步
        /// </summary>
        /// <param name="cacheLst">缓存表</param>
        /// <param name="tableLst">数据表</param>
        public static void LoadCache(IList<SysCacheModel> cacheLst, IList<SysTabChangeModel> tableLst)
        {
            //完成缓存项与数据表的关系建立
            foreach (SysTabChangeModel table in tableLst)
            {
                //声明一个数据表缓存项
                TableCacheSubject tableSubject = new TableCacheSubject(table);
                tableSubject.Table = table;
                List<SysCacheModel> _Caches = cacheLst.Where(p => p.USERNAME == table.USERNAME && p.TABLENAME == table.TABLENAME).ToList();
                foreach (SysCacheModel cache in _Caches)
                {
                    //注册观察者
                    TableCacheObserver observer = new TableCacheObserver(cache.CACHENAME, tableSubject);
                    tableSubject.Attach(observer);
                }
                //加入缓存集合
                string key = table.USERNAME + "_" + table.TABLENAME;
                CacheItemHash[key] = tableSubject;
            }
        }

        /// <summary>
        /// 加载各缓存项的关联关系
        /// </summary>
        public static void LoadCacheRelationshipKeys()
        {

            CacheHelper.CacheRelationshipHash.Clear();
            SysCacherelationService cacheRelationSrv = new SysCacherelationService();
            var queryList = cacheRelationSrv.GetList();//已经排序过
            List<string> cacheNames = new List<string>();
            string mainCacheName = string.Empty;
            foreach (var q in queryList)
            {
                if (string.IsNullOrEmpty(mainCacheName))
                {
                    cacheNames.Add(WebKeys.CacheItemKey + q.INFLCACHENAME);
                    mainCacheName = WebKeys.CacheItemKey + q.CACHENAME;
                }
                else if (mainCacheName.Equals(WebKeys.CacheItemKey + q.CACHENAME))
                {
                    cacheNames.Add(WebKeys.CacheItemKey + q.INFLCACHENAME);
                }
                else
                {
                    //先保存上一记录
                    CacheHelper.CacheRelationshipHash[mainCacheName] = cacheNames;
                    //重新开始
                    cacheNames = new List<string>();
                    cacheNames.Add(WebKeys.CacheItemKey + q.INFLCACHENAME);
                    mainCacheName = WebKeys.CacheItemKey + q.CACHENAME;
                }
            }
            if (!string.IsNullOrEmpty(mainCacheName))
            {
                //保存最后记录
                CacheHelper.CacheRelationshipHash[mainCacheName] = cacheNames;
            }

        }

        /// <summary>
        ///  根据系统实际缓存项更新缓存配置表
        /// </summary>
        public static void ReloadCache()
        {
            bool isReload = false;
            //加载系统中当前已实际存在的缓存项
            IList<string> keys = CacheHelper.GetCacheKeys();
            foreach (string kName in keys)
            {
                if (kName.StartsWith(CachePrefix))
                {
                    //与数据表相关的缓存处理,根据kName反向出数据表名称
                    string cacheName = string.Empty;
                    string tableName = GetTaleName(kName, out cacheName);
                    var q = SysCacheService.GetAllCacheList().FirstOrDefault(p => p.CACHENAME == cacheName 
                        && p.TABLENAME == tableName && p.USERNAME == WebKeys.DATABASE_USERNAME);
                    if (q == null)
                    {
                        //添加该项
                        SysCacheModel model = new SysCacheModel();
                        model.CACHENAME = cacheName;
                        model.TABLENAME = tableName;
                        model.USERNAME = WebKeys.DATABASE_USERNAME;
                        model.DB_Option_Action = WebKeys.InsertAction;
                        isReload = sysCacheSrv.Execute(model);
                    }
                }
            }

            if (isReload)
            {
                //加载数据表的变化情况
                IList<SysTabChangeModel> tabchangeList = SysTabChangeService.GetAllTableChangeList();
                //加载缓存配置表
                IList<SysCacheModel> cacheLst = SysCacheService.GetAllCacheList();
                //加载当前的缓存配置
                MyCacheManager.LoadCache(cacheLst, tabchangeList);
            }

            //加载各缓存项的关联关系
            MyCacheManager.LoadCacheRelationshipKeys();

        }
        
        /// <summary>
        /// 清空所有
        /// </summary>
        public static void ClearAll()
        {
            //1==清空所有缓存(采用此方式防止把其它项目的缓存也删除)
            foreach (DictionaryEntry entry in CacheItemHash)
            {
                TableCacheSubject tableSubject = entry.Value as TableCacheSubject;
                tableSubject.Notify();
            }
            //2==缓存关系清空
            CacheItemHash.Clear();
        }

        /// <summary>
        /// 移除指定项的缓存关系
        /// key=UserName + "_" + TableName
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveItem(string key)
        {
            if (CacheItemHash.ContainsKey(key))
            {
                TableCacheSubject tableSubject = CacheItemHash[key] as TableCacheSubject;
                tableSubject.Notify();
                CacheItemHash.Remove(key);
            }
        }

        #region 缓存关系相关方法区



        #endregion


        #region 专用方法区

        /// <summary>
        /// 根据缓存项的名称反向出数据表的名称
        /// （只适用于代码自动生成的类型）
        /// </summary>
        /// <param name="cacheKey">缓存项的全名称</param>
        /// <param name="cacheName">缓存项的保存名称</param>
        /// <returns></returns>
        public static string GetTaleName(string cacheKey, out string cacheName)
        {
            string tName = string.Empty;
            cacheName = string.Empty;
            try
            {
                //说明：用TrimStart方法总是截取字符不全 2014.6.11 只能用原始的方法
                //egg:   SSEC_CacheItemKey_Enterprise.Data.App.Project.ProjectInfoData_GetList
                string keyStr = cacheKey.Substring(cacheKey.IndexOf(CachePrefix) + CachePrefix.Length);
                //egg:   App.Project.ProjectInfoData_GetList
                keyStr = keyStr.Substring(0, keyStr.IndexOf("Data_"));
                //egg:   App.Project.ProjectInfo
                cacheName = "Enterprise.Data." + keyStr + "Data";
                string[] keys = keyStr.Split('.');
                if (keys != null && keys.Length == 3)
                {
                    //egg: keys[0]="App"   keys[1]="Project"   keys[2]="ProjectInfo"
                    keys[2] = keys[2].Substring(keys[2].IndexOf(keys[1]) + keys[1].Length);
                    //egg: keys[0]="App"   keys[1]="Project"   keys[2]="Info"
                    tName = string.Format("{0}_{1}_{2}", keys[0].ToUpper(), keys[1].ToUpper(), keys[2].ToUpper());
                }
            }
            catch { }
            return tName;
        }

        #endregion

    }
}
