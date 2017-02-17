using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Document;
using Enterprise.Model.App.Document;

namespace Enterprise.Service.App.Document
{
	
    /// <summary>
    /// 文件名:  DocumentConfigService.cs
    /// 功能描述: 业务逻辑层-文档库配置表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2014/3/6 8:24:59
    /// </summary>
    public class DocumentConfigService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDocumentConfigData dal = new DocumentConfigData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConfigModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConfigModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentConfigModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocumentConfigModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public DocumentConfigModel GetSingle(string Id)
        {
            string hql = "from DocumentConfigModel p where p.PZID='" + Id + "'";
            return dal.GetListByHQL(hql).FirstOrDefault();
        }
    }

}
