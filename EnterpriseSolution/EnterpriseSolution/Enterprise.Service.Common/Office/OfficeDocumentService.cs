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
    /// �ļ���:  OfficeDocumentService.cs
    /// ��������: ҵ���߼���-������ת�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-27 21:01:29
    /// </summary>
    public class OfficeDocumentService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IOfficeDocumentData dal = new OfficeDocumentData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<OfficeDocumentModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<OfficeDocumentModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        ///  ����IDֵ��ȡΨһ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OfficeDocumentModel GetModelById(string id)
        {
            return dal.GetModelById(id);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(OfficeDocumentModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
