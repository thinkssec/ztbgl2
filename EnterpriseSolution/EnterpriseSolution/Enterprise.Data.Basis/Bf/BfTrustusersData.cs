using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  BfTrustusersData.cs
    /// 功能描述: 数据层-事务代办表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-26 15:29:32
    /// </summary>
    public class BfTrustusersData : IBfTrustusersData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfTrustusersData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfTrustusersModel> GetList()
        {
            IList<BfTrustusersModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfTrustusersModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfTrustusersData> db = new ORMDataAccess<BfTrustusersData>())
                {
                    list = db.Query<BfTrustusersModel>("from BfTrustusersModel p where p.BF_TRUSTSTATUS='1'");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfTrustusersData), true);
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
        public IList<BfTrustusersModel> GetListByHQL(string hql)
        {
            IList<BfTrustusersModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfTrustusersModel>)CacheHelper.GetCache(cacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfTrustusersData> db = new ORMDataAccess<BfTrustusersData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<BfTrustusersModel>("from BfTrustusersModel p where p.BF_TRUSTSTATUS='1'");
                    }
                    else
                    {
                        list = db.Query<BfTrustusersModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfTrustusersData), true);
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
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfTrustusersModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfTrustusersData> db = new ORMDataAccess<BfTrustusersData>())
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
