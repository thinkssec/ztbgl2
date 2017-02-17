//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;

////using Enterprise.Data.Email;

//namespace Enterprise.Service.Common.WebEmail
//{
//    /// <summary>
//    /// 邮件服务类：Email由于应用场景单一 未使用Model
//    /// </summary>
//    public class EmailService
//    {
//        /// <summary>
//        /// 获取收件箱的邮件
//        /// </summary>
//        /// <param name="email"></param>
//        /// <returns></returns>
//        public DataSet GetMails(string email)
//        {
//            EMailData data = new EMailData();
//            return data.GetMails(email);
//        }

//        /// <summary>
//        /// 根据用户ID获取用户的邮箱地址
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <returns></returns>
//        public string GetEmailAddressByUserId(int userId)
//        {
//            DataSet ds= GetMailSetting(userId);
//            if (ds.Tables[0].Rows.Count > 0)
//                return ds.Tables[0].Rows[0]["Email"].ToString();
//            else
//                return "";
//        }

//        /// <summary>
//        /// 收件箱是否有邮件
//        /// </summary>
//        /// <param name="email"></param>
//        /// <returns></returns>
//        public bool Exist(string email)
//        {
//            EMailData data = new EMailData();
//            return data.Exist(email);
//        }

//        /// <summary>
//        /// 获取用户的邮箱设置
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <returns></returns>
//        public DataSet GetMailSetting(int userId)
//        {
//            EMailData data = new EMailData();
//            return data.GetMailSetting(userId);
//        }

//        /// <summary>
//        /// 保存设置
//        /// </summary>
//        public void SaveSet(int _userid,string _email,string _pwd,string _popserver,string _smtpserver,int _pop_port,int _smtp_port ,int _enable )        
//        {
//            EMailData data = new EMailData();
//            DataSet ds = data.GetMailSetting(_userid);
//            if (ds.Tables[0].Rows.Count > 0)
//            {
//                data.Update(_userid,_email,_pwd,_popserver,_pop_port,_smtpserver,_smtp_port,_enable);
//            }
//            else
//            {
//                data.Insert(_userid, _email, _pwd, _popserver, _pop_port, _smtpserver, _smtp_port, _enable);
//            }
                
//        }

//        /// <summary>
//        /// 将信息设为删除
//        /// </summary>
//        /// <param name="MessageIds"></param>
//        public void Delete(List<string> MessageIds)
//        {

//            EMailData data = new EMailData();
//            data.Delete(MessageIds);
            
//        }

//        /// <summary>
//        /// 邮件详细信息
//        /// </summary>
//        /// <param name="messageId"></param>
//        /// <returns></returns>
//        public DataSet getMailDetail(string messageId)
//        {
//            EMailData data = new EMailData();
//            return data.getMailDetail(messageId);
//        }

//        /// <summary>
//        /// 标记为已读
//        /// </summary>
//        /// <param name="messageId"></param>
//        public void SetReaded(string messageId)
//        {
//            EMailData data = new EMailData();
//            List<string> list = new List<string>();
//            list.Add(messageId);
//            data.SetReaded(list);
//        }

//        /// <summary>
//        /// 标记为已读
//        /// </summary>
//        /// <param name="messageIds"></param>
//        public void SetReaded(List<string> messageIds)
//        {
//            EMailData data = new EMailData();
//            data.SetReaded(messageIds);
//        }

//        /// <summary>
//        /// 检查邮件是否接受正常
//        /// </summary>
//        /// <param name="email"></param>
//        /// <returns></returns>
//        public bool IsOk(string email)
//        {
//            EMailData data = new EMailData();
//            return data.IsOk(email);
//        }
        
//        /// <summary>
//        /// 发送邮件
//        /// </summary>
//        /// <param name="from"></param>
//        /// <param name="to"></param>
//        /// <param name="subject"></param>
//        /// <param name="body"></param>
//        /// <param name="attch"></param>
//        /// <param name="success"></param>
//        /// <param name="cc">抄送</param>
//        public void SendMail(string from, string to, string subject, string body, string attch, int success,string cc)
//        {
//            EMailData data = new EMailData();
//            data.SendMail(from, to, subject, body, attch, success,cc);
//        }

//        /// <summary>
//        /// 发件箱
//        /// </summary>
//        /// <param name="email"></param>
//        /// <returns></returns>
//        public DataSet getOutBox(string email)
//        {
//            EMailData data = new EMailData();
//            return data.getOutbox(email);
//        }
//    }
//}
