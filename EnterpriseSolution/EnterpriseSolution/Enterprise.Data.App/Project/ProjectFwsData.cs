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
    /// 文件名:  ProjectFwsData.cs
    /// 功能描述: 数据层-项目服务商管理数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2015/6/1 14:34:34
    /// </summary>
    public class ProjectFwsData : IProjectFwsData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectFwsData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectFwsModel> GetList()
        {
            IList<ProjectFwsModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectFwsModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFwsData> db = new ORMDataAccess<ProjectFwsData>())
                {
                    list = db.Query<ProjectFwsModel>("from ProjectFwsModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectFwsData), false);
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
        public IList<ProjectFwsModel> GetListByHQL(string hql)
        {
            IList<ProjectFwsModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectFwsModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFwsData> db = new ORMDataAccess<ProjectFwsData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectFwsModel>("from ProjectFwsModel");
			}
			else
			{
				list = db.Query<ProjectFwsModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////数据存入缓存系统
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectFwsData), false);
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
        public IList<ProjectFwsModel> GetListBySQL(string sql)
        {
            IList<ProjectFwsModel> list = null;
 

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFwsData> db = new ORMDataAccess<ProjectFwsData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectFwsModel>(sql, typeof(ProjectFwsModel));

                        
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
        public bool Execute(ProjectFwsModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectFwsData> db = new ORMDataAccess<ProjectFwsData>())
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
