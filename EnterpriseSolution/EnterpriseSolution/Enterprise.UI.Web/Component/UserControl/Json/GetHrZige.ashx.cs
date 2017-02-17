using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// GetHrZige 的摘要说明
    /// </summary>
    public class GetHrZige : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //add by qw 2014.3.4 增加检验类型条件
            string strKind = context.Request["kind"].ToRequestString();
            //end
            string strWhere = context.Request.QueryString["where"].ToRequestString();
            if (!string.IsNullOrEmpty(strWhere))
            {
                int deptId = context.Request.QueryString["deptid"].ToInt();
                context.Response.ContentType = "text/javascript";
                context.Response.Cache.SetNoStore();
                string hql = "from HrZigeModel where " + strWhere + "='1' ";
                if (!string.IsNullOrEmpty(strKind))
                {
                    hql += " and KINDID='" + strKind + "' ";
                }
                IList<Enterprise.Model.Basis.Sys.SysUserModel> list = new Enterprise.Service.App.Hr.HrZigeService().GetListByHQL(hql).Select(s => s.SysUserModel).ToList();
                context.Response.Write(list.ToDataTable().ToJsonForCombobox("USERID", "UNAME"));
            }
            
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