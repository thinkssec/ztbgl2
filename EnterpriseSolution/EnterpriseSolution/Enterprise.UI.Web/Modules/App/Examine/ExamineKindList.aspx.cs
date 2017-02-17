using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.App.Examine;
using Enterprise.Service.Basis;
using Enterprise.Service.App.Examine;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Examine
{
    public partial class ExamineKindList : BasePage
    {
        /// <summary>
        /// 初始化参数
        /// </summary>
        ExamineKindService Service = new ExamineKindService();
        /// <summary>
        /// 科目代号Id
        /// </summary>
        string Id = (string)Utility.sink("KINDID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {
                OnBindData();
                OnConditon();
            }
        }

        private void OnCommand()
        {
            //新增，只能由项目负责人操作
            CreateBT.AddButton("new.gif", "新增", "ExamineKindList.aspx?Cmd=New&KINDID=" + Id, Utility.PopedomType.List, HeadMenu1);
        }

        private void OnBindData()
        {
            OnBindDdl();
            IList<ExamineKindModel> list = Service.GetListByHQL("from ExamineKindModel p order by p.KINDORDER");
            GridView1.DataSource = list;
            GridView1.DataBind();

        }

        private void OnBindDdl()
        {
            SysDepartmentService.BindDepartMentDropDownList(Ddl_Dep);   

        }

         private void OnConditon()
        {
            if (Cmd == "New")
            {
                doAddtion();
            }
            else if (Cmd == "Edit")
            {
                doUpdation();
            }
            else if (Cmd == "Delete")
            {
                doDelAction();
            }
        }

        private void doAddtion()
        {
            Panel1.Visible = true;
        }

        private void doUpdation()
        {
            Panel1.Visible = true;
            string ID = Id.Trim();
            ExamineKindModel Model = Service.GetSingle(ID);
            if (Model != null)
            {
                Tb_KINDID.Text = Model.KINDID.ToString();
                Tb_KINDNAME.Text = Model.KINDNAME;
                Tb_KINDORDER.Text = Model.KINDORDER;
                Tb_PARENTID.Text = Model.PARENTID.ToString();
                Ddl_Dep.SelectedValue = Model.DEPTID.ToString();
            }
        }

        private void doDelAction()
        {
            bool ok = false;
            Panel1.Visible = false;
            string ID = Id.Trim();
            ExamineKindModel Model = Service.GetSingle(ID);
            if (Model != null)
            {
                Model.DB_Option_Action = WebKeys.DeleteAction;
                ok = Service.Execute(Model);
                Utility.ShowMsg(this.Page, "系统提示", ((ok) ? "删除成功!" : "操作失败!!!"), "ExamineKindList.aspx");
            }


        }

        /// <summary>
        /// 实现gridview里按照层级顺序显示  若为子集则在前面加">"号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //绑定gridview中TextBox的值。
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Txt_KINDID = e.Row.FindControl("Txt_KINDID") as Label;
                Txt_KINDID.Text = DataBinder.Eval(e.Row.DataItem, "KINDID").ToString();
                Label Txt_KINDNAME = e.Row.FindControl("Txt_KINDNAME") as Label;
                Txt_KINDNAME.Text = DataBinder.Eval(e.Row.DataItem, "KINDNAME").ToString();
                ExamineKindModel Model = Service.GetSingle(Txt_KINDID.Text);
                if (Model != null)
                {
                    string Pid = Model.PARENTID.ToString();
                    while ( Pid != "")
                    {
                        Txt_KINDID.Text = "> " + Txt_KINDID.Text;
                        Txt_KINDNAME.Text = "> " + Txt_KINDNAME.Text;
                        ExamineKindModel model = Service.GetSingle(Pid);
                        if (model != null)
                        {
                            Pid = model.PARENTID.ToString(); ;
                        }
                        else
                            Pid = "";
                    }
                }
            }
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
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='ExamineKindList.aspx?Cmd=Edit&KINDID={0}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", id);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ExamineKindList.aspx?Cmd=Delete&KINDID={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id);
            return btnStrs;
        }

        /// <summary>
        /// 提交按钮事件
        /// </summary>
        /// <returns></returns>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            bool isOk = false;
            ExamineKindModel model = Service.GetSingle(Id);
            if (model == null)
            {
                model = new ExamineKindModel();
                model.DB_Option_Action = WebKeys.InsertAction;
                var q = Service.GetList().FirstOrDefault(p => p.KINDID == Tb_KINDID.Text.ToInt());
                if (q != null) 
                {
                    Utility.ShowMsg(this.Page, "系统提示", "业务类型ID已经存在！请重新输入", "ExamineKindList.aspx?&Cmd=New");
                }
            }
            else
            {
                model.DB_Option_Action = WebKeys.UpdateAction;
            }
          
            model.KINDID = Tb_KINDID.Text.ToInt();
            model.KINDNAME = Tb_KINDNAME.Text;
            model.KINDORDER = Tb_KINDORDER.Text;
            model.PARENTID = Tb_PARENTID.Text.ToInt();
            model.DEPTID = Ddl_Dep.SelectedValue.ToInt();
            isOk = Service.Execute(model);

            Utility.ShowMsg(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ExamineKindList.aspx");
        }
    }
}