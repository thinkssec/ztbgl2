using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// GetUser 的摘要说明
    /// </summary>
    public class GetUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //add by qw 2014.3.4 增加检验类型条件
            string strKind = context.Request["kind"].ToRequestString();
            //先解码
            strKind = Base64.Base64Decode(strKind);
            //end
            int deptId = context.Request.QueryString["deptid"].ToInt();
            context.Response.ContentType = "text/javascript";
            context.Response.Cache.SetNoStore();
            //检验类型处理
            if (!string.IsNullOrEmpty(strKind))
            {
                string hql = "from HrZigeModel where 1=1 and " + strKind;
                IList<Enterprise.Model.Basis.Sys.SysUserModel> list = new Enterprise.Service.App.Hr.HrZigeService().GetListByHQL(hql).Select(s => s.SysUserModel).ToList();
                SysDepartmentService deptSrv = new SysDepartmentService();
                IList<int> childDeptList = deptSrv.GetChildList(deptId).Select(s=>s.DEPTID).ToList();
                list = list.Where(p => p.DEPTID == deptId || childDeptList.Contains(p.DEPTID)).ToList();
                context.Response.Write(list.ToDataTable().ToJsonForCombobox("USERID", "UNAME"));
            }
            else
            {
                DataTable userdt = Service.App.AppDataService.GetDataTable("BASIS_SYS_USER", "USERID|DEPTID|UNAME");
                DataView dv = userdt.DefaultView;
                dv.RowFilter = "DEPTID=" + deptId;
                context.Response.Write(dv.ToTable().ToJsonForCombobox("USERID", "UNAME"));
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