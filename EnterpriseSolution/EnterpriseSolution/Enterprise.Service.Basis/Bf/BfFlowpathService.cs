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
    /// �ļ���:  BfFlowpathService.cs
    /// ��������: ҵ���߼���-�ڵ���ת�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:52
    /// </summary>
    public class BfFlowpathService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfFlowpathData dal = new BfFlowpathData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfFlowpathModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfFlowpathModel model)
        {
            return dal.Execute(model);
        }

    }

}
