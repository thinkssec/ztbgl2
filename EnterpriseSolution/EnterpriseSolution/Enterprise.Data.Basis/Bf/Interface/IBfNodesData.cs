using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  IBfNodesData.cs
    /// 功能描述: 数据层-业务流节点表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:18:56
    /// </summary>
    public interface IBfNodesData : IDataBasis<BfNodesModel>
    {
        /// <summary>
        /// 根据业务流ID和版本号获取所有节点信息集合
        /// </summary>
        /// <param name="bf_id">业务流ID</param>
        /// <param name="bf_version">业务流版本</param>
        /// <returns></returns>
        IList<BfNodesModel> GetListById_Version(string bf_id, int bf_version);
    }
}
