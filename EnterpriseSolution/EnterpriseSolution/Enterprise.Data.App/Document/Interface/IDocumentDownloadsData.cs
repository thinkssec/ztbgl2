using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// 文件名:  IDocumentDownloadsData.cs
    /// 功能描述: 数据层-文档浏览与下载记录表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/3/6 8:25:01
    /// </summary>
    public interface IDocumentDownloadsData : IDataApp<DocumentDownloadsModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentDownloadsModel> GetListBySQL(string sql);

        #endregion
    }

}
