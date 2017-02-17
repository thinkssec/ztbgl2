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
    /// �ļ���:  ExcCheckrecordService.cs
    /// ��������: ҵ���߼���-�쳣����¼�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:23
    /// </summary>
    public class ExcCheckrecordService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcCheckrecordData dal = new ExcCheckrecordData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcCheckrecordModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcCheckrecordModel model)
        {
            return dal.Execute(model);
        }

    }

}
