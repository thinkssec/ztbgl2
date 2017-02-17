using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Ui;
using Enterprise.Service.App.Ui;

namespace Enterprise.UI.Web.Modules.App.Ui
{
    /// <summary>
    /// 该页面没有继承BasePage
    /// </summary>
    public partial class UIIndexTabSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(Utility.Get_UserId.ToRequestString());
                InitData(Utility.Get_UserId.ToRequestString());
            }
        }

        /// <summary>
        /// 当前用户的所有可定制Tab
        /// </summary>
        /// <param name="userId"></param>
        private void BindData(string userId)
        {
            //当前用户的角色列表
            Enterprise.Service.Basis.Sys.SysUserRoleService surService = new Service.Basis.Sys.SysUserRoleService();
            IList<Enterprise.Model.Basis.Sys.SysUserRoleModel> rolelist = surService.GetListByUserId(userId);
            IList<int> roles = rolelist.Select(s => s.ROLEID).Distinct().ToList();

            //获取用户允许定制的标签索引
            UiDefaultService service = new UiDefaultService();
            IList<string> TabIndexlist = service.GetListUserTabIndexByRoles(roles);
            //获取所有标签名称
            IList<UiTabModel> tabList = new UiTabService().GetListByHQL
                ("from UiTabModel where TABID in ("+TabIndexlist.ToJoin(',')+")");

            SelChart.DataSource = tabList;
            SelChart.DataTextField = "TABNAME";
            SelChart.DataValueField = "TABID";
            SelChart.DataBind();

        }

        /// <summary>
        /// 加载用户设定
        /// </summary>
        /// <param name="userId"></param>
        private void InitData(string userId)
        {
            UiCustomModel customModel = new UiCustomModel();
            UiCustomService service = new UiCustomService();
            var q = service.GetSingleByUserId(userId);
            if (q != null)
            {
                if (!string.IsNullOrEmpty(q.UICONTENT))
                {
                    //获取当前用户的标签名称
                    IList<UiTabModel> tabList = new UiTabService().GetListByHQL
                        ("from UiTabModel where TABID in (" + q.UICONTENT + ")");
                    string[] userSelectedTabs = q.UICONTENT.Split(',');
                    SelMyChart.Items.Clear();
                    foreach (string tabId in userSelectedTabs)
                    {
                        UiTabModel model = tabList.FirstOrDefault(p => p.TABID == tabId);
                        if (model != null)
                        {
                            SelMyChart.Items.Add(new ListItem(model.TABNAME, model.TABID));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 保存用户的设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            //保存设定
            string uiContent = Hid_SelectTab.Value;
            //foreach (ListItem item in SelMyChart.Items)
            //{
            //    uiContent += item.Value + ",";
            //}
            uiContent = uiContent.TrimEnd(',');

            UiCustomModel model = new UiCustomModel();
            UiCustomService service = new UiCustomService();
            model = service.GetSingleByUserId(Utility.Get_UserId.ToRequestString());
            if (model == null)
            {
                model = new UiCustomModel();
                model.DB_Option_Action = WebKeys.InsertAction;
                model.CUSTOMID = Guid.NewGuid().ToString();
                model.USERID = Utility.Get_UserId.ToRequestString();
                model.UICONTENT = uiContent;
            }
            else
            {
                model.UICONTENT = uiContent;
                model.DB_Option_Action = WebKeys.UpdateAction;
            }
            service.Execute(model);
            //关闭弹出窗口并刷新父页面
            this.Page.ClientScript.RegisterStartupScript(this.GetType(),
                "reloadParent",
                "<script>parent.$('.easyui-window').window('close');parent.window.location.reload(true);</script>");
        }
    }
}