using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Hr;
using Enterprise.Model.App.Hr;

namespace Enterprise.Service.App.Hr
{

    /// <summary>
    /// 文件名:  HrChizhengwpService.cs
    /// 功能描述: 业务逻辑层-外聘人员持证信息表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/2/27 17:05:08
    /// </summary>
    public class HrChizhengwpService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IHrChizhengwpData dal = new HrChizhengwpData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<HrChizhengwpModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<HrChizhengwpModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HrChizhengwpModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HrChizhengwpModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
