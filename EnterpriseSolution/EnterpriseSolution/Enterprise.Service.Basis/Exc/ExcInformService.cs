using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Exc;
using Enterprise.Model.Basis.Exc;

namespace Enterprise.Service.Basis.Exc
{
    /// <summary>
    /// �ļ���:  ExcInformService.cs
    /// ��������: ҵ���߼���-�쳣֪ͨ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:28
    /// </summary>
    public class ExcInformService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcInformData dal = new ExcInformData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcInformModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcInformModel model)
        {
            return dal.Execute(model);
        }

    }

}
