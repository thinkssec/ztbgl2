using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Manager;
using Enterprise.Model.Common.Manager;

namespace Enterprise.Service.Common.Manager
{
	
    /// <summary>
    /// �ļ���:  ManagerMsgreplyService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/27 17:55:13
    /// </summary>
    public class ManagerMsgReplyService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IManagerMsgReplyData dal = new ManagerMsgReplyData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgReplyModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgReplyModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ManagerMsgReplyModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
