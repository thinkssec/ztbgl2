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
    /// �ļ���:  BfInstancesService.cs
    /// ��������: ҵ���߼���-ҵ����ʵ�������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:55
    /// </summary>
    public class BfInstancesService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfInstancesData dal = new BfInstancesData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfInstancesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfInstancesModel model)
        {
            return dal.Execute(model);
        }


        /// <summary>
        /// ����ID��ȡ��Ӧ����
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public BfInstancesModel GetModelById(string instanceId)
        {
            return dal.GetModelById(instanceId);
        }


    }

}
