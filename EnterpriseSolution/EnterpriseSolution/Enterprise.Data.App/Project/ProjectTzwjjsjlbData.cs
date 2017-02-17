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
    /// 文件名:  ProjectTzwjjsjlbData.cs
    /// 功能描述: 数据层-投标文件接收记录表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2015/6/28 1:26:18
    /// </summary>
    public class ProjectTzwjjsjlbData : IProjectTzwjjsjlbData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectTzwjjsjlbData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectTzwjjsjlbModel> GetList()
        {
            IList<ProjectTzwjjsjlbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectTzwjjsjlbModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectTzwjjsjlbData> db = new ORMDataAccess<ProjectTzwjjsjlbData>())
                {
                    list = db.Query<ProjectTzwjjsjlbModel>("from ProjectTzwjjsjlbModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectTzwjjsjlbData), false);
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
        public IList<ProjectTzwjjsjlbModel> GetListByHQL(string hql)
        {
            IList<ProjectTzwjjsjlbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectTzwjjsjlbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectTzwjjsjlbData> db = new ORMDataAccess<ProjectTzwjjsjlbData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectTzwjjsjlbModel>("from ProjectTzwjjsjlbModel");
			}
			else
			{
				list = db.Query<ProjectTzwjjsjlbModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////数据存入缓存系统
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectTzwjjsjlbData), false);
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
        public IList<ProjectTzwjjsjlbModel> GetListBySQL(string sql)
        {
            IList<ProjectTzwjjsjlbModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectTzwjjsjlbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectTzwjjsjlbData> db = new ORMDataAccess<ProjectTzwjjsjlbData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectTzwjjsjlbModel>(sql, typeof(ProjectTzwjjsjlbModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectTzwjjsjlbData), false);
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
        public bool Execute(ProjectTzwjjsjlbModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectTzwjjsjlbData> db = new ORMDataAccess<ProjectTzwjjsjlbData>())
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
