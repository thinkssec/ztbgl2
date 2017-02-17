﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Dmgl;
using Enterprise.Service.App.Dmgl;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
namespace Enterprise.UI.Web.Modules.App.Dmgl
{
    public partial class DmwxPlanEdit : Enterprise.Service.Basis.BasePage
    {
        //protected string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string pId = (string)Utility.sink("PID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
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
            CreateBT.AddButton("back.gif", Trans("返回"), "DmwxPlanList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            int deptId = 0;
            
            if (Cmd == "Edit")
            {
                OnBindData();
            }
            else if (Cmd == "Delete")
            {
                DmglPlanService aService = new DmglPlanService();
                var q = aService.GetList().FirstOrDefault(p => p.PID == pId);
                if (q != null)
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        aService.Execute(q);
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "DmwxPlancList.aspx");
                }
            }
        }

        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            DmglPlanService aService = new DmglPlanService();
            var q = aService.GetList().FirstOrDefault(p => p.PID == pId);
            if (q != null)
            {
                Ddl_PKIND1.SelectedValue = q.PKIND1;
                Ddl_PKIND2.SelectedValue = q.PKIND2;
                Txt_MX.Text = q.MX;
                Txt_MS.Text = q.MS;
                Txt_PDJ.Text = q.PDJ.ToRequestString();
                Txt_PSL.Text=q.PSL.ToRequestString();
                Txt_PAMOUNT.Text = q.PAMOUNT.ToRequestString();
                Txt_PSTARTDATE.Text = q.PSTARTDATE.ToDateYMDFormat();
                Txt_PENDDATE.Text = q.PENDDATE.ToDateYMDFormat();
                single_SHR.UserSelectValue = q.SHR.ToRequestString();
                //single_SPR.UserSelectValue = q.SPR.ToRequestString();
                tb_AFVIewNames.DBValue = q.FVIEWNAMES;
            }
        }
        private string sendMessageToRecv(DmglPlanModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                model.PID,//和项目关联的消息
                model.SHR.Value,//接收人
                this.userModel,//当前用户
                string.Format("{0}-地面维修申请，需要您进行签收!", model.MX),//消息标题
                string.Format("/Modules/App/Dmgl/DmwxPlanAudit.aspx?Cmd=Edit&PID={0}", model.PID),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
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
                DmglPlanService aService = new DmglPlanService();
                DmglPlanModel entity = new DmglPlanModel();
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = "Insert";
                    entity.PID = CommonTool.GetGuidKey();
                }
                else if (Cmd == "Edit")
                {
                    entity = aService.GetList().FirstOrDefault(p=>p.PID==pId);
                    entity.DB_Option_Action = "Update";
                }

                entity.CREATETIME = DateTime.Now;
                entity.SUBMITTER = Utility.Get_UserId;
                entity.PKIND1 = Ddl_PKIND1.SelectedValue;
                entity.PKIND2 = Ddl_PKIND2.SelectedValue;
                entity.MX = Txt_MX.Text;
                entity.MS = Txt_MS.Text;
                entity.PDJ = Txt_PDJ.Text.ToDecimal();
                entity.PSL = Txt_PSL.Text.ToInt();
                entity.PAMOUNT = Txt_PAMOUNT.Text.ToDecimal();
                entity.PSTARTDATE = Txt_PSTARTDATE.Text.ToDateTime();
                entity.PENDDATE = Txt_PENDDATE.Text.ToDateTime();
                entity.FNAMES = tb_AFVIewNames.Text;
                entity.FVIEWNAMES = tb_AFVIewNames.DBValue;
                entity.SHR = single_SHR.UserSelectValue.ToInt();
                //entity.SPR = single_SPR.UserSelectValue.ToInt();
                entity.STATUS=-1;
                if (aService.Execute(entity))
                {
                    BfMsgService bs = new BfMsgService();
                    var l = bs.GetUnhandleList().Where(p=>p.BF_INSTANCEID==entity.PID);
                    foreach (var q in l)
                    {
                        q.DB_Option_Action = WebKeys.DeleteAction;
                        bs.ExecuteUnhandle(q);
                    }
                    //sendMessageToRecv(entity);
                }
               
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "DmwxPlanList.aspx");
        }


        protected void BtnAudit_OnClick(object sender, EventArgs e)
        {
            string _note = "提交成功";
            try
            {
                DmglPlanService aService = new DmglPlanService();
                DmglPlanModel entity = new DmglPlanModel();
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = "Insert";
                    entity.PID = CommonTool.GetGuidKey();
                }
                else if (Cmd == "Edit")
                {
                    entity = aService.GetList().FirstOrDefault(p => p.PID == pId);
                    entity.DB_Option_Action = "Update";
                }

                entity.CREATETIME = DateTime.Now;
                entity.SUBMITTER = Utility.Get_UserId;
                entity.SUBMITDATE = DateTime.Now;
                entity.PKIND1 = Ddl_PKIND1.SelectedValue;
                entity.PKIND2 = Ddl_PKIND2.SelectedValue;
                entity.MX = Txt_MX.Text;
                entity.MS = Txt_MS.Text;
                entity.PDJ = Txt_PDJ.Text.ToDecimal();
                entity.PSL = Txt_PSL.Text.ToInt();

                entity.PAMOUNT = Txt_PAMOUNT.Text.ToDecimal();
                entity.PSTARTDATE = Txt_PSTARTDATE.Text.ToDateTime();
                entity.PENDDATE = Txt_PENDDATE.Text.ToDateTime();
                entity.FNAMES = tb_AFVIewNames.Text;
                entity.FVIEWNAMES = tb_AFVIewNames.DBValue;
                entity.SHR = single_SHR.UserSelectValue.ToInt();
                //entity.SPR = single_SPR.UserSelectValue.ToInt();
                entity.STATUS = 0;
                if (aService.Execute(entity))
                {
                    BfMsgService bs = new BfMsgService();
                    var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == entity.PID);
                    foreach (var q in l)
                    {
                        q.DB_Option_Action = WebKeys.DeleteAction;
                        bs.ExecuteUnhandle(q);
                    }
                    sendMessageToRecv(entity);
                }

            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "DmwxPlanList.aspx");
        }
    }
}