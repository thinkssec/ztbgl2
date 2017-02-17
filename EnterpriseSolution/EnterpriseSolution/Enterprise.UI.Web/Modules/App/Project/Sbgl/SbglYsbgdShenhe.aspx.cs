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
using Enterprise.Component.BF;


namespace Enterprise.UI.Web.Modules.App.Project.Sbgl
{

    /// <summary>
    /// 设备管理-验收报告单审核
    /// </summary>
    public partial class SbglYsbgdShenhe : BasePage
    {

        /// <summary>
        /// 服务类
        /// </summary>
        SbglYsbgdService ysbgdSrv = new SbglYsbgdService();
        /// <summary>
        /// 数据表
        /// </summary>
        protected List<SbglYsbgdModel> DataList = new List<SbglYsbgdModel>();

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
            //年度
            Ddl_Year.Items.Clear();
            for (int i = DateTime.Now.Year; i >= 2015; i--)
            {
                Ddl_Year.Items.Add(new ListItem(i + "年", i.ToString()));
            }
            Ddl_Year.SelectedValue = DateTime.Now.Year.ToString();
            //月度
            Ddl_Month.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                Ddl_Month.Items.Add(new ListItem(i + "月份", CommonTool.BuZero_2(i)));
            }
            Ddl_Month.Items.Insert(0, new ListItem("全年", ""));
            //Ddl_Month.SelectedValue = CommonTool.BuZero_2(DateTime.Now.Month);
        }

        private void OnBindData()
        {
            DataList = ysbgdSrv.GetListByJFRQ(Ddl_Year.SelectedValue, Ddl_Month.SelectedValue) as List<SbglYsbgdModel>;
            var ysbgdList = DataList.DistinctBy(p => p.BGDPH).OrderByDescending(p => p.BGDPH).ToList();
            AspNetPager1.RecordCount = ysbgdList.Count;
            AspNetPager1.PageSize = 15;
            GridView1.DataSource = ysbgdList.Skip(AspNetPager1.StartRecordIndex - 1).Take(AspNetPager1.PageSize).ToList();
            GridView1.DataBind();
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
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Save_Click(object sender, EventArgs e)
        {
            string data = Server.UrlDecode(HDData.Value);
            //对象封装方式
            ArrayList insertLst = SupCanTool.GetInsertModels(data, typeof(SbglYsbgdModel));
            ArrayList updateLst = SupCanTool.GetUpdateModels(data, typeof(SbglYsbgdModel));
            //string updSQL = SupCanTool.UpdateSQL(data, "", typeof(SbglYsbgdModel));
            string delSQL = SupCanTool.DeleteSQL(data, "", typeof(SbglYsbgdModel));
            //if (!string.IsNullOrEmpty(updSQL)) ysbgdSrv.ExecuteSQL(updSQL);
            if (!string.IsNullOrEmpty(delSQL)) ysbgdSrv.ExecuteSQL(delSQL);
            if (insertLst.Count > 0)
            {
                var lst = insertLst.Cast<SbglYsbgdModel>().ToList();
                foreach (var q in lst)
                {
                    q.DB_Option_Action = WebKeys.InsertAction;
                    q.BGDID = CommonTool.GetGuidKey();
                    q.YSFJ = Txt_YSFJ.Value;
                }
                ysbgdSrv.ExecuteListByAction(lst, WebKeys.InsertAction);
                Utility.ShowTopMsg(Page, "提示", "数据保存成功!", 80, "show");
            }
            if (updateLst.Count > 0)
            {
                var lst = updateLst.Cast<SbglYsbgdModel>().ToList();
                foreach (var q in lst)
                {
                    q.DB_Option_Action = WebKeys.UpdateAction;
                    q.YSFJ = Txt_YSFJ.Value;
                }
                ysbgdSrv.ExecuteListByAction(lst, WebKeys.UpdateAction);
                Utility.ShowTopMsg(Page, "提示", "数据保存成功!", 80, "show");
            }
        }

        /// <summary>
        /// 生成维修批号并提交领导审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Scwxph_Click(object sender, EventArgs e)
        {
            string data = Server.UrlDecode(HDData.Value);
            //对象封装方式
            ArrayList updateLst = SupCanTool.GetUpdateModels(data, typeof(SbglYsbgdModel));
            if (updateLst.Count > 0)
            {
                var lst = updateLst.Cast<SbglYsbgdModel>().ToList();
                string ysph = CommonTool.GetPkId();//验收批号
                if (lst.Count > 0 && !string.IsNullOrEmpty(lst.First().BGDPH))
                {
                    ysph = lst.First().BGDPH;
                }
                foreach (var q in lst)
                {
                    q.DB_Option_Action = WebKeys.UpdateAction;
                    q.BGDPH = ysph;
                }
                if (ysbgdSrv.ExecuteListByAction(lst, WebKeys.UpdateAction))
                {
                    //给分管领导发送待办
                    ProjectCheckService checkSrv = new ProjectCheckService();
                    checkSrv.DeleteModelsByAssociateID(ysph);
                    ProjectCheckModel checkModel = new ProjectCheckModel();
                    checkModel.DB_Option_Action = WebKeys.InsertAction;
                    checkModel.CHECKID = CommonTool.GetGuidKey();
                    checkModel.CHECKER = SysUserService.GetDutyUserId(0, "生产安全副经理");
                    checkModel.CHECKORDER = 1;
                    checkModel.CHECKSTATUS = 0;//审核状态 0未审 1已审
                    checkModel.ASSOCIATEDID = ysph;
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
                            string.Format("{0}，需要您进行审核!", "设备维修验收报告单"),//消息标题
                            string.Format("/Modules/App/Project/Sbgl/SbglYsbgdShAudit.aspx?Cmd=Audit&PH={0}", ysph),//消息内容
                            "", false);
                        Utility.ShowTopMsg(Page, "提示", "已提交领导审核!", 80, "show");
                    }
                    OnBindData();
                }
            }
        }

        /// <summary>
        /// 维修批号审批绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SbglYsbgdModel model = e.Row.DataItem as SbglYsbgdModel;
                //验收批号
                e.Row.Cells[0].Text = string.Format("<a href=\"#\" onclick=\"javascript:showData('{0}');\">{1}</a>", model.BGDPH, model.BGDPH);
                //维修单位
                e.Row.Cells[1].Text = SbglWxdwService.GetCjmcByBm(model.WXDW);
                //设备数量
                e.Row.Cells[2].Text = DataList.Count(p => p.BGDPH == model.BGDPH).ToRequestString();
                //维修费用(元)
                e.Row.Cells[3].Text = DataList.Where(p => p.BGDPH == model.BGDPH).Sum(p => p.SBZJ).ToRequestString();
                //验收附件
                e.Row.Cells[4].Text = model.YSFJ.ToAttachHtmlByOne();
                //审核状态
                e.Row.Cells[5].Text = ProjectCheckService.GetCheckProcess(model.BGDPH);
                e.Row.Cells[5].ToolTip = ProjectCheckService.GetCheckProcessResult(model.BGDPH);

            }
        }


        /// <summary>
        /// 分页控件-页面变化事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            OnBindData();
        }

    }
}