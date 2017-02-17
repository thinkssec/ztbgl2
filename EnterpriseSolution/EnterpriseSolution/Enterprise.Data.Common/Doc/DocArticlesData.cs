using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Doc;

namespace Enterprise.Data.Common.Doc
{

    /// <summary>
    /// 文件名:  DocArticlesData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/26 15:10:22
    /// </summary>
    public class DocArticlesData : IDocArticlesData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(DocArticlesData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocArticlesModel> GetList()
        {
            IList<DocArticlesModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<DocArticlesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocArticlesData> db = new ORMDataAccess<DocArticlesData>())
                {
                    list = db.Query<DocArticlesModel>("from DocArticlesModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(DocArticlesData), true);
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
        public IList<DocArticlesModel> GetList(string hql)
        {
            IList<DocArticlesModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocArticlesData> db = new ORMDataAccess<DocArticlesData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<DocArticlesModel>("from DocArticlesModel");
                    }
                    else
					{
						list = db.Query<DocArticlesModel>(hql);
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
        public bool Execute(DocArticlesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<DocArticlesData> db = new ORMDataAccess<DocArticlesData>())
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

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DocArticlesModel GetListById(int id)
        {
            return GetList("from DocArticlesModel c where c.ID=" + id).FirstOrDefault();
        }
    }
}
