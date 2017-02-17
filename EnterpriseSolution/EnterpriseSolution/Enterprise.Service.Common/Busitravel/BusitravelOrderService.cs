using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Busitravel;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Service.Common.Busitravel
{
	
    /// <summary>
    /// 文件名:  BusitravelOrderService.cs
    /// 功能描述: 业务逻辑层-出差命令数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-6-24 20:24:41
    /// </summary>
    public class BusitravelOrderService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBusitravelOrderData dal = new BusitravelOrderData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelOrderModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelOrderModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelOrderModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
