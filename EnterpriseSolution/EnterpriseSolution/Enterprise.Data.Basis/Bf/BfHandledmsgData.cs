using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Bf;
using Enterprise.Component.Cache;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  BfHandledmsgData.cs
    /// 功能描述: 数据层-业务流已处理消息表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:53
    /// </summary>
    public class BfHandledmsgData : IBfHandledmsgData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfHandledmsgData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfHandledmsgModel> GetList()
        {
            IList<BfHandledmsgModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<BfHandledmsgModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfHandledmsgData> db = new ORMDataAccess<BfHandledmsgData>())
                {
                    list = db.Query<BfHandledmsgModel>("from BfHandledmsgModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //    new CacheItemRefreshAction(typeof(BfHandledmsgData), true);
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
        public bool Execute(BfHandledmsgModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfHandledmsgData> db = new ORMDataAccess<BfHandledmsgData>())
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

    }
}
