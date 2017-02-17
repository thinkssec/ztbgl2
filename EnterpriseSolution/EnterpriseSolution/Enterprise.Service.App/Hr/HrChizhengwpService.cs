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
    /// �ļ���:  HrChizhengwpService.cs
    /// ��������: ҵ���߼���-��Ƹ��Ա��֤��Ϣ�����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/2/27 17:05:08
    /// </summary>
    public class HrChizhengwpService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IHrChizhengwpData dal = new HrChizhengwpData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HrChizhengwpModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HrChizhengwpModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HrChizhengwpModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HrChizhengwpModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
