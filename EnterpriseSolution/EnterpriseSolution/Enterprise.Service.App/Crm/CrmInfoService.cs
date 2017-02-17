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
    /// �ļ���:  CrmInfoService.cs
    /// ��������: ҵ���߼���-���������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/6/19 0:27:42
    /// </summary>
    public class CrmInfoService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmInfoData dal = new CrmInfoData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmInfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmInfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmInfoModel model)
        {
            return dal.Execute(model);
        }
        public static string GetCacheClassKey()
        {
            return CrmInfoData.CacheClassKey;
        }

        public static string GetCrmName(string crmId)
        {
            CrmInfoService cService = new CrmInfoService();
            var q = cService.GetList().Where(p => p.INFOID == crmId).FirstOrDefault();
            if (q != null)
            {
                return q.CRMNAME;
            }
            return "";
        }
        #endregion
    }

}
