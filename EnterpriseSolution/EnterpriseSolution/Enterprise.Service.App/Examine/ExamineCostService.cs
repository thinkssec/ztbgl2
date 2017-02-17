using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Examine;
using Enterprise.Model.App.Examine;

namespace Enterprise.Service.App.Examine
{
	
    /// <summary>
    /// 文件名:  ExamineCostService.cs
    /// 功能描述: 业务逻辑层-成本科目表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-11-7 14:36:26
    /// </summary>
    public class ExamineCostService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExamineCostData dal = new ExamineCostData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineCostModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 根据所选CostId返回CostName
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static object GetCostName(string costcode)
        {
            var q = dal.GetListByHQL("from ExamineCostModel where COSTCODE='" + costcode + "'").FirstOrDefault();
            if (q!=null)
            {
                return q.COSTNAME;
            }
            return "";
        }

        public ExamineCostModel GetSingle(string ID)
        {
            return dal.GetListByHQL("from ExamineCostModel p where p.COSTCODE = '" + ID + "'").FirstOrDefault();
        }
    }

}
