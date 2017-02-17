using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Crm;
using Enterprise.Model.App.Crm;

namespace Enterprise.Service.App.Crm
{
	
    /// <summary>
    /// �ļ���:  CrmFbcontractService.cs
    /// ��������: ҵ���߼���-�ְ���ͬ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/12/11 11:28:01
    /// </summary>
    public class CrmFbcontractService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmFbcontractData dal = new CrmFbcontractData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbcontractModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbcontractModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbcontractModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbcontractModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbcontractModel GetSingle(string FBHTID)
        {
            return dal.GetListByHQL("from CrmFbcontractModel p where p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
        }

        /// <summary>
        /// ���غ�ͬ���
        /// </summary>
        /// <param name="FBHTID"></param>
        /// <returns></returns>
        public static string GetHTJE(string FBHTID)
        {
            CrmFbcontractModel Model = dal.GetListByHQL("from CrmFbcontractModel p where p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
            if (Model!=null)
            {
                return Model.HTJE.ToRequestString();
            }
            return "";
        }

        /// <summary>
        /// ������ϵ��
        /// </summary>
        /// <param name="FBHTID"></param>
        /// <returns></returns>
        public static string GetGLXTID(string FBHTID)
        {
            CrmFbcontractModel Model = dal.GetListByHQL("from CrmFbcontractModel p where p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
            if (Model != null)
            {
                return Model.GLXTID;
            }
            return "";
        }

        /// <summary>
        /// ���طְ���ͬ����
        /// </summary>
        /// <param name="FBHTID"></param>
        /// <returns></returns>
        public static string GetContractName(string FBHTID)
        {
            CrmFbcontractModel Model = dal.GetListByHQL("from CrmFbcontractModel p where p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
            if (Model != null)
            {
                return Model.FBHTNAME;
            }
            return "";
        }
    }

}
