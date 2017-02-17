using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Webmail;
using Enterprise.Model.Common.Webmail;
using Enterprise.Model.Common.Notice;

namespace Enterprise.Service.Common.Webmail
{
    /// <summary>
    /// �ļ���:  WebmailInboxService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/18 9:28:02
    /// </summary>
    public class WebmailInboxService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IWebmailInboxData dal = new WebmailInboxData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <param name="hql"></param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ��ȡĳ��������ʼ�
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetListByEmail(string email)
        {
            return dal.GetListByEmail(email);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailInboxModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ��ȡһ���ռ����ʼ�
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public WebmailInboxModel GetMailById(string messageId)
        {
            return dal.GetListById(messageId).FirstOrDefault();
        }


        /// <summary>
        /// ɾ������ʼ�
        /// </summary>
        /// <param name="messageIds"></param>
        public void DeleteEmails(List<string> messageIds)
        {
            dal.SetDelelted(messageIds);
        }

        /// <summary>
        /// �����Ѷ�
        /// </summary>
        /// <param name="messageIds"></param>
        public void SetReaded(List<string> messageIds)
        {
            dal.SetReaded(messageIds);
        }       
    }

}
