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
    /// �ļ���:  BusitravelInfoService.cs
    /// ��������: ҵ���߼���-������������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-23 17:52:26
    /// </summary>
    public class BusitravelInfoService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBusitravelInfoData dal = new BusitravelInfoData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelInfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelInfoModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ��ȡָ��ID�Ĳ��ü�¼
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public BusitravelInfoModel GetModelById(string bid)
        {
            return dal.GetModelById(bid);
        }

        #endregion
    }

}
