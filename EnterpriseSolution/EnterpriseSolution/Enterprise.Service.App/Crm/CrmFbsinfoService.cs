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
    /// �ļ���:  CrmFbsinfoService.cs
    /// ��������: ҵ���߼���-�ְ�����Ϣ�����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2013/12/11 11:28:04
    /// </summary>
    public class CrmFbsinfoService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmFbsinfoData dal = new CrmFbsinfoData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbsinfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbsinfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbsinfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbsinfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbsinfoModel GetSingle(string fbsId)
        {
            return dal.GetListByHQL("from CrmFbsinfoModel p where p.FBSID = '" + fbsId + "'").FirstOrDefault();
        }

        /// <summary>
        ///  ���طְ�������
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetFBSName(string fbsId)
        {
            CrmFbsinfoService service = new CrmFbsinfoService();
            var q = service.GetList().Where(p => p.FBSID == fbsId).FirstOrDefault();
            if (q != null)
            {
                return q.FBSMC;
            }
            return "";
        }
    }

}
