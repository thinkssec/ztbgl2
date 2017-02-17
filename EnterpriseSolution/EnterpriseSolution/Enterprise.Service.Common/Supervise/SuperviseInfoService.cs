using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Supervise;
using Enterprise.Model.Common.Supervise;

namespace Enterprise.Service.Common.Supervise
{
	
    /// <summary>
    /// �ļ���:  SuperviseInfoService.cs
    /// ��������: ҵ���߼���-������������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/13 10:53:09
    /// </summary>
    public class SuperviseInfoService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ISuperviseInfoData dal = new SuperviseInfoData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseInfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SuperviseInfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// ɾ���������񼰰�����ϸ
        /// </summary>
        /// <param name="dbid"></param>
        public void Delete(string dbid)
        {
            dal.Delete(dbid);
        }

        
    }

}
