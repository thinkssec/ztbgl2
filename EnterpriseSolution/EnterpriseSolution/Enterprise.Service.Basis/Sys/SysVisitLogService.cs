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
    /// 文件名:  SysVisitLogService.cs
    /// 功能描述: 业务逻辑层-访问日志表数据处理
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysVisitLogService
    {
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysVisitLogData dal = new SysVisitLogData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysVisitLogModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysVisitLogModel model)
        {
            return dal.Execute(model);
        }
    }
}
