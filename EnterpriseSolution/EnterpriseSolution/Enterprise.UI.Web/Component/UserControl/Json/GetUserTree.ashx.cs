using Enterprise.Service.Basis.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// GetUserTree 的摘要说明
    /// </summary>
    public class GetUserTree : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int zhiwu = context.Request.QueryString["zhiwu"].ToInt();

            SysUserService uSer = new SysUserService();
            context.Response.ContentType = "text/javascript";
            DataTable dt = new DataTable();
            if (zhiwu > 0)
            {
                dt = uSer.GetRelationForCombox_Zhiwu().Tables[0];
            }
            else
            {
                dt = uSer.GetRelationForCombox().Tables[0];
            }
            string json = dt.ToJsonForEasyuiComboTree("CID", "TEXT", "PARENTID", "d-0", "");
            context.Response.Write(json);
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