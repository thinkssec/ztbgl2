using Enterprise.Component.Control;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Model.App.Ui;
using Enterprise.Service.App.Ui;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Ui
{
    /// <summary>
    /// 用户界面定制
    /// </summary>
    public partial class UserUIManage : BasePage
    {
        public UiCustomModel Model = new UiCustomModel();
        public UiCustomService Service = new UiCustomService();
        public string Id { get { return HId.Value;}set{HId.Value=value;}  }
        public IList<UiTabModel> TabList = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {               
                Id = Request.QueryString["ID"].ToRequestString();
                InitControl();
                DoAction();                
                BindGrid();
            }
        }

        private void DoAction()
        {
            if (Request.QueryString["Cmd"].ToRequestString() == "New")
            {
                Edit.Visible = true;
            }

            if (Request.QueryString["Cmd"].ToRequestString() == "Edit")
            {
                Edit.Visible = true;
                var q = Service.GetSingleById(Id);
                if (q != null)
                {
                    Id = q.USERID;
                    tb_Users.SelectedValue = q.USERID;
                    string[] str = q.UICONTENT.Split(',');
                    foreach (string s in str)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            tb_tablist.Items.FindByValue(s).Selected = true;
                        }
                    }
                }
            }

            if (Request.QueryString["Cmd"].ToRequestString() == "Delete")
            {
                Edit.Visible = false;
                var q = Service.GetSingleById(Id);
                if (q != null)
                {
                    q.DB_Option_Action = WebKeys.DeleteAction;
                    Service.Execute(q);
                    Utility.ShowMsg(this.Page, "提示", "删除成功！", "UserUIManage.aspx");
                }
                else
                {
                    Utility.ShowMsg(this.Page, "提示", "数据库不存在这条记录！", "UserUIManage.aspx");

                }
            }
        }

        private void InitControl()
        {
            SysUserService userSrv = new SysUserService();
            userSrv.BindSSECDropDownListForUser(tb_Users);

            TabList = new UiTabService().GetList();
            tb_tablist.DataSource = TabList;
            tb_tablist.DataTextField = "TABNAME";
            tb_tablist.DataValueField = "TABID";
            tb_tablist.DataBind();

        }

        private void BindGrid()
        {
            IList<UiCustomModel> list = Service.GetList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }        

        private void OnCommand()
        {
            CreateBT.AddButton("new.gif", "新增", "UserUIManage.aspx?Cmd=New", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='UserUIManage.aspx?Cmd=Edit&ID={0}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", id);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='UserUIManage.aspx?Cmd=Delete&ID={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id);
            return btnStrs;
        }

        /// <summary>
        /// 转换为TAB标签名称
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        protected string GetTabNames(object v)
        {
            string tabNames = string.Empty;
            if (v != null)
            {
                string[] tabIds = v.ToString().Split(',');
                foreach (string id in tabIds)
                {
                    var q = TabList.FirstOrDefault(p => p.TABID == id);
                    if (q != null)
                        tabNames += q.TABNAME + ",";
                }
            }
            return tabNames.TrimEnd(',');
        }        

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //保存
            Model = Service.GetSingleById(Id);
            if (Model == null)
            {
                Model = new UiCustomModel();
                Model.CUSTOMID = Guid.NewGuid().ToString();
                Model.DB_Option_Action = WebKeys.InsertAction;
                if (Service.GetSingleByUserId(tb_Users.SelectedValue) != null)
                {
                    Utility.ShowMsg(this.Page, "提示", "已经存在该用户的设定了", "UserUIManage.aspx");
                }
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            Model.USERID = tb_Users.SelectedValue;
            Model.UICONTENT = GetListBoxSelectString(tb_tablist);
            Service.Execute(Model);
            Utility.ShowMsg(this.Page, "提示", "保存成功", "UserUIManage.aspx");
        }

        /// <summary>
        /// 获取ListBox选中值
        /// </summary>
        /// <param name="listbox"></param>
        /// <returns></returns>
        protected string GetListBoxSelectString(ListBox listbox)
        {
            string str = "";
            foreach (ListItem li in listbox.Items)
            {
                if (li.Selected&&li.Value!="")
                    str += li.Value+",";
            }
            str = str.TrimEnd(',');
            return str;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        protected string GetUserInfo(object v)
        {
            string info = string.Empty;
            if (v != null) 
            {
                SysUserModel user = SysUserService.GetUserModelByUserId(v.ToInt());
                if (user != null) {
                    info = SysDepartmentService.GetDepartMentName(user.DEPTID) + "→" + user.UNAME;
                }
            }
            return info;
        }


    }
}