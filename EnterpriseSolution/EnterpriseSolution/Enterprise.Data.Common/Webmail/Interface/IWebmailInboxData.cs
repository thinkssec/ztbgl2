using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Data.Common.Webmail
{

    /// <summary>
    /// 文件名:  IWebmailInboxData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/2/18 9:28:02
    /// </summary>
    public interface IWebmailInboxData : IDataCommon<WebmailInboxModel>
    {
        ///// <summary>
        ///// 获取数据集合
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);

        /// <summary>
        /// 根据ID获取邮件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IList<WebmailInboxModel> GetListById(string Id);

        /// <summary>
        /// 根据邮箱获取邮件
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IList<WebmailInboxModel> GetListByEmail(string email);

        /// <summary>
        /// 批量标记删除
        /// </summary>
        /// <param name="messageIds"></param>
        void SetDelelted(List<string> messageIds);

        /// <summary>
        /// 批量标记成已读
        /// </summary>
        /// <param name="messageIds"></param>
        void SetReaded(List<string> messageIds);

        /// <summary>
        /// 发送新邮件消息给用户
        /// </summary>
        void SendNoticeToUsers();
    }
}
