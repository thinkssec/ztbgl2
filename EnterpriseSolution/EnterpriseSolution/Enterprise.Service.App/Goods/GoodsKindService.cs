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
    /// �ļ���:  GoodsKindService.cs
    /// ��������: ҵ���߼���-�����������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:12
    /// </summary>
    public class GoodsKindService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IGoodsKindData dal = new GoodsKindData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<GoodsKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<GoodsKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(GoodsKindModel model)
        {
            return dal.Execute(model);
        }
        #endregion


        #region �Զ��巽��

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="kindId"></param>
        /// <returns></returns>
        public static string GetKindName(string kindId)
        {
            GoodsKindModel model = dal.GetList().FirstOrDefault(p => p.KINDID == kindId);
            return (model != null) ? model.KINDNAME : "";
        }

        #endregion

    }

}
