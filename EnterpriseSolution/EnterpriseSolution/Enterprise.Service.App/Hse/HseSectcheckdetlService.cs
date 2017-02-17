using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Hse;
using Enterprise.Model.App.Hse;

namespace Enterprise.Service.App.Hse
{
	
    /// <summary>
    /// 文件名:  HseSectcheckdetlService.cs
    /// 功能描述: 业务逻辑层-安全检查明细表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/4/29 13:20:45
    /// </summary>
    public class HseSectcheckdetlService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IHseSectcheckdetlData dal = new HseSectcheckdetlData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HseSectcheckdetlModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
