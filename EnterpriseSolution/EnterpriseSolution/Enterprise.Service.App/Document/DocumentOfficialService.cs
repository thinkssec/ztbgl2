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
    /// �ļ���:  DocumentOfficialService.cs
    /// ��������: ҵ���߼���-���ı����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/4/22 16:23:52
    /// </summary>
    public class DocumentOfficialService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDocumentOfficialData dal = new DocumentOfficialData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentOfficialModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentOfficialModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentOfficialModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
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
