using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// GetUser 的摘要说明
    /// </summary>
    public class GetDept : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {            
            context.Response.ContentType = "text/javascript";
            context.Response.Cache.SetNoStore();            
            System.Data.DataTable dt = Enterprise.Service.App.AppDataService.GetDataTable("BASIS_SYS_DEPARTMENT", "DEPTID|DPARENTID|DNAME|");          
            
            context.Response.Write(dt.ToJsonForTree("DEPTID","DNAME","DPARENTID","0"));
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