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
using Enterprise.Service.Basis.Bf;
using Enterprise.Component.BF;
namespace Enterprise.UI.Web.Modules.App.Document
{
    /// <summary>
    ///  公文类
    /// </summary>
    public partial class DocumentOfcOrgn : Enterprise.Service.Basis.BasePage
    {
        protected string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string ModuleId = (string)Utility.sink("ModuleId", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s =SysModuleService.GetModuleName(ModuleId);
                OnStart();
                OnCommand();
            }
        }

        private void OnCommand()
        {
            //添加操作按钮
            //if(SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
            //    CreateBT.AddButton("edit.gif", Trans("修改"), "DocumentOfcEdit.aspx?Moduleid=" + ModuleId + "&Cmd=Edit&Id=" + Id, Utility.PopedomType.Edit, HeadMenu1);
            //if(SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Delete))
            //    CreateBT.AddButton("delete.gif", Trans("删除"), "DocumentOfcEdit.aspx?Moduleid=" + ModuleId + "&Cmd=Delete&Id=" + Id, Utility.PopedomType.Delete, HeadMenu1);
            //CreateBT.AddButton("back.gif", Trans("返回"), "DocumentOfcList.aspx?ModuleId=" + ModuleId, Utility.PopedomType.List, HeadMenu1);
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
                Lb_Rcv.Text = (int)q.RECEVIEUSER==null?"":SysUserService.GetUserName((int)q.RECEVIEUSER);
                Lb_COMPLETEDATE.Text = q.COMPLETEDATE.ToDateYMDFormat();
                Lb_REQUIREMENT.Text = q.REQUIREMENT;
                Lb_ORGANIZER.Text = (int)q.ORGANIZER==null?"":SysUserService.GetUserName((int)q.ORGANIZER);
            }
        }
        protected void BtnOrgn_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                DocumentOfficialService aService = new DocumentOfficialService();
                DocumentOfficialModel entity  = aService.GetList().FirstOrDefault(p => p.DOCID == Id);
                if (entity == null) {
                    BfMsgService.UpdateMsgOver(MsgID);
                    Utility.ShowMsg(this.Page, "OK", this.Trans("公文不存在"), "/TodoIndexBox.aspx");
                    return;
                }
                if (entity.STATUS >= 3) {
                    BfMsgService.UpdateMsgOver(MsgID);
                    Utility.ShowMsg(this.Page, "OK", this.Trans("公文已经提交承办结果"), "/TodoIndexBox.aspx");
                    return;
                }
                entity.DB_Option_Action = "Update";

                entity.RESULTDATE = Txt_RESULTDATE.Text.ToDateTime();
                entity.RESULT = Txt_RESULT.Text;
                entity.STATUS = 3;
                entity.SHSTATUS = 0;
                if (aService.Execute(entity))
                {
                    sendMessageToAudit(entity);
                }
                BfMsgService.UpdateMsgOver(MsgID);

            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "DocumentOfcList.aspx?ModuleId=" + ModuleId);
        }

        private string sendMessageToAudit(DocumentOfficialModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                model.DOCID,//和项目关联的消息
                model.RECEVIEUSER.Value,//接收人
                this.userModel,//当前用户
                string.Format("《{0}》-已提交承办结果，需要您进行审核!", model.TITLE),//消息标题
                string.Format("/Modules/App/Document/DocumentOfcAudit.aspx?Cmd=Audit&Id={0}", model.DOCID),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
        }
    }
}