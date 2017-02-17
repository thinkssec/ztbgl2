using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Component.Cache;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysUserData.cs
    /// 功能描述: 数据层-用户表数据访问方法实现类
    /// 创建人：qw
    /// 创建日期: 2013.1.21
    /// </summary>
    public class SysUserData : ISysUserData
    {
        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SysUserData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserModel> GetList()
        {
            IList<SysUserModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysUserModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysUserData> db = new ORMDataAccess<SysUserData>())
                {
                    list = db.Query<SysUserModel>("from SysUserModel");
                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction = new CacheItemRefreshAction(typeof(SysUserData), true);
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
        /// 获取部门数据集合
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public IList<SysUserModel> GetListByDeptId(int deptId)
        {
            IList<SysUserModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysUserModel>)CacheHelper.GetCache(cacheClassKey + "_GetListByDeptId_" + deptId);
            }
            using (ORMDataAccess<SysUserData> db = new ORMDataAccess<SysUserData>())
            {
                list = db.Query<SysUserModel>("from SysUserModel c where c.DEPTID=" + deptId);
                if (WebKeys.EnableCaching)
                {
                    //数据存入缓存系统
                    CacheItemRefreshAction refreshAction = new CacheItemRefreshAction(typeof(SysUserData), true);
                    refreshAction.ConstuctParms = null;
                    refreshAction.MethodName = "GetListByDeptId";
                    refreshAction.Parameters = new object[] { deptId };
                    CacheHelper.Add(cacheClassKey + "_GetListByDeptId_" + deptId, list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysUserModel model)
        {
            bool isResult = true;
            using (ORMDataAccess<SysUserData> db = new ORMDataAccess<SysUserData>())
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

        /// <summary>
        /// 获取查询数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSetBySQL(string sql)
        {
            DataSet ds = null;
            using (ORMDataAccess<SysUserData> db = new ORMDataAccess<SysUserData>())
            {
                ds = db.ExecuteDataset(sql, null);
            }

            return ds;
        }

        /// <summary>
        /// 获取用户部门组织关系
        /// </summary>
        /// <returns></returns>
        public DataSet GetRelationForCombox()
        {
            DataSet ds = null;

            if (WebKeys.EnableCaching)
            {
                ds = (DataSet)CacheHelper.GetCache(cacheClassKey + "_GetRelationForCombox");
            }

            if (ds == null || ds.Tables.Count == 0)
            {

                using (ORMDataAccess<SysUserDutyData> db = new ORMDataAccess<SysUserDutyData>())
                {
                    string sql = @"select * from (
select 'd-'||to_char(a.deptid) as cid, a.dname as text ,'d-'||a.dparentid as parentid , a.dorderby as orderby from basis_sys_department a
                union
            (select to_char(b.userid) as cid,b.uname as text ,'d-'||to_char(b.deptid) as parentid, b.uorderby as orderby  from basis_sys_user  b)
            ) where cid>'1' order by orderby asc";

                    ds = db.ExecuteDataset(sql, null);

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction = new CacheItemRefreshAction(typeof(SysUserData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetRelationForCombox";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(cacheClassKey + "_GetRelationForCombox", ds, refreshAction);
                    }
                }
            }

            return ds;
        }

        /// <summary>
        /// 查询有职务的人员
        /// </summary>
        /// <returns></returns>
        public DataSet GetRelationForCombox_Zhiwu()
        {
            DataSet ds = null;

            if (WebKeys.EnableCaching)
            {
                ds = (DataSet)CacheHelper.GetCache(cacheClassKey + "_GetRelationForCombox_Zhiwu");
            }

            if (ds == null || ds.Tables.Count == 0)
            {

                using (ORMDataAccess<SysUserDutyData> db = new ORMDataAccess<SysUserDutyData>())
                {
                    string sql = @"select * from (
select 'd-'||to_char(a.deptid) as cid, a.dname as text ,'d-'||a.dparentid as parentid , a.dorderby as orderby,'' as dname from basis_sys_department a
                union
            (select to_char(b.userid) as cid,b.uname as text ,'d-'||to_char(b.deptid) as parentid, b.uorderby as orderby,g.dname  from basis_sys_user  b,basis_sys_userduty f,basis_sys_duty g 
            where f.userid=b.userid and f.dutyid=g.dutyid)
            ) where cid>'1' order by orderby asc";

                    ds = db.ExecuteDataset(sql, null);

                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction = new CacheItemRefreshAction(typeof(SysUserData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetRelationForCombox_Zhiwu";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(cacheClassKey + "_GetRelationForCombox_Zhiwu", ds, refreshAction);
                    }
                }
            }

            return ds;
        }

    }
}
