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
    /// 文件名:  ProjectQhsecheckitemData.cs
    /// 功能描述: 数据层-质量安全检查项目数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/11/26 17:18:04
    /// </summary>
    public class ProjectQhsecheckitemData : IProjectQhsecheckitemData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectQhsecheckitemData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectQhsecheckitemModel> GetList()
        {
            IList<ProjectQhsecheckitemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectQhsecheckitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectQhsecheckitemData> db = new ORMDataAccess<ProjectQhsecheckitemData>())
                {
                    list = db.Query<ProjectQhsecheckitemModel>("from ProjectQhsecheckitemModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectQhsecheckitemData), false);
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
        public IList<ProjectQhsecheckitemModel> GetListByHQL(string hql)
        {
            IList<ProjectQhsecheckitemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectQhsecheckitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectQhsecheckitemData> db = new ORMDataAccess<ProjectQhsecheckitemData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectQhsecheckitemModel>("from ProjectQhsecheckitemModel");
			}
			else
			{
				list = db.Query<ProjectQhsecheckitemModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////数据存入缓存系统
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectQhsecheckitemData), false);
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
        public IList<ProjectQhsecheckitemModel> GetListBySQL(string sql)
        {
            IList<ProjectQhsecheckitemModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectQhsecheckitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectQhsecheckitemData> db = new ORMDataAccess<ProjectQhsecheckitemData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectQhsecheckitemModel>(sql, typeof(ProjectQhsecheckitemModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectQhsecheckitemData), false);
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
        public bool Execute(ProjectQhsecheckitemModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectQhsecheckitemData> db = new ORMDataAccess<ProjectQhsecheckitemData>())
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
