using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Supervise;

namespace Enterprise.Data.Common.Supervise
{

    /// <summary>
    /// 文件名:  SuperviseProcessData.cs
    /// 功能描述: 数据层-督办事务进度检查数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/13 10:53:10
    /// </summary>
    public class SuperviseProcessData : ISuperviseProcessData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SuperviseProcessData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseProcessModel> GetList()
        {
            IList<SuperviseProcessModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<SuperviseProcessModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
                {
                    list = db.Query<SuperviseProcessModel>("from SuperviseProcessModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(SuperviseProcessData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
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
        public IList<SuperviseProcessModel> GetList(string hql)
        {
            IList<SuperviseProcessModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SuperviseProcessModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SuperviseProcessModel>("from SuperviseProcessModel");
                    }
                    else
                    {
                        list = db.Query<SuperviseProcessModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(SuperviseProcessData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = new object[]{ hql };
                    //CacheHelper.Add(cacheClassKey + "_GetList_" + hql, list, refreshAction);
                    //}
                }
            }
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SuperviseProcessModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
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
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
            }

            return isResult;
        }

        #endregion

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="dbId"></param>
        public void DeleteJobs(string dbId)
        {
            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
            {
                db.DeleteByQuery("from SuperviseProcessModel where DBID='" + dbId + "'");
            }
        }

        /// <summary>
        /// 获取任务进度
        /// </summary>
        /// <param name="dbId"></param>
        public decimal GetProcess(string dbId,string yqsbsj)
        {
            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
            {
                IList<SuperviseProcessModel> list = GetList("from SuperviseProcessModel where DBID='"+dbId+"' and YQSBSJ='"+yqsbsj+"'");
                //取人员上报的最大值的平均值     
                if (list.Count > 0)
                    return list.Select(s => s.DQJD).Average();
                else
                    return 0;
            }
        }

        /// <summary>
        /// 获取我的ID清单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetMyIdList(int userId)
        {
            List<string> list = new List<string>();
            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
            {
                string sql = "select distinct(t.dbid) as dbid from common_supervise_process t where t.blrid='" + userId+"'";          
                System.Data.DataSet ds =  db.ExecuteDataset(sql, null);
                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr[0].ToString());
                }
            }
            return list;
        }


        public List<string> GetMyChargeList(int userId)
        {
             List<string> list = new List<string>();
            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
            {
                string sql = "select dbid from common_supervise_info where fzld=" + userId;           
                System.Data.DataSet ds =  db.ExecuteDataset(sql, null);
                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr[0].ToString());
                }
            }
            return list;
            
        }
    }
}
