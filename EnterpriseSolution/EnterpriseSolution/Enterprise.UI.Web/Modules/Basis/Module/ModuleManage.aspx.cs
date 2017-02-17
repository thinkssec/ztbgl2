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
namespace Enterprise.UI.Web.Modules.Basis.Module
{
    public partial class ModuleManage : Enterprise.Service.Basis.BasePage
    {
        string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        //string Cmd = (string)Utility.sink("Cmd", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
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
                CreateBT.AddButton("back.gif", Trans("返回"), "ModuleDisp.aspx?Id=" + Id, Utility.PopedomType.List, HeadMenu1);
            }
            else
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "ModuleIndex.aspx", Utility.PopedomType.List, HeadMenu1);
            }
        }

        private void OnBindData()
        {
            SysModuleService ser = new SysModuleService();
            var q = ser.GetList().Where(p => p.MODULEID == Id).FirstOrDefault();
            if (q != null)
            {
                if (Cmd == "Edit")
                {
                    tb_Code.Text = q.MCODE;
                    tb_Name.Text = q.MNAME;
                    tb_Url.Text = q.MURL;
                    tb_WebUrl.Text = q.MWEBURL;
                    tb_WebParam.Text = q.MWEBPARAM;
                    tb_MIMAGE.Text = q.MIMAGE;
                    ListItem limanager = tb_Single.Items.FindByValue(q.MSINGLE.ToString());
                    if (limanager != null)
                        limanager.Selected = true;
                    ListItem liheadermanager = tb_Target.Items.FindByValue(q.MTARGET.ToString());
                    if (liheadermanager != null)
                        liheadermanager.Selected = true;
                    ListItem lishow = tb_Show.Items.FindByValue(q.MDELETE.ToString());
                    if (lishow != null)
                        lishow.Selected = true;
                }
                else if (Cmd == "Delete")
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        ser.Execute(q);
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    Utility.ShowMsg(this.Page, "OK", Trans(_note), "ModuleIndex.aspx?Id=" + q.MODULEID);
                }
                else
                {
                    tb_Code.Text = Id;
                }
            }
        }


        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                SysModuleService ser = new SysModuleService();
                SysModuleModel entity = new SysModuleModel();
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = WebKeys.InsertAction;
                    entity.MODULEID = tb_Code.Text;
                    entity.MPARENTID = (string.IsNullOrEmpty(Id) ? "0" : Id);
                    entity.MROOTID = "0";
                    entity.MORDERBY = ser.GetMaxModuleOrderBy(entity.MPARENTID) + 1;
                }
                else if (Cmd == "Edit")
                {
                    entity = ser.GetList().Where(p => p.MODULEID == Id).FirstOrDefault();
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                entity.MCODE = (string)Utility.sink(tb_Code.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.MNAME = (string)Utility.sink(tb_Name.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.MURL = (string)Utility.sink(tb_Url.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                if (entity.MURL == "")
                    entity.MURL = "#";// 支持一级菜单能点击
                entity.MWEBURL = tb_WebUrl.Text;
                entity.MWEBPARAM = tb_WebParam.Text;
                entity.MIMAGE = tb_MIMAGE.Text;
                entity.MSINGLE = (int)Utility.sink(tb_Single.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                entity.MTARGET = (string)Utility.sink(tb_Target.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.MDELETE = (int)Utility.sink(tb_Show.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                if (ser.Execute(entity))
                {
                    //重新加载路由
                    Global.LoadUrlRoute();
                }
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", Trans(_note), "ModuleIndex.aspx");
        }

    }
}