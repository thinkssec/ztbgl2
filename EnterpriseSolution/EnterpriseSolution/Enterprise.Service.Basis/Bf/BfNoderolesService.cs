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
    /// 文件名:  BfNoderolesService.cs
    /// 功能描述: 业务逻辑层-业务流节点角色表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:55
    /// </summary>
    public class BfNoderolesService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBfNoderolesData dal = new BfNoderolesData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfNoderolesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfNoderolesModel model)
        {
            return dal.Execute(model);
        }


        /// <summary>
        /// 根据业务流ID和版本号获取所有角色信息集合
        /// </summary>
        /// <param name="bf_id">业务流ID</param>
        /// <param name="bf_version">业务流版本</param>
        /// <returns></returns>
        public IList<BfNoderolesModel> GetListById_Version(string bf_id, int bf_version)
        {
            return dal.GetListById_Version(bf_id, bf_version);
        }

    }

}
