using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Busitravel;
using Enterprise.Model.Common.Busitravel;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Service.Common.Busitravel
{
	
    /// <summary>
    /// 文件名:  BusitravelSummaryService.cs
    /// 功能描述: 业务逻辑层-出差情况汇总表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-6-24 20:24:42
    /// </summary>
    public class BusitravelSummaryService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBusitravelSummaryData dal = new BusitravelSummaryData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelSummaryModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BusitravelSummaryModel> GetListByHQL(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BusitravelSummaryModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取指定ID的差旅记录
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public BusitravelSummaryModel GetModelById(string bid)
        {
            return GetListByHQL("from BusitravelSummaryModel p where p.BID = '" + bid + "'").FirstOrDefault();
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<BusitravelSummaryModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        #endregion

        #region PDF附件相关

        /// <summary>
        /// 生成PDF附件的HTML
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static string GetPDFEnclosureHTML(BusitravelSummaryModel model)
        {
            StringBuilder htmlSB = new StringBuilder();
            if (model != null && !string.IsNullOrEmpty(model.BILL))
            {
                ArticleDownloadService downloadSrv = new ArticleDownloadService();
                //显示文件名==0 实际文件路径==1
                string[] afns = model.BILL.TrimEnd('|').Split('|');
                htmlSB.Append("<table border=\"0\" cellspacing=\"2\" class=\"tableborder4\"><tr><td colspan=\"2\" height=\"15\" class=\"tablebody2\">&nbsp;<B>附件</B></td></tr>");
                
                if (afns != null)
                {
                    string[] billFile = afns[0].Split(';');
                    if (billFile != null && billFile.Length == 2)
                    {
                        //显示文件名
                        string viewFileName = billFile[0];
                        if (billFile[0].LastIndexOf("_") > 0)
                        {
                            viewFileName = billFile[0].Substring(0, billFile[0].LastIndexOf("_")) + ".pdf";
                        }
                        //实际文件名
                        string fileName = billFile[1].Substring(billFile[1].LastIndexOf("/") + 1);
                        string hql = string.Format("from ArticleDownloadModel c where c.ARTICLEID='{0}' and c.FILENAME='{1}'", model.BID, viewFileName);
                        int downloadTimes = downloadSrv.GetList(hql).Count;
                        htmlSB.Append("<tr><td colspan=\"2\" height=\"20\" class=\"tablebody1\"><img title=\"dvubb\" src=\"/Resources/Common/filetype/pdf.gif\" border=\"0\" alt=\"\"/>");
                        htmlSB.Append(string.Format("文件名：<a href=\"../../../Component/FlexPaper/PdfViewer.aspx?bid={0}&fn={1}\" target=\"_blank\">{2}</a>", model.BID, fileName, viewFileName));
                        htmlSB.Append("&nbsp;&nbsp;|&nbsp;&nbsp;<img title=\"dvubb\" src=\"/Resources/Common/filetype/anchor.png\" border=\"0\" alt=\"\"/>");
                        htmlSB.Append(string.Format("<a href=\"/Modules/Common/Article/DownloadFile.aspx?bid={0}&fn={1}\" target=\"_blank\">下载{2}次</a>", model.BID, fileName, downloadTimes));
                        htmlSB.Append("</td></tr>");
                    }
                }

                htmlSB.Append("</table>");
            }

            return htmlSB.ToString();
        }

        /// <summary>
        /// 指定年度内的当前最大序号
        /// </summary>
        /// <returns></returns>
        public static int GenerateReqNum(int year)
        {
            int num = 1;
            BusitravelSummaryService srv = new BusitravelSummaryService();
            var query = srv.GetListByHQL("from BusitravelSummaryModel p where to_char(p.BAPPROVEDATE,'yyyy') = '" + year + "'");
            if (query != null && query.Count > 0)
            {
                int maxNum = query.Max(p => p.BREQSNUM).Value;
                if (maxNum >= 0)
                {
                    num = maxNum + 1;
                }
            }
            return num;
        }

        /// <summary>
        /// 根据用户ID得到其已出差的天数和护照信息
        /// 除了中国方向
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passport"></param>
        /// <returns></returns>
        public static int GetPassingDaysByUserId(int userId, out string passport)
        {
            int days = 0;
            passport = string.Empty;
            //护照号
            BusitravelPassengerService passengerSrv = new BusitravelPassengerService();
            var q = passengerSrv.GetListByHQL("from BusitravelPassengerModel p where p.USERID='" 
                + userId + "' and p.PASSPORT is not null").FirstOrDefault();
            if (q != null)
            {
                passport = q.PASSPORT;
            }
            //已出差天数
            BusitravelSummaryService summarySrv = new BusitravelSummaryService();
            var queryList = summarySrv.GetListByHQL("from BusitravelSummaryModel p where p.BREQUSER='" 
                + userId + "' AND p.BTYPE='0' AND p.BSTATE IN ('1','3','4')");
            if (queryList != null)
            {
                days = queryList.Sum(p => p.BDAYS).Value;
            }

            return days;
        }

        #endregion


        #region 出差统计数据-----------------------------


        /// <summary>
        /// 按年度和单位生成出差人员的统计数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="dw"></param>
        /// <returns></returns>
        public List<BusitravelStatisModel> GetStatisListForUser(int year,string dw)
        {
            List<BusitravelStatisModel> list = new List<BusitravelStatisModel>();
            string sql = string.Empty;
            int m1 = 0, m2 = 0, m3 = 0, m4 = 0, m5 = 0, m6 = 0, m7 = 0, m8 = 0, m9 = 0, m10 = 0, m11 = 0, m12 = 0;
            switch (dw)
            {
                case "FIOC":
                    sql =
                        "select a.* from common_busitravel_summary a,BASIS_SYS_DEPARTMENT b "
                        + " where a.bdeptid = b.deptid and (b.deptid <= 15 OR b.dparentid <= 15) "
                        + " and to_char(a.bapprovedate,'yyyy')='" + year + "' and a.BSTATE IN ('1','3','4')";
                    break;
                case "SPC":
                    sql =
                       "select a.* from common_busitravel_summary a,BASIS_SYS_DEPARTMENT b "
                       + " where a.bdeptid = b.deptid and (b.deptid = 17 OR b.dparentid = 17) "
                       + " and to_char(a.bapprovedate,'yyyy')='" + year + "' and a.BSTATE IN ('1','3','4')";
                    break;
                case "SZK":
                    sql =
                        "select a.* from common_busitravel_summary a,BASIS_SYS_DEPARTMENT b "
                        + " where a.bdeptid = b.deptid and (b.deptid = 16 OR b.dparentid = 16) "
                        + " and to_char(a.bapprovedate,'yyyy')='" + year + "' and a.BSTATE IN ('1','3','4')";
                    break;
                case "PPC":
                    sql =
                        "select a.* from common_busitravel_summary a,BASIS_SYS_DEPARTMENT b "
                        + " where a.bdeptid = b.deptid and (b.deptid = 106 OR b.dparentid = 106) "
                        + " and to_char(a.bapprovedate,'yyyy')='" + year + "' and a.BSTATE IN ('1','3','4')";
                    break;
            }

            List<BusitravelSummaryModel> dataLst = GetListBySQL(sql).OrderBy(p=>p.BREQUSER).ToList();
            List<int> userIds = new List<int>();
            foreach (BusitravelSummaryModel model in dataLst)
            {
                if (!userIds.Contains(model.BREQUSER.Value))
                {
                    BusitravelStatisModel statisModel = new BusitravelStatisModel();
                    statisModel.YEAR = year;
                    statisModel.DeptName = dw;
                    statisModel.USERID = model.BREQUSER.Value;
                    statisModel.UserName = SysUserService.GetUserName(statisModel.USERID);
                    statisModel.JanuaryDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 1 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m1 += statisModel.JanuaryDays;
                    statisModel.FebruaryDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 2 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m2 += statisModel.FebruaryDays;
                    statisModel.MarchDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 3 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m3 += statisModel.MarchDays;
                    statisModel.AprilDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 4 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m4 += statisModel.AprilDays;
                    statisModel.MayDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 5 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m5 += statisModel.MarchDays;
                    statisModel.JuneDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 6 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m6 += statisModel.JuneDays;
                    statisModel.JulyDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 7 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m7 += statisModel.JulyDays;
                    statisModel.AugustDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 8 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m8 += statisModel.AugustDays;
                    statisModel.SeptemberDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 9 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m9 += statisModel.SeptemberDays;
                    statisModel.OctoberDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 10 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m10 += statisModel.OctoberDays;
                    statisModel.NovemberDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 11 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m11 += statisModel.NovemberDays;
                    statisModel.DecemberDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 12 && p.BREQUSER == model.BREQUSER.Value).Sum(p => p.BDAYS).Value;
                    m12 += statisModel.DecemberDays;
                    statisModel.TotalDays = (statisModel.JanuaryDays + statisModel.FebruaryDays
                        + statisModel.MarchDays + statisModel.AprilDays + statisModel.MayDays
                        + statisModel.JuneDays + statisModel.JulyDays + statisModel.AugustDays
                        + statisModel.SeptemberDays + statisModel.OctoberDays + statisModel.NovemberDays
                        + statisModel.DecemberDays);
                    list.Add(statisModel);

                    userIds.Add(model.BREQUSER.Value);
                }
            }

            //合计
            BusitravelStatisModel totalModel = new BusitravelStatisModel();
            totalModel.YEAR = year;
            totalModel.DeptName = dw;
            totalModel.UserName = "合计";
            totalModel.JanuaryDays = m1;
            totalModel.FebruaryDays = m2;
            totalModel.MarchDays = m3;
            totalModel.AprilDays = m4;
            totalModel.MayDays = m5;
            totalModel.JuneDays = m6;
            totalModel.JulyDays = m7;
            totalModel.AugustDays = m8;
            totalModel.SeptemberDays = m9;
            totalModel.OctoberDays = m10;
            totalModel.NovemberDays = m11;
            totalModel.DecemberDays = m12;
            totalModel.TotalDays = (totalModel.JanuaryDays + totalModel.FebruaryDays
                + totalModel.MarchDays + totalModel.AprilDays + totalModel.MayDays
                + totalModel.JuneDays + totalModel.JulyDays + totalModel.AugustDays
                + totalModel.SeptemberDays + totalModel.OctoberDays + totalModel.NovemberDays
                + totalModel.DecemberDays);
            list.Add(totalModel);

            return list;
        }



        /// <summary>
        /// 按年度生成出差统计数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<BusitravelStatisModel> GetStatisList(int year)
        {
            List<BusitravelStatisModel> list = new List<BusitravelStatisModel>();
            int m1 = 0, m2 = 0, m3 = 0, m4 = 0, m5 = 0, m6 = 0, m7 = 0, m8 = 0, m9 = 0, m10 = 0, m11 = 0, m12 = 0;
            //单位：FIOC SPC SZK PPC 合计
            string[] dws = new string[] { "FIOC", "SPC", "SZK", "PPC" };
            string sql = string.Empty;
            foreach (string dw in dws)
            {
                switch (dw)
                {
                    case "FIOC":
                        sql =
                            "select a.* from common_busitravel_summary a,BASIS_SYS_DEPARTMENT b "
                            + " where a.bdeptid = b.deptid and (b.deptid <= 15 OR b.dparentid <= 15) "
                            + " and to_char(a.bapprovedate,'yyyy')='" + year + "' and a.BSTATE IN ('1','3','4')";
                        break;
                    case "SPC":
                        sql =
                           "select a.* from common_busitravel_summary a,BASIS_SYS_DEPARTMENT b "
                           + " where a.bdeptid = b.deptid and (b.deptid = 17 OR b.dparentid = 17) "
                           + " and to_char(a.bapprovedate,'yyyy')='" + year + "' and a.BSTATE IN ('1','3','4')";
                        break;
                    case "SZK":
                        sql =
                            "select a.* from common_busitravel_summary a,BASIS_SYS_DEPARTMENT b "
                            + " where a.bdeptid = b.deptid and (b.deptid = 16 OR b.dparentid = 16) "
                            + " and to_char(a.bapprovedate,'yyyy')='" + year + "' and a.BSTATE IN ('1','3','4')";
                        break;
                    case "PPC":
                        sql =
                            "select a.* from common_busitravel_summary a,BASIS_SYS_DEPARTMENT b "
                            + " where a.bdeptid = b.deptid and (b.deptid = 106 OR b.dparentid = 106) "
                            + " and to_char(a.bapprovedate,'yyyy')='" + year + "' and a.BSTATE IN ('1','3','4')";
                        break;
                }
                List<BusitravelSummaryModel> dataLst = GetListBySQL(sql).ToList();
                BusitravelStatisModel statisModel = new BusitravelStatisModel();
                statisModel.YEAR = year;
                statisModel.DeptName = dw;
                statisModel.JanuaryDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 1).Sum(p => p.BDAYS).Value;
                m1 += statisModel.JanuaryDays;
                statisModel.FebruaryDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 2).Sum(p => p.BDAYS).Value;
                m2 += statisModel.FebruaryDays;
                statisModel.MarchDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 3).Sum(p => p.BDAYS).Value;
                m3 += statisModel.MarchDays;
                statisModel.AprilDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 4).Sum(p => p.BDAYS).Value;
                m4 += statisModel.AprilDays;
                statisModel.MayDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 5).Sum(p => p.BDAYS).Value;
                m5 += statisModel.MarchDays;
                statisModel.JuneDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 6).Sum(p => p.BDAYS).Value;
                m6 += statisModel.JuneDays;
                statisModel.JulyDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 7).Sum(p => p.BDAYS).Value;
                m7 += statisModel.JulyDays;
                statisModel.AugustDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 8).Sum(p => p.BDAYS).Value;
                m8 += statisModel.AugustDays;
                statisModel.SeptemberDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 9).Sum(p => p.BDAYS).Value;
                m9 += statisModel.SeptemberDays;
                statisModel.OctoberDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 10).Sum(p => p.BDAYS).Value;
                m10 += statisModel.OctoberDays;
                statisModel.NovemberDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 11).Sum(p => p.BDAYS).Value;
                m11 += statisModel.NovemberDays;
                statisModel.DecemberDays = dataLst.Where(p => p.BAPPROVEDATE.Value.Month == 12).Sum(p => p.BDAYS).Value;
                m12 += statisModel.DecemberDays;
                statisModel.TotalDays = (statisModel.JanuaryDays + statisModel.FebruaryDays
                    + statisModel.MarchDays + statisModel.AprilDays + statisModel.MayDays
                    + statisModel.JuneDays + statisModel.JulyDays + statisModel.AugustDays
                    + statisModel.SeptemberDays + statisModel.OctoberDays + statisModel.NovemberDays
                    + statisModel.DecemberDays);
                list.Add(statisModel);

            }

            //合计
            BusitravelStatisModel totalModel = new BusitravelStatisModel();
            totalModel.YEAR = year;
            totalModel.DeptName = "合计";
            totalModel.JanuaryDays = m1;
            totalModel.FebruaryDays = m2;
            totalModel.MarchDays = m3;
            totalModel.AprilDays = m4;
            totalModel.MayDays = m5;
            totalModel.JuneDays = m6;
            totalModel.JulyDays = m7;
            totalModel.AugustDays = m8;
            totalModel.SeptemberDays = m9;
            totalModel.OctoberDays = m10;
            totalModel.NovemberDays = m11;
            totalModel.DecemberDays = m12;
            totalModel.TotalDays = (totalModel.JanuaryDays + totalModel.FebruaryDays
                + totalModel.MarchDays + totalModel.AprilDays + totalModel.MayDays
                + totalModel.JuneDays + totalModel.JulyDays + totalModel.AugustDays
                + totalModel.SeptemberDays + totalModel.OctoberDays + totalModel.NovemberDays
                + totalModel.DecemberDays);
            list.Add(totalModel);

            return list;
        }

        /// <summary>
        /// 按年度生成出差统计情况柱状图---XML数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string GetBusitravelColumnChartXML(int year)
        {
            StringBuilder xmlSB = new StringBuilder();
            BusitravelSummaryService srv = new BusitravelSummaryService();
            List<BusitravelStatisModel> statisLst = srv.GetStatisList(year);
            string[] colors = new string[] { "FDC12E", "56B9F9", "C9198D", "839F2F" };
            int index = 0;
            //yAxisMaxValue=\"100\" 
            xmlSB.Append("<graph showValues='0' showExportDataMenuItem='1' yaxisname='" + SysDictionaryService.TransTo("天数") + "' hovercapbg='DEDEBE' hovercapborder='889E6D' rotateNames='0' "
                + " numdivlines='6' divLineColor='CCCCCC' divLineAlpha='80' "
                + " showAlternateHGridColor='1' AlternateHGridAlpha='30' AlternateHGridColor='CCCCCC' "
                + " caption='" + SysDictionaryService.TransTo("出差情况统计图") + "(" + year + ")' baseFontSize='12'>");
            xmlSB.Append("<categories font='Arial' fontSize='11' fontColor='000000'>");
            for (int i = 1; i <= 12; i++)
            {
                xmlSB.Append("<category name='" + i + SysDictionaryService.TransTo("月") + "' />");
            }
            xmlSB.Append("</categories>");
            
            foreach (BusitravelStatisModel model in statisLst)
            {
                if (index > 3) break;
                if (model.DeptName != "合计")
                {
                    xmlSB.Append("<dataset seriesname='" + model.DeptName + "' color='" + colors[index++] + "'>");
                    xmlSB.Append("<set value='" + model.JanuaryDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.FebruaryDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.MarchDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.AprilDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.MayDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.JuneDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.JulyDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.AugustDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.SeptemberDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.OctoberDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.NovemberDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("<set value='" + model.DecemberDays + "' link='/Modules/Common/Busitravel/BusitravelChart.aspx' />");
                    xmlSB.Append("</dataset>");
                }
            }
            xmlSB.Append("</graph>");

            return xmlSB.ToString();

        }

        #endregion

    }

}
