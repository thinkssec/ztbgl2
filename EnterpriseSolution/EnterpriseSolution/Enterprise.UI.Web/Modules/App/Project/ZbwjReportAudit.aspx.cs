using Enterprise.Service.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Message;
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Component.Control;
using Enterprise.Service.Basis.Bf;
using Enterprise.Service.Basis.Message;
using Enterprise.Model.Basis.Message;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Project
{

    /// <summary>
    /// 检测报告审核页面
    /// </summary>
    public partial class ZbwjReportAudit : BasePage
    {

        /// <summary>
        /// 报告ID
        /// </summary>
        string rptId = (string)Utility.sink("RPTID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 检测报告---服务类
        /// </summary>
        ProjectZbwjshService rptSrv = new ProjectZbwjshService();
        /// <summary>
        /// 检测报告MODEL
        /// </summary>
        ProjectZbwjshModel RptModel { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {
                BindAction();
                BindGrid();
            }

        }


        #region 界面初始化 绑定

        private void BindAction()
        {
            //如果是审核
            if (Cmd == "Audit")
            {
                Pnl_Audit.Visible = true;
                LnkBtnAudit.Visible = true;
                LnkBtnApprover.Visible = false;
            }

            //如果是签发
            if (Cmd == "Sign")
            {
                Pnl_Audit.Visible = true;
                LnkBtnAudit.Visible = false;
                LnkBtnApprover.Visible = true;
            }
        }

        /// <summary>
        /// 绑定操作权限
        /// </summary>
        private void OnCommand()
        {
            //CreateBT.AddButton("back.gif", "返回", "ProjectJcReport.aspx?ProjectId=" + ProjectId + "&NodeCode=" + NodeCode, Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid()
        {
            var list = rptSrv.GetList().Where(w => w.PROJID == ProjectId).Where(p => p.RPTID == rptId);
            GridView1.DataSource = list;
            GridView1.DataBind();

            //提取审核信息
            UC_Shenhe_Show.ShowAuditInfos(rptId);
        }

        #endregion

        #region 前端HTML格式化

        /// <summary>
        /// 在页面中显示上传资质文件的图标 点击可看详细的文件 如没有 显示空
        /// </summary>
        /// <param name="imgPath"></param>
        /// <returns></returns>
        public string ATTACHMENT(object imgPath)
        {
            string str = "<a href='{0}' target='_blank'><img src='/Resources/OA/site_skin/default/img/page.png'  border=\"0\"/></a>";
            if (string.IsNullOrEmpty(imgPath.ToRequestString()))
                return "";
            else
                return string.Format(str, imgPath.ToRequestString());

        }

        /// <summary>
        /// 获取审核状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dataid"></param>
        /// <returns></returns>
        protected string GetChecker(string userId, string dataid)
        {
            string html = Enterprise.Service.Basis.Sys.SysUserService.GetUserName(userId.ToInt());
            //审核通过的加上对号 未通过的加感叹号
            ProjectCheckService service = new ProjectCheckService();
            var q = service.GetModelsByAssociateID(dataid).Where(s => s.CHECKER.ToRequestString() == userId).FirstOrDefault();
            if (q != null && q.CHECKRESULT != null)
            {
                if (q.CHECKRESULT == (int)CheckResultType.不同意)
                {
                    html += "<img src='/Resources/OA/site_skin/default/icons/unpass.png' title='审核不通过' style='vertical-align:middle;'>";
                }
                else
                {
                    string result = ((CheckResultType)Enum.Parse(typeof(CheckResultType), q.CHECKRESULT.ToString())).ToString();
                    html += "<img src='/Resources/OA/site_skin/default/icons/pass.png' title='" + result + "' style='vertical-align:middle;'>";
                }
            }
            return html;
        }

        /// <summary>
        /// 获取当前的状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetStatus(object obj)
        {
            ProjectZbwjshModel model = obj as ProjectZbwjshModel;
            string sName = string.Empty;
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            switch (model.PRTSTATUS.ToRequestString())
            {
                case "0":
                    //sName = ProjectCheckService.GetCheckProcess(model.RPTID,
                    //    new int[] { model.SHR.ToInt(),model.SPR.ToInt() });
                    sName = "待审核";
                    break;
                case "1":
                    sName = "审核通过";
                    break;
                case "2":
                    sName = "审核不通过";
                    break;
                case "3":
                    sName = "打印完成";
                    break;
            }
            return sName;
        }

        #endregion


        #region 审核流程相关 ToAUDITOR

        /// <summary>
        /// 审核意见提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtnAudit_Click(object sender, EventArgs e)
        {
            //为避免重复提交数据，只有状态=0(状态=0表示等待审核) 的时候才发送审核消息
            RptModel = rptSrv.GetList().Where(w => w.PROJID == ProjectId).FirstOrDefault(p => p.RPTID == rptId);
            //创建一个审核消息
            if (RptModel != null && RptModel.PRTSTATUS == 0)
            {
                ProjectCheckService checkSrv = new ProjectCheckService();
                ProjectCheckModel checkModel = new ProjectCheckModel();
                checkModel.DB_Option_Action = WebKeys.InsertAction;
                checkModel.CHECKID = CommonTool.GetPkId();
                checkModel.CHECKER = this.userModel.USERID;
                checkModel.CHECKORDER = 1;
                checkModel.CHECKSTATUS = 1;//审核状态 0未审 1已审
                checkModel.CHECKRESULT = UC_DoShenhe.CHECKRESULT.ToInt(); //审核结果 1通过 0未通过
                checkModel.CHECKOPINION = UC_DoShenhe.CHECKOPINION;
                checkModel.PROJID = RptModel.PROJID;
                checkModel.ASSOCIATEDID = RptModel.RPTID;
                checkModel.SENDDATE = DateTime.Now;
                checkModel.SENDER = RptModel.SUBMITTER;
                checkModel.CHECKDATE = DateTime.Now;
                //checkModel.CHECKATTCH = UC_DoShenhe.CHECKATTCH;//审核附件
                //checkModel.CHECKSCORE = UC_DoShenhe.CHECKSCORE.ToInt();//审核得分
                if (checkSrv.Execute(checkModel))
                {
                    if (checkModel.CHECKRESULT == (int)CheckResultType.不同意)
                    {
                        //质量分
                        //RptModel.QUALITYSCORE = 0;
                        //当前状态
                        RptModel.PRTSTATUS = 2;
                        RptModel.SHR = this.userModel.USERID;
                        RptModel.DB_Option_Action = WebKeys.UpdateAction;
                        rptSrv.Execute(RptModel);
                        BfMsgService bs = new BfMsgService();
                        var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == RptModel.RPTID);
                        foreach (var q in l)
                        {
                            //q.DB_Option_Action = WebKeys.DeleteAction;
                            //bs.ExecuteUnhandle(q);
                            BfMsgService.UpdateMsgOver(q.BF_MSGID);
                        }

                    }
                    else
                    {
                        //ProjectInfoService infoSrv = new ProjectInfoService();
                        //RptModel.PRTSTATUS = 1;
                        //RptModel.DB_Option_Action = WebKeys.UpdateAction;
                        //if (rptSrv.Execute(RptModel))
                        //{
                        //    var pj = infoSrv.GetList().FirstOrDefault(f => f.PROJID == ProjectId);
                        //    pj.STATUS = 3;
                        //    pj.DB_Option_Action = WebKeys.UpdateAction;
                        //    infoSrv.Execute(pj);
                        //}
                        RptModel.PRTSTATUS = 0;
                        RptModel.SHR = this.userModel.USERID;
                        RptModel.DB_Option_Action = WebKeys.UpdateAction;
                        if (rptSrv.Execute(RptModel))
                        {
                            BfMsgService bs = new BfMsgService();
                            var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == RptModel.RPTID);
                            foreach (var q in l)
                            {
                                //q.DB_Option_Action = WebKeys.DeleteAction;
                                //bs.ExecuteUnhandle(q);
                                BfMsgService.UpdateMsgOver(q.BF_MSGID);
                            }
                            sendMessageToAPPROVER(RptModel);
                        }
                    }
                    //关闭待办
                    //BfMsgService.UpdateMsgOver(MsgID);
                }

                Utility.ShowMsg(this.Page, "系统提示", "审核操作完成!", "/TodoIndexBox.aspx");
            }
            else
            {
                //关闭待办
                BfMsgService.UpdateMsgOver(MsgID);

                Utility.ShowMsg(this.Page, "系统提示", "已审核的信息，无法操作", "/TodoIndexBox.aspx");
            }
        }

        #endregion


        #region 审批流程相关 ToAPPROVER

        /// <summary>
        /// 给审批人发送待办事务
        /// </summary>
        private string sendMessageToAPPROVER(ProjectZbwjshModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            IList<SysUserModel> list = new List<SysUserModel>();
            SysUserService suer = new SysUserService();
            SysDutyService sd = new SysDutyService();
            SysDutyModel dm = sd.GetList().Where(p => p.DNAME == "招投办招标文件审批").FirstOrDefault();
            SysUserDutyService Service = new SysUserDutyService();
            IList<SysUserDutyModel> dutylist = null;
            if (dm != null) dutylist = Service.GetList().Where(p => p.DUTYID == dm.DUTYID).ToList();
            foreach (var item in dutylist)
            {
                bfCtrl.SendNotificationMessage(
                    model.RPTID,//和项目关联的消息
                    item.USERID.ToInt(),//接收人
                    this.userModel,//当前用户
                    string.Format("{0}-招标文件已提交，需要您进行审批!", ProjectInfoService.GetProjectName(model.PROJID)),//消息标题
                    string.Format("/Modules/App/Project/ZbwjReportAudit.aspx?Cmd=Sign&ProjectId={0}&RPTID={1}&NodeCode={2}", model.PROJID, model.RPTID, NodeCode),//消息内容
                    BFRemindWay.MSG.ToString(), false);
            }
            return msg;
        }

        /// <summary>
        /// 审批人操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtnApprover_Click(object sender, EventArgs e)
        {
            //为避免重复提交数据，只有状态=0(状态=0表示等待审核) 的时候才发送审核消息
            RptModel = rptSrv.GetList().Where(w => w.PROJID == ProjectId).FirstOrDefault(p => p.RPTID == rptId);
            //创建一个审批消息
            if (RptModel != null && RptModel.PRTSTATUS == 0)
            {
                ProjectCheckService checkSrv = new ProjectCheckService();
                ProjectCheckModel checkModel = new ProjectCheckModel();
                checkModel.DB_Option_Action = WebKeys.InsertAction;
                checkModel.CHECKID = CommonTool.GetPkId();
                checkModel.CHECKER = this.userModel.USERID;
                checkModel.CHECKORDER = 2;
                checkModel.CHECKSTATUS = 1;//审核状态 0未审 1已审
                checkModel.CHECKRESULT = UC_DoShenhe.CHECKRESULT.ToInt(); //审核结果 1通过 0未通过
                checkModel.CHECKOPINION = UC_DoShenhe.CHECKOPINION;
                checkModel.PROJID = RptModel.PROJID;
                checkModel.ASSOCIATEDID = RptModel.RPTID;
                checkModel.SENDDATE = DateTime.Now;
                checkModel.SENDER = RptModel.SHR;
                checkModel.CHECKDATE = DateTime.Now;
                if (checkSrv.Execute(checkModel))
                {
                    string msg = string.Empty;
                    if (checkModel.CHECKRESULT == (int)CheckResultType.不同意)
                    {
                        //不同意
                        msg = string.Format("您请交的“{0}”的{1}审批未通过!请及时登录平台修改后再提交!",
                            ProjectInfoService.GetProjectName(ProjectId), "招标文件");
                        //质量分
                        //当前状态
                        RptModel.PRTSTATUS = 2;
                        RptModel.SPR = this.userModel.USERID;
                        RptModel.DB_Option_Action = WebKeys.UpdateAction;
                        if (rptSrv.Execute(RptModel))
                        {
                            ProjectInfoService infoSrv = new ProjectInfoService();
                            var pj = infoSrv.GetList().FirstOrDefault(f => f.PROJID == ProjectId);
                            pj.STATUS = 3;
                            pj.DB_Option_Action = WebKeys.UpdateAction;
                            infoSrv.Execute(pj);
                            BfMsgService bs = new BfMsgService();
                            var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == RptModel.RPTID);
                            foreach (var q in l)
                            {
                                //q.DB_Option_Action = WebKeys.DeleteAction;
                                //bs.ExecuteUnhandle(q);
                                BfMsgService.UpdateMsgOver(q.BF_MSGID);
                            }
                        }
                    }
                    else
                    {
                        RptModel.PRTSTATUS = 1;
                        RptModel.SPR = this.userModel.USERID;
                        RptModel.DB_Option_Action = WebKeys.UpdateAction;
                        if (rptSrv.Execute(RptModel))
                        {
                            ProjectInfoService infoSrv = new ProjectInfoService();
                            var pj = infoSrv.GetList().FirstOrDefault(f => f.PROJID == ProjectId);
                            pj.STATUS = 3;
                            pj.DB_Option_Action = WebKeys.UpdateAction;
                            infoSrv.Execute(pj);

                            //ProjectBhService bhSrv = new ProjectBhService();
                            //ProjectBhModel bh = new ProjectBhModel();
                            ////bh = bhSrv.GetList().FirstOrDefault(f=>f.PROJID==ProjectId);
                            ////if (bh != null) { 
                            ////    bh.DB_Option_Action = WebKeys.DeleteAction;
                            ////    bhSrv.Execute(bh);
                            ////}
                            //string sql = @"select xid,year,xh,lpad(xh,'4','0') bh,projid,1 rk from app_project_bh where year=" + DateTime.Now.Year + " and projid='"+ProjectId+"' union select * from (select sys_guid()||'' xid,year,xh+1 xh,lpad(xh+1,'4','0') bh,projid,2 rk from app_project_bh where year=" + DateTime.Now.Year + " order by xh desc) order by rk,xh desc";
                            ////string sql = @"select sys_guid() xid,year,xh+1 xh,lpad(xh+1,'4','0') bh,projid from app_project_bh where year=" + DateTime.Now.Year + " order by xh desc";
                            //bh = bhSrv.GetListBySQL(sql).FirstOrDefault();
                            ////bh.XID = Guid.NewGuid().ToRequestString();
                            //bh.PROJID = ProjectId;
                            //bh.DB_Option_Action = WebKeys.InsertAction;
                            //try
                            //{
                            //    bhSrv.Execute(bh);
                            //}
                            //catch (Exception ee) { 
                            
                            //}
                            //pj.PROJNUMBER = "川气东送" + bh.YEAR.ToRequestString() + "招字第" + bh.BH.ToRequestString() + "号";
                            //infoSrv.Execute(pj);
                            //ProjectZbwjService zbwjSh = new ProjectZbwjService();
                            //ProjectZbwjModel zbwjM = zbwjSh.GetList().FirstOrDefault(f=>f.PROJID==ProjectId);
                            //if (zbwjM == null)
                            //{
                            //    zbwjM = new ProjectZbwjModel();
                            //    zbwjM.PROJID = ProjectId;
                            //    zbwjM.P9 = bh.YEAR.ToRequestString();
                            //    zbwjM.P10 = bh.BH.ToRequestString();
                            //    zbwjM.DB_Option_Action = WebKeys.InsertAction;

                            //}
                            //else {
                            //    zbwjM.P9 = bh.YEAR.ToRequestString();
                            //    zbwjM.P10 = bh.BH.ToRequestString();
                            //    zbwjM.DB_Option_Action = WebKeys.UpdateAction;
                            //}
                            //zbwjSh.Execute(zbwjM);
                            ////ZbwjService.CreateZbwj2(ProjectId, bh.BH.ToRequestString());

                            BfMsgService bs = new BfMsgService();
                            var l = bs.GetUnhandleList().Where(p => p.BF_INSTANCEID == RptModel.RPTID);
                            foreach (var q in l)
                            {
                                //q.DB_Option_Action = WebKeys.DeleteAction;
                                //bs.ExecuteUnhandle(q);
                                BfMsgService.UpdateMsgOver(q.BF_MSGID);
                            }
                        }
                    }
                    //给提交人发送消息    

                    //关闭待办
                    //BfMsgService.UpdateMsgOver(MsgID);
                }

                Utility.ShowMsg(this.Page, "系统提示", "审核操作完成!", "/TodoIndexBox.aspx");
            }
            else
            {
                //关闭待办
                BfMsgService.UpdateMsgOver(MsgID);

                Utility.ShowMsg(this.Page, "系统提示", "已审核的信息，无法操作", "/TodoIndexBox.aspx");
            }

        }

        #endregion ToAPPROVER

    }
}