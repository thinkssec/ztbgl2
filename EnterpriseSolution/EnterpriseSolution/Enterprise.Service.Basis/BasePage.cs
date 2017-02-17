using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.BF;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Bf;
using Enterprise.Service.Basis.Bf;

namespace Enterprise.Service.Basis
{
    /// <summary>
    /// 文件名: BasePage.cs
    /// 文件描述: 页面的基类。
    /// 用于扩展System.Web.UI.Page的功能：
    /// 1、继承业务流各节点激活方法回调类
    /// 2、实现多语言的转换
    /// 3、提供当前用户身份等信息
    /// 创建者: 乔巍
    /// 创建日期: 2012.3.5
    /// 修改日期：2013.3.3
    /// </summary>
    public class BasePage : BFNodeMethodCallback<BfInstancesModel>
    {
        /// <summary>
        /// 动作标识
        /// </summary>
        protected string Cmd = (string)Utility.sink("Cmd", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 项目ID
        /// </summary>
        protected string ProjectId = (string)Utility.sink("ProjectId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 节点编码
        /// </summary>
        protected string NodeCode = (string)Utility.sink("NodeCode", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 用户MODEL
        /// </summary>
        protected SysUserModel userModel = null;
        /// <summary>
        /// 接收参数
        /// </summary>
        protected BFNodeEventArgs<BfInstancesModel> args;
        /// <summary>
        /// 用户服务类
        /// </summary>
        protected SysUserService userSrv = new SysUserService();

        #region 业务流相关

        /// <summary>
        /// 自动装配业务流运行参数
        /// </summary>
        /// <returns></returns>
        protected BFNodeEventArgs<BfInstancesModel> GetBFNodeEventArgs()
        {
            BFNodeEventArgs<BfInstancesModel> argsE = null;
            if (!string.IsNullOrEmpty(RunID) && userModel != null)
            {
                BfRunningService runningSrv = new BfRunningService();
                BfRunningModel runningModel = runningSrv.GetModelById(RunID);
                if (runningModel != null)
                {
                    argsE = new BFNodeEventArgs<BfInstancesModel>(runningModel.BfInstance, RunID, userModel);
                }
            }
            return argsE;
        }

        /// <summary>
        /// 检测当前RUNID是否为已运行状态
        /// </summary>
        /// <returns></returns>
        protected bool CheckBFNodeIsRunOver()
        {
            bool isOver = false;
            BfRunningService runningSrv = new BfRunningService();
            BfRunningModel runningModel = runningSrv.GetModelById(RunID);
            if (runningModel != null)
            {
                if (runningModel.BF_RUNSTATUS == (int)BFRunStatus.已运行)
                {
                    isOver = true;
                }
                else if (runningModel.BfInstance != null && 
                    runningModel.BfInstance.BF_STATUSVALUE > 0)
                {
                    isOver = true;
                }
            }
            return isOver;
        }

        /// <summary>
        /// 用于获取业务流实例角色表中的用户ID
        /// 替换指定字符，返回用户ID
        /// </summary>
        /// <param name="user">用户ID串</param>
        /// <returns></returns>
        protected int GetUserId(string user)
        {
            int userId = 0;
            if (string.IsNullOrEmpty(user)) 
                return userId;

            int.TryParse(user.Replace(",", ""), out userId);
            return userId;
        }

        #endregion

        
        #region 重写超类的方法
        /// <summary>
        /// 重写OnInit方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {

            //获取用户身份信息
            userModel = userSrv.Disp(Utility.Get_UserId);
            //业务流参数
            base.RunID = Request["RunID"];
            base.MsgID = Request["MsgID"];
            //组成业务流参数对象
            args = GetBFNodeEventArgs();

            //页面渲染前执行方法,海检中心项目用不到 mod by qw 2013.11.7
            //this.PreRender += new EventHandler(BasePage_PreRender);
            base.OnInit(e);

        }

        /// <summary>
        /// 重写OnLoad方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            //先执行父类方法，以进行权限判断
            BasePage_Load(e);
            base.OnLoad(e);
        }

        /// <summary>
        /// 页面加载时的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BasePage_Load(EventArgs e)
        {
            //检测用户的缺省语言类型,只针对登录页
            string urlPath = Request.ServerVariables["Path_Info"];
            if (urlPath.Contains("Login.aspx") && Session[WebKeys.LangName] == null && 
                Request.Cookies[WebKeys.LangCookieName] != null && Request.Cookies[WebKeys.LangCookieName].Value != null)
            {
                string langType = Request.Cookies[WebKeys.LangCookieName].Value.ToString();
                Session[WebKeys.LangName] = langType;

            }
        }


        /// <summary>
        /// 页面呈现前的方法(可进行多语言转换)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BasePage_PreRender(object sender, EventArgs e)
        {
            //只进行中文转外文操作
            if (Utility.Language !=  Utility.LanguageType.zhcn)
            {                
                TransLation(this.Page, Utility.Language);
            }
        }


        /// <summary>
        /// 页面元素单独调用方法
        /// </summary>
        /// <param name="zhcn">中文</param>
        /// <returns></returns>
        protected string Trans(string zhcn)
        {
            //if (Utility.Language != Utility.LanguageType.zhcn)
            //{
            //    return SysDictionaryService.TranslateTo(zhcn, Utility.Language);
            //}
            return zhcn;
        }


        /// <summary>
        /// 页面元素单独调用方法
        /// 两种文字同时显示
        /// </summary>
        /// <param name="zhcn">中文</param>
        /// <param name="langType">第二种文字类型</param>
        /// <returns></returns>
        protected string Trans(string zhcn, Utility.LanguageType langType)
        {
            string transStr = SysDictionaryService.TranslateTo(zhcn, langType);
            return string.Format("{0}<br/>{1}", zhcn, transStr);
        }


        /// <summary>
        /// 设置控件的原始文本内容
        /// </summary>
        /// <param name="webCntrl"></param>
        /// <param name="txt"></param>
        protected void SetOriginalText(WebControl webCntrl, string txt)
        {
            if (webCntrl.HasAttributes)
            {
                webCntrl.Attributes.Add(WebKeys.OriginalText, txt);
            }
        }


        /// <summary>
        /// 获取样式表名称
        /// </summary>
        /// <param name="cssFileName"></param>
        /// <returns></returns>
        protected string GetCss(string cssFileName)
        {
            if (Utility.Language != Utility.LanguageType.zhcn)
            {
                cssFileName = cssFileName + "_" + Utility.Language.ToString();
            }
            return cssFileName + ".css";
        }


        /// <summary>
        /// 设置控制的可见性
        /// </summary>
        /// <param name="cnl"></param>
        /// <param name="v"></param>
        protected void SetCntrlVisibility(WebControl cnl, bool v)
        {
            //当Enabled为false时，默认不可见
            if (cnl.Enabled)
            {
                cnl.Visible = v;
            }
            else
            {
                cnl.Visible = false;
            }
        }

        #endregion

        //#region 多语言转换部分

        /// <summary>
        /// 语言转换入口
        /// </summary>
        /// <param name="page">Page</param>
        /// <param name="yz">LanguageType</param>
        private void TransLation(Page page, Utility.LanguageType langType)
        {
            Control control = (Control)page;
            TransLation(control, langType);
        }

        /// <summary>
        /// 对页面控件进行枚举并完成文本的语言转换
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="yz"></param>
        private void TransLation(Control parentControl, Utility.LanguageType langType)
        {
            if (!parentControl.HasControls())
            {
                return;
            }

            foreach (Control control in parentControl.Controls)
            {
                if (control.HasControls())
                {
                    //递归
                    TransLation(control, langType);
                }
                switch (control.GetType().Name.ToString())
                {
                    case "Label":
                        Label label = (Label)control;
                        label.Text = SysDictionaryService.TranslateTo(label.Text, langType);
                        break;
                    case "Button":
                        Button button = (Button)control;
                        button.Text = SysDictionaryService.TranslateTo(button.Text, langType);
                        break;
                    case "Literal":
                        Literal literal = (Literal)control;
                        literal.Text = SysDictionaryService.TranslateTo(literal.Text, langType);
                        break;
                    case "LinkButton":
                        LinkButton linkbutton = (LinkButton)control;
                        linkbutton.Text = SysDictionaryService.TranslateTo(linkbutton.Text, langType);
                        break;
                    case "DataControlFieldHeaderCell":
                        DataControlFieldHeaderCell dch = (DataControlFieldHeaderCell)control;
                        dch.Text = SysDictionaryService.TranslateTo(dch.Text, langType);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
