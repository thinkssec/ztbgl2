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
    /// 文件名:  BusitravelInfoService.cs
    /// 功能描述: 业务逻辑层-差旅申请表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-23 17:52:26
    /// </summary>
    public class BusitravelInfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBusitravelInfoData dal = new BusitravelInfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelInfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelInfoModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取指定ID的差旅记录
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public BusitravelInfoModel GetModelById(string bid)
        {
            return dal.GetModelById(bid);
        }

        #endregion
    }

}
