using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using System.Data;


namespace Enterprise.UI.Web.Component.UserControl
{
    public partial class UserSelectControl : System.Web.UI.UserControl
    {

        public string DeptSelectValue { get { return tbDeptxt.Text; } set { this.tbDeptxt.Text = value; } }
        public string UserSelectValue { get { return tbUsertxt.Text; } set { this.tbUsertxt.Text = value; } }
        public bool Required { get; set; }
        public string DeptJsonData { get; set; }
        public string UserJsonData { get; set; }

        public string Level { get; set; } 

        public List<ListItem> DeptAppendList { get; set; }
        public bool Enabled { get; set; }

        //add by qw 2014.3.4 增加附加条件
        /// <summary>
        /// 附加参数
        /// </summary>
        public string Addition { get; set; }
        //end

        public UserSelectControl()
        {
            if(string.IsNullOrEmpty(Level))
                Level= "0";
            Enabled = true;
            Required = true;
            DeptAppendList = new List<ListItem>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();    
            }
        }

        private void Bind()
        {
            if (!string.IsNullOrEmpty(UserSelectValue))
            {
                //根据Userid获取DeptId
                DeptSelectValue = Enterprise.Service.Basis.Sys.SysUserService.GetUserDeptId(UserSelectValue.ToInt()).ToRequestString();
            }
            DeptJsonData = "[]";
            //DataTable deptdt = Service.App.AppDataService.GetDataTable("BASIS_SYS_DEPARTMENT", "DEPTID|DNAME|DPARENTID");
            SysDepartmentService dsrv = new SysDepartmentService();
            DataTable deptdt = dsrv.GetList().OrderBy(o => o.DORDERBY).ToList().ToDataTable();
            DeptJsonData = deptdt.ToJsonForTree("DEPTID", "DNAME", "DPARENTID", Level);

            if (Level != "0")
            {
                string tmpName = Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName(Level.ToInt());

                DeptJsonData = "[{\"text\":\"" + tmpName + "\",\"id\":\"" + Level + "\",children:" + DeptJsonData + "}]";
            }

            UserJsonData = "[]";

            if (!string.IsNullOrEmpty(DeptSelectValue))
            {
                DataTable userdt = Service.App.AppDataService.GetDataTable("BASIS_SYS_USER", "USERID|DEPTID|UNAME");
                DataView dv = userdt.DefaultView;
                dv.RowFilter = "DEPTID=" + DeptSelectValue;
                UserJsonData = dv.ToTable().ToJsonForCombobox("USERID", "UNAME");
            }
            AddDeptListItem();
        }

        public override void DataBind()
        {
            Bind();
            base.DataBind();
        }

        public void AddDeptListItem()
        {
            string json = "";
            if (DeptAppendList.Count > 0)
            {
                foreach (var q in DeptAppendList)
                {
                    json = "{\"id\":\"" + q.Value + "\",";
                    json += "\"text\":\"" + q.Text + "\"},";
                }                 
            }
          
            DeptJsonData = "["+json+DeptJsonData.Substring(1, DeptJsonData.Length - 1);            
        }
    }
}