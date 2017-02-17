using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Control;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Crm;
using Enterprise.Service.Basis;
using Enterprise.Service.Basis.Sys;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.UI.Web.Modules.App.Crm
{
    public partial class CrmPersonList : BasePage
    {
        /// <summary>
        /// 初始化参数
        /// </summary>
        CrmPersonService Service = new CrmPersonService();
        IList<CrmPersonModel> list = null;
        string PersonId = (string)Utility.sink("PERSONID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string deptId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {
                OnBindData();
                OnBindCondition();
            }
        }

        private void OnCommand()
        {
            //新增，只能由项目负责人操作
            CreateBT.AddButton("new.gif", "新增", "CrmPersonList.aspx?Cmd=New", Utility.PopedomType.New, HeadMenu1);
           // CreateBT.AddButton("excel.ico", "导出Excel", "CrmPersonList.aspx?Cmd=Report", Utility.PopedomType.Print, HeadMenu1);
            //检测用户是否有编辑权限
            if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
            {
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            }
            else
            {
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            }
        }

        private void OnBindData()
        {
            OnBindDdl();
            OnBindGird();
        }

        private void OnBindDdl()
        {
            //CrmInfoService ser = new CrmInfoService();
            //var list = ser.GetList();
            ////Ddl_DepName.DataSource = list;
            ////Ddl_DepName.DataTextField = "CRMNAME";
            ////Ddl_DepName.DataValueField = "INFOID";
            ////Ddl_DepName.DataBind();
            //ddl_dName.DataSource = list;
            //ddl_dName.DataTextField = "CRMNAME";
            //ddl_dName.DataValueField = "INFOID";
            //ddl_dName.DataBind();
            //ddl_dName.Items.Insert(0, new ListItem("请选择公司名称...", ""));
           // Ddl_DepName.SelectedValue = "1";
           // Ddl_DepName.Items.Insert(0, new ListItem("请选择人员...", "0"));
        }

        private void OnBindGird()
        {
            SysDepartmentService deptSrv = new SysDepartmentService();
            List<SysDepartMentModel> allDeptLst = deptSrv.GetList().OrderBy(p => p.DORDERBY).ToList();
           // tb_Dept.Items.Clear();
            //tb_Affiliation.Items.Clear();
            bindDeptByTree(allDeptLst, 0, 0);
            //string hql = " from CrmPersonModel p where PERSONID is not null ";
            //string sql = @"select a.* from app_crm_person a where  a.personname like '%" + tb_Name.Text + "%' ";
            //if (!string.IsNullOrEmpty(ddl_dName.SelectedValue))
            //{
            //    hql += "and p.INFOID = '" + ddl_dName.SelectedValue + "' ";
            //    sql += " and b.infoid='" + ddl_dName.SelectedValue + "'";
            //}
            //LogHelper.WriteLog("**************"+sql);
            //list = Service.GetListByHQL(hql).ToList();
            //if (!string.IsNullOrEmpty(tb_Name.Text))
            //{
            //    list = list.Where(p => p.PERSONNAME.Contains(tb_Name.Text)).ToList();
            //}
            list = Service.GetList().Where(p => p.PERSONNAME.Contains(tb_Name.Text)).OrderBy(o=>o.LB).ToList();
            
            GridView1.DataSource = list;
            GridView1.DataBind();
            if (Cmd == "Report")
            {
                GridView1.AllowPaging = false;
                GridView1.Columns[7].Visible = false;
                ExportToExcel(Page, GridView1);
            }
            //新增，合并单元格
           // GroupRows(GridView1,1);
        }
        private void bindDeptByTree(List<SysDepartMentModel> deptLst, int parentId, int tierCount)
        {
            List<SysDepartMentModel> subDeptLst = deptLst.Where(p => p.DPARENTID == parentId).OrderBy(p => p.DORDERBY).ToList();
            foreach (SysDepartMentModel model in subDeptLst)
            {
                ListItem item = new ListItem((getBlankSpace(tierCount) + model.DNAME), model.DEPTID.ToString());
                //tb_Dept.Items.Add(item);
                //tb_Affiliation.Items.Add(item);
                bindDeptByTree(deptLst, model.DEPTID, tierCount + 1);
            }
        }
        private string getBlankSpace(int cou)
        {
            string s = "├";
            for (int i = 0; i < cou; i++)
            {
                s += "─";
            }
            return s;
        }
        ///合并GridView1中客户信息相同的行
        //public void GroupRows(GridView GridView1, int cellNum)
        //{
        //    int i = 0, rowSpanNum = 1;
        //    while (i<GridView1.Rows.Count-1)
        //    {
        //        GridViewRow gvr = GridView1.Rows[i];
        //        for (++i;i < GridView1.Rows.Count;i++)
        //        {
        //            GridViewRow gvrNext = GridView1.Rows[i];
        //            if (gvr.Cells[cellNum].Text==gvrNext.Cells[cellNum].Text)
        //            {
        //                gvrNext.Cells[cellNum].Visible = false;
        //                rowSpanNum++;
        //            }
        //            else
        //            {
        //                gvr.Cells[cellNum].RowSpan = rowSpanNum;
        //                rowSpanNum = 1;
        //                break;
        //            }
        //            if (i==GridView1.Rows.Count-1)
        //            {
        //                gvr.Cells[cellNum].RowSpan = rowSpanNum;
        //            }
        //        }
        //    }
        
        
        //}
        /// <summary>
        /// 根据不同参数执行相应操作
        /// </summary>
        private void OnBindCondition()
        {
            if (Cmd == "New")
            {
                doAddAction();
            }
            else if (Cmd == "Edit")
            {
                doUpdAction();
            }
            else if (Cmd == "Delete")
            {
                doDelAction();
            }
            //else if(Cmd=="Report"){
            //    ExportToExcel(Page, GridView1);
            //}
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string PersonId)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='CrmPersonList.aspx?Cmd=Edit&PersonId={0}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", PersonId);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='CrmPersonList.aspx?Cmd=Delete&PersonId={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", PersonId);
            return btnStrs;
        }

        /// <summary>
        /// 根据指定id返回客户单位名称
        /// </summary>
        public string GetDepName(string id)
        {
            CrmInfoService ser = new CrmInfoService();
            CrmInfoModel Model = ser.GetList().Where(p => p.INFOID == id).FirstOrDefault();
            if (Model != null)
            {
                return Model.CRMNAME;
            }
            return "";
        }

        private void doUpdAction()
        {
            Panel1.Visible = true;

            CrmPersonModel Model = Service.GetList().Where(w => w.PERSONID == PersonId).FirstOrDefault();
            if (Model != null)
            {
                //deptId = Model.DEPTID.ToRequestString();
                //Tb_ADDRESS.Text = Model.ADDRESS;
                //Tb_BIRTHDAY.Text = Model.BIRTHDAY.ToString();
                //Tb_DEPTDUTY.Text = Model.DEPTDUTY;
                Ddl_LB.Text = Model.LB.ToRequestString();
                Rd_SEX.SelectedValue = Model.SEX;
                t_MAIN.Text = Model.MAIN.ToRequestString();
                //tb_Dept.SelectedValue = Model.DEPTID.ToRequestString();
                User_SHR2.UserSelectValue = Model.USRID.ToRequestString();
                //Tb_EMAIL.Text = Model.EMAIL;
                Ddl_EMAIL.SelectedValue = Model.EMAIL;
                Tb_MOBILEPHONE.Text = Model.MOBILEPHONE;
                Tb_DEPTDUTY.Text = Model.DEPTDUTY;
                //Tb_HOMETOWN.Text = Model.HOMETOWN;
                Tb_MOBILEPHONE.Text = Model.MOBILEPHONE;
                //Tb_PERSONNAME.Text = Model.PERSONNAME;
                Tb_PHONE.Text = Model.PHONE;
                //Tb_POSTCODE.Text = Model.POSTCODE;
                //Tb_SCHOOL.Text = Model.SCHOOL;
                //Ddl_Sex.SelectedValue = Model.SEX;
                Ddl_Del.SelectedValue = Model.DEL.ToRequestString();
                //Ddl_DepName.SelectedValue = Model.INFOID;
                //Ddl_WTDW.SelectedValue = Model.DEPTID.ToRequestString();
            }
        }

        private void doDelAction()
        {
            Panel1.Visible = false;
            CrmPersonModel Model = Service.GetList().Where(w=>w.PERSONID==PersonId).FirstOrDefault();
            if (Model != null)
            {
                Model.DB_Option_Action = WebKeys.DeleteAction;
                Service.Execute(Model);
                OnBindData();
            }
        }

        private void doAddAction()
        {
            deptId = string.Empty;
            //Tb_BIRTHDAY.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Panel1.Visible = true;
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            OnBindData();
        }

        /// <summary>
        /// 提交数据
        /// </summary>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            bool Isok = false;
            CrmPersonModel Model = Service.GetList().Where(w => w.PERSONID == PersonId).FirstOrDefault();;
            if (Model == null)
            {
                Model = new CrmPersonModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                Model.PERSONID ="CP"+CommonTool.GetPkId();

            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            //Model.ADDRESS = Tb_ADDRESS.Text;
            //Model.BIRTHDAY = Tb_BIRTHDAY.Text.ToDateTime();
            //Model.DEPTDUTY = Tb_DEPTDUTY.Text;
            if (string.IsNullOrEmpty(t_MAIN.Text))
                Model.MAIN = 1;
            else Model.MAIN = t_MAIN.Text.ToInt();
            Model.LB = Ddl_LB.SelectedValue.ToInt();
            Model.SEX = Rd_SEX.SelectedValue;
            //Model.DEPTID = tb_Dept.SelectedValue.ToInt();
            Model.USRID = User_SHR2.UserSelectValue.ToInt();
            Model.DEL = Ddl_Del.SelectedValue.ToInt();
           // Model.EMAIL = Tb_EMAIL.Text;
            Model.EMAIL = Ddl_EMAIL.SelectedValue;
            Model.MOBILEPHONE = Tb_MOBILEPHONE.Text;
            Model.DEPTDUTY = Tb_DEPTDUTY.Text;
            //Model.HOMETOWN = Tb_HOMETOWN.Text;
            Model.MOBILEPHONE = Tb_MOBILEPHONE.Text;
            //Model.PERSONNAME = Tb_PERSONNAME.Text;
            Model.PHONE = Tb_PHONE.Text;
            //Model.POSTCODE = Tb_POSTCODE.Text;
            //Model.SCHOOL = Tb_SCHOOL.Text;
            //Model.INFOID = Ddl_DepName.SelectedValue;
            //Model.INFOID = Ddl_WTDW.SelectedValue;
            //Model.INFOID = hid_dw.Value;
            //Model.SEX = Ddl_Sex.SelectedValue;
            Model.DEPTID = SysUserService.GetUserDeptId(User_SHR2.UserSelectValue.ToInt());
            Model.PERSONNAME = SysUserService.GetUserName(User_SHR2.UserSelectValue.ToInt());
            Isok = Service.Execute(Model);
            Utility.ShowMsg(this.Page, "系统提示", ((Isok) ? "操作成功!" : "操作失败!!!"), "CrmPersonList.aspx");


        }

        /// <summary>
        /// 按条件搜索绑定girdview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Bt_Search_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            OnBindGird();
        }
        protected void Btn_Excel_Click2(object sender, EventArgs e)
        {
            Response.Redirect("CrmPersonList.aspx?Cmd=Report", false);
        }

        //private void ExportToExcel(System.Web.UI.Page page, GridView dgExcel)
        //{
        //    string fileName = "客户信息表.xls";
        //    try
        //    {
        //        // dgExcel.Columns[dgExcel.Columns.Count - 1].Visible = false;
        //        GridViewRow headerRow = dgExcel.HeaderRow;
        //        foreach (TableCell cell in headerRow.Cells)
        //        {
        //            cell.BorderStyle = BorderStyle.Solid;
        //            cell.BorderWidth = Unit.Pixel(1);
        //            cell.BorderColor = System.Drawing.Color.Black;
        //        }
        //        foreach (GridViewRow row in dgExcel.Rows)
        //        {
        //            foreach (TableCell cell in row.Cells)
        //            {
        //                cell.BorderStyle = BorderStyle.Solid;
        //                cell.BorderWidth = Unit.Pixel(1);
        //                cell.BorderColor = System.Drawing.Color.Black;
        //            }
        //        }
        //        //cell.Style.Add("vnd.ms-excel.numberformat", "@");
        //        Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
        //        Response.Charset = "UTF-8"; //设置编码的
        //        Response.ContentEncoding = System.Text.Encoding.UTF8;
        //        Response.ContentType = "application/ms-excel";

        //        //解决出现乱码关键问题
        //        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

        //        dgExcel.Page.EnableViewState = false;
        //        dgExcel.Visible = true;
        //        //dgExcel.HeaderStyle.Reset();
        //        //dgExcel.AlternatingRowStyle.Reset();

        //        System.IO.StringWriter tw = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(tw);
        //        dgExcel.RenderControl(hw);

        //        //输出DataGrid内容
        //        Response.Write(tw.ToString());
        //        Response.End();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }// end try catch
        //}

        private void ExportToExcel(System.Web.UI.Page page1, GridView dgExcel)
        {
            //string fileName = "CrmPersonList.xls";
            string hql = " from CrmPersonModel p where PERSONID is not null ";
            string sql = @"select a.* from app_crm_person a ,app_crm_info b where a.infoid=b.infoid and (b.crmname like '%" + tb_Name.Text + "%' or b.crmserial like '%" + tb_Name.Text.ToUpper() + "%' or a.personname like '%" + tb_Name.Text + "%')";
            //if (!string.IsNullOrEmpty(ddl_dName.SelectedValue))
            //{
            //    hql += "and p.INFOID = '" + ddl_dName.SelectedValue + "' ";
            //    sql += " and b.infoid='" + ddl_dName.SelectedValue + "'";
            //}
            //LogHelper.WriteLog("**************"+sql);
            //list = Service.GetListByHQL(hql).ToList();
            //if (!string.IsNullOrEmpty(tb_Name.Text))
            //{
            //    list = list.Where(p => p.PERSONNAME.Contains(tb_Name.Text)).ToList();
            //}
            //list = Service.getLxr(sql);

            dgExcel.DataSource = list;
            dgExcel.DataBind();
            string fileName = "联系人信息表.xls";
            //    try
            //    {
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


            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            dgExcel.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(dgExcel);

            page.RenderControl(htw);

            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
            //Response.Charset = "UTF-8";
            //Response.ContentEncoding = Encoding.Default;
            //Response.Write(sb.ToString());
            //Response.End();
            
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + Encoding.GetEncoding("ISO-8859-1").GetString(Encoding.GetEncoding("GB2312").GetBytes(fileName)));
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8).ToString());
            Response.Charset = "UTF-8"; //设置编码的
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/ms-excel";

            //解决出现乱码关键问题
            Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
            Response.Write(sb.ToString());
            Response.End();
        }

    }
}