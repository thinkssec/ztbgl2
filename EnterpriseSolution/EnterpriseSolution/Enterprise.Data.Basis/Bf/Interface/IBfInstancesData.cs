using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  IBfInstancesData.cs
    /// 功能描述: 数据层-业务流实例表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:18:55
    /// </summary>
    public interface IBfInstancesData : IDataBasis<BfInstancesModel>
    {
        /// <summary>
        /// 根据ID获取对应数据
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        BfInstancesModel GetModelById(string instanceId);
    }
}
