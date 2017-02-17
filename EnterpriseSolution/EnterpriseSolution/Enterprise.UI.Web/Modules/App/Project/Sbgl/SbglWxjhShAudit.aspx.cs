using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis;
using Enterprise.Model.App.Sbgl;
using Enterprise.Service.App.Sbgl;
using Enterprise.Component.Control;
using System.Collections;
using Enterprise.Service.Basis.Sys;
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Service.Basis.Bf;


namespace Enterprise.UI.Web.Modules.App.Project.Sbgl
{

    /// <summary>
    /// 设备管理-维修计划审核操作
    /// </summary>
    public partial class SbglWxjhShAudit : BasePage
    {

        /// <summary>
        /// 服务类
        /// </summary>
        SbglWxjhbService wxjgbSrv = new SbglWxjhbService();

        /// <summary>
        /// 维修批号
        /// </summary>
        protected string wxph = (string)Utility.sink("PH", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {

            OnCommand();
            if (!IsPostBack)
            {
                OnCondition();
                OnBindData();
            }
        }

        private void OnCondition()
        {
            //如果是审核
            if (Cmd == "Audit")
            {
                Pnl_Audit.Visible = true;
                LnkBtnAudit.Visible = true;
            }
        }

        private void OnBindData()
        {
            var list = wxjgbSrv.GetListBySbwxph(wxph);
            if (list.Count > 0)
            {
                //提取审核信息
                UC_Shenhe_Show.ShowAuditInfos(list.First().SBWXPH);
            }
        }

        private void OnCommand()
        {
            ////项目成员可操作
            //if (ProjectMemberService.IsTeamMember(ProjectId, userModel, null))
            //{
            //    CreateBT.AddButton("new.gif", "新增", "ProjectWsXmbs.aspx?Cmd=New&projectId=" + tb_projid.Value + "&NodeCode=" + NodeCode, Utility.PopedomType.List, HeadMenu1);
            //    GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            //}
            //else
            //{
            //    GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            //}
        }

        /// <summary>
        /// 审核完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtnAudit_Click(object sender, EventArgs e)
        {
            //提取维修批号关联的审核信息
            ProjectCheckService checkSrv = new ProjectCheckService();
            var checkModel = checkSrv.GetModelsByAssociateID(wxph).FirstOrDefault(p => p.CHECKER == Utility.Get_UserId);
            if (checkModel != null)
            {
                checkModel.DB_Option_Action = WebKeys.UpdateAction;
                checkModel.CHECKSTATUS = 1;//审核状态 0未审 1已审
                checkModel.CHECKRESULT = UC_DoShenhe.CHECKRESULT.ToInt(); //审核结果 1通过 0未通过
                checkModel.CHECKOPINION = UC_DoShenhe.CHECKOPINION;
                checkModel.CHECKDATE = DateTime.Now;
                if (checkSrv.Execute(checkModel))
                {
                    if (checkModel.CHECKRESULT == (int)CheckResultType.不同意)
                    {
                        //退回
                        string sql = "begin ";
                        sql += "update app_sbgl_wxjhb set sqzt='-1' where sbwxph='" + wxph + "';";
                        sql += "null; ";
                        sql += "end; ";
                        wxjgbSrv.ExecuteSQL(sql);
                    }
                    else
                    {
                        if (checkModel.CHECKORDER == 2)
                        {
                            //经理审核完成,更新状态位
                            string sql = "begin ";
                            sql += "update app_sbgl_wxjhb set sqzt='1' where sbwxph='" + wxph + "';";
                            sql += "null; ";
                            sql += "end; ";
                            wxjgbSrv.ExecuteSQL(sql);
                        }
                        else
                        {
                            //提交经理审核 发送待办
                            checkModel = new ProjectCheckModel();
                            checkModel.DB_Option_Action = WebKeys.InsertAction;
                            checkModel.CHECKID = CommonTool.GetGuidKey();
                            checkModel.CHECKER = SysUserService.GetDutyUserId(0, "经理");
                            checkModel.CHECKORDER = 2;
                            checkModel.CHECKSTATUS = 0;//审核状态 0未审 1已审
                            checkModel.ASSOCIATEDID = wxph;
                            checkModel.SENDDATE = DateTime.Now;
                            checkModel.SENDER = Utility.Get_UserId;
                            checkModel.CHECKDATE = DateTime.Now;
                            if (checkSrv.Execute(checkModel))
                            {
                                BFController bfCtrl = new BFController();
                                //发待办和提示消息
                                bfCtrl.SendNotificationMessage(
                                    "",//和项目关联的消息
                                    checkModel.CHECKER.ToInt(),//接收人
                                    this.userModel,//当前用户
                                    string.Format("{0}，需要您进行审批!", "设备维修计划申请"),//消息标题
                                    string.Format("/Modules/App/Project/Sbgl/SbglWxjhShAudit.aspx?Cmd=Audit&PH={0}", wxph),//消息内容
                                    "", false);
                                Utility.ShowTopMsg(Page, "提示", "提交领导审核成功!", 80, "show");
                            }
                        }
                        OnBindData();
                    }
                    //关闭待办
                    BfMsgService.UpdateMsgOver(MsgID);
                }
            }
            Utility.ShowMsg(this.Page, "系统提示", "审核操作完成!", "/TodoIndexBox.aspx");
        }
    }
}