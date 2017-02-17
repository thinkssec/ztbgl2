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
    /// �ļ���:  BfBaseService.cs
    /// ��������: ҵ���߼���-ҵ�������������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:51
    /// </summary>
    public class BfBaseService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfBaseData dal = new BfBaseData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfBaseModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Execute(BfBaseModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ����ҵ����ID
        /// </summary>
        /// <returns></returns>
        public string GetBF_ID()
        {
            return dal.GetBF_ID();
        }

    }

}
