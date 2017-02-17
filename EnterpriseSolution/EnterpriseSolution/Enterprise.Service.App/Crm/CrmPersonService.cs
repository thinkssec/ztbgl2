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
    /// �ļ���:  CrmPersonService.cs
    /// ��������: ҵ���߼���-ר�ҿ����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/6/21 1:15:28
    /// </summary>
    public class CrmPersonService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmPersonData dal = new CrmPersonData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPersonModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPersonModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }
        public static CrmPersonModel getModel(int id){
            CrmPersonService s = new CrmPersonService();
            CrmPersonModel m = new CrmPersonModel();
            m = s.GetList().FirstOrDefault(f=>f.USRID==id);
            return m;
        }
	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmPersonModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmPersonModel model)
        {
            return dal.Execute(model);
        }
        public static string GetCacheClassKey()
        {
            return CrmPersonData.CacheClassKey;
        }
        #endregion
    }

}
