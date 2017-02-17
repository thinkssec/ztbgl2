using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysUserRoleService.cs
    /// 功能描述: 业务逻辑层-用户职务对应关系表数据处理
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysUserRoleService
    {
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysUserRoleData dal = new SysUserRoleData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserRoleModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserRoleModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SysUserRoleModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysUserRoleModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取用户的角色ID列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<SysUserRoleModel> GetListByUserId(string userId)
        {
            return dal.GetListByHQL("from SysUserRoleModel where USERID='"+userId+"'");
        }
    }
}
