using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;
//using System.Web.Caching;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysUserPermissionService.cs
    /// 功能描述: 业务逻辑层-用户权限
    /// 创建人：caitou
    /// 创建日期: 2013.1.21
    /// </summary>
    public class SysUserPermissionService
    {

        #region "用户权限"

        /// <summary>
        /// 根据用户ID,应用ID,PageCode判断用户是否拥有当前权限
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ApplicationID"></param>
        /// <param name="PageCode"></param>
        /// <returns></returns>
        public static bool CheckPageCode(int UserId, int ApplicationId, string PageCode)
        {
            SysUserService uService = new SysUserService();
            if (uService.Disp(UserId).UADMIN == 1)//判断用户是否为超级用户
                return true;

            bool bBool = false;
            Hashtable UserPermission = Get_UserPermission(UserId);
            if (UserPermission.Count > 0)
            {
                string Key = string.Format("{0}-{1}", ApplicationId, PageCode);
                if (UserPermission.ContainsKey(Key))
                {
                    bBool = true;
                }
            }
            return bBool;
        }

        /// <summary>
        /// 根据用户ID,应用ID,PageCode,要检测权限数值
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="ApplicationID">应用ID</param>
        /// <param name="PageCode">PageCode</param>
        /// <param name="CheckPermissionValue">权限值</param>
        /// <returns></returns>
        public static bool CheckPageCode(int UserId, int ApplicationId, string PageCode, int CheckPermissionValue)
        {
            SysUserService uService = new SysUserService();
            if (uService.Disp(UserId).UADMIN == 1)//判断用户是否为超级用户
                return true;

            bool rBool = false;
            Hashtable UserPermission = (Hashtable)Get_UserPermission(UserId);
            if (UserPermission.Count > 0)
            {
                string Key = string.Format("{0}-{1}", ApplicationId, PageCode);
                if (UserPermission.ContainsKey(Key))
                {
                    if ((((SysRolePermissionModel)UserPermission[Key]).PERMISSIONVALUE & CheckPermissionValue) == CheckPermissionValue)
                    {
                        rBool = true;
                    }
                }
            }

            return rBool;
        }

        /// <summary>
        /// 判断用户按钮权限
        /// </summary>
        /// <param name="PType"></param>
        /// <returns></returns>
        public static bool CheckButtonPermission(Utility.PopedomType PType)
        {
            //返回用户判断信息
            bool rBool = false;

            string pageCode = string.Empty;
            
            rBool = CheckCurrentUserPermission(PType, out pageCode);

            return rBool;
        }

        /// <summary>
        /// 检测权限(出提示框)
        /// </summary>
        /// <param name="PT"></param>
        public static void CheckPermissionVoid(Utility.PopedomType PT)
        {
            if (!CheckButtonPermission(PT))
            {
                HttpContext.Current.Response.Redirect(string.Format("/Error.aspx?msg={0}", "对不起，您还没有访问授权！"));
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 检测用户的权限并返回当前的模块编码
        /// </summary>
        /// <param name="PT">权限值</param>
        /// <param name="mcode">输出模块编码</param>
        /// <returns></returns>
        public static bool CheckCurrentUserPermission(Utility.PopedomType PT, out string mcode)
        {
            bool isOk = false;
            mcode = string.Empty;

            //是否超级用户
            int userId = Utility.Get_UserId;
            SysUserService uService = new SysUserService();
            if (uService.Disp(userId).UADMIN == 1 || Utility.GetScriptPathUrl.ToLower().IndexOf("/modules") == -1)
                return true;

            //1==提取当前用户的所有角色
            Hashtable mcodeList = Get_UserPermission(userId);//(Value==SysRolePermissionModel)
            //2==根据URL查找对应的模块信息（以文件名和目录名称分别查询）
            //提取所有模块信息
            SysModuleService moduleSrv = new SysModuleService();
            IList<SysModuleModel> moduleLst = moduleSrv.GetList();
            //3==获取当前路径对应的模块（先按全路径检索，否则再按目录检索）
            SysModuleModel currentModule = moduleLst.FirstOrDefault(p => 
                (!string.IsNullOrEmpty(p.MURL) && Utility.GetScriptUrl.ToLower().StartsWith(p.MURL.ToLower())) || 
                (!string.IsNullOrEmpty(p.MWEBURL) && Utility.GetScriptUrl.ToLower().StartsWith(p.MWEBURL.ToLower())));//按目录+文件名
            if (currentModule == null)
            {
                return true;


                //currentModule = moduleLst.Where(p => !string.IsNullOrEmpty(p.MURL) && 
                //    p.MURL.ToLower().StartsWith(Utility.GetScriptPathUrl.ToLower())).
                //    OrderByDescending(p => p.MCODE.Length).FirstOrDefault();//只按目录查找同一模块下的文件
                //if (currentModule == null)
                //    return false;


                ////没有匹配的文件，则采用上一级模块的权限
                //int parnetMCodeLen = currentModule.MCODE.Length - 3;
                //currentModule = moduleLst.Find(p => p.MCODE == currentModule.MCODE.Substring(0, parnetMCodeLen));
                //if (currentModule == null)
                //    return false;
            }
            
            //进行权限检测
            if (mcodeList.ContainsKey(string.Format("1-{0}", currentModule.MCODE)))
            {
                mcode = currentModule.MCODE;
                return CheckPageCode(userId, 1, currentModule.MCODE, (int)PT);
            }
            //add by qw 2013.7.4 start 增加对一级菜单的特殊处理，如企业文化
            else
            {
                string allowVisitMCODES = System.Configuration.ConfigurationManager.AppSettings["AllowVisit"];
                if (allowVisitMCODES.Contains(currentModule.MCODE + ","))
                {
                    isOk = true;
                }
            }
            //end

            return isOk;
        }


        /// <summary>
        /// 获取用户权限Hashtable
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public static Hashtable Get_UserPermission(int UserId)
        {
            string Key = string.Format("{2}_{1}-Permission-{0}", UserId, "Enterprise",SysRolePermissionData.CacheClassKey);
            //if (_UserPermissionCache[Key] != null)
            //{
            //    return (Hashtable)_UserPermissionCache[Key];
            //}
            if (CacheHelper.Contains(Key))
            {
                return (Hashtable)CacheHelper.GetCache(Key);
            }
            else
            {
                //根据用户Role取得模块权限列表
                Hashtable hashtable = (Hashtable)Get_RolePermissionTable(UserId);

                //_UserPermissionCache.Insert(Key, hashtable);
                //_UserPermissionCache.Insert(Key, hashtable, null,
                //    DateTime.Now.AddMinutes(WebKeys.CacheTimeout),
                //    System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);

                //数据存入缓存系统,没有过期策略
                CacheHelper.Add(Key, hashtable);

                return hashtable;
            }

        }

        /// <summary>
        /// 根据用户ID,获取用户模块权限列表
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        private static Hashtable Get_RolePermissionTable(int UserId)
        {
            Hashtable PageCodeList = new Hashtable();
            SysUserRoleService urSer = new SysUserRoleService();
            List<SysRolePermissionModel> list = new List<SysRolePermissionModel>();
            List<SysUserRoleModel> userRoleList =urSer.GetList().Where(p => p.USERID == UserId).ToList();
            SysRolePermissionService rpService = new SysRolePermissionService();
            foreach (SysUserRoleModel userRole in userRoleList)
            {
                List<SysRolePermissionModel> query = rpService.GetList().Where(p => p.ROLEID == userRole.ROLEID).ToList();
                list.AddRange(query);
            }
            foreach (SysRolePermissionModel rp in list)
            {
                string Key = string.Format("{0}-{1}", "1", rp.MCODE);
                if (PageCodeList.ContainsKey(Key))
                {
                    SysRolePermissionModel Rpt = (SysRolePermissionModel)PageCodeList[Key];
                    if (Rpt.PERMISSIONVALUE < rp.PERMISSIONVALUE)
                    {
                        PageCodeList[Key] = rp;
                    }
                }
                else
                {
                    PageCodeList.Add(Key, rp);
                }
            }
            return PageCodeList;

        }

        ///// <summary>
        ///// 移除用户权限Cache
        ///// </summary>
        ///// <param name="UserID">用户ID</param>
        //public static void Move_UserPermissionCache(int UserId)
        //{
        //    _UserPermissionCache.Remove(string.Format("{1}-Permission-{0}", UserId, "Enterprise"));
        //}

        ///// <summary>
        ///// 移除某个角色的用户权限Cache
        ///// 实现方法：通过RoleID遍历出所有的用户UserId，在循环删除各个UserId的_UserPermissionCache
        ///// </summary>
        ///// <param name="RoleID">角色ID</param>
        //public static void Move_RoleUserPermissionCache(int RoleId)
        //{
        //    SysUserRoleService urSer = new SysUserRoleService();
        //    var q =urSer.GetList().Where(p => p.ROLEID == RoleId);
        //    foreach (var var in q)
        //    {
        //        Move_UserPermissionCache(var.USERID);
        //    }
        //}
        #endregion
    }
}
