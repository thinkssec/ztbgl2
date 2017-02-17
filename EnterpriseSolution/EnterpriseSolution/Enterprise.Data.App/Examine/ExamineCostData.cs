using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Examine;

namespace Enterprise.Data.App.Examine
{

    /// <summary>
    /// 文件名:  ExamineCostData.cs
    /// 功能描述: 数据层-成本科目表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-11-7 14:36:26
    /// </summary>
    public class ExamineCostData : IExamineCostData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ExamineCostData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostModel> GetList()
        {
            IList<ExamineCostModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ExamineCostModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExamineCostData> db = new ORMDataAccess<ExamineCostData>())
                {
                    list = db.Query<ExamineCostModel>("from ExamineCostModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ExamineCostData), false);
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
        public IList<ExamineCostModel> GetListByHQL(string hql)
        {
            IList<ExamineCostModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ExamineCostModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExamineCostData> db = new ORMDataAccess<ExamineCostData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ExamineCostModel>("from ExamineCostModel");
			}
			else
			{
				list = db.Query<ExamineCostModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////数据存入缓存系统
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ExamineCostData), false);
	                    //refreshAction.ConstuctParms = null;
	                    //refreshAction.MethodName = "GetList";
	                    //refreshAction.Parameters = new object[]{ hql };
	                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
			    //}
                }
            }
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineCostModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExamineCostData> db = new ORMDataAccess<ExamineCostData>())
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
