using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;

namespace Enterprise.UI.Web.Modules.Basis.Module
{

    public partial class ModuleIndex : Enterprise.Service.Basis.BasePage
    {
        protected string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string mId = (string)Utility.sink("mId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string Action = (string)Utility.sink("Action", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnCommand();
                OnStart();                
            }
        }

        private void OnStart()
        {
            SysModuleService ser = new SysModuleService();
            string url = "ModuleManage.aspx";
            if (!string.IsNullOrEmpty(Id))
            {
                url += "?Id=" + Id;
            }
            else
            {
                Id = "0";
            }
            CreateBT.AddButton(url, Utility.PopedomType.New, HeadMenu1);
            if (Id != "0")
            {
                string pUrl = "ModuleIndex.aspx";
                var module = ser.ModuleDisp(Id);
                if (module != null)
                {
                    pUrl = "ModuleIndex.aspx?Id=" + module.MPARENTID;
                }
                CreateBT.AddButton("back.gif", Trans("返回"), pUrl, Utility.PopedomType.List, HeadMenu1);
            }
            OnBindData();
        }

        private void OnBindData()
        {
            SysModuleService service = new SysModuleService();
            var q = service.GetList().Where(p => p.MPARENTID == Id).OrderBy(p => p.MORDERBY);
            GridView1.DataSource = q;
            GridView1.DataBind();
        }

        private void OnCommand()
        {
            if (!string.IsNullOrEmpty(Action) && !string.IsNullOrEmpty("0"))
            {
                SysModuleService mService = new SysModuleService();
                switch (Action)
                {
                    case "Up":
                        mService.ModuleMoveUpService(mId);
                        break;
                    case "Down":
                        mService.ModuleMoveDownService(mId);
                        break;
                }
                Response.Redirect("ModuleIndex.aspx?Id=" + Id);
                Response.End();
            }
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            SysModuleService ser = new SysModuleService();
            int index = Convert.ToInt32(e.CommandArgument); //获取行号
            string did = (string)GridView1.DataKeys[index].Value;
            var q = ser.ModuleDisp(did);
            if (q != null)
            {
                SysModuleService service = new SysModuleService();
                switch (e.CommandName)
                {
                    case "mClose":
                        q.MDELETE = 1;
                        q.DB_Option_Action = "UpdatemDelete";
                        service.Execute(q);
                        break;
                    case "mOpen":
                        q.MDELETE = 0;
                        q.DB_Option_Action = "UpdatemDelete";
                        service.Execute(q);
                        break;
                    case "mDelete":
                        q.DB_Option_Action = "Delete";
                        service.Execute(q);
                        break;
                }
                OnStart();
            }
        }


    }
}