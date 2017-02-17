using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Component.Cache;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysDepartMentData.cs
    /// 功能描述: 数据层-部门表数据访问方法实现类
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysDepartMentData : ISysDepartMentData
    {

        /// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SysDepartMentData).ToString();

        /// <summary>
        /// 部门数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysDepartMentModel> GetList()
        {
            IList<SysDepartMentModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysDepartMentModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysDepartMentData> db = new ORMDataAccess<SysDepartMentData>())
                {
                    list = db.Query<SysDepartMentModel>("from SysDepartMentModel");

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(SysDepartMentData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 返回数据集合
        /// 按顺序号排序，并根据单位层级显示单位名称
        /// </summary>
        /// <returns></returns>
        public IList<SysDepartMentModel> GetTreeList()
        {
            IList<SysDepartMentModel> treeList = null;
            if (WebKeys.EnableCaching)
            {
                treeList = (IList<SysDepartMentModel>)CacheHelper.GetCache(cacheClassKey + "_GetTreeList");
            }
            if (treeList == null || treeList.Count == 0)
            {
                treeList = new List<SysDepartMentModel>();
                IList<SysDepartMentModel> list = GetList().OrderBy(p => p.DORDERBY).ToList();
                foreach (SysDepartMentModel deptM in list)
                {
                    SysDepartMentModel newDeptM = (SysDepartMentModel)CommonTool.Clone(deptM);
                    newDeptM.DNAME = CommonTool.GenerateBlankSpace(deptM.DDEPTH.ToInt()) + deptM.DNAME;
                    treeList.Add(newDeptM);
                }
                if (WebKeys.EnableCaching)
                {
                    //数据存入缓存系统
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(SysDepartMentData), false);
                    refreshAction.ConstuctParms = null;
                    refreshAction.MethodName = "GetTreeList";
                    refreshAction.Parameters = null;//new object[]{};
                    CacheHelper.Add(cacheClassKey + "_GetTreeList", treeList, refreshAction);
                }
            }
            return treeList;
        }

        /// <summary>
        /// 根据ID获取部门信息MODEL
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public SysDepartMentModel GetModelById(int deptId)
        {
            return GetList().Where(p => p.DEPTID == deptId).FirstOrDefault();
        }

        /// <summary>
        /// 操作方法
        /// </summary>
        /// <param name="t">实体类</param>
        /// <returns></returns>
        public bool Execute(SysDepartMentModel t)
        {
            bool isResult = true;
            using (ORMDataAccess<SysDepartMentData> db = new ORMDataAccess<SysDepartMentData>())
            {
                if (t.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(t);
                }
                else if (t.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(t);
                }
                else if (t.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(t);
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
