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
    /// �ļ���:  ExcChecknodesService.cs
    /// ��������: ҵ���߼���-�쳣���ڵ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:22
    /// </summary>
    public class ExcChecknodesService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcChecknodesData dal = new ExcChecknodesData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcChecknodesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcChecknodesModel model)
        {
            return dal.Execute(model);
        }

    }

}
