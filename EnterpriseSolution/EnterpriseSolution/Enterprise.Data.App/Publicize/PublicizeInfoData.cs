using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Publicize;

namespace Enterprise.Data.App.Publicize
{

    /// <summary>
    /// 文件名:  PublicizeInfoData.cs
    /// 功能描述: 数据层-宣传报道投稿数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2014/2/8 10:32:28
    /// </summary>
    public class PublicizeInfoData : IPublicizeInfoData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(PublicizeInfoData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeInfoModel> GetList()
        {
            IList<PublicizeInfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<PublicizeInfoModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<PublicizeInfoData> db = new ORMDataAccess<PublicizeInfoData>())
                {
                    list = db.Query<PublicizeInfoModel>("from PublicizeInfoModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(PublicizeInfoData), false);
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
        public IList<PublicizeInfoModel> GetListByHQL(string hql)
        {
            IList<PublicizeInfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<PublicizeInfoModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<PublicizeInfoData> db = new ORMDataAccess<PublicizeInfoData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<PublicizeInfoModel>("from PublicizeInfoModel");
			}
			else
			{
				list = db.Query<PublicizeInfoModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////数据存入缓存系统
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(PublicizeInfoData), false);
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
        public IList<PublicizeInfoModel> GetListBySQL(string sql)
        {
            IList<PublicizeInfoModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<PublicizeInfoModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<PublicizeInfoData> db = new ORMDataAccess<PublicizeInfoData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<PublicizeInfoModel>(sql, typeof(PublicizeInfoModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(PublicizeInfoData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetListBySQL";
                            refreshAction.Parameters = new object[] { sql };
                            CacheHelper.Add(CacheClassKey + "_GetListBySQL_" + sql, list, refreshAction);
                        }
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
        public bool Execute(PublicizeInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<PublicizeInfoData> db = new ORMDataAccess<PublicizeInfoData>())
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
