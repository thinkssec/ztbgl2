using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Document;
using Enterprise.Service.App.Document;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.UI.Web.Modules.App.Document
{
    /// <summary>
    ///  公文类
    /// </summary>
    public partial class DocumentOfcView : Enterprise.Service.Basis.BasePage
    {
        protected string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string ModuleId = (string)Utility.sink("ModuleId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s =SysModuleService.GetModuleName(ModuleId);
                lb_MName.Text = s;
                OnStart();
                OnCommand();
            }
        }

        private void OnCommand()
        {
            //添加操作按钮
            if(SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
                CreateBT.AddButton("edit.gif", Trans("修改"), "DocumentOfcEdit.aspx?Moduleid=" + ModuleId + "&Cmd=Edit&Id=" + Id, Utility.PopedomType.Edit, HeadMenu1);
            if(SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Delete))
                CreateBT.AddButton("delete.gif", Trans("删除"), "DocumentOfcEdit.aspx?Moduleid=" + ModuleId + "&Cmd=Delete&Id=" + Id, Utility.PopedomType.Delete, HeadMenu1);
            CreateBT.AddButton("back.gif", Trans("返回"), "DocumentOfcList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
        }

        private void OnStart()
        {
            DocumentOfficialService aService = new DocumentOfficialService();
            var q = aService.GetList().FirstOrDefault(p=>p.DOCID==Id);
            if (q != null)
            {
                lb_User.Text =SysUserService.GetUserName((int)q.CREATEUSER);
                lb_Dept.Text =SysDepartmentService.GetDepartMentName((int)q.CREATEDEPT);
                //lb_Type.Text = q.ATYPE;
                lb_Title.Text = q.TITLE;
                //lb_TitleRu.Text = q.ATITLERU;
                lb_Content.Text = q.CONTENT;
                //lb_ContentRu.Text = q.ACONTENTRU;
                lb_Files.Text = DocumentOfficialService.ToAttachHtml(q);// ArticleInfoService.GetPDFEnclosureHTML(q);
                Lb_Rcv.Text = q.RECEVIEUSER==null?"":SysUserService.GetUserName((int)q.RECEVIEUSER);
            }
        }

    }
}