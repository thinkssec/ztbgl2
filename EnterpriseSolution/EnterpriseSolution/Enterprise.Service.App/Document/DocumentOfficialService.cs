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
    /// 文件名:  DocumentOfficialService.cs
    /// 功能描述: 业务逻辑层-公文表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/4/22 16:23:52
    /// </summary>
    public class DocumentOfficialService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDocumentOfficialData dal = new DocumentOfficialData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentOfficialModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentOfficialModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentOfficialModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocumentOfficialModel model)
        {
            return dal.Execute(model);
        }

        public static string ToAttachHtml(DocumentOfficialModel article)
        {
            string dbFilesString = article.FVIEWNAMES;
            DocumentOfficialService downloadSrv = new DocumentOfficialService();

            string html = "<ul>";
            if (!string.IsNullOrEmpty(dbFilesString))
            {
                string[] str = dbFilesString.Split('|');
                for (int i = 0; i < str.Length; i++)
                {
                    string[] tmp = str[i].Split('*');
                    string ext = System.IO.Path.GetExtension(Utility.GetFileExt(tmp.Last()));
                    html += string.Format("<li><a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-" + ext.Replace(".", "") + "',plain:true\" href=\"/Modules/App/Document/DownloadOfcFile.aspx?id={0}&fn={1}\" target='_blank'>{2}</a></li>",
                        article.DOCID,
        
                        FileHelper.Encrypt(tmp.Last()),
                        tmp.First());
                }
                html += "</ul>";
            }
            return html;
        }
        #endregion
    }

}
