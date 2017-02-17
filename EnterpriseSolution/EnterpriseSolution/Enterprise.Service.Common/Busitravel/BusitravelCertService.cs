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
    /// 文件名:  BusitravelCertService.cs
    /// 功能描述: 业务逻辑层-出差证明数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2013-6-24 20:24:40
    /// </summary>
    public class BusitravelCertService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBusitravelCertData dal = new BusitravelCertData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelCertModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelCertModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelCertModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
