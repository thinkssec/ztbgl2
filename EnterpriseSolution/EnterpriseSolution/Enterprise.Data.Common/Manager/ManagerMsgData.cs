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
    /// 文件名:  ManagerMsgData.cs
    /// 功能描述: 数据层-领导信箱数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/27 17:55:12
    /// </summary>
    public class ManagerMsgData : IManagerMsgData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ManagerMsgData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgModel> GetList()
        {
            IList<ManagerMsgModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ManagerMsgModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ManagerMsgData> db = new ORMDataAccess<ManagerMsgData>())
                {
                    list = db.Query<ManagerMsgModel>("from ManagerMsgModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ManagerMsgData), true);
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
        public IList<ManagerMsgModel> GetList(string hql)
        {
            IList<ManagerMsgModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ManagerMsgData> db = new ORMDataAccess<ManagerMsgData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<ManagerMsgModel>("from ManagerMsgModel");
                    }
                    else
					{
						list = db.Query<ManagerMsgModel>(hql);
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
        public bool Execute(ManagerMsgModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ManagerMsgData> db = new ORMDataAccess<ManagerMsgData>())
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
