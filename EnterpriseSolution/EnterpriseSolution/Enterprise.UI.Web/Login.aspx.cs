using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web
{
    /// <summary>
    /// 登录验证页面
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        
        //系统消息
        string msg = (string)Utility.sink("msg", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        //登录类型
        int LoginType = (int)Utility.sink("LoginType", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        //腾讯通登录需要获取的信息
        //解密处理
        string user = (string)Utility.sink("user", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string sign = (string)Utility.sink("sign", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            //登录失败账号集合
            if (Global.UserLoginFailLst == null) 
                Global.UserLoginFailLst = new List<UserLoginStatistics>();

            if (!IsPostBack)
            {
            //    if (LoginType == 1)
            //    {
            //        SysUserLoginService logService = new SysUserLoginService();
            //        bool rbool = logService.EnterpriseLogin(user, sign, 1);
            //        if (rbool)
            //        {
            //            Debuger.GetInstance().log(string.Format("RTX验证：用户【{0}】于【{1}】成功登录系统!IP:{2}", user, DateTime.Now, Utility.GetIPAddress()));
            //            Response.Redirect("Default.aspx");
            //            Response.End();
            //        }
            //        else
            //        {
            //            Debuger.GetInstance().log(string.Format("RTX验证失败：用户【{0}】于【{1}】尝试登录系统!IP:{2},方式:{3}", user, DateTime.Now, Utility.GetIPAddress(), sign));
            //            Response.Redirect("Login.aspx");
            //            Response.End();
            //        }
            //    }

                //语言选择
                DropDownList ddl = (DropDownList)Page.FindControl("Language");
                ddl.SelectedValue = Utility.Language.ToString();

                //显示提示消息
                Lbl_Msg.Text = msg;
            }
        }

        /// <summary>
        /// 页面登录验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginOA();
            
        }

        public void LoginOA()
        {
            string sName = (string)Utility.sink(UserName.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            string sPassword = (string)Utility.sink(Password.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            if (!string.IsNullOrEmpty(sName)) sName = sName.Replace(".trqi","");
            UserLoginStatistics userLoginFailModel = Global.UserLoginFailLst.Find(p => p.LoginName == sName);
            if (userLoginFailModel != null && userLoginFailModel.FailCount >= 5)
            {
                Response.Redirect("Login.aspx?msg=" + SysDictionaryService.TransTo("您的失败次数达到了5次!请5分钟后再试!"));
                Response.End();
            }

            SysUserLoginService logService = new SysUserLoginService();
            bool rbool = logService.EnterpriseLogin(sName, sPassword, 0);
            LogHelper.WriteLog(rbool+"----");
            if (rbool)
            {
                //语言类型
                Utility.Language = (Utility.LanguageType)Enum.Parse(typeof(Utility.LanguageType), Language.SelectedValue);
                Debuger.GetInstance().log(string.Format("页面验证：用户【{0}】于【{1}】成功登录系统!IP:{2}", sName, DateTime.Now, Utility.GetIPAddress()));
                Response.Redirect("/SSEC/Main");
                Response.End();
            }
            else
            {
                //add by qw 2013.5.21 start
                int failCount = 0;
                if (userLoginFailModel != null)
                {
                    UserLoginStatistics newUserModel = new UserLoginStatistics();
                    newUserModel.LoginName = userLoginFailModel.LoginName;
                    newUserModel.FailCount = userLoginFailModel.FailCount + 1;
                    failCount = newUserModel.FailCount;
                    newUserModel.RecordDate = DateTime.Now;
                    Global.UserLoginFailLst.Remove(userLoginFailModel);
                    Global.UserLoginFailLst.Add(newUserModel);
                }
                else
                {
                    UserLoginStatistics newUserModel = new UserLoginStatistics();
                    newUserModel.LoginName = sName;
                    newUserModel.FailCount = 1;
                    failCount = newUserModel.FailCount;
                    newUserModel.RecordDate = DateTime.Now;
                    Global.UserLoginFailLst.Add(newUserModel);
                }
                //end
                Debuger.GetInstance().log(string.Format("用户验证失败：用户【{0}】于【{1}】尝试登录系统!IP:{2},口令:{3}", 
                    ((!string.IsNullOrEmpty(user)) ? user : sName), DateTime.Now, Utility.GetIPAddress(), sPassword));
                Response.Redirect("Login.aspx?msg=" + SysDictionaryService.TransTo("用户验证失败") + failCount + SysDictionaryService.TransTo("次"));
                Response.End();
            }
        }

        #region 专用方法区

        /// <summary>
        /// 显示提示消息
        /// </summary>
        /// <returns></returns>
        private string showMsg()
        {
            return "";
        }

        #endregion
    }
}