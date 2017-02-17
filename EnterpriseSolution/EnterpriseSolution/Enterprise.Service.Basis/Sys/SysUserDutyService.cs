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
    /// 文件名:  SysUserDutyService.cs
    /// 功能描述: 业务逻辑层-用户职务对应关系表数据处理
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysUserDutyService
    {
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysUserDutyData dal = new SysUserDutyData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserDutyModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 获取指定查询条件下的数据集合
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SysUserDutyModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysUserDutyModel model)
        {
            return dal.Execute(model);
        }
        public List<SysUserDutyModel> GetMasterList()
        {
           // string sql = "select t.userid from basis_sys_userduty t where t.dutyid = 105";
            var q= dal.GetList().Where(p => p.DUTYID == 105).ToList();

            //var q= dal.GetListBySQL(sql);
            return q;
        }

    }
}
