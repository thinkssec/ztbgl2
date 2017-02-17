using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  IBfInstancerolesData.cs
    /// 功能描述: 数据层-业务流实例角色表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:18:54
    /// </summary>
    public interface IBfInstancerolesData : IDataBasis<BfInstancerolesModel>
    {
        /// <summary>
        /// 获取指定业务流实例ID下的对应角色数据集合
        /// </summary>
        /// <param name="instanceId">业务流实例ID</param>
        /// <returns></returns>
        IList<BfInstancerolesModel> GetListByInstanceId(string instanceId);
    }
}
