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
    /// 文件名:  DocumentConvertService.cs
    /// 功能描述: 业务逻辑层-文档转换表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/3/6 8:25:00
    /// </summary>
    public class DocumentConvertService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDocumentConvertData dal = new DocumentConvertData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocumentConvertModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        #region

        /// <summary>
        /// 根据DOCID获取转换后的数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetListByDocId(string docId)
        {
            return dal.GetListByHQL("from DocumentConvertModel p where p.DOCID='" + docId + "' order by p.CVTID desc");
        }

        /// <summary>
        /// 获取指定ID所对应的对象
        /// </summary>
        /// <param name="cvtId"></param>
        /// <returns></returns>
        public DocumentConvertModel GetModelByCvtId(string cvtId)
        {
            return dal.GetListByHQL("from DocumentConvertModel p where p.CVTID='" + cvtId + "'").FirstOrDefault();
        }

        #endregion
    }

}
