using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis;
using Enterprise.Model.App.Sbgl;
using Enterprise.Service.App.Sbgl;
using Enterprise.Component.Control;
using System.Text;


namespace Enterprise.UI.Web.Modules.App.Project.Sbgl
{

    /// <summary>
    /// 设备管理-维修单位管理
    /// </summary>
    public partial class SbglWxdwManage : BasePage
    {

        /// <summary>
        /// 服务类
        /// </summary>
        SbglWxdwService wxdwSrv = new SbglWxdwService();

        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {
                OnCondition();
                OnBindData();
            }
        }

        private void OnCondition()
        {

        }

        private void OnBindData()
        {

        }

        private void OnCommand()
        {
            ////项目成员可操作
            //if (ProjectMemberService.IsTeamMember(ProjectId, userModel, null))
            //{
            //CreateBT.AddButton("delete.gif", "删除", "ProjectWsXmbs.aspx?Cmd=New&projectI", Utility.PopedomType.List, HeadMenu1);
            //    GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            //}
            //else
            //{
            //    GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            //}
        }

        protected void LnkBtn_Save_Click(object sender, EventArgs e)
        {
            //Utility.ShowLoading(Page, 3000);
            //StringBuilder sb = new StringBuilder();
            string data = Server.UrlDecode(HDData.Value);
            string insSQL = SupCanTool.InsertSQL(data, "", typeof(SbglWxdwModel));
            string updSQL = SupCanTool.UpdateSQL(data, "", typeof(SbglWxdwModel));
            string delSQL = SupCanTool.DeleteSQL(data, "", typeof(SbglWxdwModel));
            if (!string.IsNullOrEmpty(insSQL)) wxdwSrv.ExecuteSQL(insSQL);
            if (!string.IsNullOrEmpty(updSQL)) wxdwSrv.ExecuteSQL(updSQL);
            if (!string.IsNullOrEmpty(delSQL)) wxdwSrv.ExecuteSQL(delSQL);
            //sb.Append(SupCanTool.InsertSQL(data, "", typeof(SbglWxdwModel)) + "<br/>");
            //sb.Append(SupCanTool.UpdateSQL(data, "", typeof(SbglWxdwModel)) + "<br/>");
            //sb.Append(SupCanTool.DeleteSQL(data, "", typeof(SbglWxdwModel)));
            //sb.Append();
            //string aa = Server.UrlDecode(HDData.Value);
            //Response.Write(sb.ToString() + "===" + typeof(SbglWxdwModel).ToString() + "===" + CommonTool.GetTableNameByNsCls(typeof(SbglWxdwModel).ToString()));
            //Response.End();
            //ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript' language='javascript'>alert('" +  + "');</script>");
            Utility.ShowTopMsg(Page, "提示", "数据保存成功!", 80, "show");
        }
    }
}