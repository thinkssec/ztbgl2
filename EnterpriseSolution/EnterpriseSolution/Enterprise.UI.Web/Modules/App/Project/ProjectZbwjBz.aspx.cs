using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Service.Basis;
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Service.App.Crm;
using Enterprise.Model.App.Crm;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;

using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Project
{


    /// <summary>
    /// 项目列表页面
    /// </summary>
    public partial class ProjectZbwjBz : BasePage
    {
        #region 初始化参数区

        /// <summary>
        /// 条件类型
        /// </summary>
        int showType = (int)Utility.sink("showType", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);

        /// <summary>
        /// 部门
        /// </summary>
        int deptId = HttpContext.Current.Request.QueryString["deptId"].ToInt();
        /// <summary>
        /// 项目类型
        /// </summary>
        int Kind = HttpContext.Current.Request.QueryString["kind"].ToInt();
        /// <summary>
        /// 单位信息--服务类
        /// </summary>
        SysDepartmentService deptSrv = new SysDepartmentService();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCondition();
                bindData();
            }
        }

        #region 页面方法区


        /// <summary>
        /// 绑定条件
        /// </summary>
        private void bindCondition()
        {
            // CreateBT.AddButton("new.gif", Trans("新增安全隐患整改"), "HseSectEdit.aspx?Cmd=New", Utility.PopedomType.List, HeadMenu1);

        }
        public string GetAUTHOR(string projId)
        {
            string userid = "";

            return userid;
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void bindData()
        {
            //绑定数据            
            string typeName = string.Empty;
            if (Cmd == "Report")
            {
                GridView1.AllowPaging = false;
            }
            else
            {
                GridView1.AllowPaging = true;
            }
            ///end
            ProjectInfoService service = new ProjectInfoService();

            List<ProjectInfoModel> ls = service.GetList().Where(p => p.STATUS ==1).ToList();

            if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.A))
            {
                //ls = ls.Where(p => p.STATUS > -1).ToList();//能看所有
            }
            else if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Delete))
            {
                ls = ls.Where(p => p.STATUS > -1).ToList();//能看所有提交的
            }
            else if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
            {
                ls = ls.Where(p => p.DEPTID == this.userModel.DEPTID && p.STATUS > -1).ToList();//能看部门
            }
            else if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.New))
            {
                ls = ls.Where(p => p.SUBMITTER == this.userModel.USERID).ToList();//能看个人
            }
            if (!string.IsNullOrEmpty(Ddl_ZBFS.SelectedValue))
            {
                ls = ls.Where(p => p.ZBFS == Ddl_ZBFS.SelectedValue.ToInt()).ToList();

            }
            if (!string.IsNullOrEmpty(Tb_SearchBegin.Text))
            {
                ls = ls.Where(p => p.SUBMITDATE >= Tb_SearchBegin.Text.ToDateTime()).ToList();
            }
            if (!string.IsNullOrEmpty(Tb_SearchEnd.Text))
            {
                ls = ls.Where(p => p.SUBMITDATE <= Tb_SearchEnd.Text.ToDateTime()).ToList();
            }
            GridView1.DataSource = ls.OrderByDescending(p => p.SUBMITDATE).ToList();
            GridView1.DataBind();


            if (Cmd == "Report")
            {
                ExportToExcel(Page, GridView1);
            }
        }

        #endregion
        protected string GetStatus(object obj)
        {
            ProjectInfoModel model = obj as ProjectInfoModel;
            ProjectZbwjshService sh = new ProjectZbwjshService();
            ProjectZbwjshModel zjwjsh = sh.GetList().FirstOrDefault(f => f.PROJID == model.PROJID);
            string sName = string.Empty;
            if (zjwjsh == null)
                sName = "准备招标文件";
            else {
                switch (zjwjsh.PRTSTATUS.ToRequestString())
                {
                    case "-1":
                        sName = "准备招标文件";
                        break;
                    case "0":
                        sName = "招标文件提交申请";
                        break;
                    case "1":
                        sName = "招标文件审核通过";
                        break;
                    case "2":
                        sName = "招标文件审核不通过";
                        break;

                }
            }

            return sName;
        }
        #region 事件处理区

        /// <summary>
        /// 数据行绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            ProjectInfoService service = new ProjectInfoService();

            ProjectInfoModel m = service.GetList().FirstOrDefault(p => p.PROJID == id);
            //if (m.STATUS < 0 || m.STATUS == 2)
            //{
            //    btnStrs += string.Format("<a  href='ProjectRegister.aspx?Cmd=Edit&PROJID={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/application_edit.png\" border=\"0\" /></a>", id);
            //    btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            //    btnStrs += string.Format("<a  onclick='return confirm(\"您确定要删除该记录吗?\");' href='ProjectRegister.aspx?Cmd=Delete&PROJID={0}'><img alt=\"\" src=\"/Resources/Styles/icon/delete.gif\" border=\"0\" /></a>", id);
            //}
            //else
            {
                btnStrs += string.Format("<a  href='ZbwjMain.aspx?Cmd=Edit&ProjectId={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/script.png\" border=\"0\" /></a>", id);
            }
            return btnStrs;
        }


        protected string GetFile(string id)
        {
            string btnStrs = string.Empty;
            ProjectInfoService service = new ProjectInfoService();

            ProjectInfoModel m = service.GetList().FirstOrDefault(p => p.PROJID == id);
            if (m.STATUS == 1 || m.STATUS > 2)
            {
                string ImageStoragePath = "/Modules/Public/Zbwj/";
                string zbsqF = "招标申请表";
                btnStrs += string.Format("<a  href='" + ImageStoragePath + id + "/" + zbsqF + ".doc'><img alt=\"\" src=\"/Resources/Common/img/down.gif\" border=\"0\" /></a>", id);

            }

            return btnStrs;
        }
        /// <summary>
        /// 换页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindData();
        }

        /// <summary>
        /// 项目查询按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            bindData();
        }

        #endregion



        protected void Btn_Excel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectTgsy.aspx?Cmd=Report&showType=" + showType, false);
        }


        #region 导出到EXCEL====================================================

        /// <summary>
        /// 将数据导出到Excel
        /// </summary>
        /// <param name="page"></param>
        /// <param name="dgExcel"></param>
        private void ExportToExcel(System.Web.UI.Page page, GridView dgExcel)
        {
            string fileName = "HjzxProjectTgsy.xls";
            try
            {
                // dgExcel.Columns[dgExcel.Columns.Count - 1].Visible = false;
                GridViewRow headerRow = dgExcel.HeaderRow;
                foreach (TableCell cell in headerRow.Cells)
                {
                    cell.BorderStyle = BorderStyle.Solid;
                    cell.BorderWidth = Unit.Pixel(1);
                    cell.BorderColor = System.Drawing.Color.Black;
                }
                foreach (GridViewRow row in dgExcel.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        cell.BorderStyle = BorderStyle.Solid;
                        cell.BorderWidth = Unit.Pixel(1);
                        cell.BorderColor = System.Drawing.Color.Black;
                    }
                }
                //cell.Style.Add("vnd.ms-excel.numberformat", "@");
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.Charset = "UTF-8"; //设置编码的
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.ContentType = "application/ms-excel";

                //解决出现乱码关键问题
                Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

                dgExcel.Page.EnableViewState = false;
                dgExcel.Visible = true;
                //dgExcel.HeaderStyle.Reset();
                //dgExcel.AlternatingRowStyle.Reset();

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(tw);
                dgExcel.RenderControl(hw);

                //输出DataGrid内容
                Response.Write(tw.ToString());
                Response.End();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }// end try catch
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        #endregion

    }

}