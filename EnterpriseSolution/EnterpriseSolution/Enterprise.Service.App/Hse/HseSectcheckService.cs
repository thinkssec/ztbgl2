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
    /// �ļ���:  HseSectcheckService.cs
    /// ��������: ҵ���߼���-��ȫ�������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/4/28 11:31:36
    /// </summary>
    public class HseSectcheckService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IHseSectcheckData dal = new HseSectcheckData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HseSectcheckModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HseSectcheckModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
