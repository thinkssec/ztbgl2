using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Data.Common.Webmail
{

    /// <summary>
    /// 文件名:  WebmailInboxerrorData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/18 9:28:02
    /// </summary>
    public class WebmailInboxerrorData : IWebmailInboxerrorData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(WebmailInboxerrorData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<WebmailInboxerrorModel> GetList()
        {
            IList<WebmailInboxerrorModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<WebmailInboxerrorModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailInboxerrorData> db = new ORMDataAccess<WebmailInboxerrorData>())
                {
                    list = db.Query<WebmailInboxerrorModel>("from WebmailInboxerrorModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(WebmailInboxerrorData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailInboxerrorModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<WebmailInboxerrorData> db = new ORMDataAccess<WebmailInboxerrorData>())
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


        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="hql"></param>
        /// <returns></returns>
        public IList<WebmailInboxerrorModel> GetList(string hql)
        {
            IList<WebmailInboxerrorModel> list = null;

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailInboxerrorData> db = new ORMDataAccess<WebmailInboxerrorData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<WebmailInboxerrorModel>("from WebmailInboxerrorModel");
                    }
                    else
                    {
                        list = db.Query<WebmailInboxerrorModel>(hql);
                    }
                }
            }
            return list;
        }
    }
}
