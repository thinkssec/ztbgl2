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
    /// �ļ���:  ExcGradeService.cs
    /// ��������: ҵ���߼���-�쳣�ȼ������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:25
    /// </summary>
    public class ExcGradeService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcGradeData dal = new ExcGradeData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcGradeModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcGradeModel model)
        {
            return dal.Execute(model);
        }

    }

}
