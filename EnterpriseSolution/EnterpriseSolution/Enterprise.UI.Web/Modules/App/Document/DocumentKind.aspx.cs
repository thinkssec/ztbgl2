using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Model.App.Document;
using Enterprise.Service.App.Document;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.Basis;

namespace Enterprise.UI.Web.Modules.App.Document
{
    public partial class DocumentKind : BasePage
    {
        string KId = (string)Utility.sink("KId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        DocumentKindService DKservice = new DocumentKindService();
        DocumentKindModel DKModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Oncommand();
            if (!IsPostBack)
            {
                bindData();
                bindCondition();

            }

        }
        private void Oncommand()
        {
            CreateBT.AddButton("new.gif", "新增类别", "DocumentKind.aspx?Cmd=New", Utility.PopedomType.List, HeadMenu1);
            CreateBT.AddButton("back.gif", "返回", "DocunmentList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        private void bindData()
        {
            IList<DocumentKindModel> list = DKservice.GetListByHQL("from DocumentKindModel p order by p.LBXH");
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        private void bindCondition()
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

        private void doAddAction()
        {
            Panel1.Visible = true;
        }

        private void doUpdAction()
        {
            Panel1.Visible = true;
            DKModel = DKservice.GetSingle(KId);
            if (DKModel != null)
            {
                tb_LBBH.ReadOnly = true;
                tb_LBBH.Text = DKModel.LBBH;
                tb_Name.Text = DKModel.LBMC;
                tb_LBXH.Text = DKModel.LBXH;
                tb_SJBH.Text = DKModel.SJBH;
            }
        }

        private void doDelAction()
        {
            bool isOK = false;
            Panel1.Visible = false;
            DKModel = DKservice.GetSingle(KId);
            if (DKModel != null)
            {
                DKModel.DB_Option_Action = WebKeys.DeleteAction;
                isOK = DKservice.Execute(DKModel);
            }
            if (isOK)
            {
                Utility.ShowMsg(this.Page, "操作完成", "删除成功！", "DocumentKind.aspx");
            }
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string Id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='DocumentKind.aspx?Cmd=Edit&KId={0}'><img alt=\"\" src=\"/Resources/Styles/icon/paperclip.gif\" border=\"0\"/></a>", Id);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该文章吗?\");' href='DocumentKind.aspx?Cmd=Delete&KId={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", Id);
            return btnStrs;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //绑定gridview中TextBox的值。
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Txt_LBBH = e.Row.FindControl("Txt_LBBH") as Label;
                Txt_LBBH.Text = DataBinder.Eval(e.Row.DataItem, "LBBH").ToRequestString();
                DocumentKindModel Model = DKservice.GetSingle(Txt_LBBH.Text);
                if (Model != null)
                {
                    string Pid = Model.SJBH;
                    while (Pid != "")
                    {
                        Txt_LBBH.Text = "> " + Txt_LBBH.Text;
                        DocumentKindModel model = DKservice.GetSingle(Pid);
                        if (model != null)
                        {
                            Pid = model.SJBH;
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
            bindData();
        }

        /// <summary>
        /// 文档类型提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string msg = "添加数据失败!!!";//缺省
            DKModel = DKservice.GetSingle(KId);
            if (DKModel == null)
            {
                DKModel = new DocumentKindModel();
                DKModel.DB_Option_Action = WebKeys.InsertAction;
                IList<DocumentKindModel> list = DKservice.GetList();
                foreach (var item in list)
                {
                    if (tb_LBBH.Text == item.LBBH)
                    {
                        Utility.ShowMsg(this.Page, "系统提示", "类别编号已经存在！请重新输入");
                    }
                }
            }
            else
            {
                DKModel.DB_Option_Action = WebKeys.UpdateAction;
            }
            DKModel.LBBH = tb_LBBH.Text;
            DKModel.LBMC = tb_Name.Text;
            DKModel.LBXH = tb_LBXH.Text;
            DKModel.SJBH = tb_SJBH.Text;
            if (DKservice.Execute(DKModel))
            {
                msg = "添加数据成功！";
                Utility.ShowMsg(this.Page, "操作完成", msg, "DocumentKind.aspx");
            }
            else
            {
                Utility.ShowMsg(this.Page, "操作失败", msg);
            }
        }
    }
}