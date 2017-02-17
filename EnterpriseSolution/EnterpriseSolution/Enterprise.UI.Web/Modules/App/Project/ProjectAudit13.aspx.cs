using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Project;
using Enterprise.Service.App.Project;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
using Microsoft.Office.Interop.Word;

using System.IO;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.UI.Web.Modules.App.Project
{
    public partial class ProjectAudit13 : Enterprise.Service.Basis.BasePage
    {
        public string ckId = (string)Utility.sink("PROJID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string ckdId = (string)Utility.sink("FID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        private ProjectTpinfoService service = new ProjectTpinfoService();
        private ProjectFwsService dservice = new ProjectFwsService();
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
            //CreateBT.AddButton("back.gif", Trans("返回"), "ProjectList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            //IList<SysUserModel> list = new List<SysUserModel>();
            //SysUserService suer = new SysUserService();
            //SysDutyService sd = new SysDutyService();
            //SysDutyModel dmm = sd.GetList().Where(p => p.DNAME == "招标申请审批人").FirstOrDefault();
            //SysUserDutyService Service = new SysUserDutyService();
            //IList<SysUserDutyModel> dutylist = null;
            //if (dmm != null) dutylist = Service.GetList().Where(p => p.DUTYID == dmm.DUTYID).ToList();
            //foreach (var item in dutylist)
            //{
            //    list.Add(suer.GetList().Where(p => p.USERID == item.USERID).FirstOrDefault());

            //}

            //Txt_SPR.DataSource = list;
            //Txt_SPR.DataTextField = "UNAME";
            //Txt_SPR.DataValueField = "USERID";
            //Txt_SPR.DataBind();
            if (Cmd == "New") {
                ProjectTpinfoModel cm = service.GetList().FirstOrDefault(p => p.SUBMITTER==this.userModel.USERID&&p.STATUS==-2);
                if (cm == null)
                {
                    cm = new ProjectTpinfoModel();
                    Hid_CKID.Value=cm.PROJID = Guid.NewGuid().ToRequestString();
                    cm.STATUS = -2;
                    cm.SUBMITTER = this.userModel.USERID;
                    cm.DEPTID = this.userModel.DEPTID;
                    cm.DB_Option_Action = WebKeys.InsertAction;
                    service.Execute(cm);
                    ProjectFwsModel dm = new ProjectFwsModel();
                    dm.STATUS = -2;
                    ///dm.SUBMITTER = this.userModel.USERID;
                    dm.PROJID = cm.PROJID;
                    dm.FID = Guid.NewGuid().ToRequestString();
                    dm.DB_Option_Action = WebKeys.InsertAction;
                    dservice.Execute(dm);
                }
                else {
                    Hid_CKID.Value = cm.PROJID;
                    Txt_PROJNAME.Text = cm.PROJNAME;
                    Txt_PROJINCOME.Text = cm.PROJINCOME.ToRequestString();
                    Txt_PROJCONTENT.Text = cm.PROJCONTENT.ToRequestString();
                    Txt_SQLY.Text = cm.SQLY;
                    //Txt_PHONE.Text = cm.PHONE;
                    //Txt_NKBSJ.Text = cm.NKBSJ.ToRequestString();
                    //Txt_NKBDD.Text = cm.NKBDD;
                    Ddl_KIND.SelectedValue = cm.KINDID.ToRequestString();
                    //Rad_ZBFS.SelectedValue = cm.ZBFS.ToRequestString();
                    Ddl_ZJLY.SelectedValue = cm.ZJLY;
                    //Txt_ZJBZ.Text = cm.ZJBZ;
                    Ddl_ZJBZ.SelectedValue = cm.ZJBZ;
                    //Lb_SUBMITTER.Text = SysUserService.GetUserName(cm.SUBMITTER.Value);
                    //single_RcvUsers.UserSelectValue = cm.SHR.ToRequestString();
                    Lb_SHR.Text = SysUserService.GetUserName(cm.SHR.Value);
                    int c = dservice.GetList().Where(p => p.PROJID == cm.PROJID && p.STATUS == -2).Count();
                    if (c == 0)
                    {
                        ProjectFwsModel dm = new ProjectFwsModel();
                        dm.STATUS = -2;
                        ///dm.SUBMITTER = this.userModel.USERID;
                        dm.PROJID = cm.PROJID;
                        dm.FID = Guid.NewGuid().ToRequestString();
                        dm.DB_Option_Action = WebKeys.InsertAction;
                        dservice.Execute(dm);
                    }
                    
                }
                IList<ProjectFwsModel> lll = dservice.GetList().Where(p => p.PROJID == cm.PROJID).ToList();
                GridView1.DataSource = lll;
                GridView1.DataBind();
            }
            if (Cmd == "Edit")
            {
                OnBindData();
            }
            else if (Cmd == "Delete")
            {
                var q = service.GetList().FirstOrDefault(p => p.PROJID == ckId);
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
                    Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ProjectInfoList.aspx");
                }
            }
            else if (Cmd == "Delete2")
            {
                var q = dservice.GetList().FirstOrDefault(p => p.FID == ckdId);
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
                    //Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ProjectInfoList.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value);
                    Response.Redirect("ProjectAudit13.aspx?Cmd=Edit&PROJID=" + Hid_CKID.Value, false);
                }
            }
            else if (Cmd == "Audit13") {
                OnBindData();
            }
            //else if (Cmd == "Audit2")
            //{
            //    //BtnSave.Visible = false;
            //    //LinkButton1.Visible = false;
            //    //LinkButton5.Visible = false;
            //    //ul_spr.Visible = false;
            //    //LinkButton3.Visible = true;
            //    //LinkButton4.Visible = true;
            //    Pnl_Audit_Show.Visible = true;
            //    //Lb_yj.Text = "审批意见";
            //    UC_Shenhe_Show.ShowAuditInfos(ckId);
            //    OnBindData();
            //}
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ProjectAudit13.aspx?Cmd=Delete2&FID={0}&PROJID={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id,Hid_CKID.Value);
            return btnStrs;
        }
        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            var q = service.GetList().FirstOrDefault(p => p.PROJID == ckId);
            Hid_CKID.Value = ckId;
            if (q != null)
            {

                Txt_PROJNAME.Text = q.PROJNAME;
                Txt_PROJINCOME.Text = q.PROJINCOME.ToRequestString();
                Txt_PROJCONTENT.Text = q.PROJCONTENT.ToRequestString();
                Txt_SQLY.Text = q.SQLY;
                //Txt_PHONE.Text = q.PHONE;
                //Txt_NKBSJ.Text = q.NKBSJ.ToRequestString();
                //Txt_NKBDD.Text = q.NKBDD;
                Ddl_KIND.SelectedValue = q.KINDID.ToRequestString();
                //Rad_ZBFS.SelectedValue = q.ZBFS.ToRequestString();
                Ddl_ZJLY.SelectedValue = q.ZJLY;
                //Txt_ZJBZ.Text = q.ZJBZ;
                Ddl_ZJBZ.SelectedValue = q.ZJBZ;
                //Lb_SUBMITTER.Text = SysUserService.GetUserName(q.SUBMITTER.Value);
                //single_RcvUsers.UserSelectValue = q.SHR.ToRequestString();
                Lb_SHR.Text = SysUserService.GetUserName( q.SHR.Value);
                Lb_SUBMIT.Text = SysUserService.GetUserName(q.SUBMITTER.Value)+"/"+q.SUBMITDATE.ToDateTime();
                int c = dservice.GetList().Where(p => p.PROJID == Hid_CKID.Value && p.STATUS == -2).Count();
                if (c == 0) {
                    ProjectFwsModel dm = new ProjectFwsModel();
                    dm.STATUS = -2;
                    ///dm.SUBMITTER = this.userModel.USERID;
                    dm.PROJID = Hid_CKID.Value;
                    dm.FID = Guid.NewGuid().ToRequestString();
                    dm.DB_Option_Action = WebKeys.InsertAction;
                    dservice.Execute(dm);
                }
                var lll = dservice.GetList().Where(p => p.PROJID == Hid_CKID.Value).OrderByDescending(o => o.STATUS).ToList();
                GridView1.DataSource = lll;
                GridView1.DataBind();
                //lb_Dept.Text = SysDepartmentService.GetDepartMentName((int)q.CREATEDEPT);

                //end
            }
        }
        private string sendMessageToRecv(ProjectTpinfoModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();

            IList<SysUserModel> list = new List<SysUserModel>();
            SysUserService suer = new SysUserService();
            SysDutyService sd = new SysDutyService();
            SysDutyModel dm = sd.GetList().Where(p => p.DNAME == "经营管理部项目初审").FirstOrDefault();
            SysUserDutyService Service = new SysUserDutyService();
            IList<SysUserDutyModel> dutylist = null;
            if (dm != null) dutylist = Service.GetList().Where(p => p.DUTYID == dm.DUTYID).ToList();
            foreach (var item in dutylist)
            {
                //list.Add(suer.GetList().Where(p => p.USERID == item.USERID).FirstOrDefault());

                bfCtrl.SendNotificationMessage(
                    model.PROJID,//和项目关联的消息
                    item.USERID.Value,//接收人
                    this.userModel,//当前用户
                    string.Format("{0}-立项申请，需要经营管理部初审!", model.PROJNAME),//消息标题
                    string.Format("/Modules/App/Project/ProjectAudit23.aspx?Cmd=Audit23&PROJID={0}", model.PROJID),//消息内容
                    BFRemindWay.MSG.ToString(), false);
            }
            return msg;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ProjectFwsModel model = e.Row.DataItem as ProjectFwsModel;
                DropDownList dfws = (DropDownList)e.Row.Cells[1].FindControl("Ddl_WTDW");
                System.Web.UI.HtmlControls.HtmlInputHidden hd = (System.Web.UI.HtmlControls.HtmlInputHidden)e.Row.Cells[1].FindControl("HID_WTDW");
                TextBox tmemo = (TextBox)e.Row.Cells[2].FindControl("T_MEMO");
                dfws.SelectedValue = model.CRMINFO;
                hd.Value = model.CRMINFO;
                tmemo.Text = model.BZ;
                dfws.Attributes.Add("FID",model.FID);
                hd.Attributes.Add("FID",model.FID);
            }
        }
        protected void BtnNew_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                ProjectTpinfoModel entity = service.GetList().FirstOrDefault(p => p.PROJID == Hid_CKID.Value);
                if (entity == null)
                {
                    entity.DB_Option_Action = WebKeys.InsertAction;
                    Hid_CKID.Value = entity.PROJID = Guid.NewGuid().ToRequestString();


                }
                else
                {
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                entity.STATUS = 0;
                //entity.SUBMITTER = this.userModel.USERID;
                //entity.SUBMITDATE = DateTime.Now;
                entity.PROJNAME = Txt_PROJNAME.Text;
                entity.PROJINCOME = Txt_PROJINCOME.Text.ToDecimal();
                entity.PROJCONTENT = Txt_PROJCONTENT.Text;
                entity.SQLY = Txt_SQLY.Text;
                //entity.PHONE = Txt_PHONE.Text;
                //entity.NKBSJ = Txt_NKBSJ.Text.ToDateTime();
                //entity.NKBDD = Txt_NKBDD.Text;
                entity.KINDID = Ddl_KIND.SelectedValue.ToInt();
                //entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY = Ddl_ZJLY.SelectedValue;
                //entity.ZJBZ = Txt_ZJBZ.Text;
                entity.ZJBZ = Ddl_ZJBZ.SelectedValue;
                //entity.SHR = single_RcvUsers.UserSelectValue.ToInt();
                //entity.DEPTID = this.userModel.DEPTID;
                entity.KINDNAME = Ddl_KIND.Text;
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


                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList dfws = (DropDownList)row.Cells[1].FindControl("Ddl_WTDW");
                    System.Web.UI.HtmlControls.HtmlInputHidden hd = (System.Web.UI.HtmlControls.HtmlInputHidden)row.Cells[1].FindControl("HID_WTDW");
                    TextBox tmemo = (TextBox)row.Cells[2].FindControl("T_MEMO");
                    string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    var md = dservice.GetList().FirstOrDefault(p => p.FID == str_Id);
                    md.CRMINFO = hd.Value;
                    md.BZ = tmemo.Text;
                    md.STATUS = 0;
                    if (!string.IsNullOrEmpty(hd.Value))
                    {
                        md.DB_Option_Action = WebKeys.UpdateAction;
                        dservice.Execute(md);
                    }
                }
                int c = dservice.GetList().Where(p => p.PROJID == Hid_CKID.Value && p.STATUS == -2).Count();
                if (c == 0)
                {
                    ProjectFwsModel dm = new ProjectFwsModel();
                    dm.STATUS = -2;
                    ///dm.SUBMITTER = this.userModel.USERID;
                    dm.PROJID = Hid_CKID.Value;
                    dm.FID = Guid.NewGuid().ToRequestString();
                    dm.DB_Option_Action = WebKeys.InsertAction;
                    dservice.Execute(dm);
                }
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Response.Redirect("ProjectAudit13.aspx?Cmd=" + Cmd + "&PROJID=" + Hid_CKID.Value + "&MsgID="+MsgID, false);
            //Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ProjectInfoList.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value);
        }
        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                ProjectTpinfoModel entity = service.GetList().FirstOrDefault(p => p.PROJID == Hid_CKID.Value);
                if (entity == null)
                {
                    entity.DB_Option_Action = WebKeys.InsertAction;
                    Hid_CKID.Value = entity.PROJID = Guid.NewGuid().ToRequestString();


                }
                else
                {
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }

                if (entity.STATUS != 0)
                {

                    Utility.ShowMsg(this.Page, "系统提示", "已审核的信息，无法操作", "/TodoIndexBox.aspx");
                    return;
                }
                entity.STATUS = 2;

                entity.PROJNAME=Txt_PROJNAME.Text;
                entity.PROJINCOME=Txt_PROJINCOME.Text.ToDecimal();
                entity.PROJCONTENT=Txt_PROJCONTENT.Text;
                entity.SQLY = Txt_SQLY.Text;
                //entity.PHONE=Txt_PHONE.Text;
                //entity.NKBSJ=Txt_NKBSJ.Text.ToDateTime();
                //entity.NKBDD=Txt_NKBDD.Text;
                entity.KINDID=Ddl_KIND.SelectedValue.ToInt();
                //entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY=Ddl_ZJLY.SelectedValue;
                //entity.ZJBZ = Txt_ZJBZ.Text;
                entity.ZJBZ = Ddl_ZJBZ.SelectedValue;
                //entity.SHR=single_RcvUsers.UserSelectValue.ToInt();
                //entity.DEPTID = this.userModel.DEPTID;
                entity.KINDNAME = Ddl_KIND.Text;
                entity.SHYJ = Txt_SHYJ.Text;
                entity.RTN = this.userModel.USERID;
                entity.RTNSTATUS = "Audit13";
                //entity.SHR = this.userModel.USERID;
                if (service.Execute(entity))
                {
                    ProjectCheckService checkSrv = new ProjectCheckService();
                    ProjectCheckModel checkModel = new ProjectCheckModel();
                    checkModel.DB_Option_Action = WebKeys.InsertAction;
                    checkModel.CHECKID = CommonTool.GetPkId();
                    checkModel.CHECKER = this.userModel.USERID;
                    checkModel.CHECKORDER = 1;
                    checkModel.CHECKSTATUS = 1;//审核状态 0未审 1已审
                    checkModel.CHECKRESULT = 0; //审核结果 1通过 0未通过
                    checkModel.CHECKOPINION = Txt_SHYJ.Text;

                    checkModel.ASSOCIATEDID = entity.PROJID;
                    checkModel.SENDDATE = DateTime.Now;
                    checkModel.SENDER = entity.SUBMITTER;
                    checkModel.CHECKDATE = DateTime.Now;

                    if (checkSrv.Execute(checkModel))
                    {
                        BfMsgService.UpdateMsgOver(MsgID);
                    }

                }


                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList dfws = (DropDownList)row.Cells[1].FindControl("Ddl_WTDW");
                    System.Web.UI.HtmlControls.HtmlInputHidden hd = (System.Web.UI.HtmlControls.HtmlInputHidden)row.Cells[1].FindControl("HID_WTDW");
                    TextBox tmemo = (TextBox)row.Cells[2].FindControl("T_MEMO");
                    string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    var md = dservice.GetList().FirstOrDefault(p => p.FID == str_Id);
                    md.CRMINFO= hd.Value;
                    md.BZ = tmemo.Text;
                    md.STATUS = 2;
                    if (!string.IsNullOrEmpty(hd.Value))
                    { 
                        md.DB_Option_Action = WebKeys.UpdateAction;
                        dservice.Execute(md);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            Utility.ShowMsg(this.Page, "系统提示", "审核操作完成!", "/TodoIndexBox.aspx");
        }


        protected void BtnOk_OnClick(object sender, EventArgs e)
        {
            try
            {
                ProjectTpinfoModel entity = service.GetList().FirstOrDefault(p => p.PROJID == Hid_CKID.Value);

                if (entity == null)
                {
                    entity.DB_Option_Action = WebKeys.InsertAction;
                    Hid_CKID.Value = entity.PROJID = Guid.NewGuid().ToRequestString();

                }
                else
                {
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                if (entity.STATUS != 0) { 
                    
                    Utility.ShowMsg(this.Page, "系统提示", "已审核的信息，无法操作", "/TodoIndexBox.aspx");
                    return;
                }
                entity.STATUS = 0;
                entity.PROJNAME = Txt_PROJNAME.Text;
                entity.PROJINCOME = Txt_PROJINCOME.Text.ToDecimal();
                entity.PROJCONTENT = Txt_PROJCONTENT.Text;
                entity.SQLY = Txt_SQLY.Text;
                //entity.PHONE = Txt_PHONE.Text;
                //entity.NKBSJ = Txt_NKBSJ.Text.ToDateTime();
                //entity.NKBDD = Txt_NKBDD.Text;
                entity.KINDID = Ddl_KIND.SelectedValue.ToInt();
                //entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY = Ddl_ZJLY.SelectedValue;
                //entity.ZJBZ = Txt_ZJBZ.Text;
                entity.ZJBZ = Ddl_ZJBZ.SelectedValue;
                entity.SHYJ = Txt_SHYJ.Text;
                entity.SHR = this.userModel.USERID;
                //entity.SHR = single_RcvUsers.UserSelectValue.ToInt();
                //entity.DEPTID = this.userModel.DEPTID;
                entity.KINDNAME = Ddl_KIND.Text;
                if (service.Execute(entity))
                {
                    ProjectCheckService checkSrv = new ProjectCheckService();
                    ProjectCheckModel checkModel = new ProjectCheckModel();
                    checkModel.DB_Option_Action = WebKeys.InsertAction;
                    checkModel.CHECKID = CommonTool.GetPkId();
                    checkModel.CHECKER = this.userModel.USERID;
                    checkModel.CHECKORDER = 1;
                    checkModel.CHECKSTATUS = 1;//审核状态 0未审 1已审
                    checkModel.CHECKRESULT = 1; //审核结果 1通过 0未通过
                    checkModel.CHECKOPINION = Txt_SHYJ.Text;

                    checkModel.ASSOCIATEDID = entity.PROJID;
                    checkModel.SENDDATE = DateTime.Now;
                    checkModel.SENDER = entity.SUBMITTER;
                    checkModel.CHECKDATE = DateTime.Now;
                    if (checkSrv.Execute(checkModel))
                    {
                        BfMsgService.UpdateMsgOver(MsgID);
                        
                    }
                               
                }


                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList dfws = (DropDownList)row.Cells[1].FindControl("Ddl_WTDW");
                    TextBox tmemo = (TextBox)row.Cells[2].FindControl("T_MEMO");
                    System.Web.UI.HtmlControls.HtmlInputHidden hd = (System.Web.UI.HtmlControls.HtmlInputHidden)row.Cells[1].FindControl("HID_WTDW");
                    string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    var md = dservice.GetList().FirstOrDefault(p => p.FID == str_Id);
                    md.CRMINFO = hd.Value;
                    md.BZ = tmemo.Text;
                    md.STATUS = 1;
                    if (!string.IsNullOrEmpty(hd.Value))
                    {
                        md.DB_Option_Action = WebKeys.UpdateAction;
                        dservice.Execute(md);
                    }
                }
                //ZbwjService.CreateZbsq(Hid_CKID.Value);

            }
            catch (Exception ex)
            {

            }

            Utility.ShowMsg(this.Page, "系统提示", "审核操作完成!", "/TodoIndexBox.aspx");
        }

        protected void BtnOk_OnClick2(object sender, EventArgs e)
        {
            try
            {
                ProjectTpinfoModel entity = service.GetList().FirstOrDefault(p => p.PROJID == Hid_CKID.Value);

                if (entity == null)
                {
                    entity.DB_Option_Action = WebKeys.InsertAction;
                    Hid_CKID.Value = entity.PROJID = Guid.NewGuid().ToRequestString();

                }
                else
                {
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                if (entity.STATUS != 0)
                {

                    Utility.ShowMsg(this.Page, "系统提示", "已审批的信息，无法操作", "/TodoIndexBox.aspx");
                    return;
                }
                //entity.STATUS = 1;
                entity.PROJNAME = Txt_PROJNAME.Text;
                entity.PROJINCOME = Txt_PROJINCOME.Text.ToDecimal();
                entity.PROJCONTENT = Txt_PROJCONTENT.Text;
                entity.SQLY = Txt_SQLY.Text;
                //entity.PHONE = Txt_PHONE.Text;
                //entity.NKBSJ = Txt_NKBSJ.Text.ToDateTime();
                //entity.NKBDD = Txt_NKBDD.Text;
                entity.KINDID = Ddl_KIND.SelectedValue.ToInt();
                //entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY = Ddl_ZJLY.SelectedValue;
                //entity.ZJBZ = Txt_ZJBZ.Text;
                entity.ZJBZ = Ddl_ZJBZ.SelectedValue;
                //entity.SHR = single_RcvUsers.UserSelectValue.ToInt();
                //entity.DEPTID = this.userModel.DEPTID;
                entity.KINDNAME = Ddl_KIND.Text;
                entity.SHR = this.userModel.USERID;
                entity.SHYJ = Txt_SHYJ.Text;
                if (service.Execute(entity))
                {
                    ProjectCheckService checkSrv = new ProjectCheckService();
                    ProjectCheckModel checkModel = new ProjectCheckModel();
                    checkModel.DB_Option_Action = WebKeys.InsertAction;
                    checkModel.CHECKID = CommonTool.GetPkId();
                    checkModel.CHECKER = this.userModel.USERID;
                    checkModel.CHECKORDER = 1;
                    checkModel.CHECKSTATUS = 1;//审核状态 0未审 1已审
                    checkModel.CHECKRESULT = 1; //审核结果 1通过 0未通过
                    checkModel.CHECKOPINION = Txt_SHYJ.Text;

                    checkModel.ASSOCIATEDID = entity.PROJID;
                    checkModel.SENDDATE = DateTime.Now;
                    checkModel.SENDER = entity.SUBMITTER;
                    checkModel.CHECKDATE = DateTime.Now;
                    if (checkSrv.Execute(checkModel))
                    {
                        BfMsgService.UpdateMsgOver(MsgID);
                        sendMessageToRecv(entity);
                    }

                }


                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList dfws = (DropDownList)row.Cells[1].FindControl("Ddl_WTDW");
                    TextBox tmemo = (TextBox)row.Cells[2].FindControl("T_MEMO");
                    System.Web.UI.HtmlControls.HtmlInputHidden hd = (System.Web.UI.HtmlControls.HtmlInputHidden)row.Cells[1].FindControl("HID_WTDW");
                    string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    var md = dservice.GetList().FirstOrDefault(p => p.FID == str_Id);
                    md.CRMINFO = hd.Value;
                    md.BZ = tmemo.Text;
                    md.STATUS = 1;
                    if (!string.IsNullOrEmpty(hd.Value))
                    {
                        md.DB_Option_Action = WebKeys.UpdateAction;
                        dservice.Execute(md);
                    }
                }
                //ZbwjService.CreateZbsq(Hid_CKID.Value);

            }
            catch (Exception ex)
            {

            }

            Utility.ShowMsg(this.Page, "系统提示", "审批操作完成!", "/TodoIndexBox.aspx");
        }
    }



}