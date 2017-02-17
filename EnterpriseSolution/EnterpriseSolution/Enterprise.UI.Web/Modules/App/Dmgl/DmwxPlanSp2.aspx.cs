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
    public partial class DmwxPlanSp2 : BasePage
    {

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

            DmglPlanService aService = new DmglPlanService();
            DmglPlanModel entity = new DmglPlanModel();
            IList<DmglPlanModel> list1 = aService.GetList().Where(p => p.STATUS==1&&p.SPSTATUS==1&&p.SP2STATUS==0).ToList();
            GridView3.DataSource = list1;
            GridView3.DataBind();
            int ct = aService.GetList().Where(p => p.SP2STATUS == 0).Count();
            if (ct == 0) BfMsgService.UpdateMsgOver(MsgID);
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

                //TextBox mx = (TextBox)e.Row.Cells[1].FindControl("memoT1");
                //TextBox ms = (TextBox)e.Row.Cells[2].FindControl("memoT2");
               // TextBox bz = (TextBox)e.Row.Cells[4].FindControl("memoT3");
                TextBox yj = (TextBox)e.Row.Cells[5].FindControl("memoT4");
                //TextBox amount = (TextBox)e.Row.Cells[3].FindControl("Txt_Amount");
                //mx.Text = model.MX;
                //ms.Text = model.MS;
                //bz.Text = model.BZ;
                yj.Text = model.SP2CONTENT;
                //amount.Text = model.PAMOUNT.ToRequestString();

            }
        }



        protected void btn_cancle_Click(object sender, EventArgs e)
        {
            DmglPlanService aService = new DmglPlanService();
            foreach (GridViewRow row in GridView3.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cb_select");
                if (cb.Checked)
                { 
                    TextBox yj = (TextBox)row.Cells[6].FindControl("memoT4");
                    string str_Id = GridView3.DataKeys[row.RowIndex].Value.ToString();
                    DmglPlanModel md = aService.GetList().FirstOrDefault(p=>p.PID==str_Id);
                    md.SP2CONTENT = yj.Text;
                    md.SP2STATUS = 2;
                    md.SP2TIME = DateTime.Now;
                    md.DB_Option_Action = WebKeys.UpdateAction;               
                    aService.Execute(md);
                }
            }
            int ct = aService.GetList().Where(p => p.SP2STATUS == 0).Count();
            if (ct == 0) BfMsgService.UpdateMsgOver(MsgID);
            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", "操作成功", "DmwxPlanSp2.aspx");

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

        private string sendMessageToSPR2(string lsh,int spr)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            bfCtrl.SendNotificationMessage(
                lsh,//和项目关联的消息
                spr,//接收人
                this.userModel,//当前用户
                string.Format("地面维修申请，需要您进行审批!"),//消息标题
                string.Format("/Modules/App/Dmgl/DmwxPlanSp2.aspx?Cmd=Edit"),//消息内容
                BFRemindWay.MSG.ToString(), false);
            return msg;
        }
        protected void btn_ok_Click(object sender, EventArgs e)
        {
            DmglPlanService aService = new DmglPlanService();

            foreach (GridViewRow row in GridView3.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cb_select");
                if (cb.Checked)
                {
                    TextBox yj = (TextBox)row.Cells[6].FindControl("memoT4");
                    string str_Id = GridView3.DataKeys[row.RowIndex].Value.ToString();
                    DmglPlanModel md = aService.GetList().FirstOrDefault(p => p.PID == str_Id);
                    md.SP2CONTENT = yj.Text;
                    md.SP2STATUS = 1;
                    md.SP2TIME = DateTime.Now;
                    md.DB_Option_Action = WebKeys.UpdateAction;
                    aService.Execute(md);
                    
                }
            }


            int ct = aService.GetList().Where(p => p.SP2STATUS == 0).Count();
            if (ct == 0) BfMsgService.UpdateMsgOver(MsgID);

            Utility.ShowMsgThenReloadTree(this.Page, "系统提示", "操作成功", "DmwxPlanSp2.aspx");
        }

    }
}