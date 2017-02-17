using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Doc;
using Enterprise.Model.Common.Doc;

namespace Enterprise.Service.Common.Doc
{
	
    /// <summary>
    /// 文件名:  DocArticlesService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/26 15:10:22
    /// </summary>
    public class DocArticlesService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDocArticlesData dal = new DocArticlesData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocArticlesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocArticlesModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocArticlesModel model)
        {
            return dal.Execute(model);
        }
        

        public DocArticlesModel GetListById(int id)
        {
            return dal.GetListById(id);
        }

        #endregion
    }

}
