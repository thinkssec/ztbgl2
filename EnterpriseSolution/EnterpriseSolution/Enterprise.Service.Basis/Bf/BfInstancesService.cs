using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
    /// <summary>
    /// 文件名:  BfInstancesService.cs
    /// 功能描述: 业务逻辑层-业务流实例表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:55
    /// </summary>
    public class BfInstancesService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBfInstancesData dal = new BfInstancesData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfInstancesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfInstancesModel model)
        {
            return dal.Execute(model);
        }


        /// <summary>
        /// 根据ID获取对应数据
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public BfInstancesModel GetModelById(string instanceId)
        {
            return dal.GetModelById(instanceId);
        }


    }

}
