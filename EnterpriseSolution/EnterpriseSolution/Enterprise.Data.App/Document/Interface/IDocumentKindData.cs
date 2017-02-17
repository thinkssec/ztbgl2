using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// 文件名:  IDocumentKindData.cs
    /// 功能描述: 数据层-文档库类别数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/3/6 8:25:02
    /// </summary>
    public interface IDocumentKindData : IDataApp<DocumentKindModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentKindModel> GetListBySQL(string sql);

        /// <summary>
        /// 返回数据集合
        /// 按顺序号排序，并根据层级显示
        /// </summary>
        /// <returns></returns>
        IList<DocumentKindModel> GetTreeList();

        #endregion
    }

}
