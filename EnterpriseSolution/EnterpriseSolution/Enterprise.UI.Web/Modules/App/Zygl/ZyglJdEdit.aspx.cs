using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Zygl;
using Enterprise.Service.App.Zygl;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
using Enterprise.Component.ORM;
namespace Enterprise.UI.Web.Modules.App.Zygl
{
    public partial class ZyglJdEdit : Enterprise.Service.Basis.BasePage
    {
        public string zId = (string)Utility.sink("ZID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        private ZyglPlanService service = new ZyglPlanService();

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
            CreateBT.AddButton("back.gif", Trans("返回"), "ZyglJdList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            int deptId = 0;
            //if (Cmd == "New") {
            //    HseSectcheckModel cm = service.GetList().FirstOrDefault(p => p.SUBMITTER==this.userModel.USERID&&p.STATUS==-2);
            //    if (cm == null)
            //    {
            //        cm = new HseSectcheckModel();
            //        Hid_CKID.Value=cm.CKID = Guid.NewGuid().ToRequestString();
            //        cm.STATUS = -2;
            //        cm.SUBMITTER = this.userModel.USERID;
            //        cm.DB_Option_Action = WebKeys.InsertAction;
            //        service.Execute(cm);
            //        HseSectcheckdetlModel dm = new HseSectcheckdetlModel();
            //        dm.STATUS = -2;
            //        ///dm.SUBMITTER = this.userModel.USERID;
            //        dm.CKID = cm.CKID;
            //        dm.CKDID = Guid.NewGuid().ToRequestString();
            //        dm.DB_Option_Action = WebKeys.InsertAction;
            //        dservice.Execute(dm);
            //    }
            //    else {
            //        Hid_CKID.Value = cm.CKID;
            //        Txt_TARGET.Text = cm.CTARGET;
            //        Ddl_LEVEL.SelectedValue = cm.CLEVEL;
            //        muti_RcvUsers.Value = cm.CHECKER;
            //        single_RcvUsers.UserSelectValue = cm.RECIEVER.ToRequestString();
            //        Txt_CDATE.Text = cm.CDATE.ToDateYMDFormat();
            //        Txt_ENDDATE.Text = cm.ENDDATE.ToDateYMDFormat();
            //        tb_AFVIewNames.DBValue = cm.FVIEWNAMES;
            //        int c = dservice.GetList().Where(p => p.CKID == cm.CKID && p.STATUS == -2).Count();
            //        if (c == 0)
            //        {
            //            HseSectcheckdetlModel dm = new HseSectcheckdetlModel();
            //            dm.STATUS = -2;
            //            ///dm.SUBMITTER = this.userModel.USERID;
            //            dm.CKID = cm.CKID;
            //            dm.CKDID = Guid.NewGuid().ToRequestString();
            //            dm.DB_Option_Action = WebKeys.InsertAction;
            //            dservice.Execute(dm);
            //        }
                    
            //    }
            //    IList<HseSectcheckdetlModel> lll = dservice.GetList().Where(p => p.CKID == cm.CKID).ToList();
            //    GridView1.DataSource = lll;
            //    GridView1.DataBind();
            //}
            if (Cmd == "Edit")
            {
                OnBindData();
            }
            //else if (Cmd == "Delete")
            //{
            //    var q = service.GetList().FirstOrDefault(p=>p.PID==pId);
            //    if (q != null)
            //    {
            //        string _note = "操作成功";
            //        q.DB_Option_Action = "Delete";
            //        try
            //        {
            //            service.Execute(q);
            //        }
            //        catch (Exception ex)
            //        {
            //            _note = ex.Message;
            //        }
            //        Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "HseSectList.aspx");
            //    }
            //}
            
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='DmwxJdEdit.aspx?Cmd=Delete2&JID={0}&PID={1}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id, Hid_CKID.Value);
            return btnStrs;
        }
        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            var q = service.GetList().FirstOrDefault(p => p.ZID == zId);
            Hid_CKID.Value = zId;
            if (q != null)
            {
                //t_Title.Text = q.TITLE;
                //t_Content.Text = q.CONTENT;
                //single_RcvUsers.UserSelectValue = q.RECEVIEUSER.ToRequestString();
                //lb_User.Text = SysUserService.GetUserName((int)q.CREATEUSER);
                //多附件初始化
                Txt_JH.Text = q.JH;
                Txt_STARTDATE.Text = q.STARTDATE.ToDateYMDFormat();
                Txt_PENDDATE.Text = q.PENDDATE.ToDateYMDFormat();

                string sql = "select jh,kgrq,to_char(rq,'yyyy-mm-dd') rq,gxmc,(select dmmc from vw_fla16  where dm=cslb) cslb,sgxh,sgnr from VW_DDB01 where jh='" + q.JH + "' and to_char(kgrq,'yyyy-mm-dd')='" + q.STARTDATE.ToDateYMDFormat() + "' order by rq,sgxh";
                DataSet ds = null;

                ds = service.getDsBySql(sql);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                //lb_Dept.Text = SysDepartmentService.GetDepartMentName((int)q.CREATEDEPT);

                //end
            }
        }
        //private string sendMessageToRecv(HseSectcheckModel model)
        //{
        //    string msg = "消息已发送";
        //    BFController bfCtrl = new BFController();
        //    //发待办和提示消息
        //    bfCtrl.SendNotificationMessage(
        //        model.CKID,//和项目关联的消息
        //        model.RECIEVER.Value,//接收人
        //        this.userModel,//当前用户
        //        string.Format("{0}-安全隐患整改通知，需要您进行查收!", model.CLEVEL),//消息标题
        //        string.Format("/Modules/App/Hse/HseSectRecv.aspx?Cmd=Recv&CKID={0}", model.CKID),//消息内容
        //        BFRemindWay.MSG.ToString(), false);
        //    return msg;
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DmglSgjdModel model = e.Row.DataItem as DmglSgjdModel;
                //TextBox tjtime = (TextBox)e.Row.Cells[1].FindControl("T_JTIME");
                //TextBox tdetail = (TextBox)e.Row.Cells[2].FindControl("T_DETAIL");
                //tjtime.Text = model.JTIME.ToDateYMDFormat();
                //tdetail.Text = model.DETAIL;
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
                ZyglPlanModel entity = service.GetList().FirstOrDefault(p => p.ZID == Hid_CKID.Value);
                if (entity == null)
                {
                    entity.DB_Option_Action = WebKeys.InsertAction;
                    Hid_CKID.Value = entity.ZID = Guid.NewGuid().ToRequestString();


                }
                else
                {
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }


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
            Response.Redirect("ZyglJdEdit.aspx?Cmd=Edit&PID=" + Hid_CKID.Value, false);
        }
        protected void BtnNew_OnClick(object sender, EventArgs e)
        {
            //string _note = "操作成功";
            //try
            //{
            //    ZyglPlanModel entity = service.GetList().FirstOrDefault(p => p.PID == Hid_CKID.Value);
            //    if (entity == null)
            //    {
            //        entity.DB_Option_Action = WebKeys.InsertAction;
            //        Hid_CKID.Value=entity.PID = Guid.NewGuid().ToRequestString();


            //    }
            //    else 
            //    {
            //        entity.DB_Option_Action = WebKeys.UpdateAction;
            //    }
            //    entity.SGDW = Txt_SGDW.Text;
            //    entity.PENDDATE = Txt_PENDDATE.Text.ToDateTime();
            //    entity.STARTDATE = Txt_STARTDATE.Text.ToDateTime();
            //    entity.FNAMES2 = tb_AFVIewNames.Text;
            //    entity.FVIEWNAMES2 = tb_AFVIewNames.DBValue;


            //    if (service.Execute(entity))
            //    {
            //        //BfMsgService bs = new BfMsgService();
            //        //var l = bs.GetUnhandleList().Where(p=>p.BF_INSTANCEID==entity.DOCID);
            //        //foreach (var q in l)
            //        //{
            //        //    q.DB_Option_Action = WebKeys.DeleteAction;
            //        //    bs.ExecuteUnhandle(q);
            //        //}
            //        //sendMessageToRecv(entity);
            //    }


            //    foreach (GridViewRow row in GridView1.Rows)
            //    {
            //        TextBox tjtime = (TextBox)row.Cells[1].FindControl("T_JTIME");
            //        TextBox tdetail = (TextBox)row.Cells[2].FindControl("T_DETAIL");
            //        string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
            //        var md = dservice.GetList().FirstOrDefault(p => p.JID == str_Id);
            //        md.JTIME = tjtime.Text.ToDateTime();
            //        md.DETAIL = tdetail.Text;
            //        md.STATUS = -1;
            //        if (!string.IsNullOrEmpty(tdetail.Text))
            //        {
            //            md.DB_Option_Action = WebKeys.UpdateAction;
            //            dservice.Execute(md);
            //        }
            //    }
            //    int c = dservice.GetList().Where(p => p.PID == Hid_CKID.Value && p.STATUS == -2).Count();
            //    if (c == 0)
            //    {
            //        DmglSgjdModel dm = new DmglSgjdModel();
            //        dm.STATUS = -2;
            //        ///dm.SUBMITTER = this.userModel.USERID;
            //        dm.PID = Hid_CKID.Value;
            //        dm.JID = Guid.NewGuid().ToRequestString();
            //        dm.DB_Option_Action = WebKeys.InsertAction;
            //        dservice.Execute(dm);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _note = ex.Message;
            //}
            //Response.Redirect("DmwxJdEdit.aspx?Cmd=Edit&PID=" + Hid_CKID.Value,false);
            //Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "HseSectEdit.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value);
        }

        protected void BtnRecv_OnClick(object sender, EventArgs e)
        {
            string _note = "提交成功";
            try
            {
                ZyglPlanModel entity = service.GetList().FirstOrDefault(p => p.ZID == Hid_CKID.Value);
                if (entity == null)
                {
                    entity.DB_Option_Action = WebKeys.InsertAction;
                    Hid_CKID.Value = entity.ZID = Guid.NewGuid().ToRequestString();


                }
                else
                {
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }
                entity.STATUS = 4;


                if (service.Execute(entity))
                {
                    //BfMsgService bs = new BfMsgService();
                    //var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == entity.CKID);
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
            //Response.Redirect("HseSectEdit.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value, false);
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ZyglJdList.aspx");
        }
    }
}