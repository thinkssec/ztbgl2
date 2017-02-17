using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Examine;
using Enterprise.Model.App.Examine;

namespace Enterprise.Service.App.Examine
{

    /// <summary>
    /// �ļ���:  ExamineCostitemService.cs
    /// ��������: ҵ���߼���-�ɱ�������Ŀ�����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-7 14:36:27
    /// </summary>
    public class ExamineCostitemService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExamineCostitemData dal = new ExamineCostitemData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostitemModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostitemModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineCostitemModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public ExamineCostitemModel GetSigle(string Id)
        {
            return dal.GetListByHQL("from ExamineCostitemModel p where p.ITEMCODE='" + Id + "'").FirstOrDefault();
        }
    }

}
