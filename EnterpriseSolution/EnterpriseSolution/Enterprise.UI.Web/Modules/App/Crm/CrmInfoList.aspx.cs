using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Crm;
using Enterprise.Service.Basis;
using Enterprise.Service.Basis.Sys;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Enterprise.UI.Web.Modules.App.Crm
{
    public partial class CrmInfoList : BasePage
    {
        /// <summary>
        /// 初始化参数
        /// </summary>
        CrmInfoService Service = new CrmInfoService();
        string InfoId = (string)Utility.sink("INFOID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string cx = (string)Utility.sink("CX", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        IList<CrmInfoModel> list = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {
                OnBindData();
                OnCondition();
            }
        }

        private void OnCommand()
        {
            //新增，只能由项目负责人操作
            CreateBT.AddButton("new.gif", "新增", "CrmInfoList.aspx?Cmd=New&CX=" + Txt_CRMNAME.Text, Utility.PopedomType.New, HeadMenu1);
            //CreateBT.AddButton("excel.ico", "导出Excel", "CrmInfoList.aspx?Cmd=Report&CX=" + Txt_CRMNAME.Text, Utility.PopedomType.Print, HeadMenu1);
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
            //var list = Service.GetList();
            //ddl_dName.DataSource = list;
            //ddl_dName.DataTextField = "CRMNAME";
            //ddl_dName.DataValueField = "INFOID";
            //ddl_dName.DataBind();
            //ddl_dName.Items.Insert(0, new ListItem("请选择公司名称...", ""));
            if (Cmd == "Back") {
                Txt_CRMNAME.Text = cx;
            }
            else if (Cmd == "Edit")
            {
                Txt_CRMNAME.Text = cx;
            }
            else if (Cmd == "New")
            {
                Txt_CRMNAME.Text = cx;
            }
            else if (Cmd == "Delete")
            {
                Txt_CRMNAME.Text = cx;
            }
        }

        private void OnBindGird()
        {
            Txt_SCFJ.Attributes.Add("readonly", "true");
            string hql = "from CrmInfoModel p where p.INFOID is not null ";
            //if (!string.IsNullOrEmpty(cx)) Txt_CRMNAME.Text = cx;
            if (!string.IsNullOrEmpty(Txt_CRMNAME.Text))
            {
                hql += " and (p.CRMNAME like '%" + Txt_CRMNAME.Text + "%' or p.CRMSERIAL like '%"+ Txt_CRMNAME.Text.ToUpper() +"%')";
            }
            //Txt_CRMNAME.Text = hql;
            //if (!string.IsNullOrEmpty(Txt_CRMNAME.Text)) cx = Txt_CRMNAME.Text;
            //cx = Txt_CRMNAME.Text;
            list = Service.GetListByHQL(hql).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
            if (Cmd == "Report")
            {
                GridView1.AllowPaging = false;
                GridView1.Columns[7].Visible = false;
                ExportToExcel(Page, GridView1);
            }
        }

        /// <summary>
        /// 根据不同参数执行相应操作
        /// </summary>
        private void OnCondition()
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
            
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string INFOID)
        {
            string btnStrs = string.Empty;
            //btnStrs += string.Format("<a href='CrmPerson2List.aspx?InfoId={0}&CX={1}'><img alt=\"\" src=\"/Resources/Styles/icon/lxr.png\" border=\"0\"/></a>", INFOID, Txt_CRMNAME.Text);
            //btnStrs += "|";
            btnStrs += string.Format("<a href='CrmInfoList.aspx?Cmd=Edit&InfoId={0}&CX={1}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", INFOID, Txt_CRMNAME.Text);
            btnStrs += "|";
            btnStrs += string.Format("<a onclick='return confirm(\"如果删除客户信息一并删除相应客户信息的所有信息联系人，您确定要删除该记录吗?\");' href='CrmInfoList.aspx?Cmd=Delete&InfoId={0}&CX={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", INFOID, Txt_CRMNAME.Text);
            return btnStrs;
        }


        private void doUpdAction()
        {
            Panel1.Visible = true;

            CrmInfoModel Model = Service.GetList().Where(w => w.INFOID == InfoId).FirstOrDefault();
            if (Model != null)
            {
                if (!string.IsNullOrEmpty(Model.ADDDATE.ToRequestString()))
                {
                    Tb_ADDDATE.Text = Model.ADDDATE.Value.ToString("yyyy-MM-dd");
                }
                else
                { Tb_ADDDATE.Text = DateTime.Now.ToString("yyyy-MM-dd"); }

                Tb_CRMADDR.Text = Model.CRMADDR;
                //Ddl_CRMKIND.SelectedValue = Model.CRMKIND;
                Ddl_CRMPROPERTY.SelectedValue = Model.CRMPROPERTY;
                Txt_SCFJ.DBValue = Model.FVIEWNAMES.ToRequestString();
                Txt_SCFJ.Text = Model.FNAMES.ToRequestString();
                Txt_shuih.Text = Model.SHUIH.ToRequestString() ;
                Txt_zhangh.Text = Model.ZHANGH.ToRequestString();
                Tb_CRMNAME.Text = Model.CRMNAME;
                Tb_CRMSERIAL.Text = Model.CRMSERIAL;
                Txt_ZSBH.Text = Model.ZSBH;
                //Txt_KEY5.Text = Model.KEY5;
                //Txt_KEY6.Text = Model.KEY6;
                //Txt_KEY7.Text = Model.KEY7;
                
                
                //Ddl_CRMUSER.UserSelectValue = Model.CRMUSER.ToRequestString();
                //Ddl_CRMUSER.DataBind();
            }
        }

        private void doDelAction()
        {
            Panel1.Visible = false;
            try
            {
                CrmInfoModel Model = Service.GetList().Where(w=>w.INFOID==InfoId).FirstOrDefault();
                if (Model != null)
                {
                    ///如果删除客户信息 一并删除相应客户信息的所有信息联系人
                   

                    Model.DB_Option_Action = WebKeys.DeleteAction;
                    Service.Execute(Model);
                    OnBindData();
                }
            }
            catch
            {
                Utility.ShowMsg(this.Page, "系统提示", "操作失败!这个客户信息已经被使用，无法删除！", "CrmInfoList.aspx");

            }
        }

        private void doAddAction()
        {

            Tb_ADDDATE.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
        /// 按条件搜索绑定girdview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Bt_Search_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            OnBindGird();
        }

        /// <summary>
        /// 提交数据
        /// </summary>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            bool Isok = false;
            CrmInfoModel Model = Service.GetList().Where(w => w.INFOID == InfoId).FirstOrDefault();
            if (Model == null)
            {
                Model = new CrmInfoModel();
                Model.DB_Option_Action = WebKeys.InsertAction;
                Model.INFOID = "CRM" + CommonTool.GetPkId();
            }
            else
            {
                Model.DB_Option_Action = WebKeys.UpdateAction;
            }
            Model.ADDDATE = Tb_ADDDATE.Text.ToDateTime();
            Model.CRMADDR = Tb_CRMADDR.Text;
            //Model.CRMKIND = Ddl_CRMKIND.SelectedValue;
            Model.CRMNAME = Tb_CRMNAME.Text;
            Model.CRMPROPERTY = Ddl_CRMPROPERTY.SelectedValue;
            Model.FNAMES = Txt_SCFJ.Text;
            Model.FVIEWNAMES = Txt_SCFJ.DBValue;
            Model.SHUIH=Txt_shuih.Text;
            Model.ZHANGH = Txt_zhangh.Text;
            Model.SUBMITTER = this.userModel.USERID;
            //Model.CRMSERIAL = Tb_CRMSERIAL.Text;
            Model.ZSBH = Txt_ZSBH.Text;
            //Model.KEY5 = Txt_KEY5.Text;
            //Model.KEY6 = Txt_KEY6.Text;
            //Model.KEY7 = Txt_KEY7.Text;
            Model.CRMSERIAL = getSx(Tb_CRMNAME.Text);
            //Model.CRMUSER = Ddl_CRMUSER.UserSelectValue.ToInt();
            Isok = Service.Execute(Model);
            Utility.ShowMsg(this.Page, "系统提示", ((Isok) ? "操作成功!" : "操作失败!!!"), "CrmInfoList.aspx?Cmd=Back&CX="+cx);
        }

        protected string getSx(string characters){
             if (characters.Length != 0){
                StringBuilder fullSpellBuild = new StringBuilder();

                for (int i = 0; i < characters.Length; i++)
                {
                    //判断是否是中文
                    bool itemFlag = ChineseChar.IsValidChar(characters[i]);
                    if (itemFlag)
                    {
                        ChineseChar chineseChar = new ChineseChar(characters[i]);
                        foreach (string value in chineseChar.Pinyins)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                //fullSpellBuild.Append(value.Remove(value.Length - 1, 1));
                                fullSpellBuild.Append(value.Substring(0,1));
                                break;
                            }
                        }
                    }
                    else
                    {
                        fullSpellBuild.Append(characters[i]);
                    }
                

                }
                return fullSpellBuild.ToString();
             }
            return "";
        }
        //private void ExportToExcel(System.Web.UI.Page page, GridView dgExcel)
        //{
        //    string fileName = "ProjectList.xls";
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
            string hql = "from CrmInfoModel p where p.INFOID is not null ";
            //if (!string.IsNullOrEmpty(cx)) Txt_CRMNAME.Text = cx;
            if (!string.IsNullOrEmpty(Txt_CRMNAME.Text))
            {
                hql += " and (p.CRMNAME like '%" + Txt_CRMNAME.Text + "%' or p.CRMSERIAL like '%"+ Txt_CRMNAME.Text.ToUpper() +"%')";
            }
            //Txt_CRMNAME.Text = hql;
            //if (!string.IsNullOrEmpty(Txt_CRMNAME.Text)) cx = Txt_CRMNAME.Text;
            //cx = Txt_CRMNAME.Text;
            list = Service.GetListByHQL(hql).ToList();
            dgExcel.DataSource = list;
            dgExcel.DataBind();

            string fileName = "客户信息表.xls";
            dgExcel.AllowPaging = false;
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