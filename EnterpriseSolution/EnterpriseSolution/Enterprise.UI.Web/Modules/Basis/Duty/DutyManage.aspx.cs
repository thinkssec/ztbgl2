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
namespace Enterprise.UI.Web.Manage.ZhiWu
{
    public partial class Manage : Enterprise.Service.Basis.BasePage
    {
        int Id = (int)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        string Cmd = (string)Utility.sink("Cmd", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnCommand();
            }
        }

        private void OnCommand()
        {
            if (Cmd == "Edit")
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "DutyDetail.aspx?Id=" + Id, Utility.PopedomType.List, HeadMenu1);
            }
            else
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "DutyIndex.aspx", Utility.PopedomType.List, HeadMenu1);
            }
            OnBindData();
        }

        private void OnBindData()
        {
            SysDutyService wService = new SysDutyService();
            var q = wService.GetList().Where(p => p.DUTYID == Id).FirstOrDefault();
            if (q != null)
            {
                if (Cmd == "Edit")
                {
                    tb_Name.Text = q.DNAME;
                    tb_Remark.Text = q.DREMARK;
                }
                else if (Cmd == "Delete")
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        wService.Execute(q);
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    Utility.ShowMsg(this.Page, "OK", Trans(_note), "DutyIndex.aspx");
                }
            }            
        }

        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            SysDutyModel entity = new SysDutyModel();
            SysDutyService Service = new SysDutyService();
            switch (Cmd)
            {
                case "New":
                    entity.DB_Option_Action = "Insert";
                    break;
                case "Edit":
                    entity = Service.GetList().Where(p => p.DUTYID == Id).FirstOrDefault();
                    entity.DB_Option_Action = "Update";
                    break;
            }
            entity.DNAME = (string)Utility.sink(tb_Name.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            entity.DREMARK = (string)Utility.sink(tb_Remark.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            Service.Execute(entity);
            Response.Redirect("DutyIndex.aspx");
            Response.End();
        }

    }
}