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
    /// �ļ���:  BfNoderolesService.cs
    /// ��������: ҵ���߼���-ҵ�����ڵ��ɫ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:55
    /// </summary>
    public class BfNoderolesService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfNoderolesData dal = new BfNoderolesData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfNoderolesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfNoderolesModel model)
        {
            return dal.Execute(model);
        }


        /// <summary>
        /// ����ҵ����ID�Ͱ汾�Ż�ȡ���н�ɫ��Ϣ����
        /// </summary>
        /// <param name="bf_id">ҵ����ID</param>
        /// <param name="bf_version">ҵ�����汾</param>
        /// <returns></returns>
        public IList<BfNoderolesModel> GetListById_Version(string bf_id, int bf_version)
        {
            return dal.GetListById_Version(bf_id, bf_version);
        }

    }

}
