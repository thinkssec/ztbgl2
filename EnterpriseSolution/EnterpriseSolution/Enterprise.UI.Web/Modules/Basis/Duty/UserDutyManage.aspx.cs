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
namespace Enterprise.UI.Web.Manage.ZhiWu
{
    public partial class UserZhiwuManage : Enterprise.Service.Basis.BasePage
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
            CreateBT.AddButton("back.gif", Trans("返回"), "DutyIndex.aspx", Utility.PopedomType.List, HeadMenu1);
            if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.New) || 
                SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
            {
                Pnl_Edit.Visible = true;
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            }
            else
            {
                Pnl_Edit.Visible = false;
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            }
            OnBindData();
            OnBindDepartMent();
        }

        private void OnBindDepartMent()
        {
            SysDepartmentService dService = new SysDepartmentService();
            var list = dService.GetList().OrderBy(p => p.DORDERBY);
            //tb_Dept.DataSource = list;
            //tb_Dept.DataTextField = "DNAME";
            //tb_Dept.DataValueField = "DEPTID";
            //tb_Dept.DataBind();
            //tb_Dept.Items.Insert(0, new ListItem("请选择部门", "0"));
        }

        private void OnBindData()
        {
            SysDutyService zwService = new SysDutyService();
            var q = zwService.GetList().Where(p => p.DUTYID == Id).FirstOrDefault();
            if (q != null)
            {
                lb_Name.Text =  q.DNAME;
                lb_Remark.Text = q.DREMARK;
            }
            SysUserDutyService uzService = new SysUserDutyService();
            string sql = "select p.UDID,p.USERID,p.DUTYID from basis_sys_userduty p,basis_sys_user q where p.USERID=q.USERID AND p.DUTYID='" + Id + "' ORDER BY q.UORDERBY";
            List<SysUserDutyModel> list = uzService.GetListBySQL(sql).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument); //获取行号
            string did = (string)GridView1.DataKeys[index].Value;
            SysUserDutyService ser = new SysUserDutyService();
            var q = ser.GetList().Where(p=>p.UDID==did).FirstOrDefault();
            if (q != null)
            {
                switch (e.CommandName)
                {
                    case "mDelete":
                        q.DB_Option_Action = "Delete";
                        ser.Execute(q);
                        break;
                }
                OnStart();
            }
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            SysUserDutyService uzService = new SysUserDutyService();
            SysUserDutyModel entity = new SysUserDutyModel();
            entity.UDID = CommonTool.GetGuidKey();
            entity.DUTYID = Id;
            int userId = single_RcvUsers.UserSelectValue.ToInt();
            if (userId != 0)
            {
                entity.USERID = userId;
                entity.DB_Option_Action = "Insert";
                uzService.Execute(entity);
                Response.Redirect("UserDutyManage.aspx?Id=" + Id);
                Response.End();
            }
        }
        //protected void tb_Dept_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    tb_User.Items.Clear();
        //    int deptId = (int)Utility.sink(tb_Dept.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
        //    if (deptId != 0)
        //    {
        //        SysUserService uService = new SysUserService();
        //        var list = uService.GetList().Where(p => p.DEPTID == deptId).OrderBy(p => p.UORDERBY);
        //        tb_User.DataSource = list;
        //        tb_User.DataTextField = "UNAME";
        //        tb_User.DataValueField = "USERID";
        //        tb_User.DataBind();
        //        tb_User.Items.Insert(0, new ListItem("请选择人员", "0"));
        //    }
        //}

    }
}