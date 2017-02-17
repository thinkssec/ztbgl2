using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{

    /// <summary>
    /// 文件名:  DocumentOfficialData.cs
    /// 功能描述: 数据层-公文表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2015/4/22 16:23:52
    /// </summary>
    public class DocumentOfficialData : IDocumentOfficialData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(DocumentOfficialData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentOfficialModel> GetList()
        {
            IList<DocumentOfficialModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<DocumentOfficialModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentOfficialData> db = new ORMDataAccess<DocumentOfficialData>())
                {
                    list = db.Query<DocumentOfficialModel>("from DocumentOfficialModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(DocumentOfficialData), false);
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
        public IList<DocumentOfficialModel> GetListByHQL(string hql)
        {
            IList<DocumentOfficialModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<DocumentOfficialModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentOfficialData> db = new ORMDataAccess<DocumentOfficialData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<DocumentOfficialModel>("from DocumentOfficialModel");
			}
			else
			{
				list = db.Query<DocumentOfficialModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////数据存入缓存系统
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(DocumentOfficialData), false);
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
        public IList<DocumentOfficialModel> GetListBySQL(string sql)
        {
            IList<DocumentOfficialModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<DocumentOfficialModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocumentOfficialData> db = new ORMDataAccess<DocumentOfficialData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<DocumentOfficialModel>(sql, typeof(DocumentOfficialModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(DocumentOfficialData), false);
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
        public bool Execute(DocumentOfficialModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<DocumentOfficialData> db = new ORMDataAccess<DocumentOfficialData>())
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
