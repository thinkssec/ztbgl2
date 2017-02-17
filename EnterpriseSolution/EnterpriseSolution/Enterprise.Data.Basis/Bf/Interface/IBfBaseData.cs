using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  IBfBaseData.cs
    /// 功能描述: 数据层-业务流基础表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:18:50
    /// </summary>
    public interface IBfBaseData : IDataBasis<BfBaseModel>
    {
        /// <summary>
        /// 生成业务流ID
        /// </summary>
        /// <returns></returns>
        string GetBF_ID();
    }
}
