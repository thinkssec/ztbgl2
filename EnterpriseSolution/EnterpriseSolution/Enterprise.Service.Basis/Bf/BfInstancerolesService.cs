using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
    /// <summary>
    /// �ļ���:  BfInstancerolesService.cs
    /// ��������: ҵ���߼���-ҵ����ʵ����ɫ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:54
    /// </summary>
    public class BfInstancerolesService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfInstancerolesData dal = new BfInstancerolesData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfInstancerolesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfInstancerolesModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ��ȡָ��ҵ����ʵ��ID�µĶ�Ӧ��ɫ���ݼ���
        /// </summary>
        /// <param name="instanceId">ҵ����ʵ��ID</param>
        /// <returns></returns>
        public IList<BfInstancerolesModel> GetListByInstanceId(string instanceId)
        {
            return dal.GetListByInstanceId(instanceId);
        }

    }

}
