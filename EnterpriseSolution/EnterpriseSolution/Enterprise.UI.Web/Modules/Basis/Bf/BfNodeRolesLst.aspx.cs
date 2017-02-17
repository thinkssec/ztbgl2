using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using Enterprise.Model.Basis.Sys;
using Enterprise.Model.Basis.Bf;
using Enterprise.Service.Basis.Bf;
using Enterprise.Service.Basis;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Modules.Basis.Bf
{

    /// <summary>
    /// 业务流--节点角色列表
    /// </summary>
    public partial class BfNodeRolesLst : BasePage
    {

        /// <summary>
        /// 业务流版本发布--服务类
        /// </summary>
        BfPublishService publishSrv = new BfPublishService();
        /// <summary>
        /// 业务流节点--服务类
        /// </summary>
        BfNodesService nodesSrv = new BfNodesService();
        /// <summary>
        /// 业务流节点角色--服务类
        /// </summary>
        BfNoderolesService noderolesSrv = new BfNoderolesService();

        /// <summary>
        /// 业务流发布版本数据集合
        /// </summary>
        List<BfPublishModel> pubModelLst;
        /// <summary>
        /// 业务流节点数据集合
        /// </summary>
        List<BfNodesModel> nodesList;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定数据列表
                BindDdl();
            }
        }


        /// <summary>
        /// 绑定下拉控件
        /// </summary>
        protected void BindDdl()
        {
            Ddl_BF_ID.Items.Clear();
            Ddl_BF_ID.Items.Add(new ListItem("", ""));
            pubModelLst = publishSrv.GetList().Where(p => p.BF_VERSION == 1).ToList();
            foreach (BfPublishModel model in pubModelLst)
            {
                if (model.BfBase != null)
                {
                    Ddl_BF_ID.Items.Add(new ListItem(model.BfBase.BF_NAME, model.BfBase.BF_ID));
                }
            }
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        protected void BindGrid()
        {
            //绑定数据列表
            nodesList = nodesSrv.GetList().
                Where(p => p.BF_ID == Ddl_BF_ID.SelectedValue && p.BF_VERSION == int.Parse(Ddl_BF_VERSION.SelectedValue)).ToList();
            List<BfNoderolesModel> rolesList = noderolesSrv.
                GetListById_Version(Ddl_BF_ID.SelectedValue, int.Parse(Ddl_BF_VERSION.SelectedValue)).ToList();
            GridView1.DataSource = rolesList;
            GridView1.DataBind();
        }


        /// <summary>
        /// 业务流下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddl_BF_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ddl_BF_VERSION.Items.Clear();
            Ddl_BF_VERSION.Items.Add(new ListItem("", ""));
            pubModelLst = publishSrv.GetList().Where(p => p.BF_ID == Ddl_BF_ID.SelectedValue).ToList();
            foreach (BfPublishModel model in pubModelLst)
            {
                Ddl_BF_VERSION.Items.Add(new ListItem(model.BF_VERSION.ToString(), model.BF_VERSION.ToString()));
            }
        }


        /// <summary>
        /// 业务流版本下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddl_BF_VERSION_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 分页事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BfNoderolesModel dataModel = e.Row.DataItem as BfNoderolesModel;
                if (dataModel != null)
                {
                    //节点信息
                    BfNodesModel node = nodesList.Find(p => p.BF_NODEID == dataModel.BF_NODEID);
                    if (node != null)
                    {
                        e.Row.Cells[1].Text = node.BF_NODENAME;
                    }

                    //角色类型  4
                    switch (dataModel.BF_ROLETYPE.Value) 
                    {
                        case 0://指定人员
                            e.Row.Cells[4].Text = "指定人员";
                            break;
                        case 1://静态角色
                            e.Row.Cells[4].Text = "静态角色";
                            break;
                        case 2://动态角色
                            e.Row.Cells[4].Text = "动态角色";
                            break;
                    }
                    
                    //操作类型  5
                    e.Row.Cells[5].Text = (dataModel.BF_OPERATIONTYPE.Value == 0) ? "操作人员" : "通知人员";

                    //方法名称  6
                    e.Row.Cells[6].Text = (dataModel.BfClsmethod != null) ? dataModel.BfClsmethod.BF_METHODDESC : "";
                }
            }
        }


        #region 私有方法

        /// <summary>
        /// 清空输入框内容
        /// </summary>
        private void clearText()
        {

        }

        #endregion

        

        


    }
}
