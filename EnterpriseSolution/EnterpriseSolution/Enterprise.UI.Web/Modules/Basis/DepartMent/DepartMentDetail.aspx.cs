using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.UI.Web.Manage.DepartMent
{
    public partial class Create : Enterprise.Service.Basis.BasePage
    {
        int Id = (int)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            OnBindData();
            OnCommand();
        }

        private void OnCommand()
        {
            //添加操作按钮
            CreateBT.AddButton("edit.gif", Trans("修改"), "DepartMentManage.aspx?Cmd=Edit&Id=" + Id, Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("delete.gif", Trans("删除"),"DelData('DepartMentManage.aspx?Cmd=Delete&Id=" + Id + "')", Utility.PopedomType.Delete, Utility.UrlType.JavaScript, HeadMenu1);
            CreateBT.AddButton("back.gif", Trans("返回"), "DepartMentList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        private void OnBindData()
        {
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.GetList().Where(p => p.DEPTID == Id).FirstOrDefault();
            if (q != null)
            {
                lb_Name.Text = q.DNAME + ((q.DEPTID == 1) ? " [虚拟机构]" : "");
                lb_Manager.Text = SysUserService.GetUserName(q.DMANAGER);
                lb_HeadManager.Text = SysUserService.GetUserName(q.DHEADERMANAGER);
                lb_HeadDepartment.Text = SysDepartmentService.GetDepartMentName(q.DPARENTID);
                lb_Orderby.Text = q.DORDERBY.ToString();
            }
        }

    }
}