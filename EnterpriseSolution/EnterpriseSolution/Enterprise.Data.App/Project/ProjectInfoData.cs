using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{

    /// <summary>
    /// 文件名:  ProjectInfoData.cs
    /// 功能描述: 数据层-立项数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2015/6/1 14:34:34
    /// </summary>
    public class ProjectInfoData : IProjectInfoData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectInfoData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectInfoModel> GetList()
        {
            IList<ProjectInfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectInfoModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectInfoData> db = new ORMDataAccess<ProjectInfoData>())
                {
                    list = db.Query<ProjectInfoModel>("from ProjectInfoModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectInfoData), false);
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
        public IList<ProjectInfoModel> GetListByHQL(string hql)
        {
            IList<ProjectInfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectInfoModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectInfoData> db = new ORMDataAccess<ProjectInfoData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectInfoModel>("from ProjectInfoModel");
			}
			else
			{
				list = db.Query<ProjectInfoModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////数据存入缓存系统
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectInfoData), false);
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
        public IList<ProjectInfoModel> GetListBySQL(string sql)
        {
            IList<ProjectInfoModel> list = null;

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectInfoData> db = new ORMDataAccess<ProjectInfoData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectInfoModel>(sql, typeof(ProjectInfoModel));
                    }
                }
            }
            return list;
        }

        public DataTable GetDataTableBySQL(string sql)
        {
            DataTable dt = new DataTable();
            if (WebKeys.EnableCaching)
            {
                dt = (DataTable)CacheHelper.GetCache(CacheClassKey + "_GetDataTableBySQL_" + sql);
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                using (ORMDataAccess<ProjectInfoData> db = new ORMDataAccess<ProjectInfoData>())
                {
                    DataSet ds = db.ExecuteDataset(sql, null);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                                new CacheItemRefreshAction(typeof(ProjectInfoData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetDataTableBySQL";
                            refreshAction.Parameters = new object[] { sql };
                            CacheHelper.Add(CacheClassKey + "_GetDataTableBySQL_" + sql, dt, refreshAction);
                        }
                    }
                }
            }
            return dt;
        }
        private string getCacheNameByTableName(string tname)
        {
            string cacheName = WebKeys.CacheItemKey;
            tname = tname.ToLower();
            string[] tStrs = tname.Split('_');
            if (tStrs.Length >= 3)
            {
                tStrs[0] = tStrs[0].ToTitleCase();
                tStrs[1] = tStrs[1].ToTitleCase();
                tStrs[2] = tStrs[2].ToTitleCase();
                if (tname.StartsWith("app_"))
                {
                    cacheName += "Enterprise.Data.App.";
                }
                else if (tname.StartsWith("common_"))
                {
                    cacheName += "Enterprise.Data.Common.";
                }
                else if (tname.StartsWith("basis_"))
                {
                    cacheName += "Enterprise.Data.Basis.";
                }
                cacheName += string.Format("{0}.{1}Data", tStrs[1], tStrs[1] + tStrs[2]);
            }
            return cacheName;
        }
        public DataTable GetDataTable(string tname, string tfield)
        {
            DataTable dt = new DataTable();
            string cacheName = getCacheNameByTableName(tname);
            if (WebKeys.EnableCaching)
            {
                dt = (DataTable)CacheHelper.GetCache(cacheName + "_GetDataTable_" + tname + "_" + tfield);
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                using (ORMDataAccess<ProjectInfoData> db = new ORMDataAccess<ProjectInfoData>())
                {
                    string fields = tfield.Replace('|', ',');
                    string sql = string.Format("select {0} from {1}", fields, tname);
                    DataSet ds = db.ExecuteDataset(sql, null);
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                                new CacheItemRefreshAction(typeof(ProjectInfoData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetDataTable";
                            refreshAction.Parameters = new object[] { tname, tfield };
                            CacheHelper.Add(cacheName + "_GetDataTable_" + tname + "_" + tfield, dt, refreshAction);
                        }
                    }
                }
            }
            return dt;
        }
        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectInfoData> db = new ORMDataAccess<ProjectInfoData>())
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
