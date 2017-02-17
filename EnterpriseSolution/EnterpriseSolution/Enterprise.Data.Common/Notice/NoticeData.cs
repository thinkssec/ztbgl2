using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Notice;
using Enterprise.Component.Cache;
namespace Enterprise.Data.Common.Notice
{
    /// <summary>
    /// 文件名:  NoticeData.cs
    /// 功能描述: 数据层-个人备忘数据访问方法实现类
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class NoticeData:INoticeData
    {

        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(NoticeData).ToString();

        /// <summary>
        /// 个人备忘数据集合
        /// </summary>
        /// <returns></returns>
        public IList<NoticeModel> GetList()
        {
            IList<NoticeModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<NoticeModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<NoticeData> db = new ORMDataAccess<NoticeData>())
                {
                    list = db.Query<NoticeModel>("from NoticeModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction = new CacheItemRefreshAction(typeof(NoticeData), false);
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
        /// 个人备忘操作方法
        /// </summary>
        /// <param name="t">方法类</param>
        /// <returns></returns>
        public bool Execute(NoticeModel t)
        {
            bool isResult = true;
            using (ORMDataAccess<NoticeData> db = new ORMDataAccess<NoticeData>())
            {
                if (t.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(t);
                }
                else if (t.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(t);
                }
                else if (t.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(t);
                }

                if (WebKeys.EnableCaching)
                {
                    //清空相关的缓存
                    CacheHelper.RemoveCacheForClassKey(cacheClassKey);
                }
            }
            return isResult;
        }


        /// <summary>
        /// 个人备忘操作方法（批量更新状态）
        /// </summary>
        /// <param name="modelLst">对象集合</param>
        /// <returns></returns>
        public bool UpdateStatus(IList<NoticeModel> modelLst)
        {
            bool isResult = true;
            using (ORMDataAccess<NoticeData> db = new ORMDataAccess<NoticeData>())
            {
                foreach (NoticeModel model in modelLst)
                {
                    model.NREMINDTYPE = "已提醒";
                    model.NCREATETIME = DateTime.Now;
                    db.Update(model);
                }

                if (WebKeys.EnableCaching)
                {
                    //清空相关的缓存
                    CacheHelper.RemoveCacheForClassKey(cacheClassKey);
                }
            }
            return isResult;
        }


        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<NoticeModel> GetList(string hql)
        {
            IList<NoticeModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<NoticeModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            }
            using (ORMDataAccess<NoticeData> db = new ORMDataAccess<NoticeData>())
            {
                if (string.IsNullOrEmpty(hql))
                {
                    list = db.Query<NoticeModel>("from NoticeModel");
                }
                else
                {
                    list = db.Query<NoticeModel>(hql);
                }

                if (WebKeys.EnableCaching)
                {
                    //数据存入缓存系统
                    CacheItemRefreshAction refreshAction = new CacheItemRefreshAction(typeof(NoticeData), false);
                    refreshAction.ConstuctParms = null;
                    refreshAction.MethodName = "GetList";
                    refreshAction.Parameters = new object[] { hql };
                    CacheHelper.Add(cacheClassKey + "_GetList_" + hql, list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取指定ID的记录
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public NoticeModel GetModelById(int bid)
        {
            return GetList("from NoticeModel p where p.NOTEID = " + bid + "").FirstOrDefault();
        }

    }
}
