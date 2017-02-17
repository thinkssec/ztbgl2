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
    /// �ļ���:  CrmPbsurveyitemService.cs
    /// ��������: ҵ���߼���-�ҷ���λ�������ݱ����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2014/3/31 17:16:11
    /// </summary>
    public class CrmPbsurveyitemService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmPbsurveyitemData dal = new CrmPbsurveyitemData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbsurveyitemModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbsurveyitemModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmPbsurveyitemModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmPbsurveyitemModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
