using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Office;

namespace Enterprise.Data.Common.Office
{	

    /// <summary>
    /// 文件名:  IOfficeRecevieData.cs
    /// 功能描述: 数据层-公文签收记录数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-27 21:01:30
    /// </summary>
    public interface IOfficeRecevieData : IDataCommon<OfficeRecevieModel>
    {
        #region 代码生成器

        /// <summary>
        ///  根据ID值获取唯一数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OfficeRecevieModel GetModelById(string id);

        #endregion
    }

}
