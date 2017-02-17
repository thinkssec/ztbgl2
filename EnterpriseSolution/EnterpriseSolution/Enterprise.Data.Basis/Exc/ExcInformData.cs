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
    /// 文件名:  ExcInformData.cs
    /// 功能描述: 数据层-异常通知单数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:19:28
    /// </summary>
    public class ExcInformData : IExcInformData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcInformData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcInformModel> GetList()
        {
            IList<ExcInformModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ExcInformModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcInformData> db = new ORMDataAccess<ExcInformData>())
                {
                    list = db.Query<ExcInformModel>("from ExcInformModel");
                    
                    //数据存入缓存系统
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ExcInformData), true);
                    refreshAction.ConstuctParms = null;
                    refreshAction.MethodName = "GetList";
                    refreshAction.Parameters = null;//new object[]{};
                    CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcInformModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcInformData> db = new ORMDataAccess<ExcInformData>())
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
