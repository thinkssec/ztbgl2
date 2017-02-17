using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Office;
using Enterprise.Model.Common.Office;

namespace Enterprise.Service.Common.Office
{
	
    /// <summary>
    /// �ļ���:  OfficeRecevieService.cs
    /// ��������: ҵ���߼���-����ǩ�ռ�¼���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-27 21:01:30
    /// </summary>
    public class OfficeRecevieService
    {
        #region ����������

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IOfficeRecevieData dal = new OfficeRecevieData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<OfficeRecevieModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<OfficeRecevieModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        ///  ����IDֵ��ȡΨһ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OfficeRecevieModel GetModelById(string id)
        {
            return dal.GetModelById(id);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(OfficeRecevieModel model)
        {
            return dal.Execute(model);
        }

        #endregion
    }

}
