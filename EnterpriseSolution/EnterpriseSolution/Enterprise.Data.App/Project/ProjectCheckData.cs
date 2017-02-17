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
    /// 文件名:  ProjectCheckData.cs
    /// 功能描述: 数据层-审核信息表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2013-11-5 15:48:14
    /// </summary>
    public class ProjectCheckData : IProjectCheckData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectCheckData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCheckModel> GetList()
        {
            IList<ProjectCheckModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectCheckModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectCheckData> db = new ORMDataAccess<ProjectCheckData>())
                {
                    list = db.Query<ProjectCheckModel>("from ProjectCheckModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectCheckData), false);
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
        public IList<ProjectCheckModel> GetListByHQL(string hql)
        {
            IList<ProjectCheckModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectCheckModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectCheckData> db = new ORMDataAccess<ProjectCheckData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectCheckModel>("from ProjectCheckModel");
                    }
                    else
                    {
                        list = db.Query<ProjectCheckModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ProjectCheckData), false);
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
        public bool Execute(ProjectCheckModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectCheckData> db = new ORMDataAccess<ProjectCheckData>())
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
        /// 执行批量添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteLst(IList<ProjectCheckModel> models)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectCheckData> db = new ORMDataAccess<ProjectCheckData>())
            {
                foreach (ProjectCheckModel model in models)
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
