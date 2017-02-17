using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Webmail;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Service.Common.Webmail
{
    /// <summary>
    /// �ļ���:  WebmailOutboxService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/18 9:28:03
    /// </summary>
    public class WebmailOutboxService
    {
        #region '����������'
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IWebmailOutboxData dal = new WebmailOutboxData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <param name="hql"></param>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailOutboxModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// �����������ƻ�ȡ���ݼ���
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetListByEmail(string email)
        {
            return dal.GetListByEmail(email);
        }


        public void Delete(List<string> Ids)
        {
            dal.Delete(Ids);
        }

        public void ReSend(List<string> Ids)
        {
            dal.ReSend(Ids);
        }

        public IList<WebmailOutboxModel> GetListById(int id)
        {
            return dal.GetListById(id);
        }
    }

}
