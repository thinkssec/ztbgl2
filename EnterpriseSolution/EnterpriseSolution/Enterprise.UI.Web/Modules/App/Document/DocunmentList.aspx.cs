using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Service.Basis;
using Enterprise.Model.App.Document;
using Enterprise.Service.App.Document;
using Enterprise.Component.Control;
using Enterprise.Component.Infrastructure;
using System.Text;

namespace Enterprise.UI.Web.Modules.App.Document
{
    public partial class DocunmentList : BasePage
    {
        string DkindId = (string)Utility.sink("DkindId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string DId = (string)Utility.sink("DId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        DocumentProjService DPservice = new DocumentProjService();
        DocumentKindService Kservice = new DocumentKindService();
        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {
                OnBindDDl();
                OnBindTreeList();
                OnBindData();
                OnCondition();
            }
        }

        //<summary>
        //绑定类别的下拉菜单
        // </summary>
        private void OnBindDDl()
        {
            IList<DocumentKindModel> list = Kservice.GetTreeList();
            Ddl_Kind.DataSource = list;
            Ddl_Kind.DataTextField = "LBMC";
            Ddl_Kind.DataValueField = "LBBH";
            Ddl_Kind.DataBind();
            Ddl_Kind.Items.Insert(0, new ListItem("...请选择类型", ""));
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void OnBindData()
        {
            string hql = "from DocumentProjModel p where 1=1";
            if (!string.IsNullOrEmpty(DkindId))
            {
                hql += " and p.LBBH = '" + DkindId + "'";
            }
            if (Cmd == "WXS")
            {
                hql += " and p.DOCSTATUS != 1";
            }
            else
            {
                hql += " and p.DOCSTATUS = 1";
            }
            hql += " order by p.DOCSAVEDATE desc";
            IList<DocumentProjModel> List = DPservice.GetListByHQL(hql);
            GridView1.DataSource = List;
            GridView1.DataBind();
        }

        private void OnBindTreeList()
        {
            TreeView1.Nodes.Clear();
            Bind_Tv(Kservice.GetList().ToList(), null, "0");
        }

        /// <summary>
        /// 筛选绑定girdview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Bt_Search_Click(object sender, EventArgs e)
        {
            string hql = "from DocumentProjModel p where 1=1";
            if (!string.IsNullOrEmpty(s_Key.Text))
            {
                // hql += " and p.ProjectInfo.PROJNAME like '%" + s_Key.Text + "%'";
                hql += " and (p.ProjectInfo.PROJNAME like '%" + s_Key.Text + "%' or p.DOCNAME like '%" + s_Key.Text + "%' or p.DOCOVERVIEW like '%" + s_Key.Text + "%' or p.DOCWRITER like'%" + s_Key.Text + "%')";
            }
            if (!string.IsNullOrEmpty(Ddl_Kind.SelectedValue))
            {
                hql += " and p.LBBH like '" + Ddl_Kind.SelectedValue + "%'";
                // hql += " and p.LBBH = '" + Ddl_Kind.SelectedValue + "'";
            }
            if (!Enterprise.Service.Basis.Sys.SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
            {
                hql += " and p.DOCSTATUS = 1";
            }
            hql += " order by p.DOCSAVEDATE desc";
            IList<DocumentProjModel> List = DPservice.GetListByHQL(hql);
            GridView1.DataSource = List;
            GridView1.DataBind();
            // OnBindData();
        }


        /// <summary>
        /// 绑定TreeView（利用TreeNode）
        /// </summary>
        /// <param name="dt">部门列表</param>
        /// <param name="pNode">树节点</param>
        /// <param name="pId">上级节点ID</param>
        protected void Bind_Tv(List<DocumentKindModel> dt, TreeNode pNode, string pId)
        {
            TreeNode tn;//建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中            
            List<DocumentKindModel> relist = dt.Where(p => p.SJBH == pId).OrderBy(p => p.LBXH).ToList();//利用DataView将数据进行筛选，选出相同 父id值 的数据
            foreach (DocumentKindModel row in relist)
            {
                tn = new TreeNode();//建立一个新节点（学名叫：一个实例）
                if (pNode == null)//如果为根节点
                {
                    tn.Value = row.LBBH.ToString();//节点的Value值，一般为数据库的id值
                    tn.Text = string.Format("<a href=\"DocunmentList.aspx?DkindId={0}\">{1}</a>", row.LBBH, row.LBMC);//节点的Text，节点的文本显示
                    TreeView1.Nodes.Add(tn);//将该节点加入到TreeView中
                    Bind_Tv(dt, tn, row.LBBH);//递归（反复调用这个方法，直到把数据取完为止）
                }
                else//如果不是根节点
                {
                    tn.Value = row.LBBH.ToString();//节点Value值
                    tn.Text = string.Format("<a href=\"DocunmentList.aspx?DkindId={0}\">{1}</a>", row.LBBH, row.LBMC);//节点Text值
                    pNode.ChildNodes.Add(tn);//该节点加入到上级节点中
                    Bind_Tv(dt, tn, row.LBBH);//递归
                }
            }
        }

        /// <summary>
        /// 如果是管理员则增加新增按钮和类别维护按钮
        /// </summary>
        private void OnCommand()
        {
            // if (this.userModel.USERID == userModel.UADMIN)
            // {
            CreateBT.AddButton("new.gif", "新增文档库内容", "DocumentEditAndView.aspx?Cmd=New", Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("look.gif", "修改未显示的文档", "DocunmentList.aspx?Cmd=WXS", Utility.PopedomType.Edit, HeadMenu1);
            CreateBT.AddButton("wode.png", "修改文档库类别", "DocumentKind.aspx", Utility.PopedomType.Edit, HeadMenu1);
            GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            if (Enterprise.Service.Basis.Sys.SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
            {
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
                GridView1.Columns[GridView1.Columns.Count - 2].Visible = true;
            }
            //  }
            else
            {
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
                GridView1.Columns[GridView1.Columns.Count - 2].Visible = false;
            }
        }

        /// <summary>
        /// 根据条件呈现页面信息
        /// </summary>
        private void OnCondition()
        {
            if (Cmd == "Delete")
            {
                // Panel_Detail.Visible = Panel_Edit.Visible = false;
                DocumentProjModel DPmode = DPservice.GetSingle(DId);
                if (DPmode != null)
                {
                    DPmode.DB_Option_Action = WebKeys.DeleteAction;
                    DPservice.Execute(DPmode);
                    OnBindData();
                }
            }
        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(string DId, string DkindId)
        {
            DocumentProjModel DPmode = DPservice.GetSingle(DId);
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='DocumentEditAndView.aspx?Cmd=Edit&DId={0}&DkindId={1}'><img alt=\"\" src=\"/Resources/Styles/icon/paperclip.gif\" border=\"0\"/></a>", DId, DkindId);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该文章吗?\");' href='DocunmentList.aspx?Cmd=Delete&DId={0}&DkindId={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", DId, DkindId);
            return btnStrs;
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
    }
}