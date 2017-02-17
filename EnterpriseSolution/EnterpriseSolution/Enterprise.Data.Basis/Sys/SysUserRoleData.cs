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
    /// 文件名:  SysUserRoleData.cs
    /// 功能描述: 数据层-用户角色表数据访问方法实现类
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysUserRoleData:ISysUserRoleData
    {
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(SysUserRoleData).ToString();

        /// <summary>
        /// 数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserRoleModel> GetList()
        {
            IList<SysUserRoleModel> list = null;
            using (ORMDataAccess<SysUserRoleData> db = new ORMDataAccess<SysUserRoleData>())
            {
                list = db.Query<SysUserRoleModel>("from SysUserRoleModel");
            }
            return list;
        }

        /// <summary>
        /// 操作方法
        /// </summary>
        /// <param name="t">实体类</param>
        /// <returns></returns>
        public bool Execute(SysUserRoleModel t)
        {
            bool isResult = true;
            using (ORMDataAccess<SysUserRoleData> db = new ORMDataAccess<SysUserRoleData>())
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
            return isResult;
        }

        #region ISysUserRoleData 成员

        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<SysUserRoleModel> GetListByHQL(string hql)
        {
            IList<SysUserRoleModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SysUserroleModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysUserRoleData> db = new ORMDataAccess<SysUserRoleData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SysUserRoleModel>("from SysUserroleModel");
                    }
                    else
                    {
                        list = db.Query<SysUserRoleModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(SysUserroleData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetListByHQL";
                    //refreshAction.Parameters = new object[]{ hql };
                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    //}
                }
            }
            return list;
        }


        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SysUserRoleModel> GetListBySQL(string sql)
        {
            IList<SysUserRoleModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysUserRoleModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysUserRoleData> db = new ORMDataAccess<SysUserRoleData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<SysUserRoleModel>(sql, typeof(SysUserRoleModel));

                        if (WebKeys.EnableCaching)
                        {
                            //数据存入缓存系统
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(SysUserRoleData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetListBySQL";
                            refreshAction.Parameters = new object[] { sql };
                            CacheHelper.Add(CacheClassKey + "_GetListBySQL_" + sql, list, refreshAction);
                        }
                    }
                }
            }
            return list;
        }

        #endregion
    }
}
