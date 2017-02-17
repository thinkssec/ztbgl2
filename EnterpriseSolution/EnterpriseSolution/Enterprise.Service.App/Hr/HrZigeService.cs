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
    /// 文件名:  HrZigeService.cs
    /// 功能描述: 业务逻辑层-人员资格表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-11-5 15:48:13
    /// </summary>
    public class HrZigeService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IHrZigeData dal = new HrZigeData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<HrZigeModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<HrZigeModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HrZigeModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HrZigeModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        
    }

}
