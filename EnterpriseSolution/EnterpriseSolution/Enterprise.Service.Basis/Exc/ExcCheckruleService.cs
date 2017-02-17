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
    /// �ļ���:  ExcCheckruleService.cs
    /// ��������: ҵ���߼���-�쳣����������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:23
    /// </summary>
    public class ExcCheckruleService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcCheckruleData dal = new ExcCheckruleData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcCheckruleModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcCheckruleModel model)
        {
            return dal.Execute(model);
        }

    }

}
