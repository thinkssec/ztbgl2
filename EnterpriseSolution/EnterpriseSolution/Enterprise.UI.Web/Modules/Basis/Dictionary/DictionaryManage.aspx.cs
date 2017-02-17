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
namespace Enterprise.UI.Web.Modules.Basis.Dictionary
{
    /// <summary>
    /// 字典表维护界面
    /// </summary>
    public partial class DictionaryManage :Enterprise.Service.Basis.BasePage
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
                CreateBT.AddButton("back.gif", Trans("返回"), "DictionaryDisp.aspx?Id=" + Id, Utility.PopedomType.List, HeadMenu1);
            }
            else
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "DictionaryList.aspx", Utility.PopedomType.List, HeadMenu1);
            }
        }

        private void OnBindData()
        {
            SysDictionaryService dSer = new SysDictionaryService();
            var q = dSer.GetList().Where(p => p.DID == Id).FirstOrDefault();
            if (q != null)
            {
                if (Cmd == "Edit")
                {
                    tb_Zwmc.Text = q.ZWMC;
                    tb_Dymc.Text = q.DYMC;
                }
                else if (Cmd == "Delete")
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        dSer.Execute(q);
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    Utility.ShowMsg(this.Page, "OK", Trans(_note), "DictionaryList.aspx");
                }
            }
        }

        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                SysDictionaryService ser = new SysDictionaryService();
                SysDictionaryModel entity = new SysDictionaryModel();
                if (string.IsNullOrEmpty(Cmd)||Cmd=="New")
                {
                    entity.DB_Option_Action = "Insert";
                }
                else if (Cmd == "Edit")
                {
                    entity = ser.GetList().Where(p => p.DID == Id).FirstOrDefault();
                    entity.DB_Option_Action = "Update";
                }
                entity.ZWMC = (string)Utility.sink(tb_Zwmc.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.YZ = (string)Utility.sink(tb_Language.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.DYMC = (string)Utility.sink(tb_Dymc.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                ser.Execute(entity);
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", Trans(_note), "DictionaryList.aspx");
        }

    }
}