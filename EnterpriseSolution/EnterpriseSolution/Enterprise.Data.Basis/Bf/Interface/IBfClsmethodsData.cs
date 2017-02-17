using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  IBfClsmethodsData.cs
    /// 功能描述: 数据层-角色获取方法表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:18:51
    /// </summary>
    public interface IBfClsmethodsData : IDataBasis<BfClsmethodsModel>
    {
        /// <summary>
        /// 生成角色获取方法表ID
        /// </summary>
        /// <returns></returns>
        string GetClsMethod_ID();
    }
}
