using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Zygl;
using Enterprise.Model.App.Zygl;
using Enterprise.Component.ORM;
namespace Enterprise.Service.App.Zygl
{
	
    /// <summary>
    /// �ļ���:  ZyglPlanService.cs
    /// ��������: ҵ���߼���-��ҵ�������������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/5/19 14:47:47
    /// </summary>
    public class ZyglPlanService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IZyglPlanData dal = new ZyglPlanData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ZyglPlanModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ZyglPlanModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ZyglPlanModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ZyglPlanModel model)
        {
            return dal.Execute(model);
        }
        public DataSet getDsBySql(string sql)
        {

            DataSet ds = null;
            using (ORMDataAccess<ZyglPlanData> db = new ORMDataAccess<ZyglPlanData>())
            {
                ds = db.ExecuteDataset(sql, null);
            }
            return ds;
        }
        #endregion
    }

}
