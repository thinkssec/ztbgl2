using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
namespace Enterprise.UI.Web.Modules.Basis.Cache
{
    public partial class CacheManage : Enterprise.Service.Basis.BasePage
    {
        string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
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
            if (Cmd == "Edit")
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "CacheDisp.aspx?Id=" + Id, Utility.PopedomType.List, HeadMenu1);
            }
            else
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "CacheList.aspx", Utility.PopedomType.List, HeadMenu1);
            }
        }

        private void OnBindData()
        {
            SysCacheService cSer = new SysCacheService();
            var q = cSer.GetList().Where(p => p.CACHENAME == Id).FirstOrDefault();
            if (q != null)
            {
                if (Cmd == "Edit")
                {
                    tb_Hcmc.Text = q.CACHENAME;
                    tb_User.Text = q.USERNAME;
                    tb_Sjmc.Text = q.TABLENAME;
                    tb_Describe.Text = q.CACHEDESCRIBE;
                }
                else if (Cmd == "Delete")
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        cSer.Execute(q);
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    Utility.ShowMsg(this.Page, "OK", Trans(_note), "CacheList.aspx");
                }
            }
        }

        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                SysCacheService ser = new SysCacheService();
                SysCacheModel entity = new SysCacheModel();
                if (string.IsNullOrEmpty(Cmd)||Cmd=="New")
                {
                    entity.DB_Option_Action = "Insert";
                }
                else if (Cmd == "Edit")
                {
                    entity = ser.GetList().Where(p => p.CACHENAME == Id).FirstOrDefault();
                    entity.DB_Option_Action = "Update";
                }
                entity.CACHENAME = (string)Utility.sink(tb_Hcmc.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.USERNAME = (string)Utility.sink(tb_User.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.TABLENAME = (string)Utility.sink(tb_Sjmc.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.CACHEDESCRIBE = (string)Utility.sink(tb_Describe.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                ser.Execute(entity);
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", Trans(_note), "CacheList.aspx");
        }
    }
}