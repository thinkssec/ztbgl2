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
using System.Collections;


namespace Enterprise.UI.Web.Modules.App.Project.Sbgl
{

    /// <summary>
    /// 设备管理-台账管理
    /// </summary>
    public partial class SbglTzManage : BasePage
    {

        /// <summary>
        /// 服务类
        /// </summary>
        SbglTzService tzSrv = new SbglTzService();

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
           
            string data = Server.UrlDecode(HDData.Value);

            //对象封装方式
            ArrayList insertLst = SupCanTool.GetInsertModels(data, typeof(SbglTzModel));
            ArrayList updateLst = SupCanTool.GetUpdateModels(data, typeof(SbglTzModel));
            string updSQL = SupCanTool.UpdateSQL(data, "", typeof(SbglTzModel));
            string delSQL = SupCanTool.DeleteSQL(data, "", typeof(SbglTzModel));
            if (!string.IsNullOrEmpty(updSQL)) tzSrv.ExecuteSQL(updSQL);
            if (!string.IsNullOrEmpty(delSQL)) tzSrv.ExecuteSQL(delSQL);
            if (insertLst.Count > 0)
            {
                var lst = insertLst.Cast<SbglTzModel>().ToList();
                tzSrv.ExecuteListByAction(lst, WebKeys.InsertAction);
            }

            //SQL方式
            //string insSQL = SupCanTool.InsertSQL(data, "", typeof(SbglTzModel));
            //string updSQL = SupCanTool.UpdateSQL(data, "", typeof(SbglTzModel));
            //string delSQL = SupCanTool.DeleteSQL(data, "", typeof(SbglTzModel));
            //if (!string.IsNullOrEmpty(insSQL)) tzSrv.ExecuteSQL(insSQL);
            //if (!string.IsNullOrEmpty(updSQL)) tzSrv.ExecuteSQL(updSQL);
            //if (!string.IsNullOrEmpty(delSQL)) tzSrv.ExecuteSQL(delSQL);

            Utility.ShowTopMsg(Page, "提示", "数据保存成功!", 80, "show");
        }
    }
}