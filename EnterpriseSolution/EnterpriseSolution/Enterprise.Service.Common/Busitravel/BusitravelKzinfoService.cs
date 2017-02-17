using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Busitravel;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Service.Common.Busitravel
{
	
    /// <summary>
    /// �ļ���:  BusitravelKzinfoService.cs
    /// ��������: ҵ���߼���-�����������뵥���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-6-24 20:24:40
    /// </summary>
    public class BusitravelKzinfoService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBusitravelKzinfoData dal = new BusitravelKzinfoData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelKzinfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelKzinfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelKzinfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// ��ȡָ��ID�Ĳ��ü�¼
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public BusitravelKzinfoModel GetModelById(string bid)
        {
            return GetList("from BusitravelKzinfoModel p where p.BID = '" + bid + "'").FirstOrDefault();
        }

    }

}
