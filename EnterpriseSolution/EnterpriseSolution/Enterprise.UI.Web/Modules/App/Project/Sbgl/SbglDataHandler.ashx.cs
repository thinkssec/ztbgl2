using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.App.Sbgl;
using Enterprise.Service.App.Sbgl;
using Enterprise.Component.Control;
using System.Collections;

namespace Enterprise.UI.Web.Modules.App.Project.Sbgl
{
    /// <summary>
    /// 设备管理-数据查询工具类
    /// </summary>
    public class SbglDataHandler : IHttpHandler
    {

        #region 服务类声明
        
        /// <summary>
        /// 设备维修厂家服务类
        /// </summary>
        private static readonly SbglWxdwService wxdwSrv = new SbglWxdwService();
        /// <summary>
        /// 设备台账服务类
        /// </summary>
        private static readonly SbglTzService sbtzSrv = new SbglTzService();
        /// <summary>
        /// 设备维修计划服务类
        /// </summary>
        private static readonly SbglWxjhbService wxjgbSrv = new SbglWxjhbService();
        /// <summary>
        /// 设备维修验收报告单服务类
        /// </summary>
        private static readonly SbglYsbgdService ysbgdSrv = new SbglYsbgdService();
        /// <summary>
        /// 组织机构
        /// </summary>
        private static readonly SysDepartmentService deptSrv = new SysDepartmentService();

        #endregion

        public void ProcessRequest(HttpContext context)
        {
            string result = string.Empty;
            context.Response.ContentType = "text/plain";
            string p = context.Request["type"];
            switch (p) {
                case "DL_TZ"://台账下拉XML
                    result = GetTzDropListXML();
                    break;
                case "DL_WXJH"://维修计划下拉XML
                    result = GetSbwxjhDropListXML("SBWXJHZX");
                    break;
                case "DL_WXJHALL"://提取所有符合条件的维修计划
                    result = GetSbwxjhDropListXML("SBWXJHZX_ALL");
                    break;
                case "WXDW"://维修单位
                    result = GetSBWXCJList();
                    break;
                case "TZ"://台账
                    result = GetSbtzList();
                    break;
                case "WXJHSQ"://维修申请
                    string yy = context.Request["Y"];
                    string mm = context.Request["M"];
                    string zt = context.Request["ZT"];
                    result = GetSbWxjhsqList(yy, mm, zt);
                    break;
                case "WXJH"://维修计划
                    string yy2 = context.Request["Y"];
                    string mm2 = context.Request["M"];
                    string zt2 = context.Request["ZT"];
                    string ph = context.Request["PH"];
                    if (!string.IsNullOrEmpty(ph))
                    {
                        result = GetSbWxjhListByWxph(ph);
                    }
                    else
                    {
                        result = GetSbWxjhList(yy2, mm2, zt2);
                    }
                    break;
                case "WXJHSH"://维修计划审核
                    string wxph = context.Request["PH"];
                    result = GetSbWxjhListByWxph(wxph);
                    break;
                case "SBWXYS"://设备维修验收
                    string yy3 = context.Request["Y"];
                    string mm3 = context.Request["M"];
                    string zt3 = context.Request["ZT"];
                    string ph3 = context.Request["PH"];
                    if (!string.IsNullOrEmpty(ph3))
                    {
                        result = GetSbwxysByYsbgdh(ph3);
                    }
                    else
                    {
                        result = GetSbwxysList(yy3, mm3, zt3);
                    }
                    break;
                case "SBWXYSSH"://设备维修验收审核
                    string ysph = context.Request["PH"];
                    result = GetSbwxysByYsbgdh(ysph);
                    break;
                case "SBWXJHZX"://提取可执行的设备维修计划
                    result = GetSbwxjhListToDo();
                    break;
                case "SBWXJHZX_ALL"://提取所有已通过的设备维修计划
                    result = GetSbwxjhListForAll();
                    break;
                case "Chart_SBLX"://按设备类型
                    string yy4 = context.Request["Y"];
                    string mm4 = context.Request["M"];
                    result = GetChartDataByType("SBLX", yy4, mm4);
                    break;
                case "Chart_SYDW"://按使用单位
                    string yy5 = context.Request["Y"];
                    string mm5 = context.Request["M"];
                    result = GetChartDataByType("SYDW", yy5, mm5);
                    break;
            }
            context.Response.Write(result);
        }

        #region 设备验收和费用统计相关

        /// <summary>
        /// 获取相应类型图表的数据串
        /// </summary>
        /// <param name="chartType">图表类型</param>
        /// <param name="yy">年</param>
        /// <param name="mm">月</param>
        /// <returns></returns>
        public string GetChartDataByType(string chartType, string yy, string mm)
        {
            //return ysbgdSrv.GetChartData(chartType,yy,mm);
            //StringBuilder sb = new StringBuilder();
            ////sb.Append("费用统计图\r\n");
            ////sb.Append("北京\t上海\t杭州\t深圳\t广州\t天津\t重庆\r\n");
            ////sb.Append("130\t33\t312\t134\t290\t90\t122");
            //switch (chartType)
            //{
            //    case "SBLX":
            //        sb.Append("费用统计图(按设备类型)\r\n");

            //        break;
            //    case "SYDW":
            //        sb.Append("费用统计图(按使用单位)\r\n");

            //        break;
            //}
            return ysbgdSrv.GetChartData(chartType, yy, mm);
        }

        /// <summary>
        /// 获取验收报告单号对应的数据信息
        /// </summary>
        /// <param name="ysph">验收批号</param>
        /// <returns></returns>
        public string GetSbwxysByYsbgdh(string ysph)
        {
            List<SbglYsbgdModel> list = ysbgdSrv.GetListByYsbgdph(ysph) as List<SbglYsbgdModel>;
            ArrayList array = new ArrayList();
            array.AddRange(list);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("BGDID");//验收报告单ID
            colNames.Add("BGDPH");//验收报告批号
            colNames.Add("JHBID");//计划表ID
            colNames.Add("WXXMMC");//设备维修项目名称
            colNames.Add("CLPH");//车牌号码
            colNames.Add("GGXH");//规格型号
            colNames.Add("JLDW");//计量单位
            colNames.Add("SL");//数量
            colNames.Add("SZDD");//所在地点
            colNames.Add("GZLMS");//维修工作量描述
            colNames.Add("KGRQ");//开工维修日期
            colNames.Add("JFRQ");//交付使用日期
            colNames.Add("SBYZ");//原值
            colNames.Add("SBDJ");//单价
            colNames.Add("SBZJ");//总价
            colNames.Add("YSYJBZ");//验收意见及备注
            colNames.Add("WXDW");//维修单位
            colNames.Add("SHZT");//审核状态
            colNames.Add("YSFJ");//验收附件
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglYsbgdModel), colNames.ToArray(), 0, int.MaxValue));
        }

        /// <summary>
        /// 获取设备维修验收信息
        /// </summary>
        /// <param name="yy">年</param>
        /// <param name="mm">月</param>
        /// <param name="shzt">审核状态</param>
        /// <returns></returns>
        public string GetSbwxysList(string yy, string mm, string shzt)
        {
            List<SbglYsbgdModel> list = ysbgdSrv.GetListByJFRQ(yy, mm) as List<SbglYsbgdModel>;
            if (!string.IsNullOrEmpty(shzt))
            {
                list = list.Where(p => p.SHZT == shzt.ToInt()).ToList();
            }
            ArrayList array = new ArrayList();
            array.AddRange(list);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("BGDID");//验收报告单ID
            colNames.Add("BGDPH");//验收报告批号
            colNames.Add("JHBID");//计划表ID
            colNames.Add("WXXMMC");//设备维修项目名称
            colNames.Add("CLPH");//车牌号码
            colNames.Add("GGXH");//规格型号
            colNames.Add("JLDW");//计量单位
            colNames.Add("SL");//数量
            colNames.Add("SZDD");//所在地点
            colNames.Add("GZLMS");//维修工作量描述
            colNames.Add("KGRQ");//开工维修日期
            colNames.Add("JFRQ");//交付使用日期
            colNames.Add("SBYZ");//原值
            colNames.Add("SBDJ");//单价
            colNames.Add("SBZJ");//总价
            colNames.Add("YSYJBZ");//验收意见及备注
            colNames.Add("WXDW");//维修单位
            colNames.Add("SHZT");//审核状态
            colNames.Add("YSFJ");//验收附件
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglYsbgdModel), colNames.ToArray(), 0, int.MaxValue));
        }

        #endregion

        #region 设备维修计划相关

        /// <summary>
        /// 获取设备维修计划的数据XML
        /// </summary>
        /// <returns></returns>
        public string GetSbwxjhDropListXML(string typeName)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.Append("<TreeList>");
            sb.Append("<Properties dataURL=\"/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=" + typeName + "\"></Properties>");
            sb.Append("<Cols>");
            sb.Append("<Col name=\"SXNY\" width=\"100\">送修年月</Col>");
            sb.Append("<Col name=\"SBBH\" width=\"100\" droplistID=\"DL_SBTZ\" edittype=\"droplist\">自编号</Col>");
            sb.Append("<Col name=\"SBWXPH\" width=\"100\" editAble=\"false\">设备维修批号</Col>");
            sb.Append("<Col name=\"SBSYDW\" width=\"100\" droplistID=\"DL_DW\" edittype=\"droplist\">使用单位</Col>");
            sb.Append("<Col name=\"SBLX\" width=\"70\" editAble=\"false\" backcolor=\"#eeeeee\">维修设备类型</Col>");
            sb.Append("<Col name=\"GGXH\" width=\"70\" editAble=\"false\" backcolor=\"#eeeeee\">规格型号</Col>");
            sb.Append("<Col name=\"CLXH\" width=\"70\" editAble=\"false\" backcolor=\"#eeeeee\">车辆牌号</Col>");
            sb.Append("<Col name=\"AZDD\" width=\"100\">安装地点</Col>");
            sb.Append("<Col name=\"YXSJLC\" width=\"100\">运行时间或行驶里程</Col>");
            sb.Append("<Col name=\"SCXLRQ\" width=\"100\" datatype=\"date\">上次修理日期</Col>");
            sb.Append("<Col name=\"SXRQ\" width=\"100\" datatype=\"date\">预计送修日期</Col>");
            sb.Append("<Col name=\"JYWXDW\" width=\"150\" droplistID=\"DL_WXDW\" edittype=\"droplist\">建议维修单位</Col>");
            sb.Append("<Col name=\"SBWXNR\" width=\"300\">维修内容</Col>");
            sb.Append("<Col name=\"YJWXFY\" width=\"100\" datatype=\"double\" decimal=\"2\" displayMask=\"=data+'元';\" totalExpress=\"=@sum+'元'\">预计维修费用</Col>");
            sb.Append("<Col name=\"SQZT\" editAble=\"false\" width=\"100\" droplistID=\"DL_ZT\"  edittype=\"droplist\" defaultValue=\"1\">维修申请状态</Col>");
            sb.Append("<Col name=\"JHBID\" width=\"100\" isHide=\"true\">计划表ID</Col>");
            sb.Append("<Col name=\"TBR\" width=\"100\" isHide=\"true\">填报人</Col>");
            sb.Append("<Col name=\"TBRQ\" width=\"100\" isHide=\"true\">填报日期</Col>");
            sb.Append("</Cols>");
            sb.Append("<DropLists>");
            
            sb.Append("<DropList id=\"DL_WXDW\">");
            var wxdwLst = wxdwSrv.GetList();
            foreach (var q in wxdwLst)
            {
                sb.Append("<item key=\"" + q.CJBH + "\">" + q.CJMC + "</item>");
            }
            sb.Append("</DropList>");

            sb.Append("<DropList id=\"DL_SBTZ\">");
            var tzLst = sbtzSrv.GetList();
            foreach (var q in tzLst)
            {
                sb.Append("<item key=\"" + q.SBBH + "\">" + q.SBBH + "</item>");
            }
            sb.Append("</DropList>");

            sb.Append("<DropList id=\"DL_DW\">");
            var deptLst = deptSrv.GetList();
            foreach (var d in deptLst)
            {
                sb.Append("<item key=\"" + d.DEPTID + "\">" + d.DNAME + "</item>");
            }            
            sb.Append("</DropList>");
        
            sb.Append("<DropList id=\"DL_ZT\">");
            sb.Append("<item key=\"1\">已通过</item>");
            sb.Append("<item key=\"0\">待审核</item>");
            sb.Append("<item key=\"-1\">不通过</item>");
            sb.Append("</DropList>");
            sb.Append("</DropLists>");
            sb.Append("</TreeList>");
            return sb.ToString();
        }

        /// <summary>
        /// 获取当前可执行的设备维修计划
        /// </summary>
        /// <returns></returns>
        public string GetSbwxjhListForAll()
        {
            //维修计划审核通过，同时未在验收单中出现过的
            var wxjhLst = wxjgbSrv.GetListBySQL(
                "select a.* from app_sbgl_wxjhb a where a.jhbid in (select distinct(t.jhbid) from app_sbgl_ysbgd t) and a.sqzt='1'") as List<SbglWxjhbModel>;
            ArrayList array = new ArrayList();
            array.AddRange(wxjhLst);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("SBBH");//自编号
            colNames.Add("SBWXPH");//设备维修批号
            colNames.Add("SBSYDW");//使用单位
            colNames.Add("SBLX");//维修设备类型
            colNames.Add("GGXH");//规格型号
            colNames.Add("CLXH");//车辆牌号
            colNames.Add("AZDD");//安装地点
            colNames.Add("YXSJLC");//运行时间或行驶里程
            colNames.Add("SCXLRQ");//上次修理日期
            colNames.Add("SXRQ");//预计送修日期
            colNames.Add("SBWXNR");//维修内容
            colNames.Add("YJWXFY");//预计维修费用
            colNames.Add("JYWXDW");//建议维修单位
            colNames.Add("SQZT");//维修申请状态    
            colNames.Add("JHBID");//计划表ID
            colNames.Add("SXNY");//送修年月
            colNames.Add("TBR");//填报人
            colNames.Add("TBRQ");//填报日期
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglWxjhbModel), colNames.ToArray(), 0, int.MaxValue));
        }

        /// <summary>
        /// 获取当前可执行的设备维修计划
        /// </summary>
        /// <returns></returns>
        public string GetSbwxjhListToDo()
        {
            //维修计划审核通过，同时未在验收单中出现过的
            var wxjhLst = wxjgbSrv.GetListBySQL(
                "select a.* from app_sbgl_wxjhb a where a.jhbid not in (select distinct(t.jhbid) from app_sbgl_ysbgd t where t.shzt='1') and a.sqzt='1'") as List<SbglWxjhbModel>;
            ArrayList array = new ArrayList();
            array.AddRange(wxjhLst);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("SBBH");//自编号
            colNames.Add("SBWXPH");//设备维修批号
            colNames.Add("SBSYDW");//使用单位
            colNames.Add("SBLX");//维修设备类型
            colNames.Add("GGXH");//规格型号
            colNames.Add("CLXH");//车辆牌号
            colNames.Add("AZDD");//安装地点
            colNames.Add("YXSJLC");//运行时间或行驶里程
            colNames.Add("SCXLRQ");//上次修理日期
            colNames.Add("SXRQ");//预计送修日期
            colNames.Add("SBWXNR");//维修内容
            colNames.Add("YJWXFY");//预计维修费用
            colNames.Add("JYWXDW");//建议维修单位
            colNames.Add("SQZT");//维修申请状态    
            colNames.Add("JHBID");//计划表ID
            colNames.Add("SXNY");//送修年月
            colNames.Add("TBR");//填报人
            colNames.Add("TBRQ");//填报日期
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglWxjhbModel), colNames.ToArray(), 0, int.MaxValue));
        }

        /// <summary>
        /// 根据维修批号获取设备维修计划
        /// </summary>
        /// <param name="wxph">维修批号</param>
        /// <returns></returns>
        public string GetSbWxjhListByWxph(string wxph)
        {
            //数据
            var list = wxjgbSrv.GetListBySbwxph(wxph).ToList();
            ArrayList array = new ArrayList();
            array.AddRange(list);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("SBBH");//自编号
            colNames.Add("SBWXPH");//设备维修批号
            colNames.Add("SBSYDW");//使用单位
            colNames.Add("SBLX");//维修设备类型
            colNames.Add("GGXH");//规格型号
            colNames.Add("CLXH");//车辆牌号
            colNames.Add("AZDD");//安装地点
            colNames.Add("YXSJLC");//运行时间或行驶里程
            colNames.Add("SCXLRQ");//上次修理日期
            colNames.Add("SXRQ");//预计送修日期
            colNames.Add("SBWXNR");//维修内容
            colNames.Add("YJWXFY");//预计维修费用
            colNames.Add("JYWXDW");//建议维修单位
            colNames.Add("SQZT");//维修申请状态    
            colNames.Add("JHBID");//计划表ID
            colNames.Add("SXNY");//送修年月
            colNames.Add("TBR");//填报人
            colNames.Add("TBRQ");//填报日期
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglWxjhbModel), colNames.ToArray(), 0, int.MaxValue));
        }

        /// <summary>
        /// 获取设备维修计划信息
        /// </summary>
        /// <param name="yy">年度</param>
        /// <param name="mm">月度</param>
        /// <returns></returns>
        public string GetSbWxjhList(string yy, string mm, string sqzt)
        {
            //数据
            var list = wxjgbSrv.GetListBySXRQ(yy, mm).Where(p => p.SQZT == sqzt.ToInt()).ToList();
            ArrayList array = new ArrayList();
            array.AddRange(list);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("SBBH");//自编号
            colNames.Add("SBWXPH");//设备维修批号
            colNames.Add("SBSYDW");//使用单位
            colNames.Add("SBLX");//维修设备类型
            colNames.Add("GGXH");//规格型号
            colNames.Add("CLXH");//车辆牌号
            colNames.Add("AZDD");//安装地点
            colNames.Add("YXSJLC");//运行时间或行驶里程
            colNames.Add("SCXLRQ");//上次修理日期
            colNames.Add("SXRQ");//预计送修日期
            colNames.Add("SBWXNR");//维修内容
            colNames.Add("YJWXFY");//预计维修费用
            colNames.Add("JYWXDW");//建议维修单位
            colNames.Add("SQZT");//维修申请状态    
            colNames.Add("JHBID");//计划表ID
            colNames.Add("SXNY");//送修年月
            colNames.Add("TBR");//填报人
            colNames.Add("TBRQ");//填报日期
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglWxjhbModel), colNames.ToArray(), 0, int.MaxValue));
        }

        /// <summary>
        /// 获取设备维修计划申请信息
        /// </summary>
        /// <param name="yy">年度</param>
        /// <param name="mm">月度</param>
        /// <returns></returns>
        public string GetSbWxjhsqList(string yy, string mm, string sqzt)
        {
            //数据
            var list = wxjgbSrv.GetListByTbrAndTbrq(yy, mm).Where(p => p.SQZT == sqzt.ToInt()).ToList();
            ArrayList array = new ArrayList();
            array.AddRange(list);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("SBBH");//自编号
            colNames.Add("SBWXPH");//设备维修批号
            colNames.Add("SBSYDW");//使用单位
            colNames.Add("SBLX");//维修设备类型
            colNames.Add("GGXH");//规格型号
            colNames.Add("CLXH");//车辆牌号
            colNames.Add("AZDD");//安装地点
            colNames.Add("YXSJLC");//运行时间或行驶里程
            colNames.Add("SCXLRQ");//上次修理日期
            colNames.Add("SXRQ");//预计送修日期
            colNames.Add("SBWXNR");//维修内容
            colNames.Add("YJWXFY");//预计维修费用
            colNames.Add("SQZT");//维修申请状态    
            colNames.Add("JHBID");//计划表ID
            colNames.Add("SXNY");//送修年月
            colNames.Add("TBR");//填报人
            colNames.Add("TBRQ");//填报日期
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglWxjhbModel), colNames.ToArray(), 0, int.MaxValue));
        }

        #endregion

        #region 设备台账管理

        /// <summary>
        /// 生成台账的下拉控件XML数据
        /// </summary>
        /// <returns></returns>
        protected string GetTzDropListXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<TreeList>");
            sb.Append("<Properties dataURL=\"/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=TZ\"></Properties>");
            sb.Append("<Cols>");
            sb.Append("<Col name=\"SBBH\" width=\"100\">设备自编号</Col>");
            sb.Append("<Col name=\"SBLX\" width=\"100\" >设备类型</Col>");
            sb.Append("<Col name=\"SBMC\" width=\"70\" >设备名称</Col>");
            sb.Append("<Col name=\"GGXH\" width=\"100\" >规格型号</Col>");
            sb.Append("<Col name=\"CLPH\" width=\"100\" >车辆牌号</Col>");
            sb.Append("<Col name=\"SBYZ\" width=\"100\" datatype=\"double\" decimal=\"2\" displayMask=\"=data+'元';\">设备原值</Col>");
            sb.Append("<Col name=\"SBJZ\" width=\"100\" datatype=\"double\" decimal=\"2\" displayMask=\"=data+'元';\">设备净值</Col>");
            sb.Append("<Col name=\"AZDD\" width=\"100\" >安装地点</Col>");
            sb.Append("<Col name=\"CCRQ\" width=\"100\" datatype=\"date\">出厂日期</Col>");
            sb.Append("<Col name=\"TCRQ\" width=\"100\" datatype=\"date\">投用日期</Col>");
            sb.Append("<Col name=\"SYDW\" width=\"100\" droplistID=\"DW\" edittype=\"droplist\">使用单位</Col>");
            sb.Append("<Col name=\"YXSJLC\" width=\"100\" isHide=\"true\">运行时间或行驶里程</Col>");
            sb.Append("<Col name=\"BGR\" width=\"70\" isHide=\"true\">保管人</Col>");
            sb.Append("<Col name=\"SBZT\"  width=\"70\"  droplistID=\"ZT\"  edittype=\"droplist\" defaultValue=\"1\">设备状态</Col>");
            sb.Append("</Cols>");
            sb.Append("<DropLists>");
            sb.Append("<DropList id=\"DW\">");
            var deptLst = deptSrv.GetList();
            foreach (var d in deptLst)
            {
                sb.Append("<item key=\"" + d.DEPTID + "\">" + d.DNAME + "</item>");
            }
            sb.Append("</DropList>");
            sb.Append("<DropList id=\"ZT\">");
            sb.Append("<item key=\"1\">在用</item>");
            sb.Append("<item key=\"0\">非在用</item>");
            sb.Append("</DropList>");
            sb.Append("</DropLists>");
            sb.Append("</TreeList>");
            return sb.ToString();
        }

        /// <summary>
        /// 获取设备台账信息
        /// </summary>
        /// <returns></returns>
        protected string GetSbtzList()
        {
            //数据
            var list = sbtzSrv.GetList().OrderBy(p=>p.SBLX).ToList();
            ArrayList array = new ArrayList();
            array.AddRange(list);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("SBLX");//设备类型
            colNames.Add("SBBH");//设备自编号
            colNames.Add("SBMC");//设备名称
            colNames.Add("GGXH");//规格型号
            colNames.Add("CLPH");//车辆牌号
            colNames.Add("SBYZ");//设备原值
            colNames.Add("SBJZ");//设备净值
            colNames.Add("AZDD");//安装地点
            colNames.Add("CCRQ");//出厂日期
            colNames.Add("TCRQ");//投用日期
            colNames.Add("SYDW");//使用单位
            colNames.Add("YXSJLC");//运行时间或行驶里程
            colNames.Add("BGR");//保管人
            colNames.Add("SBZT");//设备状态
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglTzModel), colNames.ToArray(), 0, int.MaxValue));
        }

        #endregion

        #region 维修厂家管理

        /// <summary>
        /// 获取设备维修厂家信息
        /// </summary>
        /// <returns></returns>
        protected string GetSBWXCJList()
        {
            //数据
            var list = wxdwSrv.GetList() as List<SbglWxdwModel>;
            ArrayList array = new ArrayList();
            array.AddRange(list);
            //显示字段
            List<string> colNames = new List<string>();
            colNames.Add("CJBH");//厂家编号
            colNames.Add("CJMC");//厂家名称
            colNames.Add("CJDZ");//厂家地址
            colNames.Add("CJZZ");//厂家资质
            colNames.Add("YHZH");//银行账户
            colNames.Add("LXR");//联系人
            colNames.Add("LXFS");//联系方式
            colNames.Add("DQZT");//当前状态
            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(SbglWxdwModel), colNames.ToArray(), 0, int.MaxValue));
        }

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}