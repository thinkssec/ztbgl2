using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Service.Basis;
using Enterprise.Service.App.Hse;
using Enterprise.Model.App.Hse;
using Enterprise.Service.App.Crm;
using Enterprise.Model.App.Crm;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;

using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Hse
{


    /// <summary>
    /// 项目列表页面
    /// </summary>
    public partial class HseSectList : BasePage
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
            CreateBT.AddButton("new.gif", Trans("新增安全隐患整改"), "HseSectEdit.aspx?Cmd=New", Utility.PopedomType.List, HeadMenu1);

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

            #region by pengwei 为首页统计穿透 重构


            #endregion

            ///new by zy 2014/07/16
            if (Cmd == "Report")
            {
                GridView1.AllowPaging = false;
            }
            else
            {
                GridView1.AllowPaging = true;
            }
            ///end
            HseSectcheckService service = new HseSectcheckService();

            List<HseSectcheckModel> ls = service.GetList().Where(p=>p.STATUS>-2).ToList();
            if (!string.IsNullOrEmpty(Ddl_Tongji.SelectedValue))
            {
                ls = ls.Where(p => p.CLEVEL == Ddl_Tongji.SelectedValue).OrderByDescending(p => p.CDATE).ToList();

            }
            if (!string.IsNullOrEmpty(Tb_SearchBegin.Text)) {
                ls = ls.Where(p => p.CDATE >= Tb_SearchBegin.Text.ToDateTime()).ToList();
            }
            if (!string.IsNullOrEmpty(Tb_SearchEnd.Text)) {
                ls = ls.Where(p => p.CDATE <= Tb_SearchEnd.Text.ToDateTime()).ToList();
            }
            GridView1.DataSource = ls;
            GridView1.DataBind();


            if (Cmd == "Report")
            {
                ExportToExcel(Page, GridView1);
            }
        }

        #endregion
        protected string GetStatus(object obj)
        {
            HseSectcheckModel model = obj as HseSectcheckModel;
            string sName = string.Empty;
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            switch (model.STATUS.ToRequestString())
            {
                case "-5":
                    sName = "审核不通过";
                    break;
                case "-4":
                    sName = "单位安全员不通过";
                    break;
                case "-3":
                    sName = "单位负责人不通过";
                    break;
                case "-1":
                    sName = "临时保存";
                    break;
                case "0":
                    sName = "提交安全整改";
                    break;
                case "1":
                    sName = "提交单位负责人验收";
                    break;
                case "2":
                    sName = "提交单位安全员验收";
                    break;
                case "3":
                    sName = "提交安全承保员验收";
                    break;
                case "4":
                    sName = "完成";
                    break;
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
            HseSectcheckService service = new HseSectcheckService();

            HseSectcheckModel m = service.GetList().FirstOrDefault(p=>p.CKID==id);
            if (m.STATUS < 0) { 
                btnStrs += string.Format("<a  href='HseSectEdit.aspx?Cmd=Edit&CKID={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/application_edit.png\" border=\"0\" /></a>", id);
                btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
                btnStrs += string.Format("<a  onclick='return confirm(\"您确定要删除该记录吗?\");' href='HseSectEdit.aspx?Cmd=Delete&CKID={0}'><img alt=\"\" src=\"/Resources/Styles/icon/delete.gif\" border=\"0\" /></a>", id);
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