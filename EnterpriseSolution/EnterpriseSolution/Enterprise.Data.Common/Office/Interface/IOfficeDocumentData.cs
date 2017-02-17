using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Office;

namespace Enterprise.Data.Common.Office
{	

    /// <summary>
    /// 文件名:  IOfficeDocumentData.cs
    /// 功能描述: 数据层-公文流转表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-27 21:01:29
    /// </summary>
    public interface IOfficeDocumentData : IDataCommon<OfficeDocumentModel>
    {
        #region 代码生成器

        /// <summary>
        ///  根据ID值获取唯一数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OfficeDocumentModel GetModelById(string id);

        #endregion
    }

}
