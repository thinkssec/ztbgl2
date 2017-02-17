using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using RTXSAPILib;
using Enterprise.Component.Infrastructure;

namespace Enterprise.Component.Message
{
    /// <summary>
    /// 文件名:  RtxServiceEntry.cs
    /// 功能描述: 统一调用腾讯通Rtx访问接口的服务类
    /// 创建人：qw
    /// 创建日期: 2013.2.26
    /// </summary>
    public class RtxServiceEntry
    {

        #region  "RTX添加用户"
        /// <summary>
        /// RTX添加用户
        /// </summary>
        /// <param name="_uLoginName">登录名</param>
        /// <param name="_uName">姓名</param>
        /// <param name="_uSex">性别</param>
        /// <param name="deptId">所在部门</param>
        public static void RTXAddUser(System.Web.UI.Page page, string _uLoginName, string _uName, string _uSex, string _uMobile,string _uEmail,string _uTel,string deptName)
        {
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPIUserManager UserManagerObj = RootObj.UserManager;
                RTXSAPIDeptManager DeptManagerObj = RootObj.DeptManager;

                //if (!UserManagerObj.IsUserExist(_uLoginName))
                //{
                //向腾讯通中添加用户
                UserManagerObj.AddUser(_uLoginName, 0);  //添加用户
                UserManagerObj.SetUserPwd(_uLoginName, _uLoginName);  //添加密码，默认与用户名相同
                //给用户指定部门
                DeptManagerObj.AddUserToDept(_uLoginName, "", deptName, false);
                //用户基本信息设置--用户名、姓名、性别、手机、邮箱、座机、用户性质（0、1）
                int plGender = _uSex == "男" ? 0 : 1;
                UserManagerObj.SetUserBasicInfo(_uLoginName, _uName, plGender, _uMobile, _uEmail, _uTel, 0);
                //}
                //else
                //{
                //    Debuger.GetInstance().log("腾讯通中已经存在该用户！" + _uLoginName);
                //    Utility.ShowMsg(page, "腾讯通中已经存在该用户！");
                //}
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(page, "RTXAddUser方法执行出现错误!" + _uLoginName, ex);
                Utility.ShowMsg(page, ex.Message);
            }
        }
        #endregion

        #region "RTX调整用户部门"
        /// <summary>
        /// RTX调整用户部门
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_uLoginName">帐号</param>
        /// <param name="_oDeptId">旧部门</param>
        /// <param name="_nDeptId">新部门</param>
        public static void RTXModifyUserDept(System.Web.UI.Page page, string _uLoginName,string _odeptName,string _ndeptName)
        {
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPIUserManager UserManagerObj = RootObj.UserManager;
                RTXSAPIDeptManager DeptManagerObj = RootObj.DeptManager;
                DeptManagerObj.DelUserFromDept(_uLoginName, _odeptName);
                DeptManagerObj.AddUserToDept(_uLoginName, "", _ndeptName, false);
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(page, "RTXModifyUserDept方法执行出现错误!" + _uLoginName, ex);
                Utility.ShowMsg(page, ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// RTX修改用户信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_uLoginName">帐号</param>
        /// <param name="_uName">姓名</param>
        /// <param name="_uSex">性别</param>
        /// <param name="_uMobile">手机</param>
        /// <param name="_uEmail">电子邮箱</param>
        /// <param name="_uTel">座机</param>
        public static void RTXModifyUserInfo(System.Web.UI.Page page, string _uLoginName, string _uName, string _uSex, string _uMobile, string _uEmail, string _uTel)
        {
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPIUserManager UserManagerObj = RootObj.UserManager;
                //if (UserManagerObj.IsUserExist(_uLoginName))
                //{                    
                //用户基本信息设置--用户名、姓名、性别、手机、邮箱、座机、用户性质（0、1）
                int plGender = _uSex == "男" ? 0 : 1;
                UserManagerObj.SetUserBasicInfo(_uLoginName, _uName, plGender, _uMobile, _uEmail, _uTel, 0);
                //}
                //else
                //{
                //    Debuger.GetInstance().log("腾讯通中不存在该用户！" + _uLoginName);
                //    Utility.ShowMsg(page, "腾讯通中不存在该用户！");
                //}
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(page, "RTXModifyUserInfo方法执行出现错误!" + _uLoginName, ex);
                Utility.ShowMsg(page, ex.Message);
            }
        }

        #region "RTX重置用户密码"
        /// <summary>
        /// RTX重置用户密码
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_uLoginName"></param>
        public static void RTXModifyUser(System.Web.UI.Page page, string _uLoginName)
        {
            RTXModifyUserPwd(page, _uLoginName, _uLoginName);
        }
        #endregion

        #region "RTX修改用户密码"
        /// <summary>
        /// RTX重置用户密码
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_uLoginName"></param>
        public static void RTXModifyUserPwd(System.Web.UI.Page page, string _uLoginName, string _uLoginPwd)
        {
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPIUserManager UserManagerObj = RootObj.UserManager;
                //if (UserManagerObj.IsUserExist(_uLoginName))
                //{
                UserManagerObj.SetUserPwd(_uLoginName, _uLoginPwd);
                //}
                //else
                //{
                //    Debuger.GetInstance().log("腾讯通中不存在该用户！" + _uLoginName);
                //    Utility.ShowMsg(page, "腾讯通中不存在该用户！");
                //}
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(page, "RTXModifyUserPwd方法执行出现错误!" + _uLoginName, ex);
                Utility.ShowMsg(page, ex.Message);
            }
        }
        #endregion

        #region "RTX删除用户"
        /// <summary>
        /// RTX删除用户
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_uLoginName"></param>
        public static void RTXDeleteUser(System.Web.UI.Page page, string _uLoginName)
        {
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPIUserManager UserManagerObj = RootObj.UserManager;
                //if (UserManagerObj.IsUserExist(_uLoginName))
                //{
                UserManagerObj.DeleteUser(_uLoginName);
                //}
                //else
                //{
                //    Debuger.GetInstance().log("腾讯通中不存在该用户！" + _uLoginName);
                //    Utility.ShowMsg(page, "腾讯通中不存在该用户！");
                //}
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(page, "RTXDeleteUser方法执行出现错误!" + _uLoginName, ex);
                Utility.ShowMsg(page, ex.Message);
            }
        }
        #endregion

        #region "RTX新增部门"
        /// <summary>
        /// RTX新增部门
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_dName">部门名称</param>
        /// <param name="_dParentName">上级部门名称</param>
        public static void RTXAddDept(System.Web.UI.Page page, string _dName, string _dParentName)
        {
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPIDeptManager DeptManagerObj = RootObj.DeptManager;
                //if (!DeptManagerObj.IsDeptExist(_dName))
                //{
                DeptManagerObj.AddDept(_dName, _dParentName);
                //}
                //else
                //{
                //    Debuger.GetInstance().log("腾讯通中已经存在该部门！" + _dName);
                //    Utility.ShowMsg(page, "腾讯通中已经存在该部门！");
                //}
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(page, "RTXAddDept方法执行出现错误!" + _dName, ex);
                Utility.ShowMsg(page, ex.Message);
            }
        }
        #endregion

        #region "RTX修改部门名称"
        /// <summary>
        /// RTX修改部门名称
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_dName">旧名称</param>
        /// <param name="_dNewName">新名称</param>
        public static void RTXModifyDept(System.Web.UI.Page page, string _dName, string _dNewName)
        {
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPIDeptManager DeptManagerObj = RootObj.DeptManager;
                //if (DeptManagerObj.IsDeptExist(_dName))
                //{
                DeptManagerObj.SetDeptName(_dName, _dNewName);
                //}
                //else
                //{
                //    Debuger.GetInstance().log("腾讯通中不存在该部门！" + _dName);
                //    Utility.ShowMsg(page, "腾讯通中不存在该部门！");
                //}
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(page, "RTXModifyDept方法执行出现错误!" + _dName, ex);
                Utility.ShowMsg(page, ex.Message);
            }
        }

        #endregion

        #region "RTX删除部门"
        /// <summary>
        /// RTX删除部门
        /// </summary>
        /// <param name="page"></param>
        /// <param name="_dName">部门名称</param>
        public static void RTXDeleteDept(System.Web.UI.Page page, string _dName)
        {
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPIDeptManager DeptManagerObj = RootObj.DeptManager;
                //if (DeptManagerObj.IsDeptExist(_dName))
                //{
                DeptManagerObj.DelDept(_dName, true);
                //}
                //else
                //{
                //    Debuger.GetInstance().log("腾讯通中不存在该部门！" + _dName);
                //    Utility.ShowMsg(page, "腾讯通中不存在该部门！");
                //}
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(page, "RTXDeleteDept方法执行出现错误!" + _dName, ex);
                Utility.ShowMsg(page, ex.Message);
            }
        }

        #endregion


        #region 发送腾讯通即时消息"

        /// <summary>
        /// 发送腾讯通即时消息 By Caitou 2011/4/10  9:43
        /// </summary>
        /// <param name="sReveiver">接收人帐号</param>
        /// <param name="sTitle">标题</param>
        /// <param name="sContent">内容</param>
        /// UserName:Caitou
        /// Date：2011/4/10 9:43
        /// MachineName:CAITOU-PC
        public static void SendRtxMessageServices(string sReveiver, string sTitle, string sContent)
        {
            if (!string.IsNullOrEmpty(sReveiver))
            {
                try
                {
                    //当为debug时候，则不发送腾讯通消息
                    bool rbool = bool.Parse(ConfigurationManager.AppSettings["Debug"].ToString());
                    if (rbool == false)
                    {
                        //声明一个腾讯通接口根对象           
                        RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                        RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                        RootObj.ServerPort = 8006;
                        RootObj.SendNotify(sReveiver, sTitle, 0, sContent);
                    }
                }
                catch (Exception ex)
                {
                    Debuger.GetInstance().log(ex.Message);
                }
            }
        }

        #endregion


        #region "用户登录验证方法"

        /// <summary>
        /// 腾讯通界面自动登录处理程序 By Caitou 2011/8/14  9:02
        /// </summary>
        /// <param name="sUser">System sUser</param>
        /// <param name="sSign">The s sign.</param>
        /// <returns>System.Boolean</returns>
        /// UserName:Caitou
        /// Date：2011/8/14 9:02
        /// MachineName:CAITOU-PC
        public static bool RtxLoginService(string sUser, string sSign)
        {
            sUser = sUser.ToLower();
            //初始化腾讯通服务
            bool rbool = false;
            try
            {
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                RTXSAPILib.IRTXSAPIUserAuthObj2 AuthObj2 = (RTXSAPILib.IRTXSAPIUserAuthObj2)RootObj.UserAuthObj;
                rbool = AuthObj2.SignatureAuth(sUser, sSign);
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(ex.Message);
            }
            return rbool;
        }

        /// <summary>
        /// 系统界面登录处理程序 By Caitou 2012/8/20
        /// </summary>
        /// <param name="sUser"></param>
        /// <param name="sSign"></param>
        public static bool FormLoginService(string sUser, string sSign)
        {
            bool rbool = false;

            try
            {
                //初始化腾讯通服务
                RTXSAPIRootObj RootObj = new RTXSAPIRootObj();
                RootObj.ServerIP = ConfigurationManager.AppSettings["RTXServer"];
                RootObj.ServerPort = 8006;
                short sResult = RootObj.Login(sUser, sSign); //用户登录验证
                if (sResult == 0)
                {
                    rbool = true;
                }
                bool b = false;
                bool.TryParse(ConfigurationManager.AppSettings["Debug"].ToString(), out b);
                if (b)
                    return true;
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(ex.Message);
            }

            return rbool;
        }

        #endregion

    }
}
