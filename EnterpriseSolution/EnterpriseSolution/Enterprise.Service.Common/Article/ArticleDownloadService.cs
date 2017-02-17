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
    /// �ļ���:  ArticleDownloadService.cs
    /// ��������: ҵ���߼���-�ĵ����ع������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-5-16 17:44:17
    /// </summary>
    public class ArticleDownloadService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IArticleDownloadData dal = new ArticleDownloadData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArticleDownloadModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArticleDownloadModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
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
