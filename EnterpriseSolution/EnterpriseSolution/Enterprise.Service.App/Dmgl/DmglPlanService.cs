using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Dmgl;
using Enterprise.Model.App.Dmgl;

namespace Enterprise.Service.App.Dmgl
{
	
    /// <summary>
    /// 文件名:  DmglPlanService.cs
    /// 功能描述: 业务逻辑层-地面维修计划管理数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/5/12 9:15:46
    /// </summary>
    public class DmglPlanService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDmglPlanData dal = new DmglPlanData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DmglPlanModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DmglPlanModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DmglPlanModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DmglPlanModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
