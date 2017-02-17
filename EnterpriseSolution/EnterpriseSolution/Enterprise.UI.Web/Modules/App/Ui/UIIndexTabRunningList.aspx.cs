using Enterprise.Service.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Sys;
using Enterprise.Service.Basis.Bf;
using Enterprise.Model.Basis.Bf;
using Enterprise.Component.BF;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.UI.Web.Modules.App.Ui
{
    public partial class UIIndexTabRunningList : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectInfoService service = new ProjectInfoService();

            List<ProjectInfoModel> ls = service.GetList().Where(p => p.STATUS > 0 && p.STATUS != 2).ToList();

            if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.A))
            {
                //ls = ls.Where(p => p.STATUS > -1).ToList();//能看所有
            }
            else if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Delete))
            {
                ls = ls.Where(p => p.STATUS > -1).ToList();//能看所有提交的
            }
            else if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
            {
                ls = ls.Where(p => p.DEPTID == this.userModel.DEPTID && p.STATUS > -1).ToList();//能看部门
            }
            else if (SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.New))
            {
                ls = ls.Where(p => p.SUBMITTER == this.userModel.USERID).ToList();//能看个人
            }

            GridView1.DataSource = ls.OrderByDescending(p => p.SUBMITDATE).Take(7).ToList();
            GridView1.DataBind();
        }

        protected string GetFile(string id)
        {
            string btnStrs = string.Empty;
            ProjectZbwjshService service = new ProjectZbwjshService();


            ProjectZbwjshModel m = service.GetList().OrderByDescending(o => o.SUBMITDATE).FirstOrDefault(p => p.PROJID == id && p.PRTSTATUS == 1);
            //if (m.STATUS == 1 || m.STATUS > 2)
            //{
            //    string ImageStoragePath = "/Modules/Public/Zbwj/";
            //    string zbsqF = "招标申请表";
            //    btnStrs += string.Format("<a  href='" + ImageStoragePath + id + "/" + zbsqF + ".doc'><img alt=\"\" src=\"/Resources/Common/img/down.gif\" border=\"0\" /></a>", id);

            //}
            if (m != null)
                btnStrs = m.ATTACHMENT.ToAttachHtmlByOne();
            return btnStrs;
        }

        protected string GetStatus(object obj)
        {
            ProjectInfoModel model = obj as ProjectInfoModel;
            string sName = string.Empty;
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            switch (model.STATUS.ToRequestString())
            {
                case "1":
                    sName = "准备招标文件";
                    break;
                case "3":
                    sName = "招标文件审核通过";
                    break;
                case "7":
                    sName = "准备评标";
                    break;
                case "8":
                    sName = "完成评标";
                    break;
            }

            return sName;
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            ProjectInfoService service = new ProjectInfoService();

            ProjectInfoModel m = service.GetList().FirstOrDefault(p => p.PROJID == id);
            {
                btnStrs += string.Format("<a  href='/Modules/App/Project/ZbwjMain.aspx?Cmd=Edit&ProjectId={0}' target='_parent'><img alt=\"\" src=\"/Resources/Common/img/icon/script.png\" border=\"0\" /></a>", id);
                    btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
                    btnStrs += string.Format("<a  href='/Modules/App/Project/ZbglMain.aspx?Cmd=Edit&ProjectId={0}' target='_parent'><img alt=\"\" src=\"/Resources/Common/img/icon/select.gif\" border=\"0\" /></a>", id);
            }
            return btnStrs;
        }
    }
}