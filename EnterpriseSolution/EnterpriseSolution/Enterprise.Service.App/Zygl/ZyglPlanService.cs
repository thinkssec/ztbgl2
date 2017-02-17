using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Zygl;
using Enterprise.Model.App.Zygl;
using Enterprise.Component.ORM;
namespace Enterprise.Service.App.Zygl
{
	
    /// <summary>
    /// 文件名:  ZyglPlanService.cs
    /// 功能描述: 业务逻辑层-作业管理开工申请数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/5/19 14:47:47
    /// </summary>
    public class ZyglPlanService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IZyglPlanData dal = new ZyglPlanData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ZyglPlanModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ZyglPlanModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ZyglPlanModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ZyglPlanModel model)
        {
            return dal.Execute(model);
        }
        public DataSet getDsBySql(string sql)
        {

            DataSet ds = null;
            using (ORMDataAccess<ZyglPlanData> db = new ORMDataAccess<ZyglPlanData>())
            {
                ds = db.ExecuteDataset(sql, null);
            }
            return ds;
        }
        #endregion
    }

}
