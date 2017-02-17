using Enterprise.Service.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Service.App.Dmgl;
using Enterprise.Model.App.Dmgl;
using Enterprise.Model.Basis.Message;
using Enterprise.Service.Basis.Message;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using System.Collections;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
namespace Enterprise.UI.Web.Modules.App.Dmgl
{
    public partial class DmwxPlanSum : BasePage
    {
        public DmglPlanService aService = new DmglPlanService();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindCommand();
            if (!IsPostBack)
            {
                InitControl();                
                BindGrid();
            }
        }

        private void BindCommand()
        {

        }

        private void InitControl()
        {           
            
        }

        private void BindGrid()
        {


            DmglPlanModel entity = new DmglPlanModel();
            IList<DmglPlanModel> list3 = aService.GetList().Where(p => (p.STATUS == 1 && p.SPSTATUS != 1 && p.SPSTATUS != 0) || (p.STATUS == 1 && p.SPSTATUS == 1 && p.SP2STATUS != 1 && p.SP2STATUS != 0)).ToList();
            DmglPlanModel hz = new DmglPlanModel();
            hz.PID = "-1111";
            hz.MX = "汇总";
            hz.PAMOUNT = list3.Sum(s=>s.PAMOUNT);
            list3.Add(hz);
            GridView3.DataSource = list3.OrderByDescending(o=>o.PID).ToList();
            GridView3.DataBind();

            IList<DmglPlanModel> list1 = aService.GetList().Where(p => p.STATUS == 1&&p.SPSTATUS!=null &&p.SPSTATUS!=-1&& p.SPSTATUS != 2 && p.SP2STATUS != 2).ToList();
            GridView1.DataSource = list1;
            GridView1.DataBind();

        }

        /// <summary>
        /// 生成操作按钮
        /// </summary>
        /// <returns></returns>
        protected string GetCommandBtn(object data)
        {
            string btnStrs = string.Empty;
            //if (typeof(ProjectMemberModel).IsAssignableFrom(data.GetType()))
            //{
            //    ProjectMemberModel model = data as ProjectMemberModel;
            //    //btnStrs += string.Format("<a href='ProjectTeam2Edit.aspx?Cmd=Edit&ProjectId={0}&MEMID={1}&NodeCode={2}&XZ={3}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", ProjectId, model.MEMBERID, NodeCode,(int)MemberProperty.职工);
            //    if (model.POSTROLE != PM_ROLENAME.项目负责人.ToString())
            //    {
            //        //btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            //        btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ProjectTeam2Edit.aspx?Cmd=Delete&ProjectId={0}&MEMID={1}&NodeCode={2}&XZ={3}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", ProjectId, model.MEMBERID, NodeCode, (int)MemberProperty.职工);
            //    }
            //}
            //else if (typeof(ProjectMbroutsideModel).IsAssignableFrom(data.GetType()))
            //{
            //    ProjectMbroutsideModel model = data as ProjectMbroutsideModel;
            //    if (model.POSTROLE != PM_ROLENAME.项目负责人.ToString())
            //    {
            //        //btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            //        btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ProjectTeam3Edit.aspx?Cmd=Delete&ProjectId={0}&MEMID={1}&NodeCode={2}&XZ={3}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", ProjectId, model.MBROUTID, NodeCode, (int)MemberProperty.辅助);
            //    }
            //}
            return btnStrs;
        }


        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DmglPlanModel model = e.Row.DataItem as DmglPlanModel;
                TextBox mx = (TextBox)e.Row.Cells[1].FindControl("memoT1");
                CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("cb_select");
                Label hz = (Label)e.Row.Cells[1].FindControl("hz");
                TextBox ms = (TextBox)e.Row.Cells[2].FindControl("memoT2");
                TextBox bz = (TextBox)e.Row.Cells[4].FindControl("memoT3");
                TextBox amount = (TextBox)e.Row.Cells[3].FindControl("Txt_Amount");
                Label hzamount = (Label)e.Row.Cells[3].FindControl("hzamount");
                if (model.PID == "-1111")
                {
                    hz.Text = "汇总";
                    hzamount.Text = model.PAMOUNT.ToRequestString();
                    mx.Visible = false;
                    ms.Visible = false;
                    bz.Visible = false;
                    amount.Visible = false;
                    cb.Visible = false;
                    return;
                }
                mx.Text = model.MX;
                ms.Text = model.MS;
                bz.Text = model.BZ;
                amount.Text = model.PAMOUNT.ToRequestString();

            }
        }

        

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView3.Rows)
            {
                
                string str_Id = GridView3.DataKeys[row.RowIndex].Value.ToString();
                DmglPlanModel md = aService.GetList().FirstOrDefault(p=>p.PID==str_Id);
                if (md == null) continue;
                if (md.PID == "-1111") continue;
                TextBox mx = (TextBox)row.Cells[1].FindControl("memoT1");
                TextBox ms = (TextBox)row.Cells[2].FindControl("memoT2");
                TextBox bz = (TextBox)row.Cells[4].FindControl("memoT3");
                TextBox amount = (TextBox)row.Cells[3].FindControl("Txt_Amount");
                md.MX = mx.Text;
                md.MS = ms.Text;
                md.BZ = bz.Text;
                md.PAMOUNT = amount.Text.ToDecimal();
                md.SPSTATUS = -1;
                md.DB_Option_Action = WebKeys.UpdateAction;
                aService.Execute(md);
            }
            
        }

        protected void btn_selectall_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView3.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cb_select");
                if (cb.Enabled)
                    cb.Checked = true;
            }
        }

        /// <summary>
        /// 取消全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancelselect_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView3.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cb_select");
                if (cb.Checked == false) cb.Checked = true;
                if (cb.Checked == true) cb.Checked = false;
            }
        }

        private string sendMessageToSPR(string lsh,int spr)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                lsh,//和项目关联的消息
                spr,//接收人
                this.userModel,//当前用户
                string.Format("地面维修申请，需要您进行审批!"),//消息标题
                string.Format("/Modules/App/Dmgl/DmwxPlanSp.aspx?Cmd=Edit"),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
        }
        protected void btn_audit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView3.Rows)
            {
                string str_Id = GridView3.DataKeys[row.RowIndex].Value.ToString();
                DmglPlanModel md = aService.GetList().FirstOrDefault(p => p.PID == str_Id);
                if (md == null) continue;
                if (md.PID == "-1111") continue;
                TextBox mx = (TextBox)row.Cells[1].FindControl("memoT1");
                TextBox ms = (TextBox)row.Cells[2].FindControl("memoT2");
                TextBox bz = (TextBox)row.Cells[4].FindControl("memoT3");
                TextBox amount = (TextBox)row.Cells[3].FindControl("Txt_Amount");
                md.MX = mx.Text;
                md.MS = ms.Text;
                md.BZ = bz.Text;
                md.PAMOUNT = amount.Text.ToDecimal();
                md.DB_Option_Action = WebKeys.UpdateAction;
                aService.Execute(md);
            }

            SysDutyService sd = new SysDutyService();
            SysDutyModel dm = sd.GetList().Where(p => p.DNAME == "地面维修分管领导").FirstOrDefault();
            SysUserDutyService ssss = new SysUserDutyService();
            SysUserDutyModel spr = ssss.GetList().Where(p => p.DUTYID == dm.DUTYID).FirstOrDefault();
            bool t = true;
            foreach (GridViewRow row in GridView3.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cb_select");
                if (cb.Checked)
                {
                    string pId = GridView3.DataKeys[row.RowIndex].Value.ToString();
                    DmglPlanModel model = aService.GetList().FirstOrDefault(p=>p.PID==pId);
                    if (model != null)
                    {
                        model.SPR = spr.USERID;
                        model.SPSTATUS = 0;
                        model.DB_Option_Action = WebKeys.UpdateAction;
                        aService.Execute(model);

                    }

                    //BfMsgService.UpdateMsgOver(MsgID);
                    if (t) { 
                        sendMessageToSPR(CommonTool.GetGuidKey(), spr.USERID.Value);
                        t = false;
                    }
                }

            }

            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", "操作成功", "DmwxPlanSum.aspx");
        }

        protected string GetStatus(object obj) {
            string i = string.Empty;
            string id=(string)obj;
            DmglPlanModel p = aService.GetList().FirstOrDefault(f=>f.PID==id);
            if(p.SPSTATUS==0){
                i = "分管领导审批中";
            }
            else if (p.SP2STATUS == 0) {
                i = "主要领导审批中";
            }
            else if (p.SP2STATUS == 1) {
                i = "审批通过";
            }
            return i;
        }
    }
}