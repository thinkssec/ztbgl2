using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Compression;
using System.Text;
using System.Linq;
using System.Web.Security;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.Basis
{
    /// <summary>
    /// 权限验证服务类,实现IHttpModule接口中的方法
    /// </summary>
    public class PermissionService : IHttpModule
    {

        #region 变量定义区

        /// <summary>
        /// 读取配置状态
        /// </summary>
        public static bool InitState = true;
        internal delegate void DelegateCheckUpdate();
        /// <summary>
        /// 应用启动时间
        /// </summary>
        public static DateTime AppStartTime;
        /// <summary>
        /// 保存用户最近一次访问的日志数据
        /// </summary>
        private static Hashtable historyVisitLogHash = Hashtable.Synchronized(new Hashtable());

        #endregion

        void IHttpModule.Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(app_HttpGZip);
            app.Error += new EventHandler(app_Error);
            app.AuthenticateRequest += new EventHandler(app_AuthMethod);
            app.AcquireRequestState += new EventHandler(app_Auth);
            AppStartTime = DateTime.Now;
        }

        /// <summary>
        /// HttpGZip压缩
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="ex"></param>
        private void app_HttpGZip(object ob, EventArgs ex)
        {
            //加载遮罩
            HttpApplication ap = ob as HttpApplication;             
            //UserOnlineService.ClearTimeOut();
            if ((InitState) && true)
            {
                
                if (Utility.GetScriptNameExt.ToLower() == "aspx" && 
                    ap.Request.Headers["Accept-encoding"] != null && ap.Request.Headers["Accept-encoding"].Contains("gzip"))
                {
                    ap.Response.Filter = new GZipStream(ap.Response.Filter, CompressionMode.Compress);
                    ap.Response.AppendHeader("Content-encoding", "gzip");
                    ap.Response.AppendHeader("Vary", "Content-encoding");
                }
            }
        }

        /// <summary>
        /// 系统认证方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private void app_AuthMethod(object sender, EventArgs ex)
        {
            //判断文件名为aspx
            if (!Utility.CheckScriptNameChar("login") && !Utility.CheckScriptNameChar("website") &&
                (Utility.GetScriptNameExt.ToLower() == "aspx" || Utility.GetScriptUrl.Contains("/SSEC/")))
            {
                //检测方法权限设置
                HttpApplication App = (HttpApplication)sender;
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = App.Context.Request.Cookies[cookieName];

                if (null == authCookie)
                {
                    // 沒有驗證 Cookie。
                    return;
                }
                FormsAuthenticationTicket authTicket = null;
                try
                {
                    authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                }
                catch (Exception e)
                {
                    // 記錄例外狀況詳細資料 (為簡單起見已省略)
                    LogHelper.WriteLog(ex.ToString());
                    return;
                }

                if (null == authTicket)
                {
                    // Cookie 無法解密。
                    return;
                }

                // 建立 Identity 物件
                FormsIdentity id = new FormsIdentity(authTicket);
                App.Context.User = new PermissionPrincipal(id);
            }

        }

        /// <summary>
        /// 处理认证成功事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void app_Auth(object sender, EventArgs e)
        {
            //保存SESSIONID
            if (HttpContext.Current.Session != null &&
                !Utility.SessionIDHash.ContainsKey(HttpContext.Current.Session.SessionID) &&
                Utility.Get_UserId > 0)
            {
                Utility.SessionIDHash[HttpContext.Current.Session.SessionID] = Utility.Get_UserId;
            }

            //当前用户验证
            if (!Utility.CheckScriptNameChar("login")&&!Utility.CheckScriptNameChar("mobile") && !Utility.CheckScriptNameChar("website") &&
                (Utility.GetScriptNameExt.ToLower() == "aspx" || Utility.GetScriptUrl.Contains("/SSEC/")))
            {
                int UserId = Utility.Get_UserId;
                if (UserId == 0)
                {
                    if (HttpContext.Current != null &&
                        Utility.SessionIDHash.ContainsKey(HttpContext.Current.Session.SessionID))
                    {
                        UserId = (int)Utility.SessionIDHash[HttpContext.Current.Session.SessionID];
                        SysUserService uService = new SysUserService();
                        var user = uService.GetList().Where(p => p.USERID == UserId).FirstOrDefault();
                        if (user != null)
                        {
                            SysUserLoginService loginSrv = new SysUserLoginService();
                            loginSrv.Signin(user);
                            Debuger.GetInstance().log("用户重新验证：" + user.ULOGINNAME + "," + user.USERID);
                            System.Web.HttpContext.Current.Response.Redirect("/Default.aspx");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                    else
                    {
                        Debuger.GetInstance().log("<<<<<<用户验证无效>>>>>");
                        System.Web.HttpContext.Current.Response.Redirect("/Login.aspx");
                        System.Web.HttpContext.Current.Response.End();
                    }
                }

                //add by qw 2015.3.19 为了减轻数据库负载，对相同路径进行过滤
                bool isSave = false;
                if (historyVisitLogHash.ContainsKey(UserId))
                {
                    //进行路径比较
                    string userUrlPath = "http://" + Utility.GetHomeUrl() + Utility.GetScriptName;
                    SysVisitLogModel model = historyVisitLogHash[UserId] as SysVisitLogModel;
                    isSave = (model != null && model.VLURL.StartsWith(userUrlPath)) ? false : true;
                }
                else
                {
                    //不包含该用户信息则直接保存
                    isSave = true;
                }
                if (isSave)
                {
                    //访问日志
                    SysVisitLogModel lModel = new SysVisitLogModel();
                    lModel.VLID = CommonTool.GetGuidKey();
                    lModel.DB_Option_Action = WebKeys.InsertAction;
                    lModel.VLLOGINUSERID = UserId;
                    lModel.VLLOGINTIME = DateTime.Now;
                    lModel.VLLOGINIP = Utility.GetIPAddress();
                    lModel.VLURL = "http://" + Utility.GetHomeUrl() + Utility.GetScriptUrl;
                    lModel.VLTIMESPAN = 0;
                    SysVisitLogService vSer = new SysVisitLogService();
                    vSer.Execute(lModel);
                    //暂存
                    historyVisitLogHash[UserId] = lModel;
                }
                //end
                //检测权限
                if (!Check_Permission())
                {
                    System.Web.HttpContext.Current.Response.Redirect(string.Format("/Error.aspx?msg={0}", "对不起，您还没有访问授权！"));
                    System.Web.HttpContext.Current.Response.End();
                }
            }
        }

        /// <summary>
        /// 处理出错日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void app_Error(object sender, EventArgs e)
        {

            HttpApplication ap = sender as HttpApplication;
            Exception ex = ap.Server.GetLastError();
            if (ex is HttpException)
            {
                HttpException hx = (HttpException)ex;
                if (hx.GetHttpCode() == 404)
                {
                    string page = ap.Request.PhysicalPath;
                    LogHelper.WriteLog(string.Format("app_Error=>文件不存在:{0}", ap.Request.Url.AbsoluteUri));
                    return;
                }
            }
            if (ex.InnerException != null) ex = ex.InnerException;
            //日志接入口
            LogHelper.WriteLog(ex.Source + " thrown " + ex.GetType().ToString() + "<br />" + ex.Message.Replace("\r", "").Replace("\n", "<br />") + "<br />" + ex.StackTrace.Replace("\r", "").Replace("\n", "<br />"));
            //跳转到错误显示页面
            if (!ConfigurationManager.AppSettings["Debug"].ToLower().Equals("true"))
            {
                ap.Response.Redirect("/Error.aspx?msg=程序执行出现错误！请查看系统日志！");
            }
        }


        /// <summary>
        /// 访问权限验证
        /// 说明：通过验证只表示用户具有访问权限，其他类型的操作权限在页面中具体处理
        /// </summary>
        /// <returns></returns>
        public bool Check_Permission()
        {
            bool isOK = false;
            string pageCode = string.Empty;
            isOK = SysUserPermissionService.CheckCurrentUserPermission(Utility.PopedomType.List, out pageCode);
            return isOK;
        }

        /// <summary>
        /// 获取当前访问网页文件名格式: ,文件名,
        /// </summary>
        public static string Get_Script_Name
        {
            get
            {
                string Script_Name = Utility.GetScriptName;
                Script_Name = Script_Name.Substring(Script_Name.LastIndexOf("/") + 1);
                return string.Format(",{0},", Script_Name);
            }
        }

        /// <summary>
        /// 移除用户无权限模块列表
        /// </summary>
        /// <param name="list"></param>
        public static List<SysModuleModel> RemoveNoPermission(List<SysModuleModel> list)
        {
            List<SysModuleModel> relist = new List<SysModuleModel>();
            foreach (SysModuleModel var in list)
            {
                bool rbool = SysUserPermissionService.CheckPageCode(Utility.Get_UserId, 1, var.MCODE);
                if (rbool)
                {
                    relist.Add(var);
                }
            }
            return relist;
        }

        #region IHttpModule 成员

        void IHttpModule.Dispose()
        {

        }
        #endregion
    }
}
