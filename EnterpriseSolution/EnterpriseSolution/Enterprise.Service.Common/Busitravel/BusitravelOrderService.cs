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
    /// �ļ���:  BusitravelOrderService.cs
    /// ��������: ҵ���߼���-�����������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-6-24 20:24:41
    /// </summary>
    public class BusitravelOrderService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBusitravelOrderData dal = new BusitravelOrderData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelOrderModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelOrderModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelOrderModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
