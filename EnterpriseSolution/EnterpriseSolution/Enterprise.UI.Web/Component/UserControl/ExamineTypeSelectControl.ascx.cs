using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using Enterprise.Model.App.Examine;
using Enterprise.Service.App.Examine;
using Enterprise.Service.App;


namespace Enterprise.UI.Web.Component.UserControl
{

    /// <summary>
    /// 检验设施类型选择用户控件
    /// </summary>
    public partial class ExamineTypeSelectControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// 本级代码控件ID
        /// </summary>
        public string HtmlId { get { return Hid_Bjdm.ClientID; } }
        /// <summary>
        /// 本级代码选择值
        /// </summary>
        public string GetBjdmSelectValue { get { return Hid_Bjdm.Value; } }
        /// <summary>
        /// 子级设施类型
        /// </summary>
        public string SubTypeSelectValue { get { return tbExamineSubType.Text; } set { this.tbExamineSubType.Text = Hid_Bjdm.Value = value; } }
        /// <summary>
        /// 主类型
        /// </summary>
        public string MainTypeSelectValue { get { return tbExamineMainType.Text; } set { this.tbExamineMainType.Text = value; } }
        /// <summary>
        /// 是否必选
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 本级代码JSON数据
        /// </summary>
        public string BjdmJsonData { get; set; }
        /// <summary>
        /// 主类型JSON数据
        /// </summary>
        public string MainTypeJsonData { get; set; }
        /// <summary>
        /// 检验类型ID
        /// </summary>
        public int Kind { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; set; }

        public ExamineTypeSelectControl()
        {
            Enabled = true;
            Required = true;
            Kind = 2;//缺省为发证检验
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Bind();    
            //}
        }

        private void Bind()
        {
            //检验类型
            DataTable examineTypeDt = AppDataService.GetDataTable("APP_EXAMINE_PROCESS", "BJDM|BJMC|SJDM|KINDID|CJSX");
            DataView dv = examineTypeDt.DefaultView;
            dv.RowFilter = "SJDM='0' and KINDID='" + Kind + "'";
            dv.Sort = "CJSX";
            MainTypeJsonData = dv.ToTable().ToJsonForCombobox("BJDM", "BJMC");
            
            //本级代码类型
            BjdmJsonData = "[]";
            //只支持单一数据的修改
            if (!string.IsNullOrEmpty(GetBjdmSelectValue))
            {
                string sjdm = GetBjdmSelectValue.Substring(0, 5);
                DataView bjdmDV = examineTypeDt.DefaultView;
                bjdmDV.RowFilter = "SJDM like '" + sjdm + "%' and KINDID='" + Kind + "'";
                bjdmDV.Sort = "BJDM,CJSX";
                BjdmJsonData = bjdmDV.ToTable().
                    ToJsonForEasyuiComboTree("BJDM", "BJMC", "SJDM", sjdm, GetBjdmSelectValue);
            }
        }

        public override void DataBind()
        {
            Bind();
            base.DataBind();
        }

    }
}