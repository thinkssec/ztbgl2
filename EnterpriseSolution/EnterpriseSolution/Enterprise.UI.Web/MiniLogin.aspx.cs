using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Model.Basis.Sys;
using Enterprise.Model.Basis.Bf;
using Enterprise.Service.Basis.Sys;
using Enterprise.Service.Basis.Bf;
using Enterprise.Service.Common.Meeting;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;

namespace Enterprise.UI.Web
{
    public partial class MiniLogin : System.Web.UI.Page
    {
        //接收验证参数
        protected string user = (string)Utility.sink("user", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string sign = (string)Utility.sink("sign", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected Utility.LanguageType UserLangType = Utility.LanguageType.zhcn;
        private string cmd = (string)Utility.sink("Cmd", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        private string articleId = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmd) && !string.IsNullOrEmpty(user))
            {
                SysUserService uService = new SysUserService();
                var userModel = uService.GetList().Where(p => p.ULOGINNAME == user).FirstOrDefault();
                if (userModel != null && userModel.USTATUS == 0)
                {
                    SysUserLoginService logingSrv = new SysUserLoginService();
                    logingSrv.Signin(userModel);
                    switch (cmd)
                    {
                        case "1"://Default.aspx
                            Response.Redirect("Default.aspx", true);
                            break;
                        case "2"://TodoIndex.aspx
                            Response.Redirect("TodoIndexBox.aspx", true);
                            break;
                        case "3"://Modules/Common/Article/ArticleDetail.aspx?
                            Response.Redirect("/Modules/Common/Article/ArticleDetail.aspx?Id=" + articleId, true);
                            break;
                    }
                }
            }
            else if (!string.IsNullOrEmpty(user))
            {
                bool isValid = true;
                SysUserService uService = new SysUserService();
                var userModel = uService.GetList().Where(p => p.ULOGINNAME == user).FirstOrDefault();
                if (userModel != null && userModel.USTATUS == 0)
                {
                    if (userModel.UDEFAULTLANGUAGE == Utility.LanguageType.ru.ToString())
                    {
                        UserLangType = Utility.LanguageType.ru;
                    }
                }
                else if (userModel == null)
                {
                    //用户验证失败时，进行IP地址的验证
                    userModel = uService.GetList().Where(p => p.UIP == Utility.GetIPAddress()).FirstOrDefault();
                    if (userModel != null && userModel.USTATUS == 0)
                    {
                        user = userModel.ULOGINNAME;//因为是IP验证，要转为正确的用户账号
                        if (userModel.UDEFAULTLANGUAGE == Utility.LanguageType.ru.ToString())
                        {
                            UserLangType = Utility.LanguageType.ru;
                        }
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }

                if (!isValid)
                {
                    Response.Write("用户[" + user + "]身份验证失败!<br/>");
                    Response.Write("【<a href='EnterpriseAutoLogin.aspx'>重新尝试</a>】");
                    Response.End();
                }
            }
        }

        /// <summary>
        /// 获取进入信息
        /// </summary>
        /// <returns></returns>
        protected string GetEnterInfo()
        {
            string info = string.Empty;
            //string rtxUsers = ConfigurationManager.AppSettings["RtxAccounts"];
            //由于有些用户的IE浏览器有问题，在不能重装的情况下一个折衷办法，但需要降低IE的安全等级
            string cmdKey = DESEncrypt.Encrypt("1");
            string cmdUser = DESEncrypt.Encrypt(user);
            //if (rtxUsers.Contains("," + user + ","))
            //{
            //    info = "<a href=\"#\" onclick=\"callDefExplorer('http://118.186.56.88:8007/QuickLogin.aspx?Cmd="
            //        + cmdKey + "&user=" + cmdUser + "');return false;\" target=\"_blank\">"
            //        + SysDictionaryService.TranslateTo("进入", UserLangType) + "/Enter</a>";
            //}
            //else
            {
                info = "<a href=\"QuickLogin.aspx?Cmd=" + cmdKey + "&user=" + cmdUser + "\" target=\"_blank\">"
                    + SysDictionaryService.TranslateTo("进入", UserLangType) + "/Enter</a>";
            }
            return info;
        }

        /// <summary>
        /// 获取待办信息
        /// </summary>
        /// <returns></returns>
        protected string GetBacklogInfo()
        {
            string info = string.Empty;
            //string rtxUsers = ConfigurationManager.AppSettings["RtxAccounts"];
            //由于有些用户的IE浏览器有问题，在不能重装的情况下一个折衷办法，但需要降低IE的安全等级
            string cmdKey = DESEncrypt.Encrypt("2");
            string cmdUser = DESEncrypt.Encrypt(user);
            string backlogCount = getUnhandleListCountToJSONForUser(user);
            //if (rtxUsers.Contains("," + user + ","))
            //{
            //    info = "<a href=\"#\" onclick=\"callDefExplorer('http://118.186.56.88:8007/QuickLogin.aspx?Cmd=" 
            //        + cmdKey + "&user=" + cmdUser + "');return false;\" target=\"_blank\" title=\"待办事务\" style=\"padding-left: 32px;\">"
            //        + SysDictionaryService.TranslateTo("待办事务", UserLangType) + "(" + backlogCount + ")</a>";
            //}
            //else
            {
                info = "<a href=\"QuickLogin.aspx?Cmd=" + cmdKey + "&user=" + cmdUser + "\" target=\"_blank\" title=\"待办事务\" style=\"padding-left: 32px;\">"
                    + SysDictionaryService.TranslateTo("待办事务", UserLangType) + "(" + backlogCount + ")</a>";
            }
            return info;
        }

        /// <summary>
        /// 得到指定用户所有未处理的待办数量
        /// </summary>
        /// <param name="loginName">登录名称</param>
        /// <returns></returns>
        private string getUnhandleListCountToJSONForUser(string loginName)
        {
            BfMsgService messageSrv = new BfMsgService();
            MeetingInfoService meetingService = new MeetingInfoService();
            int userId = SysUserService.GetUserId(loginName);
            //未处理的待办消息
            StringBuilder sb = new StringBuilder();
            List<BfUnhandledmsgModel> todomsgLst = messageSrv.GetUnhandleList().
                Where(p => p.BF_RECIPIENTS == userId && p.BF_ISREAD == 0).ToList();
            //待签收确认的会议通知
            var meetinglist = meetingService.MeetingUnCheck(userId);
            sb.Append(todomsgLst.Count + meetinglist.Count);
            return sb.ToString();
        }

        /// <summary>
        /// 产生其它系统的链接
        /// </summary>
        /// <returns></returns>
        protected string GetLinkUrl()
        {
            //string rtxUsers = ConfigurationManager.AppSettings["RtxAccounts"];
            StringBuilder url = new StringBuilder();
            //if (!string.IsNullOrEmpty(user))
            //{
            //    SysUserService uService = new SysUserService();
            //    var userModel = uService.GetList().Where(p => p.ULOGINNAME == user).FirstOrDefault();
            //    if (userModel != null && userModel.USTATUS == 0)
            //    {
            //        //传递参数"key"，如："jian_li|zhcn|2013-03-13 15:36:42|公司领导|jian_li,jian_li_spc"
            //        string keys = string.Empty;
            //        keys = userModel.ULOGINNAME + "|" + userModel.UDEFAULTLANGUAGE + "|"
            //                + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") + "|"
            //                + SysDepartmentService.GetDepartMentName(userModel.DEPTID) + "|" + userModel.USYSTEM2;
            //        keys = DESEncrypt.Encrypt(keys);
            //        url.Append("<ul>");
            //        ////需要特殊处理的用户
            //        //if (rtxUsers.Contains("," + user + ","))
            //        //{
            //        //    url.Append("<li><a href='#' onclick=\"callDefExplorer('http://118.186.56.88:8009/Login.aspx?Key="
            //        //        + keys + "');return false;\" target='_blank'>"
            //        //        + SysDictionaryService.TranslateTo("全员绩效考核", UserLangType) + "</a></li>");
            //        //}
            //        //else
            //        {
            //            url.Append("<li><a href='http://118.186.56.88:8009/Login.aspx?Key=" + keys + "' target='_blank'>"
            //                + SysDictionaryService.TranslateTo("全员绩效考核", UserLangType) + "</a></li>");
            //        }

            //        keys = userModel.ULOGINNAME + "|" + userModel.UDEFAULTLANGUAGE + "|"
            //                + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") + "|"
            //                + SysDepartmentService.GetDepartMentName(userModel.DEPTID) + "|" + userModel.USYSTEM1;
            //        keys = DESEncrypt.Encrypt(keys);
            //        ////需要特殊处理的用户
            //        //if (rtxUsers.Contains("," + user + ","))
            //        //{
            //        //    url.Append("<li><a href='#' onclick=\"callDefExplorer('http://118.186.56.88:8008/Login.aspx?Key="
            //        //        + keys + "');return false;\" target='_blank'>"
            //        //        + SysDictionaryService.TranslateTo("机构绩效考核", UserLangType) + "</a></li>");
            //        //}
            //        //else
            //        {
            //            url.Append("<li><a href='http://118.186.56.88:8008/Login.aspx?Key=" + keys + "' target='_blank'>"
            //                + SysDictionaryService.TranslateTo("机构绩效考核", UserLangType) + "</a></li>");
            //        }
                    
            //        url.Append("</ul>");
            //    }
            //}
            return url.ToString();
        }
    }
}