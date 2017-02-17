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
    /// 业务流--流程节点列表
    /// </summary>
    public partial class BfNodesLst : BasePage
    {

        /// <summary>
        /// 服务类
        /// </summary>
        BfPublishService publishSrv = new BfPublishService();
        BfNodesService nodesSrv = new BfNodesService();
        BfFlowpathService flowpathSrv = new BfFlowpathService();

        /// <summary>
        /// 数据集合
        /// </summary>
        List<BfPublishModel> pubModelLst;


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
            //1===绑定节点数据列表
            List<BfNodesModel> nodesList = nodesSrv.GetList().
                Where(p => p.BF_ID == Ddl_BF_ID.SelectedValue && p.BF_VERSION == int.Parse(Ddl_BF_VERSION.SelectedValue)).ToList();
            GridView1.DataSource = nodesList;
            GridView1.DataBind();

            //2===绑定流转表数据列表 
            List<BfFlowpathModel> flowpathList = flowpathSrv.GetList().
                Where(p => p.BF_ID == Ddl_BF_ID.SelectedValue && p.BF_VERSION == int.Parse(Ddl_BF_VERSION.SelectedValue)).ToList();
            GridView2.DataSource = flowpathList;
            GridView2.DataBind();
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
        /// 数据行绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //}
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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
