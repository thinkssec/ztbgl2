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
    /// 业务流定义
    /// </summary>
    public partial class BfBaseManage : BasePage
    {

        /// <summary>
        /// 业务流定义--服务类
        /// </summary>
        BfBaseService baseSrv = new BfBaseService();
        /// <summary>
        /// 业务流版本发布--服务类
        /// </summary>
        BfPublishService publishSrv = new BfPublishService();

        /// <summary>
        /// 数据集合
        /// </summary>
        List<BfBaseModel> baseModelLst;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定数据列表
                clearText();
                BindGrid();
            }
        }


        /// <summary>
        /// 绑定数据列表
        /// </summary>
        protected void BindGrid()
        {
            //1=绑定数据列表
            baseModelLst = baseSrv.GetList().ToList();
            GridView1.DataSource = baseModelLst;
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
                BfBaseModel dataModel = e.Row.DataItem as BfBaseModel;

                e.Row.Cells[2].Text = string.Format("<a href='BfPublishManage.aspx?CUR_BFID={0}'>{1}</a>", dataModel.BF_ID, dataModel.BF_NAME);

                if (dataModel.BF_STATUS != null)
                {
                    e.Row.Cells[5].Text = (dataModel.BF_STATUS.Value == 1) ? "启用" : "废弃";
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
            string selectId = GridView1.SelectedRow.Cells[1].Text;
            BfBaseModel baseModel = baseSrv.GetList().FirstOrDefault(p => p.BF_ID == selectId);
            if (baseModel != null)
            {
                ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
                Hid_BF_ID.Value = selectId;
                CommonTool.SetModelDataToForm(baseModel, cont, "Txt_", true);
                CommonTool.SetModelDataToForm(baseModel, cont, "Ddl_", true);
            }
            LnkBtn_Ins.Visible = false;
            LnkBtn_Upd.Visible = true;
            LnkBtn_Del.Visible = true;
            LnkBtn_Cancel.Visible = true;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Ins_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
            //新的流程定义
            BfBaseModel baseModel = (BfBaseModel)CommonTool.GetFormDataToModel(typeof(BfBaseModel), cont);
            baseModel.BF_ID = WebKeys.BF_PREFIX + baseSrv.GetBF_ID();
            baseModel.BF_CDATE = DateTime.Now;
            baseModel.DB_Option_Action = WebKeys.InsertAction;
            baseSrv.Execute(baseModel);
            //缺省版本为1
            BfPublishModel publishModel = new BfPublishModel();
            publishModel.BF_ID = baseModel.BF_ID;
            publishModel.BF_VERSION = 1;
            publishModel.BF_MODDATE = DateTime.Now;
            publishModel.BF_PUBSIGN = 0;
            publishModel.BF_STATUS = 1;
            publishModel.DB_Option_Action = WebKeys.InsertAction;
            publishSrv.Execute(publishModel);

            clearText();
            BindGrid();
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Upd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Hid_BF_ID.Value))
            {
                ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
                BfBaseModel baseModel = (BfBaseModel)CommonTool.GetFormDataToModel(typeof(BfBaseModel), cont);
                baseModel.BF_ID = Hid_BF_ID.Value;
                baseModel.BF_CDATE = DateTime.Now;
                baseModel.DB_Option_Action = WebKeys.UpdateAction;
                baseSrv.Execute(baseModel);
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
            if (!string.IsNullOrEmpty(Hid_BF_ID.Value))
            {
                //1==删除版本信息
                BfPublishModel delPublishModel = new BfPublishModel();
                delPublishModel.BF_ID = Hid_BF_ID.Value;
                delPublishModel.DB_Option_Action = "DeleteByBF_ID";
                publishSrv.Execute(delPublishModel);

                //2==删除流程定义
                BfBaseModel baseModel = new BfBaseModel();
                baseModel.BF_ID = Hid_BF_ID.Value;
                baseModel.DB_Option_Action = WebKeys.DeleteAction;
                baseSrv.Execute(baseModel);
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
            Response.Redirect("BfBaseManage.aspx");
        }


        #region 私有方法


        /// <summary>
        /// 清空输入框内容
        /// </summary>
        private void clearText()
        {
            Hid_BF_ID.Value = "";
            Txt_BF_NAME.Text = "";
            Txt_BF_TYPE.Text = "";
            LnkBtn_Ins.Visible = true;
            LnkBtn_Upd.Visible = false;
            LnkBtn_Del.Visible = false;
            LnkBtn_Cancel.Visible = false;
        }

        #endregion

        


    }
}
