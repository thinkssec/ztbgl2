﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysDepartmentService.cs
    /// 功能描述: 业务逻辑层-角色权限数据处理
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysRolePermissionService
    {
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysRolePermissionData dal = new SysRolePermissionData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysRolePermissionModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysRolePermissionModel model)
        {
            return dal.Execute(model);
        }
    }
}
