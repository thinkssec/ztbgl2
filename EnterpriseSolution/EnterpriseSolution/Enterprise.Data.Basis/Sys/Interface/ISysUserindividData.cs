using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Data.Basis.Sys
{	

    /// <summary>
    /// 文件名:  ISysUserindividData.cs
    /// 功能描述: 数据层-个性化设置表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-7-3 11:42:29
    /// </summary>
    public interface ISysUserindividData : IDataBasis<SysUserindividModel>
    {
        #region 代码生成器

        /// <summary>
        /// 获取指定ID的数据
        /// </summary>
        /// <returns></returns>
        SysUserindividModel GetModelById(int id);

        #endregion
    }

}
