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
    public partial class ProjectRegister2 : Enterprise.Service.Basis.BasePage
    {
        public string ckId = (string)Utility.sink("PROJID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string ckdId = (string)Utility.sink("FID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        private ProjectInfoService service = new ProjectInfoService();
        private ProjectFwsService dservice = new ProjectFwsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IList<SysUserModel> list = new List<SysUserModel>();
                SysUserService suer = new SysUserService();
                //SysDutyService sd = new SysDutyService();
                //SysDutyModel dm = sd.GetList().Where(p => p.DNAME == "招标申请审核").FirstOrDefault();
                //SysUserDutyService Service = new SysUserDutyService();
                //IList<SysUserDutyModel> dutylist = null;
                //if (dm != null) dutylist = Service.GetList().Where(p => p.DUTYID == dm.DUTYID).ToList();
                //foreach (var item in dutylist)
                //{
                //    list.Add(suer.GetList().Where(p => p.USERID == item.USERID).FirstOrDefault());

                //}
                list = suer.GetList().Where(w=>w.DEPTID==this.userModel.DEPTID&&w.ULOGINPASS=="1").ToList();
                Txt_SHR.DataSource = list;
                Txt_SHR.DataTextField = "UNAME";
                Txt_SHR.DataValueField = "USERID";
                Txt_SHR.DataBind();
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
            if(Cmd=="Edit")CreateBT.AddButton("back.gif", Trans("返回"), "ProjectInfoList2.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            
            if (Cmd == "New") {
                ProjectInfoModel cm = service.GetList().FirstOrDefault(p => p.SUBMITTER==this.userModel.USERID&&p.STATUS==-2);
                if (cm == null)
                {
                    cm = new ProjectInfoModel();
                    Hid_CKID.Value=cm.PROJID = Guid.NewGuid().ToRequestString();
                    cm.STATUS = -2;
                    cm.SUBMITTER = this.userModel.USERID;
                    cm.DEPTID = this.userModel.DEPTID;
                    cm.NKBDD = "";
                    cm.NKBSJSTR = "招标申请批复后二十一日";
                    cm.DB_Option_Action = WebKeys.InsertAction;
                    service.Execute(cm);
                    ProjectFwsModel dm = new ProjectFwsModel();
                    dm.STATUS = -2;
                    ///dm.SUBMITTER = this.userModel.USERID;
                    dm.PROJID = cm.PROJID;
                    dm.FID = Guid.NewGuid().ToRequestString();
                    dm.DB_Option_Action = WebKeys.InsertAction;
                    dservice.Execute(dm);
                    Lb_SUBMITTER.Text = SysUserService.GetUserName(cm.SUBMITTER.Value);
                    Txt_NKBDD.Text = cm.NKBDD;
                    Txt_NKBSJSTR.Text = cm.NKBSJSTR;
                }
                else {
                    Hid_CKID.Value = cm.PROJID;
                    Txt_PROJNAME.Text = cm.PROJNAME;
                    Txt_PROJINCOME.Text = cm.PROJINCOME.ToRequestString();
                    Txt_PROJCONTENT.Text = cm.PROJCONTENT.ToRequestString();
                    Txt_SQLY.Text = cm.SQLY;
                    Txt_PHONE.Text = cm.PHONE;
                    Txt_NKBSJSTR.Text = cm.NKBSJSTR;
                    Txt_NKBDD.Text = cm.NKBDD;
                    Ddl_KIND.SelectedValue = cm.KINDID.ToRequestString();
                    Rad_ZBFS.SelectedValue = cm.ZBFS.ToRequestString();
                    Ddl_ZJLY.SelectedValue = cm.ZJLY;
                    Txt_ZJBZ.Text = cm.ZJBZ;
                    Lb_SUBMITTER.Text = SysUserService.GetUserName(cm.SUBMITTER.Value);
                    //single_RcvUsers.UserSelectValue = cm.SHR.ToRequestString();
                    Txt_SHR.SelectedValue = cm.SHR.ToRequestString();
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
                    Response.Redirect("ProjectRegister2.aspx?Cmd=Edit&PROJID=" + Hid_CKID.Value, false);
                }
            }
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ProjectRegister2.aspx?Cmd=Delete2&FID={0}&PROJID={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id,Hid_CKID.Value);
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
                Txt_NKBSJSTR.Text = q.NKBSJSTR;
                Txt_NKBDD.Text = q.NKBDD;
                Txt_PHONE.Text = q.PHONE;
                Ddl_KIND.SelectedValue = q.KINDID.ToRequestString();
                Rad_ZBFS.SelectedValue = q.ZBFS.ToRequestString();
                Ddl_ZJLY.SelectedValue = q.ZJLY;
                Txt_ZJBZ.Text = q.ZJBZ;
                Lb_SUBMITTER.Text = SysUserService.GetUserName(q.SUBMITTER.Value);
                //single_RcvUsers.UserSelectValue = q.SHR.ToRequestString();
                Txt_SHR.SelectedValue = q.SHR.ToRequestString();
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
        private string sendMessageToRecv(ProjectInfoModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            //bfCtrl.SendNotificationMessage(
            //    model.PROJID,//和项目关联的消息
            //    model.SHR.Value,//接收人
            //    this.userModel,//当前用户
            //    string.Format("{0}-立项申请，需要您进行审核!", model.PROJNAME),//消息标题
            //    string.Format("/Modules/App/Project/ProjectAudit1.aspx?Cmd=Audit1&PROJID={0}", model.PROJID),//消息内容
            //    BFRemindWay.MSG.ToString(), false);
            bfCtrl.SendNotificationMessage(
                model.PROJID,//和项目关联的消息
                model.RTN.Value,
                this.userModel,//当前用户
                string.Format("{0}-立项申请，需要您进行审核!", model.PROJNAME),//消息标题
                string.Format("/Modules/App/Project/Project"+model.RTNSTATUS+".aspx?Cmd="+model.RTNSTATUS+"&PROJID={0}", model.PROJID),//消息内容
                BFRemindWay.MSG.ToString(), false);
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
                entity.PROJNAME=Txt_PROJNAME.Text;
                entity.PROJINCOME=Txt_PROJINCOME.Text.ToDecimal();
                entity.PROJCONTENT=Txt_PROJCONTENT.Text;
                entity.SQLY = Txt_SQLY.Text;
                //entity.PHONE=Txt_PHONE.Text;
                //entity.NKBSJ=Txt_NKBSJ.Text.ToDateTime();
                //entity.NKBDD=Txt_NKBDD.Text;

                entity.PHONE=Txt_PHONE.Text;
                entity.NKBSJSTR=Txt_NKBSJSTR.Text;
                entity.NKBDD=Txt_NKBDD.Text;
                entity.KINDID=Ddl_KIND.SelectedValue.ToInt();
                entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY=Ddl_ZJLY.SelectedValue;
                entity.ZJBZ = Txt_ZJBZ.Text;
                //entity.SHR=single_RcvUsers.UserSelectValue.ToInt();
                entity.SHR = Txt_SHR.SelectedValue.ToInt();
                entity.DEPTID = this.userModel.DEPTID;
                entity.KINDNAME = Ddl_KIND.Text;
                if (service.Execute(entity))
                {
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
                _note = ex.Message;
            }
            Response.Redirect("ProjectRegister2.aspx?Cmd=Edit&PROJID=" + Hid_CKID.Value, false);
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
                entity.PROJCONTENT = Txt_PROJCONTENT.Text;
                entity.SQLY = Txt_SQLY.Text;
                //entity.PHONE = Txt_PHONE.Text;
                //entity.NKBSJ = Txt_NKBSJ.Text.ToDateTime();
                //entity.NKBDD = Txt_NKBDD.Text;
                entity.PHONE = Txt_PHONE.Text;
                entity.NKBSJSTR = Txt_NKBSJSTR.Text;
                entity.NKBDD = Txt_NKBDD.Text;
                entity.KINDID = Ddl_KIND.SelectedValue.ToInt();
                entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY = Ddl_ZJLY.SelectedValue;
                entity.ZJBZ = Txt_ZJBZ.Text;
                //entity.SHR = single_RcvUsers.UserSelectValue.ToInt();
                entity.SHR = Txt_SHR.SelectedValue.ToInt();
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
                    var md = dservice.GetList().FirstOrDefault(p=>p.FID==str_Id);
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
            Response.Redirect("ProjectRegister2.aspx?Cmd=Edit&PROJID=" + Hid_CKID.Value,false);
            //Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ProjectInfoList.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value);
        }

        protected void BtnRecv_OnClick(object sender, EventArgs e)
        {
            string _note = "提交成功";
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
                if (entity.STATUS == 0 || entity.STATUS == 1)
                    return;
                entity.STATUS = 0;
                entity.SUBMITTER = this.userModel.USERID;
                entity.SUBMITDATE = DateTime.Now;
                entity.PROJNAME = Txt_PROJNAME.Text;
                entity.PROJINCOME = Txt_PROJINCOME.Text.ToDecimal();
                entity.PROJCONTENT = Txt_PROJCONTENT.Text;
                entity.SQLY = Txt_SQLY.Text;
                //entity.PHONE = Txt_PHONE.Text;
                //entity.NKBSJ = Txt_NKBSJ.Text.ToDateTime();
                //entity.NKBDD = Txt_NKBDD.Text;

                entity.PHONE = Txt_PHONE.Text;
                entity.NKBSJSTR = Txt_NKBSJSTR.Text;
                entity.NKBDD = Txt_NKBDD.Text;

                entity.KINDID = Ddl_KIND.SelectedValue.ToInt();
                entity.ZBFS = Rad_ZBFS.SelectedValue.ToInt();
                entity.ZJLY = Ddl_ZJLY.SelectedValue;
                entity.ZJBZ = Txt_ZJBZ.Text;
                //entity.SHR = single_RcvUsers.UserSelectValue.ToInt();
                entity.SHR = Txt_SHR.SelectedValue.ToInt();
                entity.DEPTID = this.userModel.DEPTID;
                entity.KINDNAME = Ddl_KIND.Text;
                if (string.IsNullOrEmpty(entity.RTNSTATUS)) {
                    entity.RTN = entity.SHR;
                    entity.RTNSTATUS = "Audit1";
                }
                if (service.Execute(entity))
                {
                    //BfMsgService bs = new BfMsgService();
                    //var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == entity.PROJID);
                    //foreach (var q in l)
                    //{
                    //    q.DB_Option_Action = WebKeys.DeleteAction;
                    //    bs.ExecuteUnhandle(q);
                    //}
                    BfMsgService bs = new BfMsgService();
                    var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == entity.PROJID);
                    foreach (var q in l)
                    {
                        //q.DB_Option_Action = WebKeys.DeleteAction;
                        //bs.ExecuteUnhandle(q);
                        BfMsgService.UpdateMsgOver(q.BF_MSGID);
                    }
                    sendMessageToRecv(entity);
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
                //int c = dservice.GetList().Where(p => p.CKID == Hid_CKID.Value && p.STATUS == -2).Count();
                //if (c == 0)
                //{
                //    ProjectFwsModel dm = new ProjectFwsModel();
                //    dm.STATUS = -2;
                //    ///dm.SUBMITTER = this.userModel.USERID;
                //    dm.CKID = Hid_CKID.Value;
                //    dm.CKDID = Guid.NewGuid().ToRequestString();
                //    dm.DB_Option_Action = WebKeys.InsertAction;
                //    dservice.Execute(dm);
                //}
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            //Response.Redirect("ProjectInfoList.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value, false);
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ProjectInfoList2.aspx");
        }
    }
}