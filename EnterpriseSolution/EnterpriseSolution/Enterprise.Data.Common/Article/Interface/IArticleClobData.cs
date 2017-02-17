using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Article;

namespace Enterprise.Data.Common.Article
{	

    /// <summary>
    /// 文件名:  IArticleClobData.cs
    /// 功能描述: 数据层-大文本内容表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/2/7 13:50:48
    /// </summary>
    public interface IArticleClobData : IDataCommon<ArticleClobModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ArticleClobModel> GetListBySQL(string sql);


        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        IList<ArticleClobModel> GetListByHQL(string hql);


        #endregion
    }

}
