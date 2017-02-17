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

namespace Enterprise.UI.Web.Component.UserControl
{
    /// <summary>
    /// 审核信息编辑控件
    /// </summary>
    public partial class ProjectDoAuditUControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// 获取审核意见文本控件ID
        /// </summary>
        public string MyOpinionHtmlId { get { return Txt_CHECKOPINION.HtmlId; } }
        /// <summary>
        /// 获取审核结论控件ID
        /// </summary>
        public string MyCheckResultId { get { return Txt_CHECKRESULT.ClientID; } }

        public bool ShowScore { get; set; }

        public ProjectDoAuditUControl()
        {
            ShowScore = true;            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Txt_CHECKATTCH.Attributes.Add("readonly", "true");
                //trscore.Visible = ShowScore;
                Txt_CHECKOPINION.Text = "审核通过!";
            }
        }

        /// <summary>
        /// 审核结果
        /// </summary>
        public string CHECKRESULT
        {
            get { return Txt_CHECKRESULT.SelectedValue; }
            set { Txt_CHECKRESULT.SelectedValue = value; }
        }
        /// <summary>
        /// 审核意见
        /// </summary>
        public string CHECKOPINION
        {
            get { return Txt_CHECKOPINION.Text; }
            set { Txt_CHECKOPINION.Text = value; }
        }
        ///// <summary>
        ///// 审核意见稿
        ///// </summary>
        //public string CHECKATTCH
        //{
        //    get { return Txt_CHECKATTCH.Value; }
        //    set { Txt_CHECKATTCH.Text = Txt_CHECKATTCH.Value = value; }
        //}
        ///// <summary>
        ///// 质量得分
        ///// </summary>
        //public string CHECKSCORE
        //{
        //    get { return Txt_CHECKSCORE.Text; }
        //    set { Txt_CHECKSCORE.Text = value; }
        //}
    }
}