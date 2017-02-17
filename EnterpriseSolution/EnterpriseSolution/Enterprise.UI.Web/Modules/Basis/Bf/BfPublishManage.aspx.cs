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
    /// 业务流版本发布管理
    /// </summary>
    public partial class BfPublishManage : BasePage
    {

        string bfId = (string)Utility.sink("CUR_BFID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        /// <summary>
        /// 服务类
        /// </summary>
        BfPublishService publishSrv = new BfPublishService();
        BfNoderolesService noderolesSrv = new BfNoderolesService();
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
                clearText();
                BindDdl();
                BindGrid();
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
            Ddl_BF_ID.SelectedValue = bfId;
        }

        /// <summary>
        /// 业务流下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddl_BF_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }


        /// <summary>
        /// 绑定数据列表
        /// </summary>
        protected void BindGrid()
        {
            //1=绑定数据列表
            if (string.IsNullOrEmpty(Ddl_BF_ID.SelectedValue))
            {
                pubModelLst = publishSrv.GetList().ToList();
            }
            else
            {
                pubModelLst = publishSrv.GetList().Where(p => p.BF_ID == Ddl_BF_ID.SelectedValue).ToList();
            }
            GridView1.DataSource = pubModelLst;
            GridView1.DataBind();
        }

        /// <summary>
        /// 页索引变化
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
                BfPublishModel dataModel = e.Row.DataItem as BfPublishModel;
                BfBaseModel baseModel = dataModel.BfBase;
                if (baseModel != null)
                {
                    //业务流名称
                    e.Row.Cells[2].Text = baseModel.BF_NAME;
                }
                //发布情况 5
                e.Row.Cells[5].Text = (dataModel.BF_PUBSIGN != null && dataModel.BF_PUBSIGN.Value == 1) ? "已发布" : "未发布";
                //当前状态 7
                e.Row.Cells[7].Text = (dataModel.BF_STATUS != null && dataModel.BF_STATUS.Value == 1) ? "启用" : "废弃";
                //业务流脚本 8
                if (dataModel.BF_PUBSIGN != null && dataModel.BF_PUBSIGN.Value == 1)
                {
                    e.Row.Cells[8].Text = string.Format(
                        "<a href='../../../Component/BF/BFToView.aspx?CUR_BFID={0}&CUR_BFVER={1}' target='_blank'>{2}</a>",
                        dataModel.BF_ID, dataModel.BF_VERSION, "<img src='../../../Resources/Styles/images/sitemap.png' border='0'/>");
                }
                else
                {
                    e.Row.Cells[8].Text = string.Format(
                        "<a href='../../../Component/BF/BFDesigner.aspx?CUR_BFID={0}&CUR_BFVER={1}' target='_blank'>{2}</a>",
                        dataModel.BF_ID, dataModel.BF_VERSION, "<img src='../../../Resources/Styles/images/vector.png' border='0'/>");
                }
            }
        }


        /// <summary>
        /// 选择行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bfId = GridView1.SelectedRow.Cells[1].Text;
            string bfName = GridView1.SelectedRow.Cells[2].Text;
            string bfVer = GridView1.SelectedRow.Cells[3].Text;
            BfPublishModel publishModel = publishSrv.GetList().
                FirstOrDefault(p => p.BF_ID == bfId && p.BF_VERSION == int.Parse(bfVer));
            if (publishModel != null)
            {
                ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
                Hid_BF_ID.Value = bfId;
                Hid_BF_VERSION.Value = bfVer;
                CommonTool.SetModelDataToForm(publishModel, cont, "Txt_", true);
                CommonTool.SetModelDataToForm(publishModel, cont, "Ddl_", true);
                Lbl_BF_NAME.Text = bfName + "  [版本" + bfVer + "]";
            }
            LnkBtn_Upd.Visible = true;
            LnkBtn_Del.Visible = true;
            LnkBtn_Cancel.Visible = true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Upd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Hid_BF_ID.Value) && 
                !string.IsNullOrEmpty(Hid_BF_VERSION.Value))
            {
                ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
                BfPublishModel publishModel = publishSrv.GetList().
                    FirstOrDefault(p => p.BF_ID == Hid_BF_ID.Value && p.BF_VERSION == int.Parse(Hid_BF_VERSION.Value));
                BfPublishModel updModel = (BfPublishModel)CommonTool.GetFormDataToModel(typeof(BfPublishModel), cont);
                if (publishModel != null)
                {
                    publishModel.BF_MODDATE = DateTime.Now;
                    publishModel.BF_STATUS = updModel.BF_STATUS;
                    publishModel.BF_PUBSIGN = updModel.BF_PUBSIGN;
                    if (updModel.BF_PUBSIGN.Value == 1) {
                        publishModel.BF_PUBDATE = DateTime.Now;
                    }
                    publishModel.DB_Option_Action = WebKeys.UpdateAction;
                    publishSrv.Execute(publishModel);
                }
            }

            clearText();
            BindGrid();
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Del_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Hid_BF_ID.Value) &&
                !string.IsNullOrEmpty(Hid_BF_VERSION.Value))
            {
                string bfId = Hid_BF_ID.Value;
                int bfVersion = int.Parse(Hid_BF_VERSION.Value);

                //1==删除节点角色
                BfNoderolesModel delNoderolesModel = new BfNoderolesModel();
                delNoderolesModel.BF_ID = bfId;
                delNoderolesModel.BF_VERSION = bfVersion;
                delNoderolesModel.DB_Option_Action = "DeleteByBF_ID_VERSION";
                noderolesSrv.Execute(delNoderolesModel);
                //2==删除流转路径
                BfFlowpathModel delFlowpathModel = new BfFlowpathModel();
                delFlowpathModel.BF_ID = bfId;
                delFlowpathModel.BF_VERSION = bfVersion;
                delFlowpathModel.DB_Option_Action = "DeleteByBF_ID_VERSION";
                flowpathSrv.Execute(delFlowpathModel);
                //3==删除节点
                BfNodesModel delNodesModel = new BfNodesModel();
                delNodesModel.BF_ID = bfId;
                delNodesModel.BF_VERSION = bfVersion;
                delNodesModel.DB_Option_Action = "DeleteByBF_ID_VERSION";
                nodesSrv.Execute(delNodesModel);
                //4==删除版本信息
                BfPublishModel delPublishModel = new BfPublishModel();
                delPublishModel.BF_ID = bfId;
                delPublishModel.BF_VERSION = bfVersion;
                delPublishModel.DB_Option_Action = WebKeys.DeleteAction;
                publishSrv.Execute(delPublishModel);
            }
            clearText();
            BindGrid();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BFPublishManage.aspx");
        }


        #region 私有方法


        /// <summary>
        /// 清空输入框内容
        /// </summary>
        private void clearText()
        {
            Hid_BF_ID.Value = "";
            Hid_BF_VERSION.Value = "";
            Lbl_BF_NAME.Text = "";
            LnkBtn_Upd.Visible = false;
            LnkBtn_Del.Visible = false;
            LnkBtn_Cancel.Visible = false;
        }

        #endregion

        


    }
}
