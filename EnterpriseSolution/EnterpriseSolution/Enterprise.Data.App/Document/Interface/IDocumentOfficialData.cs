using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// 文件名:  IDocumentOfficialData.cs
    /// 功能描述: 数据层-公文表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/4/22 16:23:52
    /// </summary>
    public interface IDocumentOfficialData : IDataApp<DocumentOfficialModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentOfficialModel> GetListBySQL(string sql);

        #endregion
    }

}
