using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Sys;
using System.Web.UI.HtmlControls;

namespace Enterprise.UI.Web.Component.UserControl
{
    /// <summary>
    /// 审核信息显示控件
    /// </summary>
    public partial class ProjectAuditUControl : System.Web.UI.UserControl
    {

        /// <summary>
        /// 审核信息--服务类
        /// </summary>
        private static readonly ProjectCheckService checkSrv = new ProjectCheckService();

        /// <summary>
        /// 关联ID
        /// </summary>
        public string ASSOCIATEDID { get; set; }


        public bool ShowScore { get; set; }

        public ProjectAuditUControl()
        {
            ShowScore = true;            
        }

        /// <summary>
        /// 显示审核信息
        /// </summary>
        /// <param name="asscId"></param>
        public void ShowAuditInfos(string asscId)
        {
            this.ASSOCIATEDID = asscId;
            var query = checkSrv.GetModelsByAssociateID(ASSOCIATEDID).OrderBy(o=>o.CHECKDATE);
            Repeater1.DataSource = query;
            Repeater1.DataBind();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ProjectCheckModel dataModel = e.Item.DataItem as ProjectCheckModel;

                Label lblShr = e.Item.FindControl("Lbl_Shr") as Label;
                lblShr.Text = SysUserService.GetUserName(dataModel.CHECKER.Value);

                Label lblShyj = e.Item.FindControl("Lbl_Shyj") as Label;
                if (dataModel.CHECKRESULT != null)
                {
                    if (dataModel.CHECKRESULT.Value == 1)
                    {
                        if (!string.IsNullOrEmpty(dataModel.CHECKOPINION))
                        {
                            lblShyj.Text = dataModel.CHECKOPINION + "&nbsp;&nbsp;<font color='green'>(通过)</font><br/>";
                        }
                        else
                        {
                            lblShyj.Text = string.Format("<b>审核通过!</b><br/>");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dataModel.CHECKOPINION))
                        {
                            lblShyj.Text = dataModel.CHECKOPINION + "&nbsp;&nbsp;<font color='red'>(未通过)</font><br/>";
                        }
                        else
                        {
                            lblShyj.Text = string.Format("<font color='red'>审核未通过!</font><br/>");
                        }
                    }
                    //审核意见稿
                    lblShyj.Text += ProjectInfoService.GetAttachmentHTML(dataModel.CHECKID, "意见稿;" + dataModel.CHECKATTCH);
                }
                else
                {
                    lblShyj.Text = "<font color='red'>还未审核！</font>";
                }

                Label lblShrq = e.Item.FindControl("Lbl_Shrq") as Label;
                lblShrq.Text = dataModel.CHECKDATE.ToRequestString();

                //Label lblZldf = e.Item.FindControl("Lbl_Zldf") as Label;
                //lblZldf.Text = dataModel.CHECKSCORE.ToRequestString();

                //if (!ShowScore)
                //{
                //    //找到分数的行
                //    HtmlTableRow tr = e.Item.FindControl("trscore") as HtmlTableRow;
                //    tr.Visible = false;                    
                    
                //}
                
            }
        }

    }
}