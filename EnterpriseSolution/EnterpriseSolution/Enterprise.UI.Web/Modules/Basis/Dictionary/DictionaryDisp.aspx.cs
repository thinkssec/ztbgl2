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
    public partial class DictionaryDisp : Enterprise.Service.Basis.BasePage
    {
        string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
                OnCommand();
            }
        }

        private void OnStart()
        {
            SysDictionaryService dSer = new SysDictionaryService();
            var query = dSer.GetList().Where(p => p.DID == Id).FirstOrDefault();
            if (query != null)
            {
                lb_Zwmc.Text = query.ZWMC;
                lb_Language.Text = query.YZ;
                lb_Dymc.Text = query.DYMC;
            }
        }

        private void OnCommand()
        {
            //添加操作按钮
            CreateBT.AddButton("edit.gif", Trans("修改"), "DictionaryManage.aspx?Cmd=Edit&Id=" + Id, Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("delete.gif", Trans("删除"), "DictionaryManage.aspx?Cmd=Delete&Id=" + Id, Utility.PopedomType.Delete, HeadMenu1);
            CreateBT.AddButton("back.gif", Trans("返回"), "DictionaryList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

    }
}