using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Hr;
using Enterprise.Model.App.Hr;

namespace Enterprise.Service.App.Hr
{
	
    /// <summary>
    /// �ļ���:  HrZigeService.cs
    /// ��������: ҵ���߼���-��Ա�ʸ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:13
    /// </summary>
    public class HrZigeService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IHrZigeData dal = new HrZigeData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HrZigeModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HrZigeModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HrZigeModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HrZigeModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        
    }

}
