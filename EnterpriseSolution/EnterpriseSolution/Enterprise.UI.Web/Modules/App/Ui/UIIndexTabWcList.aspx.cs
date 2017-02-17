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
    public partial class UIIndexTabWcList : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectInfoService service = new ProjectInfoService();

            List<ProjectInfoModel> ls = service.GetList().Where(p => p.STATUS ==11).ToList();

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
                    sName = "招标申请审核通过";
                    break;
                case "3":
                    sName = "编制完成招标文件";
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
                if(m.STATUS<3)
                    btnStrs += string.Format("<a  href='ZbwjMain.aspx?Cmd=Edit&ProjectId={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/select.gif\" border=\"0\" /></a>", id);
                else
                    btnStrs += string.Format("<a  href='ZbglMain.aspx?Cmd=Edit&ProjectId={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/select.gif\" border=\"0\" /></a>", id);
            }
            return btnStrs;
        }
    }
}