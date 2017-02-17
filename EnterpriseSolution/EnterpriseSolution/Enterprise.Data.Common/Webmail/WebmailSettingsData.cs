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
    /// 文件名:  WebmailSettingsData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/18 9:28:04
    /// </summary>
    public class WebmailSettingsData : IWebmailSettingsData
    {
        #region '代码生成器'
        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(WebmailSettingsData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<WebmailSettingsModel> GetList()
        {
            IList<WebmailSettingsModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<WebmailSettingsModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailSettingsData> db = new ORMDataAccess<WebmailSettingsData>())
                {
                    list = db.Query<WebmailSettingsModel>("from WebmailSettingsModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(WebmailSettingsData), true);
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
        public IList<WebmailSettingsModel> GetList(string hql)
        {
            IList<WebmailSettingsModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailSettingsData> db = new ORMDataAccess<WebmailSettingsData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<WebmailSettingsModel>("from WebmailSettingsModel");
                    }
                    else
                    {
                        list = db.Query<WebmailSettingsModel>(hql);
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
        public bool Execute(WebmailSettingsModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<WebmailSettingsData> db = new ORMDataAccess<WebmailSettingsData>())
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

        public IList<WebmailSettingsModel> GetListByUserId(int userId)
        {
            IList<WebmailSettingsModel> list = null;
            using (ORMDataAccess<WebmailSettingsData> db = new ORMDataAccess<WebmailSettingsData>())
            {
                list = db.Query<WebmailSettingsModel>("from WebmailSettingsModel c where c.USERID='" + userId + "'");
            }
            return list;
        }        
    }
}
