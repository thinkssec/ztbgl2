using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Diagnostics;

using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.Basis
{
    public class PermissionPrincipal : IPrincipal
    {
        private IIdentity _identity;
        private string[] _roles;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="IID"></param>
        public PermissionPrincipal(IIdentity IID)
        {
            _identity = IID;
            _roles = new string[1] { "check" };
        }

        public IIdentity Identity
        {
            get { return this._identity; }
        }

        public bool IsInRole(string role)
        {
            return Check_PopedomTypeAttaible();
        }

        /// <summary>
        /// 检测权限指
        /// </summary>
        /// <returns></returns>
        private bool Check_PopedomTypeAttaible()
        {
            StackTrace stack = new StackTrace();
            foreach (StackFrame sframe in stack.GetFrames())
            {
                foreach (PopedomTypeAttaible var in sframe.GetMethod().GetCustomAttributes(typeof(PopedomTypeAttaible), true))
                {
                    SysUserPermissionService.CheckPermissionVoid(var.PType);
                }
            }
            return true;
        }
    }

    /// <summary>
    /// 权限方法属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class PopedomTypeAttaible : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="PType"></param>
        public PopedomTypeAttaible(Utility.PopedomType PT)
        {
            _PType = PT;
        }

        #region "私有属性"
        /// <summary>
        /// 权限类型
        /// </summary>
        private Utility.PopedomType _PType;
        #endregion

        #region "公有属性"
        /// <summary>
        /// 权限类型
        /// </summary>
        public Utility.PopedomType PType
        {
            get
            {
                return _PType;
            }
        }
        #endregion
    }
}
