using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Sbgl;
using System.Data;

namespace Enterprise.Data.App.Sbgl
{

    /// <summary>
    /// 文件名:  SbglYsbgdData.cs
    /// 功能描述: 数据层-设备维修项目验收报告单数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2015/4/30 8:22:37
    /// </summary>
    public class SbglYsbgdData : ISbglYsbgdData
    {

        #region 代码生成器

        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(SbglYsbgdData).ToString();

        /// <summary>
        /// 根据主键获取唯一记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglYsbgdModel GetSingle(string key)
        {
            return null;
        }

        /// <summary>
        /// 获取查询数据集
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
            {
                DataSet ds = db.ExecuteDataset(sql);
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetList()
        {
            IList<SbglYsbgdModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglYsbgdModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
                {
                    list = db.Query<SbglYsbgdModel>("from SbglYsbgdModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheHelper.Add(typeof(SbglYsbgdData), false, null, "GetList", null, CacheClassKey + "_GetList", list);
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
        public IList<SbglYsbgdModel> GetListByHQL(string hql)
        {
            IList<SbglYsbgdModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglYsbgdModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SbglYsbgdModel>("from SbglYsbgdModel");
                    }
                    else
                    {
                        list = db.Query<SbglYsbgdModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheHelper.Add(typeof(SbglYsbgdData), false, null, "GetListByHQL", new object[] { hql }, CacheClassKey + "_GetListByHQL_" + hql, list);
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
        public IList<SbglYsbgdModel> GetListBySQL(string sql)
        {
            IList<SbglYsbgdModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<SbglYsbgdModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<SbglYsbgdModel>(sql, typeof(SbglYsbgdModel));

                        //if (WebKeys.EnableCaching)
                        //{
                        ////数据存入缓存系统
                        //CacheHelper.Add(typeof(SbglYsbgdData), false, null, "GetListBySQL", new object[] { sql }, CacheClassKey + "_GetListBySQL_" + sql, list);		
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
        public bool Execute(SbglYsbgdModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
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

            using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
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
