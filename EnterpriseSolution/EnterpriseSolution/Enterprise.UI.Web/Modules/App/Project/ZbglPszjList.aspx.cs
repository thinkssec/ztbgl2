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
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
namespace Enterprise.UI.Web.Modules.App.Project

{
    public partial class ZbglPszjList : BasePage
    {
        /// <summary>
        /// 初始化参数
        /// </summary>
        CrmPersonService Service = new CrmPersonService();
        ProjectInfoService psrv = new ProjectInfoService();
        ProjectPszjService zsrv = new ProjectPszjService();
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
            var p = psrv.GetList().Where(w => w.PROJID == ProjectId).FirstOrDefault();
            if (true)
            {
                CreateBT.AddButton("new.gif", "新增需求评委", "ZbglPszjList.aspx?Cmd=New&ProjectId=" + ProjectId, Utility.PopedomType.New, HeadMenu1);
                //CreateBT.AddButton("new.gif", "随机抽取", "ZbglPszjList.aspx?Cmd=Get&ProjectId="+ProjectId, Utility.PopedomType.New, HeadMenu1);
                Bt_Search.Visible = true;
                LinkButton2.Visible = true;
                LinkButton3.Visible = true;
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
                GridView2.Columns[GridView2.Columns.Count - 1].Visible = true;
                GridView3.Columns[GridView3.Columns.Count - 1].Visible = true;
            }
            else {
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
                GridView2.Columns[GridView2.Columns.Count - 1].Visible = false;
                GridView3.Columns[GridView3.Columns.Count - 1].Visible = false;
            }
           // CreateBT.AddButton("excel.ico", "导出Excel", "ZbglPszjList.aspx?Cmd=Report", Utility.PopedomType.Print, HeadMenu1);

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
            //tb_Dept.Items.Clear();
            //tb_Affiliation.Items.Clear();
            bindDeptByTree(allDeptLst, 0, 0);
            
            List<ProjectPszjModel>list =zsrv.GetList().ToList();
            
            GridView1.DataSource = list.Where(w=>w.PROJID==ProjectId&&w.LB==1).ToList();
            GridView1.DataBind();

            GridView2.DataSource = list.Where(w => w.PROJID == ProjectId && w.LB == 2).ToList();
            GridView2.DataBind();

            GridView3.DataSource = list.Where(w => w.PROJID == ProjectId && w.LB == 3).ToList();
            GridView3.DataBind();
            
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
            else if (Cmd == "Rget") {

                ProjectPszjModel md = zsrv.GetList().Where(w => w.ZID == PersonId).FirstOrDefault();
                int lb = md.LB.Value;
                string sql = @"select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t 
where t.usrid not in ( select personid from app_project_pszj where projid='" + ProjectId + "') and lb=" + lb + " and del<>1 order by r desc) where rownum<=" + 1;
                List<CrmPersonModel> l = Service.GetListBySQL(sql).ToList();
                md.DB_Option_Action = WebKeys.DeleteAction;
                zsrv.Execute(md);
                foreach (var m in l)
                {
                    ProjectPszjModel tt = new ProjectPszjModel();
                    tt.ZID = Guid.NewGuid().ToRequestString();
                    tt.PROJID = ProjectId;
                    tt.PERSONID = m.USRID.ToRequestString();
                    tt.PERSONNAME = m.PERSONNAME;
                    tt.LB = m.LB;
                    tt.DEPTID = m.DEPTID;
                    tt.DB_Option_Action = WebKeys.InsertAction;
                    zsrv.Execute(tt);
                }
                OnBindGird();
            }
            else if (Cmd == "Lead")
            {
                List<ProjectPszjModel> l = zsrv.GetList().Where(w=>w.LB<=3&&w.PROJID==ProjectId).ToList();
                foreach (var m in l)
                {

                    m.ROLE = "";
                    m.DB_Option_Action = WebKeys.UpdateAction;
                    zsrv.Execute(m);
                }
                ProjectPszjModel md = zsrv.GetList().Where(w => w.ZID == PersonId).FirstOrDefault();
                md.DB_Option_Action = WebKeys.UpdateAction;
                md.ROLE ="1";
                zsrv.Execute(md);
                OnBindGird();
            }
            else if (Cmd == "Get")
            {
                int x = 0,x2=0, y = 0,y2=0;
                x = Txt_X.Text.ToInt();
                x2 = Txt_X2.Text.ToInt();
                y = Txt_Y.Text.ToInt();
                y2 = Txt_Y2.Text.ToInt();
                //if (Ddl_RS.SelectedValue == "7")
                //{
                //    x = 2;
                //    y = 3;
                //    z = 2;
                //}
                List<ProjectPszjModel> ol = zsrv.GetList().Where(w => w.PROJID == ProjectId && w.LB < 5).ToList();
                foreach (var m in ol)
                {
                    m.DB_Option_Action = WebKeys.DeleteAction;
                    zsrv.Execute(m);
                }

                string sql = @"select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=1 and del<>1 order by r) where rownum<=" + x;
                sql += "union all select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=2 and del<>1  order by r) where rownum<=" + y;
                List<CrmPersonModel> l = Service.GetListBySQL(sql).ToList();
                foreach (var m in l)
                {
                    ProjectPszjModel tt = new ProjectPszjModel();
                    tt.ZID = Guid.NewGuid().ToRequestString();
                    tt.PROJID = ProjectId;
                    tt.PERSONID = m.USRID.ToRequestString();
                    tt.PERSONNAME = m.PERSONNAME;
                    tt.LB = m.LB;
                    tt.DEPTID = m.DEPTID;
                    tt.DB_Option_Action = WebKeys.InsertAction;
                    zsrv.Execute(tt);

                }
                OnBindGird();
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
            btnStrs += string.Format("<a href='ZbglPszjList.aspx?Cmd=Edit&PersonId={0}&ProjectId="+ProjectId+"'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", PersonId);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a href='ZbglPszjList.aspx?Cmd=Lead&PersonId={0}&ProjectId=" + ProjectId + "'><img alt=\"设置为组长\" src=\"/Resources/Styles/images/index_ldxx.png\" border=\"0\"/></a>", PersonId);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZbglPszjList.aspx?Cmd=Delete&PersonId={0}&ProjectId="+ProjectId+"'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", PersonId);
            
            return btnStrs;
        }

        protected string GetCommandBtn2(string PersonId)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='ZbglPszjList.aspx?Cmd=Rget&PersonId={0}&ProjectId=" + ProjectId + "'><img alt=\"\" src=\"/Resources/Common/img/ui/ico_refresh.png\" border=\"0\"/></a>", PersonId);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a href='ZbglPszjList.aspx?Cmd=Lead&PersonId={0}&ProjectId=" + ProjectId + "'><img alt=\"设置为组长\" src=\"/Resources/Styles/images/index_ldxx.png\" border=\"0\"/></a>", PersonId);
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

            ProjectPszjModel Model = zsrv.GetList().Where(w => w.ZID == PersonId).FirstOrDefault();
            if (Model != null)
            {
                //deptId = Model.DEPTID.ToRequestString();
                //Tb_ADDRESS.Text = Model.ADDRESS;
                //Tb_BIRTHDAY.Text = Model.BIRTHDAY.ToString();
                //Tb_DEPTDUTY.Text = Model.DEPTDUTY;
                //tb_Dept.SelectedValue = Model.DEPTID.ToRequestString();
                //Tb_EMAIL.Text = Model.EMAIL;
                ////Tb_HOMETOWN.Text = Model.HOMETOWN;
                //Tb_MOBILEPHONE.Text = Model.MOBILEPHONE;
                //Tb_PERSONNAME.Text = Model.PERSONNAME;
                //Tb_PHONE.Text = Model.PHONE;
                ////Tb_POSTCODE.Text = Model.POSTCODE;
                ////Tb_SCHOOL.Text = Model.SCHOOL;
                //Ddl_Sex.SelectedValue = Model.SEX;
                User_SHR2.UserSelectValue = Model.PERSONID;
                //Ddl_DepName.SelectedValue = Model.INFOID;
                //Ddl_WTDW.SelectedValue = Model.DEPTID.ToRequestString();
            }
        }

        private void doDelAction()
        {
            Panel1.Visible = false;
            ProjectPszjModel Model = zsrv.GetList().Where(w => w.ZID == PersonId).FirstOrDefault();
            if (Model != null)
            {
                Model.DB_Option_Action = WebKeys.DeleteAction;
                zsrv.Execute(Model);
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
            ProjectPszjModel Model = zsrv.GetList().Where(w => w.PERSONID == PersonId).FirstOrDefault();
            if (Model == null)
            {
                Model = new ProjectPszjModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                Model.ZID = Guid.NewGuid().ToRequestString();
                Model.PERSONID =User_SHR2.UserSelectValue;
                Model.PERSONNAME = SysUserService.GetUserName(User_SHR2.UserSelectValue.ToInt());
                Model.DEPTID = SysUserService.GetUserDeptId(User_SHR2.UserSelectValue.ToInt());
                Model.LB = 3;
                Model.PROJID = ProjectId;

            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            //Model.ADDRESS = Tb_ADDRESS.Text;
            //Model.BIRTHDAY = Tb_BIRTHDAY.Text.ToDateTime();
            //Model.DEPTDUTY = Tb_DEPTDUTY.Text;
            //Model.DEPTID = tb_Dept.SelectedValue.ToInt();
            //Model.EMAIL = Tb_EMAIL.Text;
            ////Model.HOMETOWN = Tb_HOMETOWN.Text;
            //Model.MOBILEPHONE = Tb_MOBILEPHONE.Text;
            //Model.PERSONNAME = Tb_PERSONNAME.Text;
            //Model.PHONE = Tb_PHONE.Text;
            ////Model.POSTCODE = Tb_POSTCODE.Text;
            ////Model.SCHOOL = Tb_SCHOOL.Text;
            ////Model.INFOID = Ddl_DepName.SelectedValue;
            ////Model.INFOID = Ddl_WTDW.SelectedValue;
            ////Model.INFOID = hid_dw.Value;
            //Model.SEX = Ddl_Sex.SelectedValue;

            Isok = zsrv.Execute(Model);
            Utility.ShowMsg(this.Page, "系统提示", ((Isok) ? "操作成功!" : "操作失败!!!"), "ZbglPszjList.aspx?ProjectId="+ProjectId);


        }

        /// <summary>
        /// 按条件搜索绑定girdview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Bt_Search_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            int x = 0,x2=0, y = 0,y2=0;
            x = Txt_X.Text.ToInt();
            x2 = Txt_X2.Text.ToInt();
            if (string.IsNullOrEmpty(Txt_X.Text))
                x = 2;
            y = Txt_Y.Text.ToInt();
            y2 = Txt_Y2.Text.ToInt();
            if (string.IsNullOrEmpty(Txt_Y.Text))
                y = 2;
            //if (Ddl_RS.SelectedValue == "7")
            //{
            //    x = 2;
            //    y = 3;
            //    z = 2;
            //}
            List<ProjectPszjModel> ol = zsrv.GetList().Where(w => w.PROJID == ProjectId && w.LB != 3 && w.LB < 5).ToList();
            foreach (var m in ol)
            {
                m.DB_Option_Action = WebKeys.DeleteAction;
                zsrv.Execute(m);
            }

            string sql = @"select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=1 and del<>1 and sex='1' order by r desc) where rownum<=" + x;
            sql += " union all select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=1 and del<>1 and sex='0' order by r desc) where rownum<=" + x2;
            sql += " union all select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=2 and del<>1 and sex='1'  order by r desc) where rownum<=" + y;
            sql += " union all select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=2 and del<>1 and sex='0'  order by r desc) where rownum<=" + y2;
            List<CrmPersonModel> l = Service.GetListBySQL(sql).ToList();
            foreach (var m in l)
            {
                ProjectPszjModel tt = new ProjectPszjModel();
                tt.ZID = Guid.NewGuid().ToRequestString();
                tt.PROJID = ProjectId;
                tt.PERSONID = m.USRID.ToRequestString();
                tt.PERSONNAME = m.PERSONNAME;
                tt.LB = m.LB;
                tt.DEPTID = m.DEPTID;
                tt.DB_Option_Action = WebKeys.InsertAction;
                zsrv.Execute(tt);

            }
            OnBindGird();
        }


        protected void Bt_Search_Click2(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            int y = 0,y2=0;

            List<ProjectPszjModel> ol = zsrv.GetList().Where(w => w.PROJID == ProjectId && w.LB == 2).ToList();
            y = Txt_Y.Text.ToInt();
            y2 = Txt_Y2.Text.ToInt();
            if (string.IsNullOrEmpty(Txt_Y.Text))
                y = ol.Count();
            foreach (var m in ol)
            {
                m.DB_Option_Action = WebKeys.DeleteAction;
                zsrv.Execute(m);
            }

            string sql = @"select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=2 and del<>1 and sex='1' order by r desc) where rownum<=" + y;
            sql += " union all select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=2 and del<>1 and sex='0' order by r desc) where rownum<=" + y2;
            List<CrmPersonModel> l = Service.GetListBySQL(sql).ToList();
            foreach (var m in l)
            {
                ProjectPszjModel tt = new ProjectPszjModel();
                tt.ZID = Guid.NewGuid().ToRequestString();
                tt.PROJID = ProjectId;
                tt.PERSONID = m.USRID.ToRequestString();
                tt.PERSONNAME = m.PERSONNAME;
                tt.LB = m.LB;
                tt.DEPTID = m.DEPTID;
                tt.DB_Option_Action = WebKeys.InsertAction;
                zsrv.Execute(tt);

            }
            OnBindGird();
        }
        protected void Bt_Search_Click3(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            int x = 0,x2=0;
            
            List<ProjectPszjModel> ol = zsrv.GetList().Where(w => w.PROJID == ProjectId&&w.LB==1).ToList();

            x = Txt_X.Text.ToInt();
            x2 = Txt_X2.Text.ToInt();
            if (string.IsNullOrEmpty(Txt_X.Text))
                x = ol.Count();
            foreach (var m in ol)
            {
                m.DB_Option_Action = WebKeys.DeleteAction;
                zsrv.Execute(m);
            }

            string sql = @"select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=1 and del<>1 and sex='1' order by r desc) where rownum<=" + x;
            sql += " union all select * from (select t.*,dbms_random.value(0,10)*main r from app_crm_person t where lb=1 and del<>1 and sex='0' order by r desc) where rownum<=" + x2;
            List<CrmPersonModel> l = Service.GetListBySQL(sql).ToList();
            foreach (var m in l)
            {
                ProjectPszjModel tt = new ProjectPszjModel();
                tt.ZID = Guid.NewGuid().ToRequestString();
                tt.PROJID = ProjectId;
                tt.PERSONID = m.USRID.ToRequestString();
                tt.PERSONNAME = m.PERSONNAME;
                tt.LB = m.LB;
                tt.DEPTID = m.DEPTID;
                tt.DB_Option_Action = WebKeys.InsertAction;
                zsrv.Execute(tt);

            }
            OnBindGird();
        }
        protected void Btn_Excel_Click2(object sender, EventArgs e)
        {
            Response.Redirect("ZbglPszjList.aspx?Cmd=Report", false);
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

       

    }
}