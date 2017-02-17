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
    /// 文件名:  ProjectRwgzlData.cs
    /// 功能描述: 数据层-检测任务工作量表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2013-11-5 15:48:24
    /// </summary>
    public class ProjectRwgzlData : IProjectRwgzlData
    {
        #region 代码生成器

        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectRwgzlData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectRwgzlModel> GetList()
        {
            IList<ProjectRwgzlModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectRwgzlModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRwgzlData> db = new ORMDataAccess<ProjectRwgzlData>())
                {
                    list = db.Query<ProjectRwgzlModel>("from ProjectRwgzlModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectRwgzlData), false);
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
        public IList<ProjectRwgzlModel> GetListByHQL(string hql)
        {
            IList<ProjectRwgzlModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectRwgzlModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRwgzlData> db = new ORMDataAccess<ProjectRwgzlData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectRwgzlModel>("from ProjectRwgzlModel");
                    }
                    else
                    {
                        list = db.Query<ProjectRwgzlModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectRwgzlData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetListByHQL";
                        refreshAction.Parameters = new object[] { hql };
                        CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
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
        public bool Execute(ProjectRwgzlModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectRwgzlData> db = new ORMDataAccess<ProjectRwgzlData>())
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
                //关联处理节点运行表的缓存
                CacheHelper.RemoveCacheForClassKey(ProjectRunningData.CacheClassKey);
                //清空任务策划的缓存
                CacheHelper.RemoveCacheForClassKey(ProjectRwchData.CacheClassKey);
            }
            return isResult;
        }

        #endregion
    }
}
