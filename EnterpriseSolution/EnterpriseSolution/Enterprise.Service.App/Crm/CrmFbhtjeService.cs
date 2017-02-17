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
    /// �ļ���:  CrmFbhtjeService.cs
    /// ��������: ҵ���߼���-��Ŀ�ְ���ͬ�������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/12/11 11:28:02
    /// </summary>
    public class CrmFbhtjeService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmFbhtjeData dal = new CrmFbhtjeData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbhtjeModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbhtjeModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbhtjeModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbhtjeModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbhtjeModel GetSingle(string REQID, string FBHTID)
        {
            return dal.GetListByHQL("from CrmFbhtjeModel p where p.REQID = '" + REQID + "' and p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
        }
    }

}
