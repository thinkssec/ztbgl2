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
    /// 文件名:  WebmailInboxData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/18 9:28:01
    /// </summary>
    public class WebmailInboxData : IWebmailInboxData
    {
        #region '代码生成器'
        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(WebmailInboxData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetList()
        {
            IList<WebmailInboxModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<WebmailInboxModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
                {
                    list = db.Query<WebmailInboxModel>("from WebmailInboxModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(WebmailInboxData), true);
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
        public IList<WebmailInboxModel> GetList(string hql)
        {
            IList<WebmailInboxModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<WebmailInboxModel>("from WebmailInboxModel");
                    }
                    else
                    {
                        list = db.Query<WebmailInboxModel>(hql);
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
        public bool Execute(WebmailInboxModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
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

        #region '扩展方法'
        /// <summary>
        /// 获取收件箱中的一个邮件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetListById(string Id)
        {
            IList<WebmailInboxModel> list = null;
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                list = db.Query<WebmailInboxModel>("from WebmailInboxModel c where c.MESSAGEID='" + Id + "'");
            }
            return list;
        }

        /// <summary>
        /// 获取收件箱中的一个邮件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetListByEmail(string email)
        {
            IList<WebmailInboxModel> list = null;
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                list = db.Query<WebmailInboxModel>("from WebmailInboxModel c where c.EMAIL='" + email + "'");
            }
            return list;
        }

        /// <summary>
        /// 删除多个邮件
        /// Sorry 不用SQL不知道怎么写
        /// </summary>
        /// <param name="messageIds"></param>
        public void SetDelelted(List<string> messageIds)
        {
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                db.ExecuteNonQuery("update common_webmail_inbox set isdelete=1 where messageid in " + messageIds.ToInSQLString(), null);
            }
        }


        /// <summary>
        /// 将多个邮件标记为已读
        /// </summary>
        /// <param name="messageIds"></param>
        public void SetReaded(List<string> messageIds)
        {
            using (ORMDataAccess<WebmailInboxData> db = new ORMDataAccess<WebmailInboxData>())
            {
                db.ExecuteNonQuery("update common_webmail_inbox set readed=1 where messageid in " + messageIds.ToInSQLString(), null);      
            }
        }

        #endregion


        /// <summary>
        /// 发送新邮件到达通知给用户
        /// </summary>
        public void SendNoticeToUsers()
        {
            
        }
    }
}
