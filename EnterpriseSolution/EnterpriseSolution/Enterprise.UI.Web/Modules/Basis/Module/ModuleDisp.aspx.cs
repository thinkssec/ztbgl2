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

namespace Enterprise.UI.Web.Modules.Basis.Module
{
    public partial class ModuleDisp : Enterprise.Service.Basis.BasePage
    {
        string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateBT.AddButton("edit.gif", Trans("修改"), "ModuleManage.aspx?Cmd=Edit&Id=" + Id + "", Utility.PopedomType.Edit, HeadMenu1);
                CreateBT.AddButton("delete.gif", Trans("删除"), "ModuleManage.aspx?Cmd=Delete&Id=" + Id + "", Utility.PopedomType.Delete, HeadMenu1);
                CreateBT.AddButton("back.gif", Trans("返回"), "ModuleIndex.aspx", Utility.PopedomType.List, HeadMenu1);
                OnStart();
            }
        }

        private void OnStart()
        {
            SysModuleService mSer = new SysModuleService();
            var q = mSer.GetList().Where(p => p.MODULEID == Id).FirstOrDefault();
            if (q != null)
            {
                lb_Code.Text = q.MCODE;
                lb_Name.Text = q.MNAME;
                lb_Url.Text = q.MURL;
                lb_WebUrl.Text = q.MWEBURL + q.MWEBPARAM;
                lb_Target.Text = q.MTARGET;
                lb_Link.Text = q.MSINGLE == 0 ? "否" : "是";
                lb_Show.Text = q.MDELETE == 0 ? "显示" : "不显示";
                lb_Image.Text = q.MIMAGE;
            }
        }
    }
}