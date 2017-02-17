using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Article;
using Enterprise.Model.Common.Article;

namespace Enterprise.Service.Common.Article
{
	
    /// <summary>
    /// 文件名:  ArticleDownloadService.cs
    /// 功能描述: 业务逻辑层-文档下载管理数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-5-16 17:44:17
    /// </summary>
    public class ArticleDownloadService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IArticleDownloadData dal = new ArticleDownloadData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ArticleDownloadModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ArticleDownloadModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ArticleDownloadModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
