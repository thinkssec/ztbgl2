using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Meeting;

namespace Enterprise.Data.Common.Meeting
{

    /// <summary>
    /// 文件名:  MeetingRecevieData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/1 15:50:38
    /// </summary>
    public class MeetingRecevieData : IMeetingRecevieData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(MeetingRecevieData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetList()
        {
            IList<MeetingRecevieModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<MeetingRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<MeetingRecevieData> db = new ORMDataAccess<MeetingRecevieData>())
                {
                    list = db.Query<MeetingRecevieModel>("from MeetingRecevieModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(MeetingRecevieData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="hql">Nhibernate HQL,如果hql为空 返回所有数据</param>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetListByHQL(string hql)
        {
            IList<MeetingRecevieModel> list = null;

            if (WebKeys.EnableCaching)
            {
                list = (IList<MeetingRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetListByHQL_" + hql);
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<MeetingRecevieData> db = new ORMDataAccess<MeetingRecevieData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<MeetingRecevieModel>("from MeetingRecevieModel");
                    }
                    else
                    {
                        list = db.Query<MeetingRecevieModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(MeetingRecevieData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetListByHQL";
                        refreshAction.Parameters = new object[] { hql };
                        CacheHelper.Add(cacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    }
                }
            }

            return list;
        }


        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetList(string hql)
        {
            IList<MeetingRecevieModel> list = GetListByHQL(hql);
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(MeetingRecevieModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<MeetingRecevieData> db = new ORMDataAccess<MeetingRecevieData>())
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
    }
}
