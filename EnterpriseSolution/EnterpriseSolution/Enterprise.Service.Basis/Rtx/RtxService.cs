using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.Message;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.Basis.Rtx
{

    /// /// <summary>
    /// 文件名:  RtxService.cs
    /// 功能描述: 腾讯通信息服务，用于统一调用RTX的访问接口
    /// 创建人：qw
    /// 创建日期: 2013.2.28
    /// </summary>
    public class RtxService
    {

        #region "RTX重置用户密码"

        /// <summary>
        /// RTX重置用户密码
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_uLoginName"></param>
        public static void RTXModifyUser(System.Web.UI.Page page, string _uLoginName)
        {
            RtxServiceEntry.RTXModifyUser(page, _uLoginName);
        }

        #endregion

        #region "发送腾讯通消息提醒"

        /// <summary>
        /// 多人组成的字符串发送腾讯通消息提醒--用户ID串
        /// </summary>
        /// <param name="iUsers">人员</param>
        /// <param name="sTitle">标题</param>
        /// <param name="sContent">内容</param>
        public static void SendRtxMessageServices(string iUsers, string sTitle, string sContent)
        {
            if (!string.IsNullOrEmpty(iUsers))
            {
                string[] users = iUsers.Split(',');
                if (users.Length >= 1)
                {
                    for (int i = 0; i < users.Length; i++)
                    {
                        int uId = 0;
                        int.TryParse(users[i],out uId);
                        if (uId != 0)
                        {
                            //按用户ID
                            SendRtxMessageByUserId(uId, sTitle, sContent);
                        }
                    }
                }
            }
        }

        #endregion

        #region "发送腾讯通即时提醒消息"

        /// <summary>
        ///  发送腾讯通即时提醒消息--按用户ID
        /// </summary>
        /// <param name="iReveiver">用户Id</param>
        /// <param name="sTitle">标题</param>
        /// <param name="sContent">内容</param>
        public static void SendRtxMessageByUserId(int iReveiver, string sTitle, string sContent)
        {
            SysUserService uService = new SysUserService();
            var query = uService.GetList().FirstOrDefault(p=>p.USERID == iReveiver);
            if (query != null)
            {
                RtxServiceEntry.SendRtxMessageServices(query.ULOGINNAME, sTitle, sContent);
            }
        }

        /// <summary>
        /// 发送腾讯通即时消息--按用户登录名
        /// </summary>
        /// <param name="sReveiver">接收人帐号</param>
        /// <param name="sTitle">标题</param>
        /// <param name="sContent">内容</param>
        /// UserName:Caitou
        /// Date：2011/4/10 9:43
        /// MachineName:CAITOU-PC
        public static void SendRtxMessageByLoginName(string sReveiver, string sTitle, string sContent)
        {
            RtxServiceEntry.SendRtxMessageServices(sReveiver, sTitle, sContent);
        }

        #endregion

    }

}
