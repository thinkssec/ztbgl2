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
    /// �ļ���:  DocumentConvertService.cs
    /// ��������: ҵ���߼���-�ĵ�ת�������ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/3/6 8:25:00
    /// </summary>
    public class DocumentConvertService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDocumentConvertData dal = new DocumentConvertData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
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
        /// ����DOCID��ȡת��������ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentConvertModel> GetListByDocId(string docId)
        {
            return dal.GetListByHQL("from DocumentConvertModel p where p.DOCID='" + docId + "' order by p.CVTID desc");
        }

        /// <summary>
        /// ��ȡָ��ID����Ӧ�Ķ���
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
