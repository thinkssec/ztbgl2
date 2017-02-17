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
    /// �ļ���:  DocumentKindService.cs
    /// ��������: ҵ���߼���-�ĵ���������ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/3/6 8:25:02
    /// </summary>
    public class DocumentKindService
    {

        #region ����������

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDocumentKindData dal = new DocumentKindData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// �������ݼ���
        /// ��˳������򣬲����ݲ㼶��ʾ
        /// </summary>
        /// <returns></returns>
        public IList<DocumentKindModel> GetTreeList()
        {
            return dal.GetTreeList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocumentKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentKindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
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
