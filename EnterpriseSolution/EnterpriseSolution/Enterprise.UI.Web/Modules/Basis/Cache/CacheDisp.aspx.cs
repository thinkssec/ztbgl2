using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Control;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.UI.Web.Modules.Basis.Cache
{
    public partial class CacheDisp : Enterprise.Service.Basis.BasePage
    {
        string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                OnStart();
                OnCommand();
            }
        }

        private void OnStart()
        {
            SysCacheService cSer=new SysCacheService();
            var q=cSer.GetList().Where(p=>p.CACHENAME==Id).FirstOrDefault();
            if(q!=null)
            {
                lb_Hcmc.Text = q.CACHENAME;
                lb_User.Text = q.USERNAME;
                lb_Sjmc.Text = q.TABLENAME;
                lb_Describe.Text = q.CACHEDESCRIBE;
            }
        }

        private void OnCommand()
        {
            //添加操作按钮
            CreateBT.AddButton("edit.gif", Trans("修改"), "CacheManage.aspx?Cmd=Edit&Id=" + Id, Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("delete.gif", Trans("删除"), "CacheManage.aspx?Cmd=Delete&Id=" + Id, Utility.PopedomType.Delete, HeadMenu1);
            CreateBT.AddButton("back.gif", Trans("返回"), "CacheList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

    }
}