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
using System.Collections;
using Enterprise.Service.Basis.Sys;


namespace Enterprise.UI.Web.Modules.App.Project.Sbgl
{

    /// <summary>
    /// 设备管理-维修计划管理
    /// </summary>
    public partial class SbglWxjhManage : BasePage
    {

        /// <summary>
        /// 服务类
        /// </summary>
        SbglWxjhbService wxjgbSrv = new SbglWxjhbService();

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
            //年度
            Ddl_Year.Items.Clear();
            for (int i = DateTime.Now.Year; i >= 2015; i--)
            {
                Ddl_Year.Items.Add(new ListItem(i + "年", i.ToString()));
            }
            Ddl_Year.SelectedValue = DateTime.Now.Year.ToString();
            //月度
            Ddl_Month.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                Ddl_Month.Items.Add(new ListItem(i + "月份", CommonTool.BuZero_2(i)));
            }
            Ddl_Month.Items.Insert(0, new ListItem("全年", ""));
            //Ddl_Month.SelectedValue = CommonTool.BuZero_2(DateTime.Now.Month);
        }

        private void OnBindData()
        {
        }

        private void OnCommand()
        {
            ////项目成员可操作
            //if (ProjectMemberService.IsTeamMember(ProjectId, userModel, null))
            //{
            //    CreateBT.AddButton("new.gif", "新增", "ProjectWsXmbs.aspx?Cmd=New&projectId=" + tb_projid.Value + "&NodeCode=" + NodeCode, Utility.PopedomType.List, HeadMenu1);
            //    GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            //}
            //else
            //{
            //    GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            //}
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Save_Click(object sender, EventArgs e)
        {
            string data = Server.UrlDecode(HDData.Value);
            //对象封装方式
            ArrayList insertLst = SupCanTool.GetInsertModels(data, typeof(SbglWxjhbModel));
            //ArrayList updateLst = SupCanTool.GetUpdateModels(data, typeof(SbglWxjhbModel));
            string updSQL = SupCanTool.UpdateSQL(data, "", typeof(SbglWxjhbModel));
            string delSQL = SupCanTool.DeleteSQL(data, "", typeof(SbglWxjhbModel));
            if (!string.IsNullOrEmpty(updSQL)) wxjgbSrv.ExecuteSQL(updSQL);
            if (!string.IsNullOrEmpty(delSQL)) wxjgbSrv.ExecuteSQL(delSQL);
            if (insertLst.Count > 0)
            {
                var lst = insertLst.Cast<SbglWxjhbModel>().ToList();
                foreach (var q in lst)
                {
                    q.DB_Option_Action = WebKeys.InsertAction;
                    q.JHBID = CommonTool.GetGuidKey();
                    q.TBR = SysUserService.GetUserName(Utility.Get_UserId);
                    q.TBRQ = DateTime.Now;
                }
                wxjgbSrv.ExecuteListByAction(lst, WebKeys.InsertAction);
            }
        }

        /// <summary>
        /// 生成维修批号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Scwxph_Click(object sender, EventArgs e)
        {
            string data = Server.UrlDecode(HDData.Value);
            //对象封装方式
            ArrayList updateLst = SupCanTool.GetUpdateModels(data, typeof(SbglWxjhbModel));
            if (updateLst.Count > 0)
            {
                var lst = updateLst.Cast<SbglWxjhbModel>().ToList();
                string wxph = CommonTool.GetPkId();
                foreach (var q in lst)
                {
                    q.DB_Option_Action = WebKeys.UpdateAction;
                    q.SBWXPH = wxph;
                }
                wxjgbSrv.ExecuteListByAction(lst, WebKeys.UpdateAction);
            }

        }
    }
}