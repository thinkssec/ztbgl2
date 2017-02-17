using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.BF;
using Enterprise.Model.Basis.Bf;
using Enterprise.Model.Basis.Sys;
using Enterprise.Model.Common.Busitravel;
using Enterprise.Service.Basis.Sys;
using Enterprise.Data.Common.Busitravel;

namespace Enterprise.Service.Common
{
	
    /// <summary>
    /// 文件名:  BFInstanceRoleSrv.cs
    /// 功能描述: 业务逻辑层-用于获取出差审批流程的各种角色用户
    /// 创建人：qw
	/// 创建时间 ：2013-2-24
    /// </summary>
    public partial class BFInstanceRoleSrv
    {
        
        #region 静态角色==职务角色

        /// <summary>
        /// 总裁
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetPresidencyUserId(BFNodeEventArgs<BfInstancesModel> e)
        {
            //总裁 == 公司领导 虚拟部门的分管领导
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(1);
            if (q != null)
            {
                return string.Format(",{0},", q.DHEADERMANAGER);
            }
            return "";
        }


        /// <summary>
        /// 人力资源部经理
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetHRManagerUserId(BFNodeEventArgs<BfInstancesModel> e)
        {
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(4);//人力资源部
            if (q != null)
            {
                return string.Format(",{0},", q.DMANAGER);
            }
            return "";
        }

        #endregion

        #region 动态角色

        /// <summary>
        /// 申请人
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetBusitravelSqrUserId(BFNodeEventArgs<BfInstancesModel> e)
        {
            StringBuilder sqrSB = new StringBuilder();
            //SysUserModel user = e.User as SysUserModel;
            sqrSB.Append(string.Format(",{0},", SysUserService.GetUserId(e.Model.BF_FOUNDER)));
            return sqrSB.ToString();
        }

        /// <summary>
        ///  获取部门经理(子公司部门经理)编码
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetDeptManager(BFNodeEventArgs<BfInstancesModel> e)
        {
            //获取当前用户所在的单位
            int userId = SysUserService.GetUserId(e.Model.BF_FOUNDER);
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(SysUserService.GetUserAffiliationDeptId(userId));
            if (q != null)
            {
                return string.Format(",{0},", q.DMANAGER);
            }
            return "";
        }

        /// <summary>
        /// 获取子公司总经理编码
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetSubcompanyManager(BFNodeEventArgs<BfInstancesModel> e)
        {
            //获取当前用户所在的单位
            int userId = SysUserService.GetUserId(e.Model.BF_FOUNDER);
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(SysUserService.GetUserAffiliationDeptId(userId));
            if (q != null)
            {
                //只支持两级
                if (q.DPARENTID > 0)
                {
                    //子公司总经理，有子部门
                    var qq = dService.DepartmentDisp(q.DPARENTID);
                    if (qq != null)
                    {
                        return string.Format(",{0},", qq.DMANAGER);
                    }
                }
                else
                {
                    //子公司总经理，无子部门
                    return string.Format(",{0},", q.DMANAGER);
                }
            }
            return "";
        }

        /// <summary>
        /// 获取分管领导编码
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetDeptHeaderManager(BFNodeEventArgs<BfInstancesModel> e)
        {
            //获取当前用户所在的单位
            int userId = SysUserService.GetUserId(e.Model.BF_FOUNDER);
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(SysUserService.GetUserAffiliationDeptId(userId));
            if (q != null)
            {
                return string.Format(",{0},", q.DHEADERMANAGER);
            }
            return "";
        }

        #endregion
    }

}
