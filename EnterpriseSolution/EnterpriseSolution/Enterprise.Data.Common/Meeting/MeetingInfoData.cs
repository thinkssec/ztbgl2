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
    /// 文件名:  MeetingInfoData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/1 15:50:38
    /// </summary>
    public class MeetingInfoData : IMeetingInfoData
    {
        #region 代码生成器

		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(MeetingInfoData).ToString();

        //同步
        private static object _synRoot = new Object();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<MeetingInfoModel> GetList()
        {
            IList<MeetingInfoModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<MeetingInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<MeetingInfoData> db = new ORMDataAccess<MeetingInfoData>())
                {
                    list = db.Query<MeetingInfoModel>("from MeetingInfoModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(MeetingInfoData), false);
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
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<MeetingInfoModel> GetList(string hql)
        {
            IList<MeetingInfoModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<MeetingInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<MeetingInfoData> db = new ORMDataAccess<MeetingInfoData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<MeetingInfoModel>("from MeetingInfoModel");
                    }
                    else
                    {
                        list = db.Query<MeetingInfoModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(MeetingInfoData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = new object[]{ hql };
                        CacheHelper.Add(cacheClassKey + "_GetList_" + hql, list, refreshAction);
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
        public bool Execute(MeetingInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<MeetingInfoData> db = new ORMDataAccess<MeetingInfoData>())
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


        /// <summary>
        /// 生成会议ID
        /// </summary>
        /// <returns></returns>
        public int GetMeeting_ID()
        {
            lock (_synRoot)
            {
                int amount = 0;
                string sql =
                    "select max(meetingid) from common_meeting_info";
                using (ORMDataAccess<MeetingInfoData> db = new ORMDataAccess<MeetingInfoData>())
                {
                    object rr = db.ScalarBySQL(sql);
                    if (rr != null)
                    {
                        int.TryParse(rr.ToString(), out amount);
                    }
                }
                amount++;//自增
                return amount;
            }
        }

        #endregion
    }
}
