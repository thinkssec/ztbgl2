using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Hse;
using Enterprise.Service.App.Hse;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
namespace Enterprise.UI.Web.Modules.App.Hse
{
    public partial class HseSectAudit : Enterprise.Service.Basis.BasePage
    {
        public string ckId = (string)Utility.sink("CKID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string ckdId = (string)Utility.sink("CKDID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        private HseSectcheckService service = new HseSectcheckService();
        private HseSectcheckdetlService dservice = new HseSectcheckdetlService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                OnStart();
                OnCommand();
            }
        }

        /// <summary>
        /// 控制按钮
        /// </summary>
        private void OnCommand()
        {
            //添加操作按钮
            //CreateBT.AddButton("back.gif", Trans("返回"), "HseSectList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            int deptId = 0;
            //lb_User.Text =SysUserService.GetUserName(Utility.Get_UserId, out deptId);
            //lb_Dept.Text =SysDepartmentService.GetDepartMentName(deptId);
            Txt_CDATE.Text = DateTime.Now.ToDateYMDFormat();
            if (Cmd == "New") {
                HseSectcheckModel cm = service.GetList().FirstOrDefault(p => p.SUBMITTER==this.userModel.USERID&&p.STATUS==-2);
                if (cm == null)
                {
                    cm = new HseSectcheckModel();
                    Hid_CKID.Value=cm.CKID = Guid.NewGuid().ToRequestString();
                    cm.STATUS = -2;
                    cm.SUBMITTER = this.userModel.USERID;
                    cm.DB_Option_Action = WebKeys.InsertAction;
                    service.Execute(cm);
                    HseSectcheckdetlModel dm = new HseSectcheckdetlModel();
                    dm.STATUS = -2;
                    ///dm.SUBMITTER = this.userModel.USERID;
                    dm.CKID = cm.CKID;
                    dm.CKDID = Guid.NewGuid().ToRequestString();
                    dm.DB_Option_Action = WebKeys.InsertAction;
                    dservice.Execute(dm);
                }
                else {
                    Hid_CKID.Value = cm.CKID;
                    Txt_TARGET.Text = cm.CTARGET;
                    Ddl_LEVEL.SelectedValue = cm.CLEVEL;
                    muti_RcvUsers.Text = SysUserService.GetUserNameArray( cm.CHECKER);
                    single_RcvUsers.UserSelectValue = cm.RECIEVER.ToRequestString();
                    Txt_CDATE.Text = cm.CDATE.ToDateYMDFormat();
                    Txt_ENDDATE.Text = cm.ENDDATE.ToDateYMDFormat();
                    //tb_AFVIewNames.DBValue = cm.FVIEWNAMES;
                    tb_AFVIewNames.Text = ToAttachHtml2(cm.FVIEWNAMES);
                    int c = dservice.GetList().Where(p => p.CKID == cm.CKID && p.STATUS == -2).Count();
                    if (c == 0)
                    {
                        HseSectcheckdetlModel dm = new HseSectcheckdetlModel();
                        dm.STATUS = -2;
                        ///dm.SUBMITTER = this.userModel.USERID;
                        dm.CKID = cm.CKID;
                        dm.CKDID = Guid.NewGuid().ToRequestString();
                        dm.DB_Option_Action = WebKeys.InsertAction;
                        dservice.Execute(dm);
                    }
                    
                }
                IList<HseSectcheckdetlModel> lll = dservice.GetList().Where(p => p.CKID == cm.CKID).ToList();
                GridView1.DataSource = lll;
                GridView1.DataBind();
            }
            if (Cmd == "Edit")
            {
                OnBindData();
            }
            else if (Cmd == "Audit1")
            {
                OnBindData();
            }
            else if (Cmd == "Delete")
            {
                var q = service.GetList().FirstOrDefault(p=>p.CKID==ckId);
                if (q != null)
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        service.Execute(q);
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "HseSectList.aspx");
                }
            }
            else if (Cmd == "Delete2")
            {
                var q = dservice.GetList().FirstOrDefault(p => p.CKDID == ckdId);
                Hid_CKID.Value = ckId;
                if (q != null)
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        dservice.Execute(q);
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    //Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "HseSectEdit.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value);
                    Response.Redirect("HseSectEdit.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value, false);
                }
            }
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='HseSectEdit.aspx?Cmd=Delete2&CKDID={0}&CKID={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id,Hid_CKID.Value);
            return btnStrs;
        }
        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            var q = service.GetList().FirstOrDefault(p => p.CKID == ckId);
            Hid_CKID.Value = ckId;
            if (q != null)
            {
                //t_Title.Text = q.TITLE;
                //t_Content.Text = q.CONTENT;
                //single_RcvUsers.UserSelectValue = q.RECEVIEUSER.ToRequestString();
                //lb_User.Text = SysUserService.GetUserName((int)q.CREATEUSER);
                //多附件初始化
                Txt_TARGET.Text = q.CTARGET;
                Ddl_LEVEL.SelectedValue = q.CLEVEL;
                muti_RcvUsers.Text = SysUserService.GetUserNameArray(q.CHECKER);
                single_RcvUsers.UserSelectValue = q.RECIEVER.ToRequestString();
                Txt_CDATE.Text = q.CDATE.ToDateYMDFormat();
                Txt_ENDDATE.Text = q.ENDDATE.ToDateYMDFormat();
                Txt_COMPLETEDATE.Text = q.COMPLETEDATE.ToDateYMDFormat();
                //tb_AFVIewNames.DBValue = q.FVIEWNAMES;
                tb_AFVIewNames.Text = ToAttachHtml2(q.FVIEWNAMES);
                Txt_SH1CONTENT.Text = q.SH1CONTENT;
                User_SHR1.UserSelectValue = q.SHR1.ToRequestString();
                User_SHR2.UserSelectValue = q.SHR2.ToRequestString();
                //int c = dservice.GetList().Where(p => p.CKID == Hid_CKID.Value && p.STATUS == -2).Count();
                //if (c == 0) {
                //    HseSectcheckdetlModel dm = new HseSectcheckdetlModel();
                //    dm.STATUS = -2;
                //    ///dm.SUBMITTER = this.userModel.USERID;
                //    dm.CKID = Hid_CKID.Value;
                //    dm.CKDID = Guid.NewGuid().ToRequestString();
                //    dm.DB_Option_Action = WebKeys.InsertAction;
                //    dservice.Execute(dm);
                //}
                var lll = dservice.GetList().Where(p => p.CKID == Hid_CKID.Value&&p.STATUS>-2).OrderByDescending(o=>o.STATUS).ToList();
                GridView1.DataSource = lll;
                GridView1.DataBind();
                //lb_Dept.Text = SysDepartmentService.GetDepartMentName((int)q.CREATEDEPT);

                //end
            }
        }
        public  string ToAttachHtml2(object article)
        {
            string dbFilesString = article.ToRequestString();
            string html = "<table>";
            if (!string.IsNullOrEmpty(dbFilesString))
            {
                string[] str = dbFilesString.Split('|');
                for (int i = 0; i < str.Length; i++)
                {
                    string[] tmp = str[i].Split('*');
                    string ext = System.IO.Path.GetExtension(Utility.GetFileExt(tmp.Last()));
                    html += string.Format("<tr><td><a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-" + ext.Replace(".", "") + "',plain:true\" href=\"/Modules/Common/EntDisk/Content/Ashx/FileDownload.ashx?url={0}\" target='_blank'>{2}</a></td></tr>",
                        tmp.Last(),
                        FileHelper.Encrypt(tmp.Last()),
                        tmp.First());
                }
            }
            html += "</table>";
            return html;
        }
        private string sendMessageToAudit(HseSectcheckModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                model.CKID,//和项目关联的消息
                model.SHR2.Value,//接收人
                this.userModel,//当前用户
                string.Format("{0}-安全隐患整改审核，需要您进行查收!", model.CLEVEL),//消息标题
                string.Format("/Modules/App/Hse/HseSectAudit2.aspx?Cmd=Audit2&CKID={0}", model.CKID),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
        }

        private string sendMessageToAuditBack(HseSectcheckModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                model.CKID,//和项目关联的消息
                model.SHR1.Value,//接收人
                this.userModel,//当前用户
                string.Format("{0}-安全隐患整改审核不通过，需要您进行查收!", model.CLEVEL),//消息标题
                string.Format("/Modules/App/Hse/HseSectAudit.aspx?Cmd=Recv&CKID={0}", model.CKID),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HseSectcheckdetlModel model = e.Row.DataItem as HseSectcheckdetlModel;
                TextBox present = (TextBox)e.Row.Cells[5].FindControl("Txt_PRESENT");
                TextBox completedate = (TextBox)e.Row.Cells[6].FindControl("Txt_COMPLETEDATE");
                Image m = (Image)e.Row.Cells[6].FindControl("Img_Key1");
                //Label btn = (Label)e.Row.Cells[6].FindControl("Lb_Btn");
                //System.Web.UI.HtmlControls.HtmlInputHidden hid = (System.Web.UI.HtmlControls.HtmlInputHidden)e.Row.Cells[6].FindControl("Hid_Key1");
                present.Text = model.PRESENT;
                completedate.Text = model.COMPLETEDATE.ToDateYMDFormat();
                m.ImageUrl = model.FNAMES;
                //hid.Attributes.Add("ckdid", model.CKDID);
                //hid.Value = model.FNAMES;

                //m.Attributes.Add("ckdid",model.CKDID);
                //btn.Text = "<a id='" + model.CKDID + "'></a><script>$(function () {doRender('"+model.CKDID+"')});</script>";
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                HseSectcheckModel entity = service.GetList().FirstOrDefault(p => p.CKID == Hid_CKID.Value);
                if (entity == null)
                {
                    //entity.DB_Option_Action = WebKeys.InsertAction;
                    //Hid_CKID.Value = entity.CKID = Guid.NewGuid().ToRequestString();
                    return;

                }
                else
                {
                    if (entity.STATUS > 1) {
                        Utility.ShowMsg(this.Page, "OK", this.Trans("已提交安全整改审核！无法保存！"), "/TodoIndexBox.aspx");
                        return;
                    }

                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                //entity.STATUS = -1;
                //entity.SHR1 = User_SHR1.UserSelectValue.ToInt();
                entity.SHR2 = User_SHR2.UserSelectValue.ToInt();
                entity.SH1CONTENT = Txt_SH1CONTENT.Text;
                //entity.SUBMITTER = this.userModel.USERID;
                //entity.SUBMITDATE = DateTime.Now;
                //entity.CTARGET = Txt_TARGET.Text;
                //entity.CLEVEL = Ddl_LEVEL.SelectedValue;
                //entity.CHECKER = muti_RcvUsers.Value;
                //entity.RECIEVER = single_RcvUsers.UserSelectValue.ToInt();
                //entity.CDATE = Txt_CDATE.Text.ToDateTime();
                //entity.ENDDATE = Txt_ENDDATE.Text.ToDateTime();
                //entity.FNAMES = tb_AFVIewNames.Text;
                //entity.FVIEWNAMES = tb_AFVIewNames.DBValue;


                if (service.Execute(entity))
                {
                    //BfMsgService bs = new BfMsgService();
                    //var l = bs.GetUnhandleList().Where(p=>p.BF_INSTANCEID==entity.DOCID);
                    //foreach (var q in l)
                    //{
                    //    q.DB_Option_Action = WebKeys.DeleteAction;
                    //    bs.ExecuteUnhandle(q);
                    //}
                    //sendMessageToRecv(entity);
                }


               
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Response.Redirect("HseSectAudit.aspx?Cmd=Audit1&CKID=" + Hid_CKID.Value, false);
        }
        

        protected void BtnAuditPass_OnClick(object sender, EventArgs e)
        {
            string _note = "提交成功";
            try
            {
                HseSectcheckModel entity = service.GetList().FirstOrDefault(p => p.CKID == Hid_CKID.Value);
                if (entity == null)
                {
                    //entity.DB_Option_Action = WebKeys.InsertAction;
                    //Hid_CKID.Value = entity.CKID = Guid.NewGuid().ToRequestString();

                    return;
                }
                else
                {
                    if (entity.STATUS > 1)
                    {
                        Utility.ShowMsg(this.Page, "OK", this.Trans("已提交安全整改审核!无法提交"), "/TodoIndexBox.aspx");
                        return;
                    }
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                entity.STATUS = 2;
                entity.SH1TIME = DateTime.Now;
                entity.SH1CONTENT = Txt_SH1CONTENT.Text;
                entity.SHR2 = User_SHR2.UserSelectValue.ToInt();
                entity.SH2SUBMITIME = DateTime.Now;
                entity.SH2STATUS = 0;
                entity.SH1STATUS = 1;
                //entity.CTARGET = Txt_TARGET.Text;
                //entity.CLEVEL = Ddl_LEVEL.SelectedValue;
                ////entity.CHECKER = muti_RcvUsers.Value;
                //entity.RECIEVER = single_RcvUsers.UserSelectValue.ToInt();
                //entity.CDATE = Txt_CDATE.Text.ToDateTime();
                //entity.ENDDATE = Txt_ENDDATE.Text.ToDateTime();
                //entity.FNAMES = tb_AFVIewNames.Text;
                //entity.FVIEWNAMES = tb_AFVIewNames.DBValue;


                if (service.Execute(entity))
                {
                    BfMsgService bs = new BfMsgService();
                    var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == entity.CKID);
                    foreach (var q in l)
                    {
                        q.DB_Option_Action = WebKeys.DeleteAction;
                        bs.ExecuteUnhandle(q);
                    }
                    sendMessageToAudit(entity);
                }


            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            //Response.Redirect("HseSectEdit.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value, false);
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "/TodoIndexBox.aspx");
        }

        protected void BtnAuditBack_OnClick(object sender, EventArgs e)
        {
            string _note = "提交成功";
            try
            {
                HseSectcheckModel entity = service.GetList().FirstOrDefault(p => p.CKID == Hid_CKID.Value);
                if (entity == null)
                {
                    //entity.DB_Option_Action = WebKeys.InsertAction;
                    //Hid_CKID.Value = entity.CKID = Guid.NewGuid().ToRequestString();

                    return;
                }
                else
                {
                    if (entity.STATUS > 1)
                    {
                        Utility.ShowMsg(this.Page, "OK", this.Trans("已提交安全整改审核!无法提交"), "/TodoIndexBox.aspx");
                        return;
                    }
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                entity.STATUS = -3;
                entity.SH1TIME = DateTime.Now;
                entity.SH1CONTENT = Txt_SH1CONTENT.Text;
                entity.SHR2 = User_SHR2.UserSelectValue.ToInt();
                //entity.SH2SUBMITIME = DateTime.Now;
                //entity.SH2STATUS = 0;
                entity.SH1STATUS = 2;
                //entity.CTARGET = Txt_TARGET.Text;
                //entity.CLEVEL = Ddl_LEVEL.SelectedValue;
                ////entity.CHECKER = muti_RcvUsers.Value;
                //entity.RECIEVER = single_RcvUsers.UserSelectValue.ToInt();
                //entity.CDATE = Txt_CDATE.Text.ToDateTime();
                //entity.ENDDATE = Txt_ENDDATE.Text.ToDateTime();
                //entity.FNAMES = tb_AFVIewNames.Text;
                //entity.FVIEWNAMES = tb_AFVIewNames.DBValue;


                if (service.Execute(entity))
                {
                    BfMsgService bs = new BfMsgService();
                    var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == entity.CKID);
                    foreach (var q in l)
                    {
                        q.DB_Option_Action = WebKeys.DeleteAction;
                        bs.ExecuteUnhandle(q);
                    }
                    //sendMessageToAudit(entity);
                }


            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            //Response.Redirect("HseSectEdit.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value, false);
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "/TodoIndexBox.aspx");
        }
    }
}