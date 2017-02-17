using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Vote;

namespace Enterprise.Data.Common.Vote
{

    /// <summary>
    /// 文件名:  VoteItemData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/1 10:30:49
    /// </summary>
    public class VoteItemData : IVoteItemData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(VoteItemData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<VoteItemModel> GetList()
        {
            IList<VoteItemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<VoteItemModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<VoteItemData> db = new ORMDataAccess<VoteItemData>())
                {
                    list = db.Query<VoteItemModel>("from VoteItemModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(VoteItemData), true);
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
        public IList<VoteItemModel> GetList(string hql)
        {
            IList<VoteItemModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<VoteItemData> db = new ORMDataAccess<VoteItemData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<VoteItemModel>("from VoteItemModel");
                    }
                    else
					{
						list = db.Query<VoteItemModel>(hql);
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
        public bool Execute(VoteItemModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<VoteItemData> db = new ORMDataAccess<VoteItemData>())
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
