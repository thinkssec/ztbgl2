using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  IBfNoderolesData.cs
    /// 功能描述: 数据层-业务流节点角色表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:18:55
    /// </summary>
    public interface IBfNoderolesData : IDataBasis<BfNoderolesModel>
    {
        /// <summary>
        /// 根据业务流ID和版本号获取所有角色信息集合
        /// </summary>
        /// <param name="bf_id">业务流ID</param>
        /// <param name="bf_version">业务流版本</param>
        /// <returns></returns>
        IList<BfNoderolesModel> GetListById_Version(string bf_id, int bf_version);
    }
}
