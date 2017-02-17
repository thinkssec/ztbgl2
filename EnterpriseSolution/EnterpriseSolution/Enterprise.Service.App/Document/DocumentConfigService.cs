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
    /// �ļ���:  DocumentConfigService.cs
    /// ��������: ҵ���߼���-�ĵ������ñ����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2014/3/6 8:24:59
    /// </summary>
    public class DocumentConfigService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDocumentConfigData dal = new DocumentConfigData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConfigModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConfigModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentConfigModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
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
