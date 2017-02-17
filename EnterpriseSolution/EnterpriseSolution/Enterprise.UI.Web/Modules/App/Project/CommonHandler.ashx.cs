using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

using Enterprise.Component.Control;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using System.Text;


namespace Enterprise.UI.Web.Modules.App.Project
{
    /// <summary>
    /// CommonHandler 的摘要说明
    /// </summary>
    public class CommonHandler : IHttpHandler
    {

        #region 服务声明

        /// <summary>
        /// 部门服务类
        /// </summary>
        private static readonly SysDepartmentService deptSrv = new SysDepartmentService();

        #endregion

        public void ProcessRequest(HttpContext context)
        {
            string result = string.Empty;
            context.Response.ContentType = "text/plain";
            string p = context.Request["type"];
            switch (p)
            {
                case "selectDept"://选择单位
                    result = GetSelectDept();
                    break;
            }
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 获取单位选择内容
        /// </summary>
        /// <returns></returns>
        protected string GetSelectDept()
        {
            StringBuilder sb = new StringBuilder();
            var list = deptSrv.GetList().OrderBy(p=>p.DORDERBY);
            foreach (var q in list)
            {
                sb.Append(q.DEPTID + "	" + q.DNAME + "\r\n");
                //France	10248	VINET	2006-7-4	2006-8-1	10000	"Com Test'c	5bc"	Reims	12
            }
            return sb.ToString();
        }


    }
}