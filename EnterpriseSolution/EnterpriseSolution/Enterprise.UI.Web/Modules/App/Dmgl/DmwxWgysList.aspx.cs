using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.App.Dmgl;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.App.Dmgl;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Modules.App.Dmgl
{
    public partial class DmwxWgysList : Enterprise.Service.Basis.BasePage
    {

        protected string ModuleId = (string)Utility.sink("ModuleId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void OnCommand()
        {
            string s =SysModuleService.GetModuleName(ModuleId);
            //CreateBT.AddButton("list.gif", this.Trans("查询"), "DocumentOfcList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
            //if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.New))
            //CreateBT.AddButton("new.gif", this.Trans("新增计划申请"), "DmwxPlanEdit.aspx?ModuleId=" + ModuleId, Utility.PopedomType.New, HeadMenu1);
            
        }

        private void BindGrid()
        {
            OnCommand();

            DateTime et = DateTime.Now.ToThisMonthLastDay();
            DateTime st = DateTime.Now.AddMonths(-1).ToThisMonthFirstDay();
            Tb_SearchEnd.Text = et.ToDateYMDFormat();
            Tb_SearchBegin.Text = st.ToDateYMDFormat();

            DmglPlanService Service = new DmglPlanService();
            var list = new List<DmglPlanModel>();
            list = Service.GetList().Where(p=>p.PSTARTDATE>=st&&p.PENDDATE<=et&&p.STATUS>=3).OrderByDescending(p => p.PSTARTDATE).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        public void Bt_Search_OnClick(object sender, EventArgs e)
        {
            OnCommand();
            string sType = (string)Utility.sink(s_Type.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            DmglPlanService Service = new DmglPlanService();
            var list = Service.GetList().Where(p=>p.STATUS>=3).OrderByDescending(p => p.PSTARTDATE).ToList();
            if (sType == "1")
                list = list.Where(p=>p.STATUS==4).ToList();
            if (sType == "0")
                list = list.Where(p => p.STATUS ==3).ToList();


            if (string.IsNullOrEmpty(Tb_SearchBegin.Text)) {
                list = list.Where(p => p.PSTARTDATE >= Tb_SearchBegin.Text.ToDateTime()).ToList();
            }
            if (string.IsNullOrEmpty(Tb_SearchEnd.Text))
            {
                list = list.Where(p => p.PSTARTDATE <= Tb_SearchEnd.Text.ToDateTime()).ToList();
            }
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        public string CutString(object str,int length)
        {
            return (str != null) ? str.ToString().CutString(length) : "";
        }
        protected string GetStatus(object obj)
        {
            DmglPlanModel model = obj as DmglPlanModel;
            string sName = string.Empty;
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            if (model.STATUS == 3) sName = "完工";
            if (model.STATUS == 4) sName = "通过验收";
          
            return sName;
        }

        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            DmglPlanService service = new DmglPlanService();

            DmglPlanModel m = service.GetList().FirstOrDefault(p => p.PID == id);
            if (m.STATUS==3)
            {
                btnStrs += string.Format("<a  href='DmwxWgysEdit.aspx?Cmd=Edit&PID={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/application_edit.png\" border=\"0\" /></a>", id);
                //btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
                //btnStrs += string.Format("<a  onclick='return confirm(\"您确定要删除该记录吗?\");' href='DmwxPlanEdit.aspx?Cmd=Delete&PID={0}'><img alt=\"\" src=\"/Resources/Styles/icon/delete.gif\" border=\"0\" /></a>", id);
            }
            return btnStrs;
        }
    }
}