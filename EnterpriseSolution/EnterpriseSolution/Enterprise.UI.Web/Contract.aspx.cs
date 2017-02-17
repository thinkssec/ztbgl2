using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.UI.Web
{
    public partial class Contract : Enterprise.Service.Basis.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string CreateContract()
        {
            StringBuilder sb = new StringBuilder();
            SysDepartmentService dService = new SysDepartmentService();
            List<SysDepartMentModel> dlist = dService.GetList().OrderBy(p=>p.DORDERBY).ToList();
            sb.Append("<table class=\"GridViewStyle\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">");
            sb.Append("<tr class=\"GridViewHeaderStyle\"><th width=\"200\" align=\"center\" height=\"28\">" 
                + Trans("部门") + "</th><th width=\"100\" align=\"center\">"
                + Trans("人员") + "</th><th align=\"center\">" + Trans("出生日期") + "</th><th align=\"center\">"
                + Trans("手机") + "</th><th align=\"center\">" + Trans("工作电话") + "</th><th align=\"center\">" 
                + Trans("工作邮箱") + "</th></tr>");
            SysUserService uService = new SysUserService();
            foreach (SysDepartMentModel dEntity in dlist)
            {
                int i = 0;
                List<SysUserModel> ulist = uService.GetList().Where(p => p.DEPTID == dEntity.DEPTID).OrderBy(p=>p.UORDERBY).ToList();
                foreach (SysUserModel uEntity in ulist)
                {
                    if (i == 0)
                    {
                        sb.Append("<tr><td rowspan=" + ulist.Count + " align=\"center\" valign=\"center\" style=\"background-color: #ffffff;\">" + SysDepartmentService.GetDepartMentName(dEntity.DEPTID) + "</td><td height=\"25\"  align=\"center\">" + uEntity.UNAME + "</td><td align=\"center\">" + ((uEntity.UBIRTHDAY.Year == 9999) ? "" : uEntity.UBIRTHDAY.ToShortDateString()) + "</td><td align=\"center\">" + uEntity.UHWPHONE + "</td><td align=\"center\">" + uEntity.UGNPHONE + "</td><td align=\"center\">" + uEntity.OTHEREMAIL + "</td></tr>");
                    }
                    else
                    {
                        sb.Append("<tr><td height=\"25\"  align=\"center\">" + uEntity.UNAME + "</td><td align=\"center\">" + ((uEntity.UBIRTHDAY.Year == 9999) ? "" : uEntity.UBIRTHDAY.ToShortDateString()) + "</td><td align=\"center\">" + uEntity.UHWPHONE + "</td><td align=\"center\">" + uEntity.UGNPHONE + "</td><td align=\"center\">" + uEntity.OTHEREMAIL + "</td></tr>");
                    }
                    i++;
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }

    }
}