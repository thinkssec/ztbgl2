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
    public partial class UIIndexTabSqList : BasePage
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectInfoService service = new ProjectInfoService();

            List<ProjectInfoModel> ls = service.GetList().Where(p => p.STATUS > -2&&p.STATUS<=2).ToList();

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
            ProjectInfoService service = new ProjectInfoService();

            ProjectInfoModel m = service.GetList().FirstOrDefault(p => p.PROJID == id);
            if (m.STATUS == 1 || m.STATUS > 2)
            {
                string ImageStoragePath = "/Modules/Public/Zbwj/";
                string zbsqF = "招标申请表"+m.KINDID;
                btnStrs += string.Format("<a  href='" + ImageStoragePath + id + "/" + zbsqF + ".doc'><img alt=\"\" src=\"/Resources/Common/img/down.gif\" border=\"0\" /></a>", id);

            }

            return btnStrs;
        }
        protected string GetFile2(string id)
        {
            string btnStrs = string.Empty;
            ProjectInfoService service = new ProjectInfoService();
            DateTime date = DateTime.Parse("2016-07-10 00:00:00");
            ProjectInfoModel m = service.GetList().FirstOrDefault(p => p.PROJID == id);
            if (m.STATUS == 1 || m.STATUS > 2)
            {
                string ImageStoragePath = "/Modules/Public/Zbwj/";
                string zbsqF = "招标项目立项审批表" + m.KINDID;
                if (m.SUBMITDATE > date) zbsqF = "项目立项审批表" + m.KINDID + m.ZBFS;
                btnStrs += string.Format("<a  href='" + ImageStoragePath + id + "/" + zbsqF + ".doc'><img alt=\"\" src=\"/Resources/Common/img/down.gif\" border=\"0\" /></a>", id);

            }

            return btnStrs;
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            ProjectInfoService service = new ProjectInfoService();

            ProjectInfoModel m = service.GetList().FirstOrDefault(p => p.PROJID == id);
            if (m.STATUS < 0 || m.STATUS == 2)
            {
                if(m.RTN==666666)
                    btnStrs += string.Format("<a  href='/Modules/App/Project/ProjectRegister6.aspx?Cmd=Edit&PROJID={0}' target='_parent'><img alt=\"\" src=\"/Resources/Common/img/icon/application_edit.png\" border=\"0\" /></a>", id);
                else
                    btnStrs += string.Format("<a  href='/Modules/App/Project/ProjectRegister5.aspx?Cmd=Edit&PROJID={0}' target='_parent'><img alt=\"\" src=\"/Resources/Common/img/icon/application_edit.png\" border=\"0\" /></a>", id);
                btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
                btnStrs += string.Format("<a  onclick='return confirm(\"您确定要删除该记录吗?\");' target='_parent' href='/Modules/App/Project/ProjectRegister2.aspx?Cmd=Delete&PROJID={0}'><img alt=\"\" src=\"/Resources/Styles/icon/delete.gif\" border=\"0\" /></a>", id);
            }
            else
            {
                //btnStrs += string.Format("<a  href='ZbglMain.aspx?Cmd=Edit&ProjectId={0}'><img alt=\"\" src=\"/Resources/Common/img/icon/select.gif\" border=\"0\" /></a>", id);
            }
            return btnStrs;
        }
        protected string GetStatusJd(object obj)
        {
            ProjectInfoModel model = obj as ProjectInfoModel;
            string sName = string.Empty;
            string hql = "from BfUnhandledmsgModel c where c.BF_INSTANCEID='" + model.PROJID + "' order by BF_SENDTIME desc";
            BfMsgService msgSrv = new BfMsgService();
            BfUnhandledmsgModel current = msgSrv.GetMsgLstByHQL(hql).FirstOrDefault();
            if (current != null)
            {
                sName = "【" + SysUserService.GetUserName(current.BF_RECIPIENTS.ToInt()) + "】" + (current.BF_ISREAD == 1 ? "已审核" : "待审核");
            }
            return sName;
        }
        protected string GetStatus(object obj)
        {
            ProjectInfoModel model = obj as ProjectInfoModel;
            string sName = string.Empty;
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            switch (model.STATUS.ToRequestString())
            {
                case "-1":
                    sName = "临时保存";
                    break;
                case "0":
                    //sName = ProjectCheckService.GetCheckProcess(model.PROJID,
                    //    new int[] { model.SHR.ToInt() }); ;
                    sName = "待审核";
                    break;
                case "1":
                    sName = "审核通过";
                    break;
                case "2":
                    sName = "审核不通过";
                    break;
                //case "7":
                //    sName = "准备评标";
                //    break;
                //case "8":
                //    sName = "完成评标";
                //    break;
            }

            return sName;
        }

    }
}