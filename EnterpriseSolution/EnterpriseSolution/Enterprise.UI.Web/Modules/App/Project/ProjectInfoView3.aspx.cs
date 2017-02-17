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
using Enterprise.Model.Basis.Sys;
namespace Enterprise.UI.Web.Modules.App.Project
{
    public partial class ProjectInfoView3 : Enterprise.Service.Basis.BasePage
    {
        public string ckId = (string)Utility.sink("PROJID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string ckdId = (string)Utility.sink("FID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string lb = (string)Utility.sink("Lb", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        private ProjectInfoService service = new ProjectInfoService();
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

            CreateBT.AddButton("back.gif", Trans("返回"), "TbglBzjList.aspx", Utility.PopedomType.List, HeadMenu1);
            //SysUserService suer = new SysUserService();
            //SysDutyService sd = new SysDutyService();
            //SysDutyModel dm = sd.GetList().Where(p => p.DNAME == "招投标管理办公室").FirstOrDefault();
            //SysUserDutyService Service = new SysUserDutyService();
            //IList<SysUserDutyModel> dutylist = null;
            //if (dm != null) dutylist = Service.GetList().Where(p => p.DUTYID == dm.DUTYID&&p.USERID==this.userModel.USERID).ToList();
            //if (dutylist == null || dutylist.Count == 0)
            //{
            //    UL_BZ.Visible = false;
            //}
            //else {
            //    UL_BZ.Visible = true;
            //}
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            int deptId = 0;
            if (Cmd == "New") {
                ProjectInfoModel cm = service.GetList().FirstOrDefault(p => p.SUBMITTER==this.userModel.USERID&&p.STATUS==-2);
                if (cm == null)
                {
                    cm = new ProjectInfoModel();
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
                    //Txt_PROJCONTENT.Text = cm.PROJCONTENT.ToRequestString();
                    Lb_PROJCONTENT.Text = cm.PROJCONTENT.ToRequestString();
                    //Txt_BZ.Text = cm.BZ;
                    Txt_PHONE.Text = cm.PHONE;
                    Txt_NKBSJ.Text = cm.NKBSJSTR.ToRequestString();
                    Txt_NKBDD.Text = cm.NKBDD;
                    Ddl_KIND.SelectedValue = cm.KINDID.ToRequestString();
                    Rad_ZBFS.SelectedValue = cm.ZBFS.ToRequestString();
                    Ddl_ZJLY.SelectedValue = cm.ZJLY;
                    Txt_SCFJ.DBValue = cm.FVIEWNAMES.ToRequestString();
                    Txt_SCFJ.Text =cm.FNAMES.ToRequestString();
                    //Lb_SUBMITTER.Text = SysUserService.GetUserName(cm.SUBMITTER.Value);
                    //Lb_SHR.Text = SysUserService.GetUserName(cm.SHR.Value);
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
                    Response.Redirect("ProjectInfoView3.aspx?Cmd=Edit&PROJID=" + Hid_CKID.Value, false);
                }
            }
            else if (Cmd == "Audit") {
                OnBindData();
            }
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ProjectInfoView3.aspx?Cmd=Delete2&FID={0}&PROJID={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id,Hid_CKID.Value);
            return btnStrs;
        }
        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            //UC_Shenhe_Show.ShowAuditInfos(ckId);
            var q = service.GetList().FirstOrDefault(p => p.PROJID == ckId);
            Hid_CKID.Value = ckId;
            if (q != null)
            {

                Txt_PROJNAME.Text = q.PROJNAME;
                Txt_PROJINCOME.Text = q.PROJINCOME.ToRequestString();
                //Txt_PROJCONTENT.Text = q.PROJCONTENT.ToRequestString();
                Lb_PROJCONTENT.Text = q.PROJCONTENT.ToRequestString();
                //Txt_BZ.Text = q.BZ;
                Txt_PHONE.Text = q.PHONE;
                Txt_NKBSJ.Text = q.NKBSJSTR.ToRequestString();
                Txt_NKBDD.Text = q.NKBDD;
                Ddl_KIND.SelectedValue = q.KINDID.ToRequestString();
                Rad_ZBFS.SelectedValue = q.ZBFS.ToRequestString();
                Ddl_ZJLY.SelectedValue = q.ZJLY;
                Txt_SCFJ.DBValue = q.FVIEWNAMES.ToRequestString();
                Txt_SCFJ.Text = q.FNAMES.ToRequestString();
                H_Fj.Attributes.Add("onclick", "openwin('openwin','/Modules/App/Project/ZbglFjxx.aspx?fjstr=" + q.FVIEWNAMES + "','400','300')");
                //Lb_SUBMITTER.Text = SysUserService.GetUserName(q.SUBMITTER.Value);
                //single_RcvUsers.UserSelectValue = q.SHR.ToRequestString();
                Lb_SUBMIT.Text = SysUserService.GetUserName(q.SUBMITTER.Value)+"/"+q.SUBMITDATE.ToDateTime();
                
                //var lll = dservice.GetList().Where(p => p.PROJID == Hid_CKID.Value&&p.STATUS!=-2).OrderByDescending(o => o.STATUS).ToList();
                string sql = "select a.fid,a.projid,b.crmname crminfo,a.bz,a.status ,a.* from APP_PROJECT_FWS a,APP_CRM_INFO b where a.CRMINFO=b.INFOID and a.projid='" + ckId + "' and a.status<>-2";
                var lll = dservice.GetListBySQL(sql).ToList();
                GridView1.DataSource = lll;
                GridView1.DataBind();
                //lb_Dept.Text = SysDepartmentService.GetDepartMentName((int)q.CREATEDEPT);

                //end
            }
        }
        private string sendMessageToRecv(ProjectInfoModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                model.PROJID,//和项目关联的消息
                model.SHR.Value,//接收人
                this.userModel,//当前用户
                string.Format("{0}-招标申请，需要您进行审核!", model.PROJNAME),//消息标题
                string.Format("/Modules/App/Project/ProjectInfoView3.aspx?Cmd=Audit&PROJID={0}", model.PROJID),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ProjectFwsModel model = e.Row.DataItem as ProjectFwsModel;
                DropDownList dfws = (DropDownList)e.Row.Cells[3].FindControl("Ddl_BZJ");
                dfws.SelectedValue = model.BZJ.ToRequestString();
            }
        }
        protected void BtnNew_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                ProjectInfoModel entity = service.GetList().FirstOrDefault(p => p.PROJID == Hid_CKID.Value);
                if (entity == null)
                {
                    entity.DB_Option_Action = WebKeys.InsertAction;
                    Hid_CKID.Value = entity.PROJID = Guid.NewGuid().ToRequestString();


                }
                else
                {
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                entity.STATUS = -1;
                entity.SUBMITTER = this.userModel.USERID;
                entity.SUBMITDATE = DateTime.Now;
                entity.PROJNAME = Txt_PROJNAME.Text;
                entity.PROJINCOME = Txt_PROJINCOME.Text.ToDecimal();
                //entity.PROJCONTENT = Txt_PROJCONTENT.Text;
                entity.PHONE = Txt_PHONE.Text;
                entity.NKBSJSTR = Txt_NKBSJ.Text;
                entity.NKBDD = Txt_NKBDD.Text;
                entity.KINDID = Ddl_KIND.SelectedValue.ToInt();
                entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY = Ddl_ZJLY.SelectedValue;
                //entity.SHR = single_RcvUsers.UserSelectValue.ToInt();
                entity.DEPTID = this.userModel.DEPTID;
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
                    md.STATUS = -1;
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
            Response.Redirect("ProjectInfoView3.aspx?Cmd=Edit&PROJID=" + Hid_CKID.Value, false);
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
                ProjectInfoModel entity = service.GetList().FirstOrDefault(p => p.PROJID == Hid_CKID.Value);
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
                //entity.PROJCONTENT=Txt_PROJCONTENT.Text;
                entity.PHONE=Txt_PHONE.Text;
                entity.NKBSJSTR=Txt_NKBSJ.Text;
                entity.NKBDD=Txt_NKBDD.Text;
                entity.KINDID=Ddl_KIND.SelectedValue.ToInt();
                entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY=Ddl_ZJLY.SelectedValue;
                //entity.SHR=single_RcvUsers.UserSelectValue.ToInt();
                entity.DEPTID = this.userModel.DEPTID;
                entity.KINDNAME = Ddl_KIND.Text;
                entity.SHR = this.userModel.USERID;
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
                    //checkModel.CHECKOPINION = Txt_SHYJ.Text;

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
                    md.STATUS = -1;
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

            }
            Utility.ShowMsg(this.Page, "系统提示", "审核操作完成!", "/TodoIndexBox.aspx");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (SysUserPermissionService.CheckPageCode(this.userModel.USERID, 1, "0501", (int)Utility.PopedomType.New) || this.userModel.UADMIN == 1)
            {
                var Model = service.GetList().FirstOrDefault(p => p.PROJID == ckId);
                if (Model == null)
                {
                    Model = new ProjectInfoModel();
                    Model.DB_Option_Action = WebKeys.InsertAction;
                    Model.PROJID = ckId;
                }
                else
                {
                    Model.DB_Option_Action = WebKeys.UpdateAction;
                }
                Model.FNAMES = Txt_SCFJ.Text;
                Model.FVIEWNAMES = Txt_SCFJ.DBValue;
                //if (UL_BZ.Visible == true)
                //    Model.BZ = Txt_BZ.Text;
                bool isOk = service.Execute(Model);

                if (isOk)
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        DropDownList dfws = (DropDownList)row.Cells[3].FindControl("Ddl_BZJ");
                        string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                        var md = dservice.GetList().FirstOrDefault(p => p.FID == str_Id);
                        md.BZJ = dfws.SelectedIndex.ToInt();
                        md.DB_Option_Action = WebKeys.UpdateAction;
                        dservice.Execute(md);
                    }
                }
                Utility.ShowMsgThenReloadTree(this.Page, "系统提示", ((isOk) ? "操作成功!" : "操作失败!!!"), "ProjectInfoView3.aspx?PROJID=" + ckId + "&Lb=" + lb + "&Cmd=Edit");

            }
            else {
                Utility.ShowMsgThenReloadTree(this.Page, "系统提示", "没有权限！", "ProjectInfoView3.aspx?PROJID=" + ckId + "&Lb=" + lb + "&Cmd=Edit");
            }
            
        }
        protected void BtnOk_OnClick(object sender, EventArgs e)
        {
            try
            {
                ProjectInfoModel entity = service.GetList().FirstOrDefault(p => p.PROJID == Hid_CKID.Value);

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
                entity.SUBMITTER = this.userModel.USERID;
                entity.SUBMITDATE = DateTime.Now;
                entity.PROJNAME = Txt_PROJNAME.Text;
                entity.PROJINCOME = Txt_PROJINCOME.Text.ToDecimal();
                //entity.PROJCONTENT = Txt_PROJCONTENT.Text;
                entity.PHONE = Txt_PHONE.Text;
                entity.NKBSJSTR = Txt_NKBSJ.Text;
                entity.NKBDD = Txt_NKBDD.Text;
                entity.KINDID = Ddl_KIND.SelectedValue.ToInt();
                entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY = Ddl_ZJLY.SelectedValue;
                //entity.SHR = single_RcvUsers.UserSelectValue.ToInt();
                entity.DEPTID = this.userModel.DEPTID;
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
                    //checkModel.CHECKOPINION = Txt_SHYJ.Text;

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
                    md.STATUS = 0;
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
    }
}