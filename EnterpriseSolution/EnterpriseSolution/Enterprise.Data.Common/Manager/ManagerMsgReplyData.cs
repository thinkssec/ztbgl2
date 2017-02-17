using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Manager;

namespace Enterprise.Data.Common.Manager
{

    /// <summary>
    /// 文件名:  ManagerMsgreplyData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/27 17:55:12
    /// </summary>
    public class ManagerMsgReplyData : IManagerMsgReplyData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ManagerMsgReplyData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgReplyModel> GetList()
        {
            IList<ManagerMsgReplyModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ManagerMsgreplyModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ManagerMsgReplyData> db = new ORMDataAccess<ManagerMsgReplyData>())
                {
                    list = db.Query<ManagerMsgReplyModel>("from ManagerMsgReplyModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ManagerMsgreplyData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<ManagerMsgReplyModel> GetList(string hql)
        {
            IList<ManagerMsgReplyModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ManagerMsgReplyData> db = new ORMDataAccess<ManagerMsgReplyData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<ManagerMsgReplyModel>("from ManagerMsgReplyModel");
                    }
                    else
					{
                        list = db.Query<ManagerMsgReplyModel>(hql);
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
        public bool Execute(ManagerMsgReplyModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ManagerMsgReplyData> db = new ORMDataAccess<ManagerMsgReplyData>())
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

            //清空相关的缓存
            CacheHelper.RemoveCacheForClassKey(cacheClassKey);

            return isResult;
        }

        #endregion
    }
}
