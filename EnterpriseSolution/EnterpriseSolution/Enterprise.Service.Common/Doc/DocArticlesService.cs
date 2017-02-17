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
    /// �ļ���:  DocArticlesService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/26 15:10:22
    /// </summary>
    public class DocArticlesService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDocArticlesData dal = new DocArticlesData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocArticlesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocArticlesModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
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
