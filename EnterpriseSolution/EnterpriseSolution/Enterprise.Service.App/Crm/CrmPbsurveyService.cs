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
    /// �ļ���:  CrmPbsurveyService.cs
    /// ��������: ҵ���߼���-�ҷ���λ���۱����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2014/3/31 17:16:08
    /// </summary>
    public class CrmPbsurveyService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmPbsurveyData dal = new CrmPbsurveyData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbsurveyModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbsurveyModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmPbsurveyModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmPbsurveyModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
