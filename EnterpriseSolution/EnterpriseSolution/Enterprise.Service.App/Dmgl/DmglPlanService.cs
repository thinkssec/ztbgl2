using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Dmgl;
using Enterprise.Model.App.Dmgl;

namespace Enterprise.Service.App.Dmgl
{
	
    /// <summary>
    /// �ļ���:  DmglPlanService.cs
    /// ��������: ҵ���߼���-����ά�޼ƻ��������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/5/12 9:15:46
    /// </summary>
    public class DmglPlanService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDmglPlanData dal = new DmglPlanData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DmglPlanModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DmglPlanModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DmglPlanModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DmglPlanModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
