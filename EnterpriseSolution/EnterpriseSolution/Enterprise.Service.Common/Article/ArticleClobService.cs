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
    /// 文件名:  ArticleClobService.cs
    /// 功能描述: 业务逻辑层-大文本内容表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/2/7 13:50:48
    /// </summary>
    public class ArticleClobService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IArticleClobData dal = new ArticleClobData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ArticleClobModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ArticleClobModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ArticleClobModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ArticleClobModel model)
        {
            return dal.Execute(model);
        }
        #endregion


        public ArticleClobModel GetSingle(string pubId)
        {
            return dal.GetListByHQL("from ArticleClobModel p where p.ASSOCIATIONID='" + pubId + "'").FirstOrDefault();
        }
    }

}
