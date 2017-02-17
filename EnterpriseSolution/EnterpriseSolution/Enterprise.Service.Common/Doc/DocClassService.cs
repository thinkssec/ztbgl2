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
    /// 文件名:  DocClassService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/26 15:10:23
    /// </summary>
    public class DocClassService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDocClassData dal = new DocClassData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocClassModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocClassModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocClassModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DocClassModel GetListById(int classId)
        {
            return dal.GetListById(classId);
        }

        /// <summary>
        /// 栏目下是否有文章
        /// </summary>
        /// <param name="classId">栏目ID</param>
        /// <returns></returns>
        public bool HasArticle(int classId)
        {
            return dal.HasArticle(classId);
        }

        /// <summary>
        /// 用户是否有允许发布权限
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool AllowPubArticleInClass(int classId, int userId)
        {
            return dal.AllowPubArticleInClass(classId, userId);
        }
    }

}
