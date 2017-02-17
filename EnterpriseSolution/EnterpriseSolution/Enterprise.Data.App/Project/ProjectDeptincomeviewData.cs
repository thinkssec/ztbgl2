using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{

    /// <summary>
    /// 文件名:  ProjectDeptincomeviewData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2013/12/10 10:44:42
    /// </summary>
    public class ProjectDeptincomeviewData : IProjectDeptincomeviewData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectDeptincomeviewData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectDeptincomeviewModel> GetList()
        {
            IList<ProjectDeptincomeviewModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectDeptincomeviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectDeptincomeviewData> db = new ORMDataAccess<ProjectDeptincomeviewData>())
                {
                    list = db.Query<ProjectDeptincomeviewModel>("from ProjectDeptincomeviewModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectDeptincomeviewData), false);
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
        public IList<ProjectDeptincomeviewModel> GetListByHQL(string hql)
        {
            IList<ProjectDeptincomeviewModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectDeptincomeviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectDeptincomeviewData> db = new ORMDataAccess<ProjectDeptincomeviewData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectDeptincomeviewModel>("from ProjectDeptincomeviewModel");
                    }
                    else
                    {
                        list = db.Query<ProjectDeptincomeviewModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectDeptincomeviewData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetListByHQL";
                    //refreshAction.Parameters = new object[]{ hql };
                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
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
        public IList<ProjectDeptincomeviewModel> GetListBySQL(string sql)
        {
            IList<ProjectDeptincomeviewModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectDeptincomeviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectDeptincomeviewData> db = new ORMDataAccess<ProjectDeptincomeviewData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectDeptincomeviewModel>(sql, typeof(ProjectDeptincomeviewModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectDeptincomeviewData), false);
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
        public bool Execute(ProjectDeptincomeviewModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectDeptincomeviewData> db = new ORMDataAccess<ProjectDeptincomeviewData>())
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
