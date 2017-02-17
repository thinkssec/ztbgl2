using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Hse;
using Enterprise.Model.App.Hse;

namespace Enterprise.Service.App.Hse
{
	
    /// <summary>
    /// �ļ���:  HseSectcheckdetlService.cs
    /// ��������: ҵ���߼���-��ȫ�����ϸ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/4/29 13:20:45
    /// </summary>
    public class HseSectcheckdetlService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IHseSectcheckdetlData dal = new HseSectcheckdetlData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HseSectcheckdetlModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
