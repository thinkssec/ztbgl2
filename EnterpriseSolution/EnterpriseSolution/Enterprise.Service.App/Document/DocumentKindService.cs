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
    /// 文件名:  DocumentKindService.cs
    /// 功能描述: 业务逻辑层-文档库类别数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/3/6 8:25:02
    /// </summary>
    public class DocumentKindService
    {

        #region 代码生成器

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDocumentKindData dal = new DocumentKindData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 返回数据集合
        /// 按顺序号排序，并根据层级显示
        /// </summary>
        /// <returns></returns>
        public IList<DocumentKindModel> GetTreeList()
        {
            return dal.GetTreeList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentKindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocumentKindModel model)
        {
            return dal.Execute(model);
        }

        #endregion


        public DocumentKindModel GetSingle(string Id)
        {
            string hql = "from DocumentKindModel t where t.LBBH='" + Id + "'";
            return dal.GetListByHQL(hql).FirstOrDefault();
        }

        public static string GetKindName(string p)
        {
            string hql = "from DocumentKindModel t where t.LBBH='" + p + "'";
            DocumentKindModel Mod = dal.GetListByHQL(hql).FirstOrDefault();
            if (Mod!=null)
            {
                return Mod.LBMC;
            }

            else           
                return "";
        }

    }

}
