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
    /// �ļ���:  CrmFbspersonsService.cs
    /// ��������: ҵ���߼���-�ְ�����ϵ�˱����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2013/12/11 11:28:04
    /// </summary>
    public class CrmFbspersonsService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmFbspersonsData dal = new CrmFbspersonsData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbspersonsModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbspersonsModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbspersonsModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbspersonsModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbspersonsModel GetSingle(string PERID)
        {
            return dal.GetListByHQL("from CrmFbspersonsModel p where p.PERID = '" + PERID + "'").FirstOrDefault();
        }


        /// <summary>
        /// ������ϵ������
        /// </summary>
        /// <param name="perId">��ϵ��Id</param>
        /// <returns></returns>
        public static string GetLXRPhone(string perId)
        {
            CrmFbspersonsService Service = new CrmFbspersonsService();
            var q = Service.GetList().Where(p => p.PERID == perId).FirstOrDefault();
            if (q != null)
            {
                return q.NAME;
            }
            return "";
        }

        /// <summary>
        /// ������ϵ����ϵ�绰
        /// </summary>
        /// <param name="perId">���ű��</param>
        /// <returns></returns>
        public static string GetLXRName(string perId)
        {
            CrmFbspersonsService Service = new CrmFbspersonsService();
            var q = Service.GetList().Where(p => p.PERID == perId).FirstOrDefault();
            if (q != null)
            {
                return q.PHONE;
            }
            return "";
        }
    }
}
