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
    /// �ļ���:  BfClsmethodsService.cs
    /// ��������: ҵ���߼���-��ɫ��ȡ���������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:51
    /// </summary>
    public class BfClsmethodsService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfClsmethodsData dal = new BfClsmethodsData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfClsmethodsModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfClsmethodsModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ���ɽ�ɫ��ȡ������ID
        /// </summary>
        /// <returns></returns>
        public string GetClsMethod_ID()
        {
            return dal.GetClsMethod_ID();
        }


    }

}
