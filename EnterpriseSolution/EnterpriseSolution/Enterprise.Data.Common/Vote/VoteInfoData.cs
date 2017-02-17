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
    /// 文件名:  VoteInfoData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/1 10:30:49
    /// </summary>
    public class VoteInfoData : IVoteInfoData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(VoteInfoData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<VoteInfoModel> GetList()
        {
            IList<VoteInfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<VoteInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<VoteInfoData> db = new ORMDataAccess<VoteInfoData>())
                {
                    list = db.Query<VoteInfoModel>("from VoteInfoModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(VoteInfoData), true);
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
        public IList<VoteInfoModel> GetList(string hql)
        {
            IList<VoteInfoModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<VoteInfoData> db = new ORMDataAccess<VoteInfoData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<VoteInfoModel>("from VoteInfoModel");
                    }
                    else
					{
						list = db.Query<VoteInfoModel>(hql);
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
        public bool Execute(VoteInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<VoteInfoData> db = new ORMDataAccess<VoteInfoData>())
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
