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
namespace Enterprise.UI.Web.Manage.Role
{
    public partial class Edit : Enterprise.Service.Basis.BasePage
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
        }

        private void OnBindData()
        {
            if (Cmd.Equals("Edit") || Cmd.Equals("Delete"))
            {
                SysRoleService ser = new SysRoleService();
                var q = ser.GetList().Where(p => p.RID == Id).FirstOrDefault();
                if (q != null)
                {
                    if (Cmd.Equals("Delete"))
                    {
                        string _note = "操作成功";
                        q.DB_Option_Action = WebKeys.DeleteAction;
                        if (ser.Execute(q))
                        {
                            Utility.ShowMsg(this.Page, "OK", Trans(_note), "RoleIndex.aspx");
                        }
                    }
                    else
                    {
                        tb_Name.Text = q.RNAME;
                        tb_Remark.Text = q.RREMARK;
                    }
                    //添加返回按钮
                    CreateBT.AddButton("back.gif", "返回", string.Format("RoleIndex.aspx"), Utility.PopedomType.List, HeadMenu1);
                }
            }
            else
            {
                //添加返回按钮
                CreateBT.AddButton("back.gif", "返回", string.Format("RoleIndex.aspx"), Utility.PopedomType.List, HeadMenu1);
            }

        }

        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            SysRoleModel roleModel = new SysRoleModel();
            SysRoleService ser = new SysRoleService();
            if (Cmd.Equals("New"))
            {
                roleModel.DB_Option_Action = WebKeys.InsertAction;
            }
            else if (Cmd.Equals("Edit"))
            {
                var um = ser.GetList().Where(p => p.RID == Id).FirstOrDefault();
                if (um != null)
                {
                    roleModel = um;
                    roleModel.DB_Option_Action = WebKeys.UpdateAction;
                }
            }

            roleModel.RNAME = (string)Utility.sink(tb_Name.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            roleModel.RREMARK = (string)Utility.sink(tb_Remark.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            roleModel.RTYPE = "";
            if (ser.Execute(roleModel))
            {
                Utility.ShowMsg(this.Page, "OK", Trans(_note), "RoleIndex.aspx");
            }
        }

    }
}