using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{

    /// <summary>
    /// 文件名:  DocumentConvertData.cs
    /// 功能描述: 数据层-文档转换表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2014/3/6 8:25:00
    /// </summary>
    public class DocumentConvertData : IDocumentConvertData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(DocumentConvertData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetList()
        {
            IList<DocumentConvertModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<DocumentConvertModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentConvertData> db = new ORMDataAccess<DocumentConvertData>())
                {
                    list = db.Query<DocumentConvertModel>("from DocumentConvertModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(DocumentConvertData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
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
        public IList<DocumentConvertModel> GetListByHQL(string hql)
        {
            IList<DocumentConvertModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<DocumentConvertModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentConvertData> db = new ORMDataAccess<DocumentConvertData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<DocumentConvertModel>("from DocumentConvertModel");
                    }
                    else
                    {
                        list = db.Query<DocumentConvertModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    //    //数据存入缓存系统
                    //    CacheItemRefreshAction refreshAction =
                    //        new CacheItemRefreshAction(typeof(DocumentConvertData), false);
                    //    refreshAction.ConstuctParms = null;
                    //    refreshAction.MethodName = "GetListByHQL";
                    //    refreshAction.Parameters = new object[] { hql };
                    //    CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
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
        public IList<DocumentConvertModel> GetListBySQL(string sql)
        {
            IList<DocumentConvertModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<DocumentConvertModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentConvertData> db = new ORMDataAccess<DocumentConvertData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<DocumentConvertModel>(sql, typeof(DocumentConvertModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(DocumentConvertData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetListBySQL";
                            refreshAction.Parameters = new object[] { sql };
                            CacheHelper.Add(CacheClassKey + "_GetListBySQL_" + sql, list, refreshAction);
                        }
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
        public bool Execute(DocumentConvertModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<DocumentConvertData> db = new ORMDataAccess<DocumentConvertData>())
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

        #endregion
    }
}
