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
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Service.Basis.Message;
using Enterprise.Model.Basis.Message;


namespace Enterprise.UI.Web.Modules.App.Document
{
    /// <summary>
    ///  公文类
    /// </summary>
    public partial class DocumentOfcAudit : Enterprise.Service.Basis.BasePage
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
            if (Cmd == "Audit")
            {
                Pnl_Audit.Visible = true;
                LnkBtnAudit.Visible = true;
            }
            //添加操作按钮
            //if(SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Edit))
            //    CreateBT.AddButton("edit.gif", Trans("修改"), "DocumentOfcEdit.aspx?Moduleid=" + ModuleId + "&Cmd=Edit&Id=" + Id, Utility.PopedomType.Edit, HeadMenu1);
            //if(SysUserPermissionService.CheckButtonPermission(Utility.PopedomType.Delete))
            //    CreateBT.AddButton("delete.gif", Trans("删除"), "DocumentOfcEdit.aspx?Moduleid=" + ModuleId + "&Cmd=Delete&Id=" + Id, Utility.PopedomType.Delete, HeadMenu1);
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
                Lb_COMPLETEDATE.Text = q.COMPLETEDATE.ToDateYMDFormat();
                Lb_REQUIREMENT.Text = q.REQUIREMENT;
                Lb_ORGANIZER.Text = q.ORGANIZER==null?"":SysUserService.GetUserName((int)q.ORGANIZER);
                Lb_RESULT.Text = q.RESULT;
                Lb_RESULTDATE.Text = q.RESULTDATE.ToDateYMDFormat();
                Lb_SHSTATUS.Text = q.SHSTATUS == null ? "" : (q.SHSTATUS == 0 ? "待审核" : (q.SHSTATUS == 1 ? "审核通过" : "审核不通过"));
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
                    Utility.ShowMsg(this.Page, "OK", this.Trans("公文不存在"), "TodoIndexBox.aspx");
                    return;
                }
                if (entity.STATUS >= 3) {
                    BfMsgService.UpdateMsgOver(MsgID);
                    Utility.ShowMsg(this.Page, "OK", this.Trans("公文已经提交承办结果"), "TodoIndexBox.aspx");
                    return;
                }
                entity.DB_Option_Action = "Update";

                //entity.RESULTDATE = Txt_RESULTDATE.Text.ToDateTime();
                //entity.RESULT = Txt_RESULT.Text;
                entity.STATUS = 3;
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

        protected void LnkBtnAudit_Click(object sender, EventArgs e)
        {
            DocumentOfficialService aService = new DocumentOfficialService();
            DocumentOfficialModel entity = aService.GetList().FirstOrDefault(p => p.DOCID == Id);
            //创建一个审批消息
            if (entity != null && entity.STATUS == 3)
            {
               
                string msg = string.Empty;
                if (UC_DoShenhe.CHECKRESULT.ToInt() == (int)CheckResultType.不同意)
                {
                    //不同意
                    msg = string.Format("您请交的“{0}”的承办结果审批未通过!请及时登录平台修改后再提交!",
                        entity.TITLE);
 
                    //当前状态
                    entity.SHSTATUS = 2;
                    entity.SHR=this.userModel.USERID;
                    entity.SHSJ = DateTime.Now;
                    entity.WHY = UC_DoShenhe.CHECKOPINION;
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                    aService.Execute(entity);
                }
                else
                {
                    //同意
                    msg = string.Format("您请交的“{0}”的承办结果审批通过!",entity.TITLE);
                    //当前状态
                    entity.SHSTATUS = 1;
                    entity.SHR = this.userModel.USERID;
                    entity.SHSJ = DateTime.Now;
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                    aService.Execute(entity);
                }
                //给提交人发送消息    
                Messages messageModel = new Messages();
                messageModel.MSG_OBJECTID = entity.DOCID;
                messageModel.MSG_TITLE = "系统消息提醒";
                messageModel.MSG_TEXT = msg;
                IMService messageService = MessageFactory.Creator(MessageType.即时消息);
                messageModel.MSG_TYPE = MessageType.即时消息;
                messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                messageModel.MSG_RECEIVER = SysUserService.GetUserLoginName(entity.ORGANIZER.ToInt());
                messageService.SendMessage(messageModel);
                //关闭待办
                BfMsgService.UpdateMsgOver(MsgID);

                Utility.ShowMsg(this.Page, "系统提示", "审核操作完成!", "/TodoIndexBox.aspx");
            }
            else
            {
                //关闭待办
                BfMsgService.UpdateMsgOver(MsgID);

                Utility.ShowMsg(this.Page, "系统提示", "已审核的信息，无法操作", "/TodoIndexBox.aspx");
            }

        }


    }
}