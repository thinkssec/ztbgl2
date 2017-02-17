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
    /// 检测报告页面
    /// </summary>
    public partial class ZbwjReport2 : BasePage
    {

        /// <summary>
        /// 报告ID
        /// </summary>
        string rptId = (string)Utility.sink("RPTID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string baogaom = (string)Utility.sink("baogaom", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 检测报告---服务类
        /// </summary>
        ProjectZbwjfjService rptSrv = new ProjectZbwjfjService();
        ProjectInfoService pSrv=new ProjectInfoService();
        /// <summary>
        /// 检测报告MODEL
        /// </summary>
        ProjectZbwjfjModel RptModel{ get; set; }


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

           

            //如果是新增
            if (Cmd == "New")
            {
                ProjectInfoModel pInfo = pSrv.GetList().Where(w=>w.PROJID==ProjectId).FirstOrDefault();
                Pnl_Edit.Visible = true;
                
            }
            //如果是编辑
            if (Cmd == "Edit")
            {
                Pnl_Edit.Visible = true;
                ProjectInfoModel pInfo = pSrv.GetList().Where(w=>w.PROJID==ProjectId).FirstOrDefault();
                RptModel = rptSrv.GetList().Where(w=>w.PROJID==ProjectId).FirstOrDefault(p => p.RPTID == rptId);
                
                //未审核和审核不能过的可以进行修改
                if (RptModel != null && (RptModel.PRTSTATUS == 0 || RptModel.PRTSTATUS == 2))
                {
                    Hid_RPTID.Value = RptModel.RPTID;
                    Txt_MEMO.Text = RptModel.MEMO;
                    //Txt_SHR.SelectedValue = RptModel.SHR.ToRequestString();
                    Txt_RPTNAME.Text = RptModel.RPTNAME;
                    //single_RcvUsers.UserSelectValue = RptModel.SHR.ToRequestString();
                    Txt_ATTACHMENT.Text = RptModel.ATTACHMENT.Split('*')[0];
                    Txt_ATTACHMENT.Value = RptModel.ATTACHMENT.Split('*')[1];
                    //Txt_APPROVER.Text = RptModel.APPROVER.ToRequestString();
                    //Txt_RPTDATE.Text = RptModel.RPTDATE.ToDateYMDFormat();
                }
                else
                {
                    Utility.ShowMsg(this.Page, "系统提示", "数据已不允许编辑(审核通过或打印完成)", "ZbwjReport2.aspx?ProjectId=" + ProjectId + "&NodeCode=" + NodeCode);
                }
            }
            //如果是删除
            if (Cmd == "Delete")
            {
                RptModel = rptSrv.GetList().Where(w=>w.PROJID==ProjectId).FirstOrDefault(p => p.RPTID == rptId);
                //未审核和审核不能过的可以删除
                if (RptModel != null && (RptModel.PRTSTATUS == 0 || RptModel.PRTSTATUS == 2))
                {
                    RptModel.DB_Option_Action = WebKeys.DeleteAction;
                    rptSrv.Execute(RptModel);
                    Utility.ShowMsg(this.Page, "系统提示", "删除成功", "ZbwjReport2.aspx?ProjectId=" + ProjectId + "&NodeCode=" + NodeCode);
                }
                else
                {
                    Utility.ShowMsg(this.Page, "系统提示", "数据已不允许编辑(审核通过或打印完成)", "ZbwjReport2.aspx?ProjectId=" + ProjectId + "&NodeCode=" + NodeCode);
                }
            }
        }

        /// <summary>
        /// 绑定操作权限
        /// </summary>
        private void OnCommand()
        {
            Txt_ATTACHMENT.Attributes.Add("readonly", "true");
            ProjectInfoModel pInfo = pSrv.GetList().Where(w => w.PROJID == ProjectId).FirstOrDefault();

            ProjectInfoService ppps = new ProjectInfoService();
            ProjectInfoModel ppp = ppps.GetList().FirstOrDefault(f => f.PROJID == ProjectId);
            ProjectPszjService ps = new ProjectPszjService();
            bool t = false;
            List<ProjectPszjModel> l = ps.GetList().Where(w => w.PROJID == ProjectId && w.LB == 5 && w.PERSONID == this.userModel.USERID.ToRequestString()).ToList();
            t = l.Count > 0;
            if (pInfo.SUBMITTER==this.userModel.USERID||t)
            {
                CreateBT.AddButton("new.gif", "新增", "ZbwjReport2.aspx?Cmd=New&ProjectId=" + ProjectId + "&NodeCode=" + NodeCode, Utility.PopedomType.List, HeadMenu1);
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
            }
            else
            {
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
            }
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindGrid()
        {
            IList<ProjectZbwjfjModel> list = rptSrv.GetList().Where(w=>w.PROJID==ProjectId).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        #endregion

        #region 提交检测报告
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string msg = "保存成功";
            if (!string.IsNullOrEmpty(Hid_RPTID.Value))
            {
                RptModel = rptSrv.GetList().Where(w=>w.PROJID==ProjectId).FirstOrDefault(p => p.RPTID == Hid_RPTID.Value);
                RptModel.DB_Option_Action = WebKeys.UpdateAction;
            }
            else
            {
                RptModel = new ProjectZbwjfjModel();
                RptModel.RPTID = Guid.NewGuid().ToString();
                RptModel.PROJID = ProjectId;
                RptModel.DB_Option_Action = WebKeys.InsertAction;
            }

            //RptModel.RPTNAME = Txt_RPTNAME.Text;
            //RptModel.SHR = single_RcvUsers.UserSelectValue.ToInt();
            //RptModel.SHR = Txt_SHR.SelectedValue.ToInt();
            //RptModel.SHR = single_RcvUsers.UserSelectValue.ToInt();
            //RptModel.SPR = Txt_SPR.SelectedValue.ToInt();
            RptModel.RPTNAME = Txt_RPTNAME.Text;
            RptModel.MEMO = Txt_MEMO.Text;
            RptModel.ATTACHMENT = Txt_ATTACHMENT.DBValue;
            RptModel.PRTSTATUS = 0;//添加 更新 操作后都要重新审核
            //RptModel.APPROVER = Txt_APPROVER.Text.ToInt();
            RptModel.SUBMITTER = userModel.USERID;
            RptModel.SUBMITDATE = DateTime.Now;
            if (rptSrv.Execute(RptModel))
            {
               
            }
            Utility.ShowMsg(this.Page, "系统提示", msg, "ZbwjReport2.aspx?ProjectId=" + ProjectId + "&NodeCode=" + NodeCode);
        }

        /// <summary>
        /// 给审核人发送待办事务
        /// </summary>
       

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
        /// 生成操作按钮
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected string GetCommandBtn(object obj)
        {
            //说明：1=审核中和审核通过的数据不允许编辑操作 2=审核不通过的数据才能编辑 3=审核通过和打印状态的数据才能打印
            ProjectZbwjfjModel model = obj as ProjectZbwjfjModel;
            string btnStrs = string.Empty;
            btnStrs += string.Format("<a href='ZbwjReport2.aspx?Cmd=Edit&ProjectId={0}&RPTID={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\"/></a>", ProjectId, model.RPTID, NodeCode);
            btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZbwjReport2.aspx?Cmd=Delete&ProjectId={0}&RPTID={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", ProjectId, model.RPTID, NodeCode);
            //else if (model.PRTSTATUS == 1 || model.PRTSTATUS == 3)
            //{
            //    if (btnStrs != "") btnStrs += "&nbsp;&nbsp;|&nbsp;&nbsp;";
            //    if (!model.RPTID.ChkUrlFileIsExists(model.RPTNAME, model.RPTDATE.ToDateTime().Year))
            //    {
            //        btnStrs += string.Format("<a href='ZbwjReport2.aspx?Cmd=Print&ProjectId={0}&RPTID={1}&NodeCode={2}'><img alt=\"\" src=\"/Resources/Styles/icon/print.gif\" border=\"0\"/></a>", ProjectId, model.RPTID, NodeCode);
            //    }
            //    else
            //    {
            //        btnStrs += model.RPTID.ToDownloadHtmlByOne(model.RPTNAME, model.RPTDATE.ToDateTime().Year);
            //    }
            //}
            return btnStrs;
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
            ProjectZbwjfjModel model = obj as ProjectZbwjfjModel;
            string sName = string.Empty;
            //0=未审核 1=审核通过  2=审核不通过  3=打印完成
            switch (model.PRTSTATUS.ToRequestString())
            {
                case "0":
                    sName = ProjectCheckService.GetCheckProcess(model.RPTID,
                        new int[] { model.SHR.ToInt(), model.SPR.ToInt() });
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
 
    }
}