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
    /// 业务流角色对应的获取方法列表页面
    /// </summary>
    public partial class BfClsmethodsManage : BasePage
    {

        /// <summary>
        /// 业务流角色对应的获取方法--服务类
        /// </summary>
        BfClsmethodsService clsmethodSrv = new BfClsmethodsService();
        /// <summary>
        /// 数据集合
        /// </summary>
        List<BfClsmethodsModel> clsmethodModelLst;
        
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
            clsmethodModelLst = clsmethodSrv.GetList().OrderByDescending(p=>p.BF_CLSID).ToList();
            GridView1.DataSource = clsmethodModelLst;
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
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //}
        }

        /// <summary>
        /// 选择行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectId = GridView1.SelectedRow.Cells[1].Text;
            BfClsmethodsModel clsmethodModel = clsmethodSrv.GetList().FirstOrDefault(p => p.BF_CLSID == selectId);
            if (clsmethodModel != null)
            {
                ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
                Hid_BF_ID.Value = selectId;
                CommonTool.SetModelDataToForm(clsmethodModel, cont, "Txt_", true);
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
            //新的角色方法
            BfClsmethodsModel clsModel = (BfClsmethodsModel)CommonTool.GetFormDataToModel(typeof(BfClsmethodsModel), cont);
            clsModel.BF_CLSID = WebKeys.BF_CLSMETHOD_PREFIX + clsmethodSrv.GetClsMethod_ID();
            clsModel.DB_Option_Action = WebKeys.InsertAction;
            clsmethodSrv.Execute(clsModel);
    
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
                BfClsmethodsModel clsModel = (BfClsmethodsModel)CommonTool.GetFormDataToModel(typeof(BfClsmethodsModel), cont);
                clsModel.BF_CLSID = Hid_BF_ID.Value;
                clsModel.DB_Option_Action = WebKeys.UpdateAction;
                clsmethodSrv.Execute(clsModel);
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
                //删除
                BfClsmethodsModel clsModel = new BfClsmethodsModel();
                clsModel.BF_CLSID = Hid_BF_ID.Value;
                clsModel.DB_Option_Action = WebKeys.DeleteAction;
                clsmethodSrv.Execute(clsModel);
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
            Response.Redirect("BfClsmethodsManage.aspx");
        }

        #region 私有方法


        /// <summary>
        /// 清空输入框内容
        /// </summary>
        private void clearText()
        {
            Hid_BF_ID.Value = "";
            Txt_BF_CLSNAME.Text = "";
            Txt_BF_METHOD.Text = "";
            Txt_BF_METHODDESC.Text = "";
            LnkBtn_Ins.Visible = true;
            LnkBtn_Upd.Visible = false;
            LnkBtn_Del.Visible = false;
            LnkBtn_Cancel.Visible = false;
        }

        #endregion

        


    }
}
