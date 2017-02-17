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
    /// �ļ���:  HrChizhengService.cs
    /// ��������: ҵ���߼���-��Ա��֤��Ϣ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:12
    /// </summary>
    public class HrChizhengService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IHrChizhengData dal = new HrChizhengData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HrChizhengModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HrChizhengModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(HrChizhengModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
