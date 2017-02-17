using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Goods;
using Enterprise.Model.App.Goods;

namespace Enterprise.Service.App.Goods
{
	
    /// <summary>
    /// �ļ���:  GoodsDeviceService.cs
    /// ��������: ҵ���߼���-�豸���ӵ������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:11
    /// </summary>
    public class GoodsDeviceService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IGoodsDeviceData dal = new GoodsDeviceData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<GoodsDeviceModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<GoodsDeviceModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(GoodsDeviceModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
