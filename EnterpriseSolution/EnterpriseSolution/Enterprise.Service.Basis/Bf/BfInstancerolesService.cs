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
    /// 文件名:  BfInstancerolesService.cs
    /// 功能描述: 业务逻辑层-业务流实例角色表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:54
    /// </summary>
    public class BfInstancerolesService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBfInstancerolesData dal = new BfInstancerolesData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfInstancerolesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfInstancerolesModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取指定业务流实例ID下的对应角色数据集合
        /// </summary>
        /// <param name="instanceId">业务流实例ID</param>
        /// <returns></returns>
        public IList<BfInstancerolesModel> GetListByInstanceId(string instanceId)
        {
            return dal.GetListByInstanceId(instanceId);
        }

    }

}
