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
    /// 文件名:  SysRoleData.cs
    /// 功能描述: 数据层-角色权限表数据访问方法实现类
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysRolePermissionData:ISysRolePermissionData
    {

        /// <summary>
        /// 缓存项名称
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(SysRolePermissionData).ToString();

        /// <summary>
        /// 数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysRolePermissionModel> GetList()
        {
            IList<SysRolePermissionModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysRolePermissionModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysRolePermissionData> db = new ORMDataAccess<SysRolePermissionData>())
                {
                    list = db.Query<SysRolePermissionModel>("from SysRolePermissionModel");
                    if (WebKeys.EnableCaching)
                    {
                        //数据存入缓存系统
                        CacheItemRefreshAction refreshAction = new CacheItemRefreshAction(typeof(SysRolePermissionData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 操作方法
        /// </summary>
        /// <param name="t">实体类</param>
        /// <returns></returns>
        public bool Execute(SysRolePermissionModel t)
        {
            bool isResult = true;
            using (ORMDataAccess<SysRolePermissionData> db = new ORMDataAccess<SysRolePermissionData>())
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
                else if (t.DB_Option_Action == WebKeys.DeleteAllAction)
                {
                    db.ExecuteNonQuery("delete from BASIS_SYS_ROLEPERMISSION where ROLEID=" + t.ROLEID, null);
                }
            }
            if (WebKeys.EnableCaching)
            {
                //清空相关的缓存
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
            }
            return isResult;
        }
    }
}
