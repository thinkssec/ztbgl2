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
    /// �ļ���:  ArticleClobService.cs
    /// ��������: ҵ���߼���-���ı����ݱ����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/2/7 13:50:48
    /// </summary>
    public class ArticleClobService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IArticleClobData dal = new ArticleClobData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArticleClobModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArticleClobModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ArticleClobModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
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
