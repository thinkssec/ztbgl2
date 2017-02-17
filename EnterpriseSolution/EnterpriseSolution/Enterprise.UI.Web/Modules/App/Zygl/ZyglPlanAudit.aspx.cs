using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Zygl;
using Enterprise.Service.App.Zygl;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
namespace Enterprise.UI.Web.Modules.App.Zygl
{
    public partial class ZyglPlanAudit : Enterprise.Service.Basis.BasePage
    {
        //protected string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string ZID = (string)Utility.sink("ZID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
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
            //CreateBT.AddButton("back.gif", Trans("返回"), "ZyglPlanList.aspx", Utility.PopedomType.List, HeadMenu1);
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
                ZyglPlanService aService = new ZyglPlanService();
                var q = aService.GetList().FirstOrDefault(p => p.ZID == ZID);
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
            ZyglPlanService aService = new ZyglPlanService();
            var q = aService.GetList().FirstOrDefault(p => p.ZID == ZID);
            if (q != null)
            {
                Txt_JH.Text = q.JH;
                Txt_DYQK.Text = q.DYQK;
                Txt_CW.Text = q.CW;
                Txt_LASTDATE.Text = q.LASTDATE.ToDateYMDFormat();
                Txt_LSGNR.Text = q.LSGNR;
                Txt_SCZQ.Text = q.SCZQ.ToRequestString();
                Txt_ZYYY.Text = q.ZYYY;
                Txt_SGNR.Text = q.SGNR;
                Ddl_ZYFL.SelectedValue = q.ZYFL;
                Txt_CSLB.Text = q.CSLB;
                Txt_YSE.Text = q.YSE.ToRequestString();
                Txt_PSTARTDATE.Text = q.PSTARTDATE.ToDateYMDFormat();
                Txt_PENDDATE.Text = q.PENDDATE.ToDateYMDFormat();
                //single_SHR.UserSelectValue = q.SHR.ToRequestString();
                //single_SPR.UserSelectValue = q.SPR.ToRequestString();
                Lb_FL.Text = ToAttachHtml2(q.FVIEWNAMES);
            }
        }
        private string sendMessageToRecv(ZyglPlanModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                model.ZID,//和项目关联的消息
                model.SHR.Value,//接收人
                this.userModel,//当前用户
                string.Format("{0}-作业开工申请，需要您进行签收!", model.JH),//消息标题
                string.Format("/Modules/App/Zygl/ZyglPlanAudit.aspx?Cmd=Edit&ZID={0}", model.ZID),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCancle_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                ZyglPlanService aService = new ZyglPlanService();
                ZyglPlanModel entity = new ZyglPlanModel();
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = "Insert";
                    entity.ZID = CommonTool.GetGuidKey();
                }
                else if (Cmd == "Edit")
                {
                    entity = aService.GetList().FirstOrDefault(p=>p.ZID==ZID);
                    entity.DB_Option_Action = "Update";
                }

                

                //entity.SHR = single_SHR.UserSelectValue.ToInt();
                entity.SHTIME = DateTime.Now;
                entity.SHSTATUS = 2;
                //entity.SPR = single_SPR.UserSelectValue.ToInt();
                entity.STATUS=2;
                if (aService.Execute(entity))
                {
                    //sendMessageToRecv(entity);
                }
               
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "ZyglPlanList.aspx");
        }

        public string ToAttachHtml2(object article)
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
        protected void BtnOk_OnClick(object sender, EventArgs e)
        {
            string _note = "提交成功";
            try
            {
                ZyglPlanService aService = new ZyglPlanService();
                ZyglPlanModel entity = new ZyglPlanModel();
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = "Insert";
                    entity.ZID = CommonTool.GetGuidKey();
                }
                else if (Cmd == "Edit")
                {
                    entity = aService.GetList().FirstOrDefault(p => p.ZID == ZID);
                    entity.DB_Option_Action = "Update";
                }

                entity.SHTIME = DateTime.Now;
                entity.SHSTATUS = 1;
                //entity.SHR = single_SHR.UserSelectValue.ToInt();
                //entity.SPR = single_SPR.UserSelectValue.ToInt();
                entity.STATUS = 1;
                if (aService.Execute(entity))
                {
                    //sendMessageToRecv(entity);
                    BfMsgService.UpdateMsgOver(MsgID);
                }

            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "/TodoIndexBox.aspx");
        }
    }
}