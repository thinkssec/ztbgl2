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
    /// 文件名:  ProjectProfitData.cs
    /// 功能描述: 数据层-产值登记表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2013-11-5 15:48:22
    /// </summary>
    public class ProjectProfitData : IProjectProfitData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectProfitData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectProfitModel> GetList()
        {
            IList<ProjectProfitModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectProfitModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectProfitData> db = new ORMDataAccess<ProjectProfitData>())
                {
                    list = db.Query<ProjectProfitModel>("from ProjectProfitModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectProfitData), false);
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
        public IList<ProjectProfitModel> GetListByHQL(string hql)
        {
            IList<ProjectProfitModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectProfitModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectProfitData> db = new ORMDataAccess<ProjectProfitData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectProfitModel>("from ProjectProfitModel");
                    }
                    else
                    {
                        list = db.Query<ProjectProfitModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectProfitData), false);
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
        public bool Execute(ProjectProfitModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectProfitData> db = new ORMDataAccess<ProjectProfitData>())
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
                else if (model.DB_Option_Action == "DeleteByPROJIDAndCHECKDATE")
                {
                    var q = GetListByHQL("from ProjectProfitModel p where p.PROJID='" + model.PROJID 
                        + "' and to_char(p.CHECKDATE,'yyyy-MM-dd')='" 
                        + model.CHECKDATE.ToDateYMDFormat() + "'").FirstOrDefault();
                    if (q != null)
                    {
                        db.Delete(q);
                    }
                }
            }

            if (WebKeys.EnableCaching)
            {
                //清空相关的缓存
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
                CacheHelper.RemoveCacheForClassKey(ProjectDailyviewData.CacheClassKey);
            }
            return isResult;
        }

        #endregion
    }
}
