using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.User
{
    /// <summary>
    /// 用户信息显示页
    /// </summary>
    public partial class UserShow : Enterprise.Service.Basis.BasePage
    {

        int Id = (int)Utility.sink("Uid", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);

        int DeptId = (int)Utility.sink("Did", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            OnCommand();
            OnBindData();
        }

        private void OnCommand()
        {
            //添加操作按钮
            CreateBT.AddButton("a.gif", Trans("重置密码"), "UserManage.aspx?Cmd=Restore&Id=" + Id + "&deptId=" + DeptId, Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("edit.gif", Trans("修改"), "UserManage.aspx?Cmd=Edit&Id=" + Id + "&deptId=" + DeptId, Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("delete.gif", Trans("删除"), "DelData('UserManage.aspx?Cmd=Delete&Id=" + Id + "&deptId=" + DeptId + "')", Utility.PopedomType.Delete, Utility.UrlType.JavaScript, HeadMenu1);
            CreateBT.AddButton("back.gif", Trans("返回"), "UserList.aspx?Id=" + DeptId, Utility.PopedomType.List, HeadMenu1);
        }

        private void OnBindData()
        {
            SysUserService uService = new SysUserService();
            var user = uService.GetList().Where(p => p.USERID == Id).FirstOrDefault();
            if (user != null)
            {
                lb_Name.Text = user.UNAME;
                lb_LoginName.Text = user.ULOGINNAME;
                lb_Sex.Text = user.USEX;
                lb_Dept.Text =SysDepartmentService.GetDepartMentName(user.DEPTID);
                lb_Affiliation.Text = SysDepartmentService.GetDepartMentName(user.UAFFILIATION);
                lb_BirthDay.Text = (user.UBIRTHDAY.Year == 9999) ? "" : user.UBIRTHDAY.ToShortDateString();
                lb_Hw.Text = user.UHWPHONE;
                lb_Gn.Text = user.UGNPHONE;
                //lb_Sipc.Text = user.SIPCEMAIL;
                lb_UIP.Text = user.UIP;
                lb_Others.Text = user.OTHEREMAIL;
                //lb_USystem1.Text = user.USYSTEM1;
                //lb_USystem2.Text = user.USYSTEM2;
                //lb_Language.Text = user.UDEFAULTLANGUAGE == "ru" ? "俄文" : "简体中文";
                lb_Orderby.Text = user.UORDERBY.ToString();
                lb_Duty.Text = user.ULOGINPASS.ToRequestString();
                //提取签名信息
                SysUserindividService individSrv = new SysUserindividService();
                SysUserindividModel userIndivid = individSrv.GetModelById(user.USERID);
                if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
                {
                    img_Signature.ImageUrl = userIndivid.SIGNPIC;
                    img_Signature.Visible = true;
                }
            }
        }

    }
}