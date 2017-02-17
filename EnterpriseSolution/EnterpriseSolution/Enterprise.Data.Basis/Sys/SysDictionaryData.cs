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
    /// 文件名:  SysUserData.cs
    /// 功能描述: 数据层-字典表数据访问方法实现类
    /// 创建人：qw
    /// 创建日期: 2013.1.24
    /// </summary>
    public class SysDictionaryData : ISysDictionaryData
    {

        /// <summary>
        /// 缓存项名称
        /// 
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SysDictionaryData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysDictionaryModel> GetList()
        {
            IList<SysDictionaryModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysDictionaryModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysDictionaryData> db = new ORMDataAccess<SysDictionaryData>())
                {
                    list = db.Query<SysDictionaryModel>("from SysDictionaryModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(SysDictionaryData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;
                        CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// 根据中文名称获取对应的词典数据
        /// </summary>
        /// <returns></returns>
        public IList<SysDictionaryModel> GetListByZwmc(string zwmc)
        {
            //IList<SysDictionaryModel> list = new List<SysDictionaryModel>();
            //using (ORMDataAccess<SysDictionaryData> db = new ORMDataAccess<SysDictionaryData>())
            //{
            //    //Action query = delegate() { db.Insert(null); };
            //    //db.Transaction(query);

            //    //list = db.QueryInCache<SysDictionaryModel>("from SysDictionaryModel c where c.ZWMC='" + zwmc + "'",
            //    //    typeof(SysDictionaryModel).ToString());
            //    //IList ll = db.QueryBySQL("select c.* from BASIS_SYS_DICTIONARY c where c.ZWMC='" + zwmc + "'");
            //    //list = db.Query<SysDictionaryModel>("from SysDictionaryModel c where c.ZWMC='" + zwmc + "'");
            //}
            return GetList().Where(p => p.ZWMC == zwmc).ToList();
        }


        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysDictionaryModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SysDictionaryData> db = new ORMDataAccess<SysDictionaryData>())
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

    }
}
