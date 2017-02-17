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
    /// 文件名:  ExcEmailData.cs
    /// 功能描述: 数据层-邮件发送表数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:19:24
    /// </summary>
    public class ExcEmailData : IExcEmailData
    {
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcEmailData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcEmailModel> GetList()
        {
            IList<ExcEmailModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ExcEmailModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcEmailData> db = new ORMDataAccess<ExcEmailData>())
                {
                    list = db.Query<ExcEmailModel>("from ExcEmailModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ExcEmailData), true);
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
        public ExcEmailModel GetModelById(string Id)
        {
            ExcEmailModel emailModel = null;

            using (ORMDataAccess<ExcEmailData> db = new ORMDataAccess<ExcEmailData>())
            {
                emailModel = db.Query<ExcEmailModel>(
                    "from ExcEmailModel p where p.EXC_EMAILID='" + Id + "'").FirstOrDefault();
            }

            return emailModel;
        }
        

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcEmailModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcEmailData> db = new ORMDataAccess<ExcEmailData>())
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
