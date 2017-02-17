using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using Enterprise.Service.Basis;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Crm;
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Service.App.Examine;

namespace Enterprise.UI.Web.Modules.App.Project.Sbgl
{

    /// <summary>
    /// 设备管理动态首页面
    /// </summary>
    public partial class SbglIndexView : BasePage
    {

        #region 初始化参数区

        ///// <summary>
        ///// 项目信息MODEL
        ///// </summary>
        //protected ProjectInfoModel ProjectModel = null;
        ///// <summary>
        ///// 项目审核信息MODEL
        ///// </summary>
        //protected ProjectCheckModel CheckModel = null;

        /// <summary>
        /// 日报时间
        /// </summary>
        public DateTime ReportDay { get; set; }

        /// <summary>
        /// by pengwei
        /// 当前项目已有日报的天数
        /// </summary>
        public string ReportedDays = "";

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            bindCondition();

            if (!IsPostBack)
            {
                //接收参数
                string p = Request.QueryString["Day"].ToRequestString();
                if (p == "")
                {
                    ReportDay = DateTime.Now.ToShortDateString().ToDateTime();
                }
                else
                    ReportDay = p.ToDateTime();

                InitData();
            }

        }

        #region 页面方法区

        /// <summary>
        /// 绑定条件
        /// </summary>
        private void bindCondition()
        {
            ////项目组成员都能录入
            //if (ProjectMemberService.IsTeamMember(ProjectId, userModel, null))
            //{
            //    CreateBT.AddButton("new.gif", "录入日报", "Daily/ProjectDaily.aspx?ProjectId=" + ProjectId + "&Day=" + DateTime.Now.ToShortDateString(), Utility.PopedomType.New, HeadMenu1);
            //    //CreateBT.AddButton("new.gif", "测试", "/Error.aspx?msg=这是个测试了", Utility.PopedomType.New, HeadMenu1);
            //}
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {

            #region 项目基础信息



            #endregion


            #region 为前端准备数据 将已存在的日报日期变色

            #endregion
        }

        #endregion

        //#region 数据提取方法区>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        //#region 工作量完成情况

        ///// <summary>
        ///// 提取指定项目的工作量完成情况
        ///// </summary>
        ///// <returns></returns>
        //protected string GetRwgzlTable()
        //{
        //    StringBuilder tableSB = new StringBuilder();
        //    ProjectRwchService rwchSrv = new ProjectRwchService();
        //    var pInfo = ProjectInfoService.GetProjectInfoModel(ProjectId);
        //    if (pInfo.KINDID == 1 || pInfo.ExamineKind.PARENTID == 1)
        //    {
        //        //无损检测日报
        //        IList<ProjectRwchModel> list = rwchSrv.GetListByProjectId(ProjectId);
        //        tableSB.Append("<tr><th>设施类型</th><th>专业名称</th><th>单位</th><th>任务状态</th><th>委托工程量</th><th>完成工程量</th><th>剩余工程量</th><th>累计完成进度</th></tr>");
        //        foreach (var q in list)
        //        {
        //            tableSB.Append("<tr>");
        //            tableSB.Append("<td>" + GetProcessName(q.BJDM, 5) + "</td>");
        //            tableSB.Append("<td>" + q.ZYMC + "</td>");
        //            tableSB.Append("<td>" + q.DW + "</td>");
        //            tableSB.Append("<td>" + ((q.RWZT == 1) ? "已完成" : "未完成") + "</td>");
        //            decimal wtgzl = 0;
        //            if (q.RWZT == 1)
        //            {
        //                tableSB.Append("<td class='td-right'>" + q.SJGZL + "</td>");
        //                wtgzl = q.SJGZL.ToDecimal();
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class='td-right'><font color='red'>" + q.YJGZL + "</font></td>");
        //                wtgzl = q.YJGZL.ToDecimal();
        //            }
        //            decimal ljwcgzl = 0;
        //            decimal sygzl = 0;
        //            if (q.RwgzlList != null)
        //            {
        //                ljwcgzl = q.RwgzlList.Where(p => p.JYSJ <= ReportDay).Sum(p => p.WCGZL).Value;
        //                if (q.RWZT == 1)
        //                {
        //                    sygzl = q.SJGZL.ToDecimal() - ljwcgzl;
        //                }
        //                else
        //                {
        //                    sygzl = q.YJGZL.ToDecimal() - ljwcgzl;
        //                }
        //            }
        //            tableSB.Append("<td class='td-right'>" + ljwcgzl + "</td>");
        //            if (q.RWZT == 1)
        //            {
        //                tableSB.Append("<td class='td-right'>0</td>");
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class='td-right'><font color='red'>" + sygzl + "</font></td>");
        //            }
        //            int jd = 0;
        //            if (wtgzl > 0)
        //            {
        //                jd = Math.Round(ljwcgzl / wtgzl * 100).ToInt();
        //            }
        //            else
        //            {
        //                jd = 0;
        //            }
        //            if (list.Count > 150)
        //            {
        //                tableSB.Append("<td class=\"jindu\">" + jd + "%</td>");
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class=\"jindu\"><div class=\"easyui-progressbar\" data-options=\"value:" + jd + "\" style=\"width:400px;\"></div></td>");
        //            }
        //            tableSB.Append("</tr>");
        //        }
        //    }
        //    else if (pInfo.KINDID == 2 || pInfo.ExamineKind.PARENTID == 2)
        //    {
        //        //发证
        //        IList<ProjectRwchModel> list = rwchSrv.GetListByProjectId(ProjectId);
        //        tableSB.Append("<tr><th>分部工程</th><th>类型</th><th>工序</th><th>阶段划分</th><th>单位</th><th>任务状态</th><th>委托工程量</th><th>完成工程量</th><th>剩余工程量</th><th>累计完成进度</th></tr>");
        //        foreach (var q in list)
        //        {
        //            tableSB.Append("<tr>");
        //            tableSB.Append("<td>" + GetProcessName(q.BJDM, 7) + "</td>");
        //            tableSB.Append("<td>" + GetProcessName(q.BJDM, 9) + "</td>");
        //            tableSB.Append("<td>" + GetProcessName(q.BJDM, 11) + "</td>");
        //            tableSB.Append("<td>" + GetProcessName(q.BJDM, 13) + "</td>");
        //            tableSB.Append("<td>" + q.DW + "</td>");
        //            tableSB.Append("<td>" + ((q.RWZT == 1) ? "已完成" : "未完成") + "</td>");
        //            decimal wtgzl = 0;
        //            if (q.RWZT == 1)
        //            {
        //                tableSB.Append("<td class='td-right'>" + q.SJGZL + "</td>");
        //                wtgzl = q.SJGZL.ToDecimal();
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class='td-right'><font color='red'>" + q.YJGZL + "</font></td>");
        //                wtgzl = q.YJGZL.ToDecimal();
        //            }
        //            decimal ljwcgzl = 0;
        //            decimal sygzl = 0;
        //            if (q.RwgzlList != null)
        //            {
        //                ljwcgzl = q.RwgzlList.Where(p => p.JYSJ <= ReportDay).Sum(p => p.WCGZL).Value;
        //                if (q.RWZT == 1)
        //                {
        //                    sygzl = q.SJGZL.ToDecimal() - ljwcgzl;
        //                }
        //                else
        //                {
        //                    sygzl = q.YJGZL.ToDecimal() - ljwcgzl;
        //                }
        //            }
        //            tableSB.Append("<td class='td-right'>" + ljwcgzl + "</td>");
        //            if (q.RWZT == 1)
        //            {
        //                tableSB.Append("<td class='td-right'>0</td>");
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class='td-right'><font color='red'>" + sygzl + "</font></td>");
        //            }
        //            int jd = 0;
        //            if (wtgzl > 0)
        //            {
        //                jd = Math.Round(ljwcgzl / wtgzl * 100).ToInt();
        //            }
        //            else
        //            {
        //                jd = 0;
        //            }
        //            if (list.Count > 150)
        //            {
        //                tableSB.Append("<td class=\"jindu\">" + jd + "%</td>");
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class=\"jindu\"><div class=\"easyui-progressbar\" data-options=\"value:" + jd + "\" style=\"width:400px;\"></div></td>");
        //            } 
        //            tableSB.Append("</tr>");
        //        }
        //    }
        //    else if ((pInfo.KINDID == 3 || pInfo.KINDID == 4 || pInfo.KINDID == 5) ||
        //        (pInfo.ExamineKind.PARENTID == 3 || pInfo.ExamineKind.PARENTID == 4 || pInfo.ExamineKind.PARENTID == 5))
        //    {
        //        //产品
        //        IList<ProjectRwchModel> list = rwchSrv.GetListByProjectId(ProjectId);
        //        tableSB.Append("<tr><th>设施类型</th><th>工作内容</th><th>单位</th><th>任务状态</th><th>委托工程量</th><th>完成工程量</th><th>剩余工程量</th><th>累计完成进度</th></tr>");
        //        foreach (var q in list)
        //        {
        //            tableSB.Append("<tr>");
        //            tableSB.Append("<td>" + GetProcessName(q.BJDM, 5) + "</td>");
        //            tableSB.Append("<td>" + q.GZNR + "</td>");
        //            tableSB.Append("<td>" + q.DW + "</td>");
        //            tableSB.Append("<td>" + ((q.RWZT == 1) ? "已完成" : "未完成") + "</td>");
        //            decimal wtgzl = 0;
        //            if (q.RWZT == 1)
        //            {
        //                tableSB.Append("<td class='td-right'>" + q.SJGZL + "</td>");
        //                wtgzl = q.SJGZL.ToDecimal();
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class='td-right'><font color='red'>" + q.YJGZL + "</font></td>");
        //                wtgzl = q.YJGZL.ToDecimal();
        //            }
        //            decimal ljwcgzl = 0;
        //            decimal sygzl = 0;
        //            if (q.RwgzlList != null)
        //            {
        //                ljwcgzl = q.RwgzlList.Where(p => p.JYSJ <= ReportDay).Sum(p => p.WCGZL).Value;
        //                if (q.RWZT == 1)
        //                {
        //                    sygzl = q.SJGZL.ToDecimal() - ljwcgzl;
        //                }
        //                else
        //                {
        //                    sygzl = q.YJGZL.ToDecimal() - ljwcgzl;
        //                }
        //            }
        //            tableSB.Append("<td class='td-right'>" + ljwcgzl + "</td>");
        //            if (q.RWZT == 1)
        //            {
        //                tableSB.Append("<td class='td-right'>0</td>");
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class='td-right'><font color='red'>" + sygzl + "</font></td>");
        //            }
        //            int jd = 0;
        //            if (wtgzl > 0)
        //            {
        //                jd = Math.Round(ljwcgzl / wtgzl * 100).ToInt();
        //            }
        //            else
        //            {
        //                jd = 0;
        //            }
        //            if (list.Count > 150)
        //            {
        //                tableSB.Append("<td class=\"jindu\">" + jd + "%</td>");
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class=\"jindu\"><div class=\"easyui-progressbar\" data-options=\"value:" + jd + "\" style=\"width:400px;\"></div></td>");
        //            }
        //            tableSB.Append("</tr>");
        //        }
        //    }

        //    return tableSB.ToString();
        //}


        ///// <summary>
        ///// 返回设施类型
        ///// </summary>
        ///// <param name="bjdm"></param>
        ///// <returns></returns>
        //protected string GetProcessName(string bjdm, int digit)
        //{
        //    string pName = "";
        //    if (!string.IsNullOrEmpty(bjdm))
        //    {
        //        if (bjdm.Length >= digit)
        //        {
        //            pName = ExamineProcessService.GetProcessName(bjdm.Substring(0, digit));
        //        }
        //    }
        //    return pName;
        //}

        //#endregion


        //#region 项目收入与每周产值情况

        ///// <summary>
        ///// 获取指定项目的收入信息
        ///// </summary>
        ///// <returns></returns>
        //protected string GetShouruTable()
        //{
        //    /*
        //    <th>合同金额</th>
        //    <th>预计收入</th>
        //    <th>结算金额</th>
        //    <th>回款金额</th>
        //     */
        //    StringBuilder tableSB = new StringBuilder();
        //    //ProjectIncomeService incomeSrv = new ProjectIncomeService();
        //    //var incomeLst = incomeSrv.GetModelByProjectId(ProjectId);
        //    ProjectSettlementService settleSrv = new ProjectSettlementService();
        //    var jiesuanLst = settleSrv.GetSettlementListByProjectId(ProjectId, 1);
        //    var huikuanLst = settleSrv.GetSettlementListByProjectId(ProjectId, 2);
        //    var pInfo = ProjectInfoService.GetProjectInfoModel(ProjectId);

        //    tableSB.Append("<tr>");
        //    decimal incomeValue = pInfo.ProjectInComeAmount;
        //    if (incomeValue > 0)
        //    {
        //        tableSB.Append("<td><font color='red'>" + incomeValue + "</font></td>");//合同金额
        //    }
        //    else
        //    {
        //        tableSB.Append("<td><font color='red'>0</font></td>");//合同金额
        //    }
        //    tableSB.Append("<td>" + pInfo.PROJINCOME + "</td>");//预计收入
        //    if (jiesuanLst != null)
        //    {
        //        tableSB.Append("<td>" + jiesuanLst.Sum(p => p.AMOUNT) + "</td>");//结算金额
        //    }
        //    else
        //    {
        //        tableSB.Append("<td>0</td>");//结算金额
        //    }
        //    if (huikuanLst != null)
        //    {
        //        tableSB.Append("<td><font color='green'>" + huikuanLst.Sum(p => p.AMOUNT) + "</font></td>");//回款金额
        //    }
        //    else
        //    {
        //        tableSB.Append("<td><font color='green'>0</font></td>");//回款金额
        //    }
        //    tableSB.Append("</tr>");

        //    return tableSB.ToString();
        //}

        ///// <summary>
        ///// 获取项目所有每周产值
        ///// </summary>
        ///// <returns></returns>
        //protected string GetWeeklyProfit()
        //{
        //    StringBuilder tableSB = new StringBuilder();
        //    ProjectProfitService profitSrv = new ProjectProfitService();
        //    var profitLst = profitSrv.GetListByProjectId(ProjectId).OrderBy(p => p.ORDERBY).ToList();
        //    if (profitLst.Count > 0)
        //    {
        //        int skipRecords = profitLst.Count;
        //        if (skipRecords > 10)
        //        {
        //            skipRecords = skipRecords - 10;
        //        }
        //        else
        //        {
        //            skipRecords = 0;
        //        }
        //        profitLst = profitLst.Skip(skipRecords).Take(10).ToList();
        //        foreach (var q in profitLst)
        //        {
        //            tableSB.Append("<tr>");
        //            tableSB.Append("<td>第" + q.ORDERBY + "周</td>");
        //            tableSB.Append("<td>" + string.Format("{0}-{1}", q.STARTDATE.ToDateYMDFormat('.'), q.ENDDATE.ToDateYMDFormat('.')) + "</td>");
        //            tableSB.Append("<td>" + q.PROGRESS + "%</td>");
        //            tableSB.Append("<td class='td-right'>" + q.COMPLETEVALUE + "</td>");
        //            tableSB.Append("<td class='td-right'>" + q.SUMVALUE + "</td>");
        //            tableSB.Append("</tr>");
        //        }
        //    }
        //    else
        //    {
        //        tableSB.Append("<tr>");
        //        tableSB.Append("<td>第0周</td>");
        //        tableSB.Append("<td>无</td>");
        //        tableSB.Append("<td>0%</td>");
        //        tableSB.Append("<td class='td-right'>0</td>");
        //        tableSB.Append("<td class='td-right'>0</td>");
        //        tableSB.Append("</tr>");
        //    }

        //    return tableSB.ToString();
        //}

        //#endregion


        //#region 项目预算与成本情况


        ///// <summary>
        ///// 获取指定项目的预算与成本费用
        ///// </summary>
        ///// <returns></returns>
        //protected string GetBudgetAndCostTable()
        //{
        //    StringBuilder tableSB = new StringBuilder();
        //    /*
        //    <tr>
        //    <td>材料费</td>
        //    <td>13</td>
        //    <td>4</td>
        //    </tr>
        //     */
        //    ProjectPlanService planSrv = new ProjectPlanService();
        //    var plan = planSrv.GetPlanByProjectId(ProjectId);
        //    decimal hjBudgetSum = 0;
        //    decimal hjCostSum = 0;
        //    if (plan != null)
        //    {
        //        var costItemLst = plan.ProjectCostPlans;
        //        ProjectCostService costSrv = new ProjectCostService();
        //        var costLst = costSrv.GetListByProjectId(ProjectId);
        //        foreach (var q in costItemLst)
        //        {
        //            //分包和其他费用不计
        //            if (q.ExamineCostitem.ITEMCODE == "ITEM2" || q.ExamineCostitem.ITEMCODE == "ITEM7")
        //                continue;

        //            tableSB.Append("<tr>");
        //            tableSB.Append("<td>" + q.ExamineCostitem.ITEMNAME + "</td>");
        //            decimal budgetSum = Math.Round(q.AMOUNT) / 10000;//转为万元
        //            tableSB.Append("<td class='td-right'>" + budgetSum + "</td>");
        //            decimal costSum = costLst.Where(p => p.ExamineCostInfo.ITEMCODE == q.ITEMCODE).Sum(p => p.AMOUNT);//元
        //            costSum = Math.Round(costSum) / 10000;//转为万元
        //            if (costSum > budgetSum)
        //            {
        //                tableSB.Append("<td class='td-right'><font color='red'>" + costSum + "</font></td>");
        //            }
        //            else
        //            {
        //                tableSB.Append("<td class='td-right'>" + costSum + "</td>");
        //            }
        //            hjBudgetSum += budgetSum;//小计
        //            hjCostSum += costSum;//小计
        //            tableSB.Append("</tr>");
        //        }
        //    }
        //    else
        //    {
        //        tableSB.Append("<tr>");
        //        tableSB.Append("<td>无</td>");
        //        tableSB.Append("<td class='td-right'>0</td>");
        //        tableSB.Append("<td class='td-right'>0</td>");
        //        tableSB.Append("</tr>");
        //    }
        //    tableSB.Append("<tr>");
        //    tableSB.Append("<td><b>小计</b></td>");
        //    tableSB.Append("<td class='td-right'>" + hjBudgetSum + "</td>");
        //    tableSB.Append("<td class='td-right'>" + hjCostSum + "</td>");
        //    tableSB.Append("</tr>");
        //    return tableSB.ToString();
        //}


        //#endregion


        //#region 材料消耗情况

        ///// <summary>
        ///// 获取指定项目的材料消耗总量
        ///// </summary>
        ///// <returns></returns>
        //protected string GetMaterialTable()
        //{
        //    StringBuilder tableSB = new StringBuilder();
        //    ProjectMaterialService materailSrv = new ProjectMaterialService();
        //    var list = materailSrv.GetListByProjectId(ProjectId);
        //    var materials = (from l in list
        //                     group l by new { l.WLMC, l.WLDW }
        //                         into grouped
        //                         orderby grouped.Sum(m => m.SL)
        //                         select
        //                             new { grouped.Key.WLMC, grouped.Key.WLDW, SYL = grouped.Sum(m => m.SL) })
        //                                  .ToList();
        //    foreach (var q in materials)
        //    {
        //        tableSB.Append("<tr>");
        //        tableSB.Append("<td>" + q.WLMC + "</td>");
        //        tableSB.Append("<td>" + q.WLDW + "</td>");
        //        tableSB.Append("<td class='td-right'>" + q.SYL + "</td>");
        //        tableSB.Append("<td class='td-right'>&nbsp;</td>");
        //        tableSB.Append("<td class='td-right'>&nbsp;</td>");
        //        tableSB.Append("</tr>");
        //    }
        //    return tableSB.ToString();
        //}

        //#endregion


        //#region 项目组人员

        ///// <summary>
        ///// 获取指定项目的人员情况
        ///// </summary>
        ///// <returns></returns>
        //protected string GetMemberTable()
        //{
        //    /*
        //        * <tr>
        //    <td>人员类型</td>
        //    <td>总人数</td>
        //    <td>请假人次</td>
        //    <td>当月新增</td>
        //    <td>本月调离</td>
        //        * </tr>
        //        */
        //    StringBuilder tableSB = new StringBuilder();
        //    ProjectMemberService memSrv = new ProjectMemberService();
        //    var zhigongLst = memSrv.GetListByProjectId(ProjectId);//职工信息
        //    ProjectMbrattendanceService attendSrv = new ProjectMbrattendanceService();
        //    var kaoqinLst = attendSrv.GetListByProjectId(ProjectId);//考勤记录
        //    if (zhigongLst != null)
        //    {
        //        tableSB.Append("<tr>");
        //        tableSB.Append("<td><a style='text-decoration: underline;' href='ProjectTeamList.aspx?ProjectId=" + ProjectId + "' target='_blank'>职工</a></td>");
        //        tableSB.Append("<td>" + zhigongLst.Where(p => p.OFFPOSTDATE == null).ToList().Count + "</td>");
        //        if (kaoqinLst != null)
        //        {
        //            tableSB.Append("<td>" + kaoqinLst.Where(p => p.MBRPROPERTY == MemberProperty.职工.ToString() && p.RYDT == 3).Count() + "</td>");
        //            tableSB.Append("<td>" + kaoqinLst.Where(p => p.MBRPROPERTY == MemberProperty.职工.ToString() && p.RYDT == 2).Count() + "</td>");
        //        }
        //        else
        //        {
        //            tableSB.Append("<td>0</td>");
        //            tableSB.Append("<td>0</td>");
        //        }
        //        int addCount = zhigongLst.Where(p => p.POSTDATE >= CommonTool.GetMonthFirstDay(DateTime.Now) && p.POSTDATE <= CommonTool.GetMonthLastDay(DateTime.Now)).Count();
        //        tableSB.Append("<td>" + addCount + "</td>");
        //        int removeCount = zhigongLst.Where(p => p.OFFPOSTDATE >= CommonTool.GetMonthFirstDay(DateTime.Now) && p.OFFPOSTDATE <= CommonTool.GetMonthLastDay(DateTime.Now)).Count();
        //        tableSB.Append("<td>" + removeCount + "</td>");
        //        tableSB.Append("</tr>");
        //    }

        //    ProjectMbroutsideService mbroutSrv = new ProjectMbroutsideService();
        //    var waiguLst = mbroutSrv.GetListByProjectId(ProjectId);//外雇人员
        //    if (waiguLst != null)
        //    {
        //        tableSB.Append("<tr>");
        //        tableSB.Append("<td><a style='text-decoration: underline;' href='ProjectTeamList.aspx?ProjectId=" + ProjectId + "' target='_blank'>辅助</a></td>");
        //        tableSB.Append("<td>" + waiguLst.Where(p => p.OFFPOSTDATE == null).ToList().Count + "</td>");
        //        if (kaoqinLst != null)
        //        {
        //            tableSB.Append("<td>" + kaoqinLst.Where(p => p.MBRPROPERTY == MemberProperty.辅助.ToString() && p.RYDT == 3).Count() + "</td>");
        //            tableSB.Append("<td>" + kaoqinLst.Where(p => p.MBRPROPERTY == MemberProperty.辅助.ToString() && p.RYDT == 2).Count() + "</td>");
        //        }
        //        else
        //        {
        //            tableSB.Append("<td>0</td>");
        //            tableSB.Append("<td>0</td>");
        //        }
        //        int addCount = waiguLst.Where(p => p.POSTDATE >= CommonTool.GetMonthFirstDay(DateTime.Now) && p.POSTDATE <= CommonTool.GetMonthLastDay(DateTime.Now)).Count();
        //        tableSB.Append("<td>" + addCount + "</td>");
        //        int removeCount = waiguLst.Where(p => p.OFFPOSTDATE >= CommonTool.GetMonthFirstDay(DateTime.Now) && p.OFFPOSTDATE <= CommonTool.GetMonthLastDay(DateTime.Now)).Count();
        //        tableSB.Append("<td>" + removeCount + "</td>");
        //        tableSB.Append("</tr>");
        //    }
        //    return tableSB.ToString();
        //}

        //#endregion


        //#region 车辆信息

        ///// <summary>
        ///// 获取车辆信息
        ///// </summary>
        ///// <returns></returns>
        //protected string GetCarTable()
        //{
        //    StringBuilder tableSB = new StringBuilder();
        //    /*
        //     <tr>
        //        <td>鲁E123456</td>
        //        <td>李&nbsp;</td>
        //        <td>123456&nbsp;</td>
        //        <td>123&nbsp;</td>
        //        <td>1&nbsp;</td>
        //        <td>运行&nbsp;</td>
        //    </tr>
        //    <tr>
        //        <th>车号</th>
        //        <th>司机</th>
        //        <th>里程表数</th>
        //        <th>累计里程</th>
        //        <th>保养次数</th>
        //        <th>车辆状态</th>
        //    </tr>
        //     */
        //    ProjectCarService carSrv = new ProjectCarService();
        //    var carLst = carSrv.GetListByProjectId(ProjectId);
        //    var cars = (from l in carLst
        //                     group l by new { l.CH }
        //                         into grouped
        //                         orderby grouped.Sum(m => m.XSLC)
        //                         select
        //                             new { grouped.Key.CH, LJXSLC = grouped.Sum(m => m.XSLC) })
        //                                  .ToList();
        //    foreach (var q in cars)
        //    {
        //        var car = carLst.FirstOrDefault(p => p.CH == q.CH);
        //        tableSB.Append("<tr>");
        //        tableSB.Append("<td>" + car.CH + "</td>");
        //        tableSB.Append("<td>" + car.SJ + "</td>");
        //        int lcbds = carLst.Where(p => p.CH == q.CH).Max(p => p.LCBDS).Value;
        //        tableSB.Append("<td class='td-right'>" + lcbds + "</td>");
        //        tableSB.Append("<td class='td-right'>" + q.LJXSLC + "</td>");
        //        int ljbycs = carLst.Count(p => p.CH == q.CH && p.CLZT == 2);
        //        tableSB.Append("<td class='td-right'>" + ljbycs + "</td>");
        //        tableSB.Append("<td>" + getClzt(car.CLZT.ToInt()) + "</td>");
        //        tableSB.Append("</tr>");
        //    }
        //    return tableSB.ToString();
        //}

        ///// <summary>
        ///// 获取车辆状态描述
        ///// </summary>
        ///// <param name="clzt"></param>
        ///// <returns></returns>
        //private string getClzt(int clzt)
        //{
        //    string zt = string.Empty;
        //    switch (clzt)
        //    {
        //        case 0://运行
        //            zt = "运行";
        //            break;
        //        case 1://调离
        //            zt = "调离";
        //            break;
        //        case 2://维修保养
        //            zt = "维修保养";
        //            break;
        //        case 3://闲置
        //            zt = "闲置";
        //            break;
        //    }
        //    return zt;
        //}

        //#endregion


        //#region 设备信息

        ///// <summary>
        ///// 获取设备信息
        ///// </summary>
        ///// <returns></returns>
        //protected string GetDeviceTable()
        //{
        //    StringBuilder tableSB = new StringBuilder();
        //    /*
        //     <tr>
        //        <th>型号</th>
        //        <th>数量</th>
        //        <th>保管人</th>
        //        <th>累计运行小时</th>
        //        <th>运行状态</th>
        //    </tr>
        //    <tr>
        //        <td>WX型</td>
        //        <td>&nbsp;</td>
        //        <td>&nbsp;</td>
        //        <td>&nbsp;</td>
        //        <td>&nbsp;</td>
        //    </tr>
        //     */
        //    ProjectDeviceService deviceSrv = new ProjectDeviceService();
        //    var devLst = deviceSrv.GetListByProjectId(ProjectId);
        //    var devices = (from l in devLst
        //                group l by new { l.SBXH }
        //                    into grouped
        //                    orderby grouped.Sum(m => m.YXSJ)
        //                    select
        //                        new { grouped.Key.SBXH, LJYXSJ = grouped.Sum(m => m.YXSJ) })
        //                                  .ToList();
        //    foreach (var q in devices)
        //    {
        //        var dev = devLst.FirstOrDefault(p => p.SBXH == q.SBXH);
        //        tableSB.Append("<tr>");
        //        tableSB.Append("<td>" + dev.SBXH + "</td>");
        //        tableSB.Append("<td class='td-right'>" + dev.SBSL + "</td>");
        //        tableSB.Append("<td>" + dev.JLR + "</td>");
        //        tableSB.Append("<td class='td-right'>" + q.LJYXSJ + "</td>");
        //        tableSB.Append("<td>" + getClzt(dev.SBZT.ToInt()) + "</td>");
        //        tableSB.Append("</tr>");
        //    }
        //    return tableSB.ToString();
        //}

        //#endregion


        //#endregion

    }
}