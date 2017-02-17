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
    /// �ļ���:  BfPublishService.cs
    /// ��������: ҵ���߼���-ҵ�������������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:57
    /// </summary>
    public class BfPublishService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfPublishData dal = new BfPublishData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfPublishModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfPublishModel model)
        {
            return dal.Execute(model);
        }

    }

}
