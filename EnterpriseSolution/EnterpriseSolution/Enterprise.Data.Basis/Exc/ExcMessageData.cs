using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Exc;
using Enterprise.Component.Cache;

namespace Enterprise.Data.Basis.Exc
{

    /// <summary>
    /// 文件名:  ExcMessageData.cs
    /// 功能描述: 数据层-即时消息发送表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:19:28
    /// </summary>
    public class ExcMessageData : IExcMessageData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcMessageData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcMessageModel> GetList()
        {
            IList<ExcMessageModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ExcMessageModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcMessageData> db = new ORMDataAccess<ExcMessageData>())
                {
                    list = db.Query<ExcMessageModel>("from ExcMessageModel");

                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ExcMessageData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取指定的记录
        /// </summary>
        /// <returns></returns>
        public ExcMessageModel GetModelById(string Id)
        {
            ExcMessageModel model = null;

            using (ORMDataAccess<ExcMessageData> db = new ORMDataAccess<ExcMessageData>())
            {
                model = db.Query<ExcMessageModel>(
                    "from ExcMessageModel p where p.EXC_MSGID='" + Id + "'").FirstOrDefault();
            }

            return model;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcMessageModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcMessageData> db = new ORMDataAccess<ExcMessageData>())
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

    }
}
