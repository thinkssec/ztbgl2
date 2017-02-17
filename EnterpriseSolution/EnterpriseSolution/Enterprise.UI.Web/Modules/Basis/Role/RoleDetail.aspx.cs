using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.UI.Web.Manage.Role
{
    /// <summary>
    /// 角色信息
    /// </summary>
    public partial class Detail : Enterprise.Service.Basis.BasePage
    {

        int Id = (int)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        int UserId = (int)Utility.sink("UserId", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private static SysModuleService moduleSer = new SysModuleService();

        private void OnStart()
        {
            SysRoleService roleSer = new SysRoleService();
            var q = roleSer.GetList().Where(p => p.RID == Id).FirstOrDefault();
            if (q != null)
            {
                Role_Name.Text = q.RNAME;
                Role_Remark.Text = q.RREMARK;

                OnDisp();
                FormatUser();                
            }            
        }

        private void OnDisp()
        {
            var list = moduleSer.GetList().Where(p => p.MPARENTID == "0").OrderBy(p => p.MORDERBY).ToList();
            Module_Main.DataSource = list;
            Module_Main.DataBind();
            if (Cmd == "")
            {
                CreateBT.AddButton("edit.gif", Trans("修改"), "RoleDetail.aspx?Id=" + Id + "&Cmd=Edit", Utility.PopedomType.Edit, HeadMenu1);
                CreateBT.AddButton("back.gif", Trans("返回"), "RoleIndex.aspx", Utility.PopedomType.List, HeadMenu1);
            }
            else if (Cmd == "Edit")
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "RoleDetail.aspx?Id=" + Id, Utility.PopedomType.List, HeadMenu1);
                ButtonTr_End.Visible = true;
            }
            //add by qw 2013.5.20 start
            else if (Cmd == "Delete")
            {
                doDeleteUser();
            }
            //end
        }


        protected void Module_Main_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var sysModule = (SysModuleModel)e.Item.DataItem;
            if (sysModule != null)
            {
                List<SysModuleModel> lst = moduleSer.GetList().Where(p => p.MPARENTID == sysModule.MODULEID).OrderBy(p => p.MORDERBY).ToList();
                if (lst.Count > 0)
                {
                    Repeater Module_Sub = (Repeater)e.Item.FindControl("Module_Sub");
                    Module_Sub.DataSource = lst;
                    Module_Sub.DataBind();
                }
            }
        }

        protected void Module_Sub_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var sysModule = (SysModuleModel)e.Item.DataItem;
            if (sysModule != null)
            {
                List<SysModuleModel> list = moduleSer.GetList().Where(p => p.MPARENTID == sysModule.MODULEID).OrderBy(p => p.MORDERBY).ToList();
                if (list.Count > 0)
                {
                    Repeater Module_Sub1 = (Repeater)e.Item.FindControl("Module_Sub1");
                    Module_Sub1.DataSource = list;
                    Module_Sub1.DataBind();
                }
                SysRolePermissionService rpService = new SysRolePermissionService();
                var sysRolePermission = rpService.GetList().Where(p => p.ROLEID == Id && p.MCODE == sysModule.MCODE).FirstOrDefault();
                if (sysRolePermission == null)
                {
                    sysRolePermission = new SysRolePermissionModel();
                }
                string rightString = string.Format("<img src='{0}'>", ResolveClientUrl("~/Resources/Styles/_img/right.gif"));
                string wrongString = string.Format("<img src='{0}'>", ResolveClientUrl("~/Resources/Styles/_img/wrong.gif"));
                string dispString = "";
                string SelectTxt = "";
                int TempStep = 1;
                for (int i = 0; i < 8; i++)
                {
                    TempStep = TempStep + TempStep;
                    Literal li = (Literal)e.Item.FindControl(string.Format("Lab{0}_Txt", TempStep));
                    if (li != null)
                    {
                        if ((sysRolePermission.PERMISSIONVALUE & TempStep) == TempStep)
                        {
                            dispString = rightString;
                            SelectTxt = "checked";
                        }
                        else
                        {
                            dispString = wrongString;
                            SelectTxt = "";
                        }
                        if (Cmd == "Edit")
                        {
                            dispString = string.Format("<input type=checkbox id='PageCode{0}' name='PageCode{0}' value={1}  {2}>", sysModule.MCODE, TempStep, SelectTxt);
                        }
                        li.Text = dispString;
                    }
                }
            }      
        }

        protected void Module_Sub1_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var sysModule = (SysModuleModel)e.Item.DataItem;
            if (sysModule != null)
            {
                SysRolePermissionService rpService = new SysRolePermissionService();
                var sysRolePermission = rpService.GetList().Where(p => p.ROLEID == Id && p.MCODE == sysModule.MCODE).FirstOrDefault();
                if (sysRolePermission == null)
                {
                    sysRolePermission = new SysRolePermissionModel();
                }
                string rightString = string.Format("<img src='{0}'>", ResolveClientUrl("~/Resources/Styles/_img/right.gif"));
                string wrongString = string.Format("<img src='{0}'>", ResolveClientUrl("~/Resources/Styles/_img/wrong.gif"));
                string dispString = "";
                string SelectTxt = "";
                int TempStep = 1;
                for (int i = 0; i < 8; i++)
                {
                    TempStep = TempStep + TempStep;
                    Literal li = (Literal)e.Item.FindControl(string.Format("Lab2{0}_Txt", TempStep));
                    if (li != null)
                    {
                        if ((sysRolePermission.PERMISSIONVALUE & TempStep) == TempStep)
                        {
                            dispString = rightString;
                            SelectTxt = "checked";
                        }
                        else
                        {
                            dispString = wrongString;
                            SelectTxt = "";
                        }
                        if (Cmd == "Edit")
                        {
                            dispString = string.Format("<input type=checkbox id='PageCode{0}' name='PageCode{0}' value={1}  {2}>", sysModule.MCODE, TempStep, SelectTxt);

                        }
                        li.Text = dispString;
                    }
                }
            }  
        }

        private void FormatUser()
        {
            string s = "";
            SysUserRoleService userRoleSer = new SysUserRoleService();
            List<SysUserRoleModel> list = userRoleSer.GetList().Where(p => p.ROLEID == Id).ToList();
            if (list.Count > 0)
            {
                foreach (SysUserRoleModel rm in list)
                {
                    s += string.Format("<a href=\"RoleDetail.aspx?Cmd=Delete&Id={0}&UserId={1}\">{2}</a>", Id, rm.USERID, SysUserService.GetUserName(rm.USERID)) + ",";
                }
            }
            labelUser.Text = s.TrimEnd(',');
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //更新前把RoleId相关内容项
            SysRolePermissionModel old = new SysRolePermissionModel();
            old.ROLEID = Id;
            old.DB_Option_Action = WebKeys.DeleteAllAction;
            SysRolePermissionService service = new SysRolePermissionService();
            service.Execute(old);

            //取得表单的值进行更新
            SysRolePermissionModel sysRolePM = new SysRolePermissionModel();
            sysRolePM.DB_Option_Action = "Insert";
            sysRolePM.ROLEID = Id;

            string TempPageCodeString = "";
            string[] ArrayInt;
            int PageCodeValue = 0;

            foreach (string var in Request.Form)
            {
                if (var.Length > 8)
                {
                    TempPageCodeString = var.Substring(0, 8);
                    if (TempPageCodeString == "PageCode")
                    {
                        PageCodeValue = 0;
                        TempPageCodeString = var.Substring(8, var.Length - 8);
                        ArrayInt = Request.Form[var].Split(',');
                        for (int i = 0; i < ArrayInt.Length; i++)
                        {
                            PageCodeValue = PageCodeValue + Convert.ToInt32(ArrayInt[i]);
                        }
                        sysRolePM.RPID = CommonTool.GetPkId();
                        sysRolePM.MCODE = TempPageCodeString;
                        sysRolePM.PERMISSIONVALUE = PageCodeValue;
                        service.Execute(sysRolePM);
                    }
                }
            }
            //清空运行时缓存 add by qw 2013.3.6 start
            IDictionaryEnumerator id = HttpRuntime.Cache.GetEnumerator();
            while (id.MoveNext())
            {
                DictionaryEntry abc = id.Entry;
                string Tempstring = (string)id.Key;
                HttpRuntime.Cache.Remove(Tempstring);
            }
            //end
            Response.Redirect("RoleDetail.aspx?Id=" + Id);
            Response.End();
        }

        //private void OnBindUser()
        //{
        //    SysDepartmentService dService = new SysDepartmentService();
        //    var list = dService.GetList().OrderBy(p => p.DORDERBY);
        //    tb_Dept.DataSource = list;
        //    tb_Dept.DataTextField = "DNAME";
        //    tb_Dept.DataValueField = "DEPTID";
        //    tb_Dept.DataBind();
        //    tb_Dept.Items.Insert(0, new ListItem("请选择部门", "0"));
        //}

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

        protected void Button2_OnClick(object sender, EventArgs e)
        {
            //签收范围格式@1,4,5
            string rcv_users = rcv_users_value.Value;
            rcv_users = rcv_users.TrimEnd(',');            
            SysUserRoleService userRoleSer = new SysUserRoleService();
            if (!string.IsNullOrEmpty(rcv_users))
            {
                string[] users = rcv_users.Split(',');
                if (users.Length >= 1)
                {
                    for (int i = 0; i < users.Length; i++)
                    {
                        int uId = int.Parse(users[i].ToString());
                        if (uId != 0)
                        {
                            var q = userRoleSer.GetList().Where(p => p.USERID == uId && p.ROLEID == Id).FirstOrDefault();
                            if (q == null)
                            {
                                SysUserRoleModel entity = new SysUserRoleModel();
                                entity.RELATIONID = CommonTool.GetPkId();
                                entity.USERID = uId;
                                entity.ROLEID = Id;
                                entity.DB_Option_Action = "Insert";
                                userRoleSer.Execute(entity);
                            }
                        }
                    }
                }
                //刷新数据
                FormatUser();
            }
            else
            {
                //SysUserService uService = new SysUserService();
                //List<SysUserModel> list = uService.GetList().ToList();
                //foreach (var var in list)
                //{
                //    var q = userRoleSer.GetList().Where(p => p.USERID == var.USERID && p.ROLEID == Id).FirstOrDefault();
                //    if (q == null)
                //    {
                //        SysUserRoleModel entity = new SysUserRoleModel();
                //        entity.USERID = var.USERID;
                //        entity.ROLEID = Id;
                //        entity.DB_Option_Action = "Insert";
                //        userRoleSer.Execute(entity);
                //    }
                //}
                ////刷新数据
                //FormatUser();
            }
        }

        /// <summary>
        /// 删除指定角色下的指定用户
        /// </summary>
        private void doDeleteUser()
        {
            SysUserRoleService userRoleSer = new SysUserRoleService();
            var q = userRoleSer.GetList().Where(p => p.USERID == UserId && p.ROLEID == Id).FirstOrDefault();
            if (q != null)
            {
                q.DB_Option_Action = WebKeys.DeleteAction;
                userRoleSer.Execute(q);
            }

            Response.Redirect("RoleDetail.aspx?Id=" + Id, true);
        }


    }
}