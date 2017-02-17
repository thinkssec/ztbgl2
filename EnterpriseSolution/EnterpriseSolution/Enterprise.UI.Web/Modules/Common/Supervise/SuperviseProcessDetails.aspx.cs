using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Common.Supervise;
using Enterprise.Model.Common.Supervise;

namespace Enterprise.UI.Web.Modules.Common.Supervise
{
    public partial class SuperviseProcessDetails : Enterprise.Service.Basis.BasePage
    {
        string Id = (string)Enterprise.Component.Infrastructure.Utility.sink("dbid", Enterprise.Component.Infrastructure.Utility.MethodType.Get, 0, 0, Enterprise.Component.Infrastructure.Utility.DataType.Str);
        public Model.Common.Supervise.SuperviseInfoModel InfoModel { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                //
                Model.Common.Supervise.SuperviseProcessModel processModel = new SuperviseProcessModel();
                Service.Common.Supervise.SuperviseProcessService processService = new SuperviseProcessService();
                IList < SuperviseProcessModel> list  = processService.GetList("from SuperviseProcessModel where DBID='" + Id + "'");
                gv.DataSource = list;
                gv.DataBind();

                //
                Service.Common.Supervise.SuperviseInfoService infoService = new SuperviseInfoService();
                InfoModel = infoService.GetList("from SuperviseInfoModel where DBID='" + Id + "'").FirstOrDefault();
                
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = Enterprise.Service.Basis.Sys.SysUserService.GetUserName(e.Row.Cells[0].Text.ToInt());
            }
        }
    }
}