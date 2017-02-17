using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.App.Zygl;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.App.Zygl;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Modules.App.Zygl
{
    public partial class ZyglGxList : Enterprise.Service.Basis.BasePage
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
            //string s =SysModuleService.GetModuleName(ModuleId);
            //CreateBT.AddButton("list.gif", this.Trans("查询"), "DocumentOfcList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
            //if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.New))
            //CreateBT.AddButton("new.gif", this.Trans("发起任务"), "ZyglPlanEdit.aspx?ModuleId=" + ModuleId, Utility.PopedomType.New, HeadMenu1);
            
        }

        private void BindGrid()
        {
            OnCommand();

            DateTime et = DateTime.Now.ToThisMonthLastDay();
            DateTime st = DateTime.Now.AddMonths(-1).ToThisMonthFirstDay();
            Tb_SearchEnd.Text = et.ToDateYMDFormat();
            Tb_SearchBegin.Text = st.ToDateYMDFormat();

            ZyglPlanService Service = new ZyglPlanService();
            var list = new List<ZyglPlanModel>();
            list = Service.GetList().Where(p=>p.PSTARTDATE>=st&&p.PENDDATE<=et&&(p.STATUS==3 ||p.STATUS==4)).OrderByDescending(p => p.PSTARTDATE).ToList();
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
            //string sType = (string)Utility.sink(s_Type.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            string sType2 = (string)Utility.sink(s_Type2.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            ZyglPlanService Service = new ZyglPlanService();
            var list = Service.GetList().Where(p => (p.STATUS == 3|| p.STATUS == 4)).OrderByDescending(p => p.PSTARTDATE).ToList();
            if (!string.IsNullOrEmpty(sType2)) list = list.Where(p=>p.ZYFL==sType2).ToList();
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
            ZyglPlanModel model = obj as ZyglPlanModel;
            string sName = string.Empty;
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            switch (model.STATUS.ToRequestString())
            {
                case "-1":
                    sName = "临时保存";
                    break;
                case "0":
                    sName ="提交申请";
                    break;
                case "1":
                    sName = "审批通过";
                    break;

                case "3":
                    sName = "开工";
                    break;
                case "4":
                    sName = "完工";
                    break;
            }

            
            return sName;
        }

        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            ZyglPlanService service = new ZyglPlanService();

            ZyglPlanModel m = service.GetList().FirstOrDefault(p => p.ZID == id);
            if (m.STATUS == 3)
            {
                btnStrs += string.Format("<a  href='ZyglGxEdit.aspx?Cmd=Edit&ZID={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/application_edit.png\" border=\"0\" /></a>", id);
                
            }
            return btnStrs;
        }
    }
}