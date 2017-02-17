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
    /// 文件名:  WebmailInboxService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/18 9:28:02
    /// </summary>
    public class WebmailInboxService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IWebmailInboxData dal = new WebmailInboxData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="hql"></param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 获取某个邮箱的邮件
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IList<WebmailInboxModel> GetListByEmail(string email)
        {
            return dal.GetListByEmail(email);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailInboxModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取一个收件箱邮件
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public WebmailInboxModel GetMailById(string messageId)
        {
            return dal.GetListById(messageId).FirstOrDefault();
        }


        /// <summary>
        /// 删除多个邮件
        /// </summary>
        /// <param name="messageIds"></param>
        public void DeleteEmails(List<string> messageIds)
        {
            dal.SetDelelted(messageIds);
        }

        /// <summary>
        /// 设置已读
        /// </summary>
        /// <param name="messageIds"></param>
        public void SetReaded(List<string> messageIds)
        {
            dal.SetReaded(messageIds);
        }       
    }

}
