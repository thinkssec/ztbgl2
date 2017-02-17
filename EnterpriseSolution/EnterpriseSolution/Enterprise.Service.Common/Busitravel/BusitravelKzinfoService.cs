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
    /// 文件名:  BusitravelKzinfoService.cs
    /// 功能描述: 业务逻辑层-哈国出差申请单数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-6-24 20:24:40
    /// </summary>
    public class BusitravelKzinfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBusitravelKzinfoData dal = new BusitravelKzinfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelKzinfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelKzinfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelKzinfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 获取指定ID的差旅记录
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public BusitravelKzinfoModel GetModelById(string bid)
        {
            return GetList("from BusitravelKzinfoModel p where p.BID = '" + bid + "'").FirstOrDefault();
        }

    }

}
