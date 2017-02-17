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
    /// 文件名:  HseSectcheckService.cs
    /// 功能描述: 业务逻辑层-安全检查表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/4/28 11:31:36
    /// </summary>
    public class HseSectcheckService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IHseSectcheckData dal = new HseSectcheckData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HseSectcheckModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HseSectcheckModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
