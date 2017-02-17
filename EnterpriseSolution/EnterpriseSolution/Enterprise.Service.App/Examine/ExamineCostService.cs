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
    /// �ļ���:  ExamineCostService.cs
    /// ��������: ҵ���߼���-�ɱ���Ŀ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-7 14:36:26
    /// </summary>
    public class ExamineCostService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExamineCostData dal = new ExamineCostData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineCostModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// ������ѡCostId����CostName
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static object GetCostName(string costcode)
        {
            var q = dal.GetListByHQL("from ExamineCostModel where COSTCODE='" + costcode + "'").FirstOrDefault();
            if (q!=null)
            {
                return q.COSTNAME;
            }
            return "";
        }

        public ExamineCostModel GetSingle(string ID)
        {
            return dal.GetListByHQL("from ExamineCostModel p where p.COSTCODE = '" + ID + "'").FirstOrDefault();
        }
    }

}
