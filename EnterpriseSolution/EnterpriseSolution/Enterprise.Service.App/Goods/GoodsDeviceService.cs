using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Goods;
using Enterprise.Model.App.Goods;

namespace Enterprise.Service.App.Goods
{
	
    /// <summary>
    /// 文件名:  GoodsDeviceService.cs
    /// 功能描述: 业务逻辑层-设备电子档案数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-11-5 15:48:11
    /// </summary>
    public class GoodsDeviceService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IGoodsDeviceData dal = new GoodsDeviceData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<GoodsDeviceModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<GoodsDeviceModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(GoodsDeviceModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
