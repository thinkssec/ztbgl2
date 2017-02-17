using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enterprise.Component.Infrastructure;
using System.Data;

namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// CostExamine 的摘要说明
    /// </summary>
    public class CostExamine : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //add by qw 2014.3.26 增加项目ID的过滤 start
            string projId = context.Request.QueryString["projid"];
            //end
            context.Response.ContentType = "text/javascript";
            context.Response.Cache.SetNoStore();
            DataTable dt = new DataTable();
            //mod by qw 2014.3.26 增加项目ID的过滤 start
            if (string.IsNullOrEmpty(projId))
            {
                dt = Service.App.AppDataService.GetDataTable("APP_EXAMINE_COST", "COSTCODE|COSTNAME|PARENTCODE");
                DataView dv = dt.DefaultView;
                dv.Sort = " COSTCODE ASC ";
                context.Response.Write(dv.ToTable().ToJsonForEasyuiComboTree("COSTCODE", "COSTNAME", "PARENTCODE", "", ""));
            }
            else
            {
                //以项目ID进行数据过滤
                string sql =
                    string.Format("SELECT COSTCODE,COSTNAME,'' AS PARENTCODE FROM APP_EXAMINE_COST WHERE COSTCODE IN "
                    + " (SELECT COSTCODE FROM APP_PROJECT_COST WHERE PROJID='{0}') ORDER BY COSTCODE", projId);
                dt = Service.App.AppDataService.GetDataTableBySQL(sql);
                context.Response.Write(dt.ToJsonForEasyuiComboTree("COSTCODE", "COSTNAME", "PARENTCODE", "", ""));
            }
            //end
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}