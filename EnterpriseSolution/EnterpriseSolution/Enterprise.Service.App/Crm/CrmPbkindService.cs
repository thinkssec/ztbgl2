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
    /// �ļ���:  CrmPbkindService.cs
    /// ��������: ҵ���߼���-�ҷ���λ�������ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/3/31 17:16:05
    /// </summary>
    public class CrmPbkindService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmPbkindData dal = new CrmPbkindData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbkindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbkindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmPbkindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmPbkindModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// ������ĿID������Ŀ����
        /// </summary>
        /// <param name="p"></param>
        public static string GetLMName(string lmId)
        {
            string hql = "from CrmPbkindModel p where p.LBBH='" + lmId + "'";
            return dal.GetListByHQL(hql).FirstOrDefault().LBMC;
        }
    }

}
