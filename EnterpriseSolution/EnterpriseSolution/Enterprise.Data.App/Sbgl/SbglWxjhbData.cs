using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Sbgl;

namespace Enterprise.Data.App.Sbgl
{

    /// <summary>
    /// 文件名:  SbglWxjhbData.cs
    /// 功能描述: 数据层-设备维修计划表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2015/4/30 8:22:37
    /// </summary>
    public class SbglWxjhbData : ISbglWxjhbData
    {

        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(SbglWxjhbData).ToString();

        /// <summary>
        /// 根据主键获取唯一记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglWxjhbModel GetSingle(string key)
        {
            return null;
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetList()
        {
            IList<SbglWxjhbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglWxjhbModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
                {
                    list = db.Query<SbglWxjhbModel>("from SbglWxjhbModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheHelper.Add(typeof(SbglWxjhbData), false, null, "GetList", null, CacheClassKey + "_GetList", list);
                    //}
                }
            }
            return list;
        }

        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListByHQL(string hql)
        {
            IList<SbglWxjhbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglWxjhbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SbglWxjhbModel>("from SbglWxjhbModel");
                    }
                    else
                    {
                        list = db.Query<SbglWxjhbModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheHelper.Add(typeof(SbglWxjhbData), false, null, "GetListByHQL", new object[] { hql }, CacheClassKey + "_GetListByHQL_" + hql, list);
                    //}
                }
            }
            return list;
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListBySQL(string sql)
        {
            IList<SbglWxjhbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<SbglWxjhbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<SbglWxjhbModel>(sql, typeof(SbglWxjhbModel));

                        //if (WebKeys.EnableCaching)
                        //{
                        ////数据存入缓存系统
                        //CacheHelper.Add(typeof(SbglWxjhbData), false, null, "GetListBySQL", new object[] { sql }, CacheClassKey + "_GetListBySQL_" + sql, list);		
                        //}
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
        public bool Execute(SbglWxjhbModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
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
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
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

            using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
            {
                isResult = db.ExecuteNonQuery(sql);
            }

            if (WebKeys.EnableCaching)
            {
                //清空相关的缓存
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
            }

            return isResult;
        }

        #endregion
    }
}
