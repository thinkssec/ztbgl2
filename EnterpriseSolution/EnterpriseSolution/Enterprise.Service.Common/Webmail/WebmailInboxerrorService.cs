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
    /// �ļ���:  WebmailInboxerrorService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/18 9:28:03
    /// </summary>
    public class WebmailInboxerrorService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IWebmailInboxerrorData dal = new WebmailInboxerrorData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<WebmailInboxerrorModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailInboxerrorModel model)
        {
            return dal.Execute(model);
        }

    }

}
