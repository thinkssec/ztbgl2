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
namespace Enterprise.UI.Web.Manage.DepartMent
{
    /// <summary>
    /// 组织机构列表
    /// </summary>
    public partial class List : Enterprise.Service.Basis.BasePage
    {
        protected int Id = (int)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        int dId = (int)Utility.sink("dId", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        string Action = (string)Utility.sink("Action", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Action) && dId != 0)
                {
                    SysDepartmentService dService = new SysDepartmentService();
                    switch (Action)
                    {
                        case "Up":
                            //dService.DepartmentMoveUp(dId);
                            break;
                        case "Down":
                            //dService.DepartmentMoveDown(dId);
                            break;
                    }
                }
                OnStart();
            }
        }

        private void OnStart()
        {
            string url = "DepartMentManage.aspx";
            if (Id > 0)
            {
                url += "?Id=" + Id;
                CreateBT.AddButton("back.gif", Trans("返回"), "DepartMentList.aspx", Utility.PopedomType.List, HeadMenu1);
            }
            CreateBT.AddButton("new.gif", Trans("新增"), url, Utility.PopedomType.New, HeadMenu1);
            //CreateBT.AddButton("orderby.gif", Trans("排序"), "DepartMentList.aspx?Action=OrderBy&Id=" + Id, Utility.PopedomType.Orderby, HeadMenu1);
            OnBindData();
        }

        private void OnBindData()
        {
            SysDepartmentService dService = new SysDepartmentService();
            var q =dService.GetList().Where(p => p.DPARENTID == Id).OrderBy(p => p.DORDERBY).ToList();
            GridView1.DataSource = q;
            GridView1.DataBind();            
        }

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (string.IsNullOrEmpty(Action))
            //{
            //    e.Row.Cells[3].Visible = false;
            //}
        }
    }
}