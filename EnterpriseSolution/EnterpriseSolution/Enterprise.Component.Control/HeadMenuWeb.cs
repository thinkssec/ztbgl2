using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Design;
using System.Reflection;
using Enterprise.Component.Infrastructure;
namespace Enterprise.Component.Control
{
    /// <summary>
    /// 头部菜单web控件
    /// </summary>
    [
    AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal),
    DefaultProperty("ButtonList"),
    ParseChildren(true, "ButtonList"),
    ToolboxData("<{0}:HeadMenuWeb runat=\"server\"> </{0}:HeadMenuWeb>"),
    Description("头部菜单web控件")
    ]
    public class HeadMenuWeb : WebControl
    {
        /// <summary>
        /// 构造函数,不能少如果用泛型需要初始化
        /// </summary>
        public HeadMenuWeb()
        {
            _ButtonList = new List<HeadMenuButtonItem>();
        }

        #region "Private Variables"
        private List<HeadMenuButtonItem> _ButtonList;
        private string HeadMenuTemplateTxt = Utility.HeadMenuTemplateTxt1;

        private string _HeadIconPath = "~/Resources/Styles/icon/";
        private string _HeadTitleIcon = "home.png";
        private string _HeadTitleTxt = "标题";
        private string _HeadHelpIcon = "office.gif";  
        private string _HeadHelpTxt = "帮助？";
        private string _HeadOPTxt = "";


        private string CreateButtonHtml()
        {
            StringBuilder sb = new StringBuilder();
            if (_ButtonList != null && _ButtonList.Count > 0)
            {
                //sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tt\"><tr>");
                string OnUrlJs = "";
                string ButtonIcon = "";
                string ButtonTxt = "";
                int DispButtonNum = 0;
                for (int i = 0; i < _ButtonList.Count; i++)
                {
                    if (_ButtonList[i].ButtonVisible &&Enterprise.Service.Basis.Sys.SysUserPermissionService.
                        CheckButtonPermission(_ButtonList[i].ButtonPopedom))
                    {
                        DispButtonNum++;
                        OnUrlJs = "";
                        ButtonIcon = "";
                        ButtonTxt = "";
                        switch (_ButtonList[i].ButtonUrlType)
                        {
                            case Utility.UrlType.Href:
                                OnUrlJs = string.Format("{0}", _ButtonList[i].ButtonUrl);
                                break;
                            case Utility.UrlType.JavaScript:
                                OnUrlJs = string.Format("JavaScript:{0}", _ButtonList[i].ButtonUrl);
                                break;
                            case Utility.UrlType.VBScript:
                                OnUrlJs = string.Format("VBScript:{0}", _ButtonList[i].ButtonUrl);
                                break;
                        }
                        if (_ButtonList[i].ButtonIcon != string.Empty)
                        {
                            ButtonIcon = HeadIconPath + _ButtonList[i].ButtonIcon;
                        }
                        else
                        {
                            ButtonIcon = HeadIconPath + _ButtonList[i].ButtonPopedom.ToString() + ".gif";
                            switch (_ButtonList[i].ButtonPopedom)
                            {
                                case Utility.PopedomType.A:
                                    ButtonTxt = "备用A";
                                    break;
                                case Utility.PopedomType.B:
                                    ButtonTxt = "备用B";
                                    break;
                                case Utility.PopedomType.Delete:
                                    ButtonTxt = "删除";
                                    break;
                                case Utility.PopedomType.Edit:
                                    ButtonTxt = "修改";
                                    break;
                                case Utility.PopedomType.List:
                                    ButtonTxt = "列表";
                                    break;
                                case Utility.PopedomType.Orderby:
                                    ButtonTxt = "排序";
                                    break;
                                case Utility.PopedomType.New:
                                    ButtonTxt = "新增";
                                    break;
                                case Utility.PopedomType.Print:
                                    ButtonTxt = "打印";
                                    break;
                            }
                        }
                        sb.AppendFormat("<a class=\"easyui-linkbutton\" style=\"margin:6px 4px;*margin:9px 6px;_margin:9px 6px;\" plain=\"true\" href=\"{0}\">", OnUrlJs, i);
                        sb.AppendFormat("<img border=\"0\" align=\"texttop\" src=\"{0}\">&nbsp;", ButtonIcon);
                        sb.AppendFormat("{0}{1}</a>", ButtonTxt, Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo(_ButtonList[i].ButtonName));
                    }
                }
                //if (DispButtonNum == 0)
                    
            }
            //if (sb.ToString() == string.Empty)
            //    sb.Append("&nbsp");
            return sb.ToString();
        }
        #endregion

        #region "Public Variables"

        /// <summary>
        /// 读取/设置头部菜单路径
        /// </summary>
        [Description("读取/设置头部菜单路径"), Category("外观"), DefaultValue("~/Manage/Common/img/icon/")]
        public string HeadIconPath
        {
            get
            {
                object m = ViewState["HeadIconPath"];
                return m == null ? ResolveClientUrl(_HeadIconPath) : ResolveClientUrl(m.ToString());
            }
            set
            {
                ViewState["HeadIconPath"] = value;
            }
        }
        /// <summary>
        /// 读取/设置标题Icon图片名
        /// </summary>
        [Description("读取/设置标题Icon图片名"), Category("外观"), DefaultValue("default.gif")]
        public string HeadTitleIcon
        {
            get
            {
                object m = ViewState["HeadTitleIcon"];
                return m == null ? string.Format("{0}{1}", HeadIconPath, _HeadTitleIcon) : string.Format("{0}{1}", HeadIconPath, m);
            }
            set
            {
                ViewState["HeadTitleIcon"] = value;
            }
        }
        /// <summary>
        /// 读取/设置标题名称
        /// </summary>
        [Description("读取/设置标题名称"), Category("外观"), DefaultValue("标题名称")]
        public string HeadTitleTxt
        {
            get
            {
                object m = ViewState["HeadTitleTxt"];
                return m == null ? _HeadTitleTxt : m.ToString();
            }
            set
            {
                ViewState["HeadTitleTxt"] = value;
            }
        }

        /// <summary>
        /// 读取/设置帮助Icon名称
        /// </summary>
        [Description("读取/设置帮助Icon图片名"), Category("外观"), DefaultValue("office.gif")]
        public string HeadHelpIcon
        {
            get
            {
                object m = ViewState["HeadHelpIcon"];
                return m == null ? string.Format("{0}{1}", HeadIconPath, _HeadHelpIcon) : string.Format("{0}{1}", HeadIconPath, m);
            }
            set
            {
                ViewState["HeadHelpIcon"] = value;
            }
        }
        /// <summary>
        /// 读取/设置帮助文字
        /// </summary>
        [Description("读取/设置帮助文字"), Category("外观"), DefaultValue("帮助？")]
        public string HeadHelpTxt
        {
            get
            {
                object m = ViewState["HeadHelpTxt"];
                return m == null ? _HeadHelpTxt : m.ToString();
            }
            set
            {
                ViewState["HeadHelpTxt"] = value;
            }
        }
        /// <summary>
        /// 读取/设置操作说明
        /// </summary>
        [Description("读取/设置操作说明"), Category("外观"), DefaultValue("")]
        public string HeadOPTxt
        {
            get
            {
                object m = ViewState["HeadOPTxt"];
                return m == null ? _HeadOPTxt : m.ToString();
            }
            set
            {
                ViewState["HeadOPTxt"] = value;
            }
        }
        /// <summary>
        /// 按钮集合
        /// </summary>
        [
        Category("Behavior"),
        Description("按钮集合"),
        Editor(typeof(CollectionEditor), typeof(UITypeEditor)),
        PersistenceMode(PersistenceMode.InnerDefaultProperty)
        ]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<HeadMenuButtonItem> ButtonList
        {
            get
            {
                //object m = ViewState["ButtonList"];
                //return m == null ? _ButtonList : (List<HeadMenuButtonItem>)m;
                return _ButtonList;
            }
            //set
            //{
            //    ViewState["ButtonList"] = value;
            //}
        }

        /// <summary>
        /// 重写RenderContents方法
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(HeadMenuTemplateTxt, HeadTitleIcon, HeadTitleTxt, HeadHelpIcon, HeadOPTxt, CreateButtonHtml());
        }
        #endregion

    }
}
