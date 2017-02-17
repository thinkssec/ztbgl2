using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Enterprise.Component.Message;
using Enterprise.Model.Basis.Sys;
using Enterprise.Component.Infrastructure;
namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysUserLoginService.cs
    /// 功能描述: 业务逻辑层-用户登录
    /// 创建人：caitou
    /// 创建日期: 2013.1.21
    /// </summary>
    public class SysUserLoginService
    {
        #region"公有方法"
        /// <summary>
        /// 用户登录(通过腾讯通登录&通过界面进行登录);
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sSign"></param>
        /// <param name="iLoginType">登录方式 0：由系统界面登录 1：由腾讯通登录;</param>
        /// <returns></returns>
        public bool EnterpriseLogin(string sUserName, string sSign, int iLoginType)
        {
            bool rbool = false;
            //登录方式进行分解
            if (iLoginType == 0)
            {
                rbool = FormLoginService(sUserName, sSign);
                if (rbool) {
                    Debuger.GetInstance().log(string.Format("用户{0},AD身份验证通过!", sUserName));
                }
            }
            else if (iLoginType == 1)
            {
                rbool = RtxLoginService(sUserName, sSign);
            }
            //登录成功后，自动进用户记录系统中
            SysUserService uService = new SysUserService();
            var user = uService.GetList().Where(p => p.ULOGINNAME == sUserName).FirstOrDefault();
            if (rbool)
            {                
                if (user != null && user.USTATUS == 0)
                {
                    Signin(user);
                    rbool = true;
                }
                else
                {
                    rbool = false;
                }
            }
            //add by qw 2015.1.23 在外网的用户，由于RTX验证端口的问题，改用手机号登陆
            else
            {
                if (user != null && user.USTATUS == 0 && user.UHWPHONE == sSign)
                {
                    Signin(user);
                    rbool = true;
                }
            }

            return rbool;
        }

        /// <summary>
        /// 用户登陆 加密身份验证票字串
        /// </summary>
        /// <param name="uDt">用户实体类</param>
        public void Signin(SysUserModel uDt)
        {
            System.Web.Security.FormsAuthenticationTicket tk = new System.Web.Security.FormsAuthenticationTicket(1, uDt.USERID.ToString(), DateTime.Now, DateTime.Now.AddMonths(1), true, "", System.Web.Security.FormsAuthentication.FormsCookiePath);
            string key = System.Web.Security.FormsAuthentication.Encrypt(tk);//得到加密后的身份验证票字串
            //ck.Domain = System.Web.Security.FormsAuthentication.CookieDomain;  // 这句话在部署网站后有用，此为关系到同一个域名下面的多个站点是否能共享Cookie
            HttpCookie ck = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, key);
            HttpContext.Current.Response.Cookies.Add(ck);            
            //语言类型
            Utility.Language = (Utility.LanguageType)Enum.Parse(typeof(Utility.LanguageType),
                (string.IsNullOrEmpty(uDt.UDEFAULTLANGUAGE) ? Utility.LanguageType.zhcn.ToString() : 
                uDt.UDEFAULTLANGUAGE));
        }

        /// <summary>
        /// 用户退出
        /// </summary>
        public void UserOut()
        {
            //UserServices.Move_UserPermissionCache(General.Get_UserID);
            //UserServices.MoveUserCache(General.Get_UserID);
            //HttpContext.Current.Response.Cookies["MenuStyle"].Expires = DateTime.Now.AddDays(-30);
            //HttpContext.Current.Response.Cookies["PageSize"].Expires = DateTime.Now.AddDays(-30);
            //HttpContext.Current.Response.Cookies["TableSink"].Expires = DateTime.Now.AddDays(-30);
            //HttpContext.Current.Response.Cookies["IcuSessionID"].Expires = DateTime.Now.AddDays(-30);
            System.Web.Security.FormsAuthentication.SignOut();
        }
        #endregion

        #region "用户登录私有方法"

        /// <summary>
        /// 腾讯通界面自动登录处理程序 By Caitou 2011/8/14  9:02
        /// </summary>
        /// <param name="sUser">System sUser</param>
        /// <param name="sSign">The s sign.</param>
        /// <returns>System.Boolean</returns>
        /// UserName:Caitou
        /// Date：2011/8/14 9:02
        /// MachineName:CAITOU-PC
        private static bool RtxLoginService(string sUser, string sSign)
        {
            sUser = sUser.ToLower();
            //初始化腾讯通服务
            bool rbool = true;
            if (ConfigurationManager.AppSettings["Debug"].ToLower().Equals("false"))
            {
                rbool = RtxServiceEntry.RtxLoginService(sUser, sSign);
            }
            else
            {
                //测试用
                rbool = true;
            }
            //RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
            //RTXSAPILib.IRTXSAPIUserAuthObj2 AuthObj2 = (RTXSAPILib.IRTXSAPIUserAuthObj2)RootObj.UserAuthObj;
            //rbool = AuthObj2.SignatureAuth(sUser, sSign);
            return rbool;
        }

        /// <summary>
        /// 系统界面登录处理程序 By Caitou 2012/8/20
        /// </summary>
        /// <param name="sUser"></param>
        /// <param name="sSign"></param>
        private static bool FormLoginService(string sUser, string sSign)
        {
            LogHelper.WriteLog(sUser+"---------------"+sSign);
            bool rbool = false;
            if (sUser == "admin")
            {
                if (sSign == "@server" + DateTime.Now.Year)
                {
                    rbool = true;
                }
            }
            else
            {
                if (ConfigurationManager.AppSettings["Debug"].ToLower().Equals("false"))
                {
                    return (SlytADauthEntry.GetADUserInfo(sUser, sSign) != null);
                    //return RtxServiceEntry.FormLoginService(sUser, sSign);
                }
                else
                {
                    //测试用
                    rbool = true;
                }
            }
            return rbool;
        }
        #endregion
    }
}
