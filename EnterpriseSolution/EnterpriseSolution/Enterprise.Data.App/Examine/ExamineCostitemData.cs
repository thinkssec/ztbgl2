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
    /// 文件名:  ExamineCostitemData.cs
    /// 功能描述: 数据层-成本费用项目表数据访问方法实现类
    /// 创建人：代码生成器
    /// 创建时间 ：2013-11-7 14:36:27
    /// </summary>
    public class ExamineCostitemData : IExamineCostitemData
    {
        #region 代码生成器
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ExamineCostitemData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostitemModel> GetList()
        {
            IList<ExamineCostitemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ExamineCostitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExamineCostitemData> db = new ORMDataAccess<ExamineCostitemData>())
                {
                    list = db.Query<ExamineCostitemModel>("from ExamineCostitemModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ExamineCostitemData), false);
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
        public IList<ExamineCostitemModel> GetListByHQL(string hql)
        {
            IList<ExamineCostitemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ExamineCostitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExamineCostitemData> db = new ORMDataAccess<ExamineCostitemData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ExamineCostitemModel>("from ExamineCostitemModel");
                    }
                    else
                    {
                        list = db.Query<ExamineCostitemModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ExamineCostitemData), false);
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
        public bool Execute(ExamineCostitemModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExamineCostitemData> db = new ORMDataAccess<ExamineCostitemData>())
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
