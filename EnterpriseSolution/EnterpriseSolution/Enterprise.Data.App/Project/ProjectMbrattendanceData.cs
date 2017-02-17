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
    /// 文件名:  ProjectMbrattendanceData.cs
    /// 功能描述: 数据层-项目人员动态表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2014/6/19 15:35:18
    /// </summary>
    public class ProjectMbrattendanceData : IProjectMbrattendanceData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectMbrattendanceData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectMbrattendanceModel> GetList()
        {
            IList<ProjectMbrattendanceModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectMbrattendanceModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectMbrattendanceData> db = new ORMDataAccess<ProjectMbrattendanceData>())
                {
                    list = db.Query<ProjectMbrattendanceModel>("from ProjectMbrattendanceModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectMbrattendanceData), false);
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
        public IList<ProjectMbrattendanceModel> GetListByHQL(string hql)
        {

            IList<ProjectMbrattendanceModel> list =
                (IList<ProjectMbrattendanceModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectMbrattendanceData> db = new ORMDataAccess<ProjectMbrattendanceData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectMbrattendanceModel>("from ProjectMbrattendanceModel");
                    }
                    else
                    {
                        list = db.Query<ProjectMbrattendanceModel>(hql);
                    }

                    CacheHelper.Add(typeof(ProjectMbrattendanceData), false, null, "GetListByHQL",
                            new object[] { hql }, (CacheClassKey + "_GetListByHQL_" + hql), list);
                }
            }

            return list;
        }


        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectMbrattendanceModel> GetListBySQL(string sql)
        {
            IList<ProjectMbrattendanceModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectMbrattendanceModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectMbrattendanceData> db = new ORMDataAccess<ProjectMbrattendanceData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectMbrattendanceModel>(sql, typeof(ProjectMbrattendanceModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectMbrattendanceData), false);
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
        public bool Execute(ProjectMbrattendanceModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectMbrattendanceData> db = new ORMDataAccess<ProjectMbrattendanceData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(model);
                }
                else if (model.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(model);
                }
                else if (model.DB_Option_Action == WebKeys.InsertOrUpdateAction)
                {
                    db.InsertOrUpdate(model);
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
