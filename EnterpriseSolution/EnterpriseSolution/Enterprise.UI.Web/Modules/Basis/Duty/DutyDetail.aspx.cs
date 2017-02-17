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
namespace Enterprise.UI.Web.Modules.ZhiWu
{
    public partial class Detail : Enterprise.Service.Basis.BasePage
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
            OnCommand();
        }

        private void OnCommand()
        {
            //添加操作按钮
            CreateBT.AddButton("edit.gif", Trans("修改"), "DutyManage.aspx?Cmd=Edit&Id=" + Id, Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("delete.gif", Trans("删除"), "DutyManage.aspx?Cmd=Delete&Id=" + Id, Utility.PopedomType.Delete, HeadMenu1);
            CreateBT.AddButton("back.gif", Trans("返回"), "DutyIndex.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        private void OnBindData()
        {
            SysDutyService dService = new SysDutyService();
            var q = dService.GetList().Where(p => p.DUTYID == Id).FirstOrDefault();
            if (q != null)
            {
                lb_Name.Text = q.DNAME;
                lb_Remark.Text = q.DREMARK;
            }
        }

    }
}