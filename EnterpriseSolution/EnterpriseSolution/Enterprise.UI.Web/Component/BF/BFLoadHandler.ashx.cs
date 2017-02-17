using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections;

using Enterprise.Model.Basis.Sys;
using Enterprise.Model.Basis.Bf;
using Enterprise.Service.Basis.Sys;
using Enterprise.Service.Basis.Bf;
using Enterprise.Service.Common.Meeting;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;

namespace Enterprise.UI.Web.Component.BF
{
    /// <summary>
    /// 文件名称：BFLoadHandler.ashx
    /// 功能描述：业务流设计器前端数据与脚本加载
    /// 创建人：qw
    /// 创建日期：2013.2.17
    /// </summary>
    public class BFLoadHandler : IHttpHandler
    {

        #region 变量定义

        /// <summary>
        /// 业务流节点运行表--服务类
        /// </summary>
        private static readonly BfRunningService runningSrv = new BfRunningService();
        /// <summary>
        /// 业务流版本发布--服务类
        /// </summary>
        private static readonly BfPublishService publishSrv = new BfPublishService();
        /// <summary>
        /// 业务流实例--服务类
        /// </summary>
        private static readonly BfInstancesService instanceSrv = new BfInstancesService();
        /// <summary>
        /// 业务流定义--服务类
        /// </summary>
        private static readonly BfBaseService baseSrv = new BfBaseService();
        /// <summary>
        /// 系统模块管理--服务类
        /// </summary>
        private static readonly SysModuleService moduleSrv = new SysModuleService();
        /// <summary>
        /// 业务流节点角色--服务类
        /// </summary>
        private static readonly BfNoderolesService nodeRoleSrv = new BfNoderolesService();
        /// <summary>
        /// 业务流角色提取方法--服务类
        /// </summary>
        private static readonly BfClsmethodsService clsmethodSrv = new BfClsmethodsService();
        /// <summary>
        /// 用户--服务类
        /// </summary>
        private static readonly SysUserService userSrv = new SysUserService();
        /// <summary>
        /// 部门--服务类
        /// </summary>
        private static readonly SysDepartmentService deptSrv = new SysDepartmentService();
        /// <summary>
        /// 消息--服务类
        /// </summary>
        private static readonly BfMsgService messageSrv = new BfMsgService();
        /// <summary>
        /// 会议管理--服务类
        /// </summary>
        private static readonly MeetingInfoService meetingService = new MeetingInfoService();

        #endregion

        public void ProcessRequest(HttpContext context)
        {
            string responseResult = string.Empty;
            context.Response.ContentType = "text/plain";

            //接收参数>>>>>>>>>>>>
            if (!string.IsNullOrEmpty(context.Request["bfid"]) &&
                !string.IsNullOrEmpty(context.Request["bfversion"]))
            {
                string cmd = context.Request["cmd"];//指令
                string[] bfParams = new string[8];//基础参数
                bfParams[0] = context.Request["bfid"];//业务流ID
                bfParams[1] = context.Request["bfversion"];//业务流版本
                bfParams[2] = context.Request["nodeid"];//节点编号
                bfParams[3] = HttpUtility.UrlDecode(context.Request["nodename"]);//节点名称
                bfParams[4] = context.Request["nodetype"];//节点类型
                bfParams[5] = HttpUtility.UrlDecode(context.Request["nodedesc"]);

                //在jquery.easyUI.js 要实现分页，必须在后台action中声明两个变量：
                //page(当前第几页),rows(每页显示多少条信息),否者easyUI前台传递不了分页参数。
                bfParams[6] = context.Request["page"];//当前第几页
                bfParams[7] = context.Request["rows"];//每页多少条

                switch (cmd)
                {
                    case "0"://方法列表
                        responseResult = loadClsMethodGrid(bfParams);
                        break;
                    case "1"://人员树
                        responseResult = loadPersonsTree(bfParams);
                        break;
                    case "2"://节点角色
                        responseResult = loadNodeRoles(bfParams);
                        break;
                    case "3"://对应表单
                        responseResult = loadFormPath(bfParams);
                        break;
                    case "4"://保存操作人角色
                        responseResult = saveNodeRoles(bfParams,0);
                        break;
                    case "5"://保存通知人角色
                        responseResult = saveNodeRoles(bfParams,1);
                        break;
                    case "6"://子流程
                        responseResult = loadSubFlowpath(bfParams);
                        break;
                    case "7"://节点流转信息
                        string instanceId = context.Request["instanceid"];
                        responseResult = loadNodeRunInfo(bfParams, instanceId);
                        break;
                }
            }
            else if (!string.IsNullOrEmpty(context.Request["TypeId"]))
            {
                string loginName = context.Request["user"];
                string typeId = context.Request["TypeId"];
                switch (typeId) {
                    case "0"://提取当前用户所有待办事务数量
                        responseResult = getUnhandleListCountToJSON();
                        break;
                    case "1"://提取当前用户所有待办事务集合
                        responseResult = getUnhandleListToJSON();
                        break;
                    case "2"://提取指定用户所有待办事务数量
                        responseResult = getUnhandleListCountToJSONForUser(loginName);
                        break;
                    case "3"://提取通知公告
                        responseResult = getTzgg(loginName);
                        break;
                    case "4"://保存用户首页图表设置
                        string userChartValue = context.Request["uchartv"];
                        string userChartIds = context.Request["uchartIds"];
                        responseResult = saveUserCharts(loginName, userChartValue, userChartIds);
                        break;
                    case "5"://全员考核指定状态下的人员信息
                        string khzt = context.Request["khzt"];
                        //responseResult = Enterprise.Component.Extension.STAFF.Service.YgkhzztService.GetUserInfoJSON(khzt);
                        break;
                }
            }

            context.Response.Write(responseResult);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        #region 节点流转相关信息

        /// <summary>
        /// 加载节点流转相关信息
        /// </summary>
        /// <param name="bfParams">接收参数</param>
        /// <param name="instanceId">实例ID</param>
        /// <returns></returns>
        private string loadNodeRunInfo(string[] bfParams, string instanceId)
        {
            StringBuilder sb = new StringBuilder();
            string sql = string.Format(
                "select c.* from basis_bf_running c where c.bf_instanceid='{0}' and c.bf_rundesc in "
                + " (select bf_nodename from basis_bf_nodes where bf_id='{1}' and bf_version='{2}' and bf_nodeid='{3}')",
                instanceId, bfParams[0], bfParams[1], bfParams[2]);
            List<BfRunningModel> runList = runningSrv.GetListBySQL(sql).OrderBy(p=>p.BF_RUNDATE).ToList();
            sb.Append("{\"total\":1,\"rows\":[");
            foreach (BfRunningModel model in runList)
            {
                sb.Append("{\"rundesc\":\"" + model.BF_RUNDESC + "\",\"rundate\":\""
                    + model.BF_RUNDATE.Value.ToString("yyyy-MM-dd HH:mm") + "\",\"runstatus\":\""
                    + ((model.BF_RUNSTATUS.Value == 1) ? "已运行" : "未运行") + "\"},");
            }
            //sb.Append("{\"total\":1,\"rows\":[{\"rundesc\":\"部门审批\",\"rundate\":\"2013-4-23 9:52:27\",\"runstatus\":\"已运行\"}]}");
            return sb.ToString().TrimEnd(',') + "]}";
        }

        #endregion


        #region 图表设置相关

        /// <summary>
        /// 用户首页图表设置
        /// </summary>
        /// <param name="loginName">用户账号</param>
        /// <param name="uChartV">总权限值</param>
        /// <param name="uChartIds">图表值字符串</param>
        /// <returns></returns>
        private string saveUserCharts(string loginName, string uChartV, string uChartIds)
        {
            int userChartsValue = uChartV.ToInt();
            uChartIds = uChartIds.TrimEnd('|');
            //保存用户的设置
            SysUserModel userModel = SysUserService.GetUserModelByLoginName(loginName);
            if (userModel != null && userChartsValue > 0 && !string.IsNullOrEmpty(uChartIds))
            {
                SysUserindividService indevidSrv = new SysUserindividService();
                SysUserindividModel model = new SysUserindividModel();
                model.USERID = userModel.USERID;
                model.CHARTPOWER = userChartsValue;
                model.INDEXCHART = uChartIds;
                model.DB_Option_Action = WebKeys.InsertOrUpdateAction;
                indevidSrv.Execute(model);
            }
            return "OK";
        }

        #endregion


        #region 消息操作

        /// <summary>
        /// 得到当前用户所有未处理的待办信息
        /// </summary>
        /// <returns></returns>
        private string getUnhandleListToJSON()
        {
            
            StringBuilder sb = new StringBuilder();
            //所有定义的业务流信息
            List<BfBaseModel> bfBaseList = baseSrv.GetList().ToList();
            //当前用户的所有待办
            List<BfUnhandledmsgModel> todomsgLst = messageSrv.GetUnhandleList().
                Where(p => p.BF_RECIPIENTS == Utility.Get_UserId && p.BF_ISREAD == 0).ToList();
            //头
            sb.Append("<div><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            if (todomsgLst.Count > 0)
            {
                //1==未定义流程的待办数量
                int wdyCount = todomsgLst.Where(p => string.IsNullOrEmpty(p.BF_RUNID)).Count();
                Hashtable bfCountHash = new Hashtable();
                foreach (BfUnhandledmsgModel msg in todomsgLst)
                {
                    if (string.IsNullOrEmpty(msg.BF_RUNID)) continue;
                    BfInstancesModel instanceModel = instanceSrv.GetModelById(msg.BF_INSTANCEID);
                    if (instanceModel != null)
                    {
                        if (!bfCountHash.ContainsKey(instanceModel.BF_ID))
                        {
                            bfCountHash[instanceModel.BF_ID] = 1;
                        }
                        else
                        {
                            bfCountHash[instanceModel.BF_ID] = bfCountHash[instanceModel.BF_ID].ToInt() + 1;
                        }
                    }
                }

                //2==显示各业务流的待办数量
                foreach (DictionaryEntry need in bfCountHash)
                {
                    BfBaseModel bfBase = bfBaseList.Find(p=>p.BF_ID == need.Key.ToString());
                    sb.Append("<tr>");
                    sb.Append("<td width=\"23\" height=\"24\" align=\"left\" valign=\"middle\">  ●</td>");
                    sb.Append("<td align=\"left\" valign=\"middle\" style=\"padding-right: 9px\">");
                    switch (bfBase.BF_ID)
                    {
                        case "BF0001"://回国休假出差审批流程
                            sb.Append(string.Format("<a href=\"{0}\">{1}【{2}】</a>",
                                "/Modules/Common/Busitravel/BusitravelCheckIndex.aspx", bfBase.BF_NAME, need.Value));
                            break;
                        case "BF0002"://公文起草审批流程
                            sb.Append(string.Format("<a href=\"{0}\">{1}【{2}】</a>",
                                "/Modules/Common/Office/OfficeCheckIndex.aspx", bfBase.BF_NAME, need.Value));
                            break;
                        case "BF0004"://哈国内出差审批流程
                            sb.Append(string.Format("<a href=\"{0}\">{1}【{2}】</a>",
                                "/Modules/Common/Busitravel/BusitravelCheckIndexRU.aspx", bfBase.BF_NAME, need.Value));
                            break;
                    }
                    sb.Append("</td></tr>");
                }

                //加载非流程性质的待办
                if (wdyCount > 0)
                {
                    sb.Append("<tr>");
                    sb.Append("<td width=\"23\" height=\"24\" align=\"left\" valign=\"middle\">  ●</td>");
                    sb.Append("<td align=\"left\" valign=\"middle\" style=\"padding-right: 9px\">");
                    sb.Append(string.Format("<a href=\"{0}\">{1}【{2}】</a>",
                                    "/Modules/Common/Notice/MyCheckIndex.aspx", "其它待办事项", wdyCount));
                    sb.Append("</td></tr>");
                }
            }

            //会议签收待办
            var meetinglist = meetingService.MeetingUnCheck(Utility.Get_UserId);
            if (meetinglist.Count > 0)
            {
                sb.Append("<tr>");
                sb.Append("<td width=\"23\" height=\"24\" align=\"left\" valign=\"middle\">  ●</td>");
                sb.Append("<td align=\"left\" valign=\"middle\" style=\"padding-right: 9px\">");
                sb.Append(string.Format("<a href=\"{0}\">{1}【{2}】</a>",
                                "/Modules/Common/Meeting/CheckIndex.aspx", "会议签收待办", meetinglist.Count));
                sb.Append("</td></tr>");
            }

            //尾
            sb.Append("</table></div>");

            //sb.Append("[{\"id\":1,\"code\":\"01\",\"name\":\"name1\",\"addr\":\"address1\",\"children\":[{\"id\":2,\"code\":\"S04M09N04\",\"name\":\"井位设计书通知书\",\"addr\":\"/Modules/Basis/Module/ModuleIndex.aspx\"},{\"id\":3,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"},{\"id\":31,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"},{\"id\":32,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"},{\"id\":33,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"},{\"id\":34,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"}]},{\"code\":\"02\",\"name\":\"Languages abc\",\"addr\":\"address2\",\"state\":\"open\",\"children\":[{\"code\":\"0201\",\"name\":\"Java\",\"state\":\"open\",\"children\":[{\"code\":\"02013\",\"name\":\"jdk1\"},{\"code\":\"02014\",\"name\":\"jdk2\"}]},{\"code\":\"0202\",\"name\":\"C#\"}]}]");
            
            return sb.ToString();
        }

        /// <summary>
        /// 得到当前用户所有未处理的待办数量
        /// </summary>
        /// <returns></returns>
        private string getUnhandleListCountToJSON()
        {
            //未处理的待办消息
            StringBuilder sb = new StringBuilder();
            List<BfUnhandledmsgModel> todomsgLst = messageSrv.GetUnhandleList().
                Where(p => p.BF_RECIPIENTS == Utility.Get_UserId && p.BF_ISREAD == 0).ToList();
            ////待签收确认的会议通知
            //var meetinglist = meetingService.MeetingUnCheck(Utility.Get_UserId);
            sb.Append(todomsgLst.Count);//+ meetinglist.Count
            return sb.ToString();
        }

        /// <summary>
        /// 得到指定用户所有未处理的待办数量
        /// </summary>
        /// <param name="loginName">登录名称</param>
        /// <returns></returns>
        private string getUnhandleListCountToJSONForUser(string loginName)
        {
            int userId = SysUserService.GetUserId(loginName);
            //未处理的待办消息
            StringBuilder sb = new StringBuilder();
            List<BfUnhandledmsgModel> todomsgLst = messageSrv.GetUnhandleList().
                Where(p => p.BF_RECIPIENTS == userId && p.BF_ISREAD == 0).ToList();
            ////待签收确认的会议通知
            //var meetinglist = meetingService.MeetingUnCheck(userId);
            sb.Append(todomsgLst.Count);// + meetinglist.Count
            return sb.ToString();
        }

        /// <summary>
        /// 获取通知公告
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        private string getTzgg(string loginName)
        {
            SysUserService uService = new SysUserService();
            SysUserModel userModel = uService.GetList().Where(p => p.ULOGINNAME == loginName).FirstOrDefault();
            if (userModel == null) return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            ArticleInfoService aService = new ArticleInfoService();
            List<ArticleInfoModel> list = aService.ArticleQianshouList(
                aService.GetList("from ArticleInfoModel p where p.AMODULEID=28"),loginName).
                OrderByDescending(p => p.ACREATETIME).Take(7).ToList();
            foreach (ArticleInfoModel entity in list)
            {
                sb.Append("<li><a href=\"MiniLogin.aspx?Cmd=3&user=" + loginName
                    + "&Id=" + entity.ARTICLEID + "\" target=\"_blank\">" + 
                    FormatString(entity.ATITLE, entity.ATITLERU, userModel) + "</a></li>");
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="ru"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        private string FormatString(string cn, string ru, SysUserModel userModel)
        {
            if (userModel.UDEFAULTLANGUAGE == Utility.LanguageType.ru.ToString())
            {
                return ru.CutString(28);
            }
            else
            {
                return cn.CutString(16);
            }
        }

        #endregion


        #region 节点角色--操作人，通知人

        /// <summary>
        /// 加载人员信息的树型脚本
        /// </summary>
        /// <param name="bfParams"></param>
        /// <returns></returns>
        private string loadPersonsTree(string[] bfParams)
        {
            StringBuilder sb = new StringBuilder();
            List<SysUserModel> userList = userSrv.GetList().OrderBy(p => p.USERID).ToList();
            List<SysDepartMentModel> deptList = deptSrv.GetList().OrderBy(p => p.DEPTID).ToList();
            foreach (SysDepartMentModel deptModel in deptList)
            {
                sb.Append("{\"id\":\"DEPT" + deptModel.DEPTID + "\",\"text\":\"" + toUni(deptModel.DNAME) 
                    + "\",\"state\":\"closed\",\"children\":[" + getPersonsJSON(userList, deptModel) + "]},");
            }
            //[{\"id\":\"1a\",\"text\":\"Folder1\",\"state\":\"closed\",\"children\":[{\"id\":\"2a\",\"text\":\"File1\"},{\"id\":\"3a\",\"text\":\"Folder2\",\"state\":\"closed\",\"children\":[{\"id\":\"4a\",\"text\":\"File3\"},{\"id\":\"8a\",\"text\":\"AsyncFolder\"}]}]},{\"text\":\"Languages\",\"state\":\"closed\",\"children\":[{\"id\":\"j1\",\"text\":\"Java\"},{\"id\":\"j2\",\"text\":\"C#\"}]}]
            //sb.Append("[{\"id\":1,\"text\":\"Folder1\",\"iconCls\":\"icon-ok\",\"children\":[{\"id\":50,\"text\":\"File1\",\"checked\":true},{\"id\":49,\"text\":\"File1\",\"checked\":true},{\"id\":48,\"text\":\"File1\",\"checked\":true},{\"id\":47,\"text\":\"File1\",\"checked\":true},{\"id\":46,\"text\":\"File1\",\"checked\":true},{\"id\":45,\"text\":\"File1\",\"checked\":true},{\"id\":44,\"text\":\"File1\",\"checked\":true},{\"id\":2,\"text\":\"File1\",\"checked\":true},{\"id\":3,\"text\":\"Folder2\",\"state\":\"open\",\"children\":[{\"id\":4,\"text\":\"File3\",\"attributes\":{\"p1\":\"value1\",\"p2\":\"value2\"},\"checked\":true,\"iconCls\":\"icon-reload\"},{\"id\":8,\"text\":\"AsyncFolder\",\"state\":\"closed\"}]}]},{\"text\":\"Languages\",\"state\":\"closed\",\"children\":[{\"id\":\"j1\",\"text\":\"Java\"},{\"id\":\"j2\",\"text\":\"C#\"}]}]");
            return "[" + sb.ToString().TrimEnd(',') + "]";
        }

        /// <summary>
        /// 加载提取角色的对应方法列表
        /// </summary>
        /// <param name="bfParams"></param>
        /// <returns></returns>
        private string loadClsMethodGrid(string[] bfParams)
        {
            StringBuilder sb = new StringBuilder();
            List<BfClsmethodsModel> methodList = clsmethodSrv.GetList().ToList();
            List<BfClsmethodsModel> showLst = new List<BfClsmethodsModel>();
            if (!string.IsNullOrEmpty(bfParams[6]) && !string.IsNullOrEmpty(bfParams[7]))
            {
                int p = bfParams[6].ToInt();//当前页码
                int rows = bfParams[7].ToInt();//每页条数
                if (p > 0 && rows > 0)
                {
                    //提取分页数据
                    showLst = methodList.Skip((p - 1) * rows).Take(rows).ToList();
                }
                else
                {
                    //缺省第1页10条
                    showLst = methodList.Skip(0).Take(10).ToList();
                }
            }
            else
            {
                //缺省第1页10条
                showLst = methodList.Skip(0).Take(10).ToList();
            }

            if (methodList.Count > 0)
            {
                sb.Append("{\"total\":" + methodList.Count + ",\"rows\":[");
                foreach (BfClsmethodsModel clsmethodModel in showLst)
                {
                    sb.Append("{\"code\":\"" + clsmethodModel.BF_CLSID + "\",\"name\":\"" + clsmethodModel.BF_CLSNAME
                        + "\",\"addr\":\"" + clsmethodModel.BF_METHOD + "\",\"col4\":\"" 
                        + toUni(clsmethodModel.BF_METHODDESC) + "\"},");
                } 
            }
            //sb.Append("{\"total\":239,\"rows\":[{\"code\":\"001\",\"name\":\"Name1\",\"addr\":\"Address11\",\"col4\":\"col4data\"},{\"code\":\"002\",\"name\":\"Name2\",\"addr\":\"Address13\",\"col4\":\"col4data\"},{\"code\":\"003\",\"name\":\"Name3\",\"addr\":\"Address87\",\"col4\":\"col4data\"},{\"code\":\"004\",\"name\":\"Name4\",\"addr\":\"Address63\",\"col4\":\"col4data\"},{\"code\":\"005\",\"name\":\"Name5\",\"addr\":\"Address45\",\"col4\":\"col4data\"},{\"code\":\"006\",\"name\":\"Name6\",\"addr\":\"Address16\",\"col4\":\"col4data\"},{\"code\":\"007\",\"name\":\"Name7\",\"addr\":\"Address27\",\"col4\":\"col4data\"},{\"code\":\"008\",\"name\":\"Name8\",\"addr\":\"Address81\",\"col4\":\"col4data\"},{\"code\":\"009\",\"name\":\"Name9\",\"addr\":\"Address69\",\"col4\":\"col4data\"},{\"code\":\"010\",\"name\":\"Name10\",\"addr\":\"Address78\",\"col4\":\"col4data\"}]}");
            return sb.ToString().TrimEnd(',') + "]}";
        }

        /// <summary>
        /// 加载节点对应的角色信息
        /// </summary>
        /// <param name="bfParams"></param>
        /// <returns></returns>
        private string loadNodeRoles(string[] bfParams)
        {
            StringBuilder sb = new StringBuilder();

            List<BfNoderolesModel> nodeRoleList = nodeRoleSrv.
                GetListById_Version(bfParams[0], int.Parse(bfParams[1])).Where(p=>p.BF_NODEID == bfParams[2]).ToList();
            if ("DUTYOFFICER".Equals(bfParams[5]))
            {
                //操作人
                nodeRoleList = nodeRoleList.Where(p => p.BF_OPERATIONTYPE == 0).OrderBy(p=>p.BF_ROLETYPE).ToList();
            }
            else if ("NOTIFIER".Equals(bfParams[5]))
            {
                //通知人
                nodeRoleList = nodeRoleList.Where(p => p.BF_OPERATIONTYPE == 1).OrderBy(p => p.BF_ROLETYPE).ToList();
            }
            //顺序：指定人1,指定人2|静态角色1,静态角色2|动态角色1,动态角色2
            int roleType = -1;
            string zdry = string.Empty;
            string jtjs = string.Empty;
            string dtjs = string.Empty;
            foreach (BfNoderolesModel roleModel in nodeRoleList)
            {
                roleType = roleModel.BF_ROLETYPE.Value;
                switch (roleType)
                {
                    case 0://指定人员
                        zdry += roleModel.BF_ROLENAME + "_" + roleModel.USERID + ",";
                        break;
                    case 1://静态角色
                        jtjs += roleModel.BF_ROLENAME + "_" + roleModel.BF_CLSID + ",";
                        break;
                    case 2://动态角色
                        dtjs += roleModel.BF_ROLENAME + "_" + roleModel.BF_CLSID + ",";
                        break;
                }
            }
            sb.Append("ZDRY," + zdry.TrimEnd(',') + "|");
            sb.Append("JTJS," + jtjs.TrimEnd(',') + "|");
            sb.Append("DTJS," + dtjs.TrimEnd(','));

            return sb.ToString();
        }

        /// <summary>
        /// 保存节点的角色
        /// </summary>
        /// <param name="bfParams"></param>
        /// <param name="operateType">操作类型 0=操作人 1=通知人</param>
        /// <returns></returns>
        private string saveNodeRoles(string[] bfParams, int operateType)
        {
            bool isOk = false;

            List<BfNoderolesModel> nodeRoleList = nodeRoleSrv.
                GetListById_Version(bfParams[0], int.Parse(bfParams[1])).
                Where(p => p.BF_NODEID == bfParams[2] && p.BF_OPERATIONTYPE == operateType).ToList();

            string[] rolesStrs = bfParams[5].Split('-');
            if (rolesStrs.Length > 0)
            {
                //指定人员
                if (string.IsNullOrEmpty(rolesStrs[0]))
                {
                    //删除原有的角色类型
                    BfNoderolesModel roleModel = new BfNoderolesModel();
                    roleModel.BF_ID = bfParams[0];
                    roleModel.BF_VERSION = int.Parse(bfParams[1]);
                    roleModel.BF_NODEID = bfParams[2];
                    roleModel.BF_OPERATIONTYPE = operateType;
                    roleModel.BF_ROLETYPE = 0;
                    roleModel.DB_Option_Action = "DeleteByRoleType";
                    isOk = nodeRoleSrv.Execute(roleModel);
                }
                else
                {
                    string[] zdrys = rolesStrs[0].Split(',');
                    foreach (string zdry in zdrys)
                    {
                        if (string.IsNullOrEmpty(zdry)) continue;
                        string[] zd = zdry.TrimEnd(',').Split('_');
                        if (zd == null || zd.Length < 2) continue;
                        BfNoderolesModel roleModel = nodeRoleList.
                            Find(p => p.BF_ROLETYPE == 0 && p.USERID == int.Parse(zd[1]));
                        if (roleModel == null)
                        {
                            roleModel = new BfNoderolesModel();
                            roleModel.BF_ROLEID = CommonTool.GetPkId();
                            roleModel.BF_ID = bfParams[0];
                            roleModel.BF_VERSION = int.Parse(bfParams[1]);
                            roleModel.BF_NODEID = bfParams[2];
                            roleModel.BF_OPERATIONTYPE = operateType;
                        }
                        roleModel.BF_ROLENAME = zd[0];
                        roleModel.BF_ROLETYPE = 0;
                        roleModel.USERID = int.Parse(zd[1]);
                        roleModel.DB_Option_Action = WebKeys.InsertOrUpdateAction;
                        isOk = nodeRoleSrv.Execute(roleModel);
                    }
                }
                //静态角色
                if (string.IsNullOrEmpty(rolesStrs[1]))
                {
                    //删除原有的角色类型
                    BfNoderolesModel roleModel = new BfNoderolesModel();
                    roleModel.BF_ID = bfParams[0];
                    roleModel.BF_VERSION = int.Parse(bfParams[1]);
                    roleModel.BF_NODEID = bfParams[2];
                    roleModel.BF_OPERATIONTYPE = operateType;
                    roleModel.BF_ROLETYPE = 1;
                    roleModel.DB_Option_Action = "DeleteByRoleType";
                    isOk = nodeRoleSrv.Execute(roleModel);
                }
                else
                {
                    string[] jtjss = rolesStrs[1].Split(',');
                    foreach (string jtjs in jtjss)
                    {
                        if (string.IsNullOrEmpty(jtjs)) continue;
                        string[] jt = jtjs.TrimEnd(',').Split('_');
                        if (jt == null || jt.Length < 2) continue;
                        BfNoderolesModel roleModel = nodeRoleList.
                            Find(p => p.BF_ROLENAME == jt[0] && p.BF_ROLETYPE == 1);
                        if (roleModel == null)
                        {
                            roleModel = new BfNoderolesModel();
                            roleModel.BF_ROLEID = CommonTool.GetPkId();
                            roleModel.BF_ID = bfParams[0];
                            roleModel.BF_VERSION = int.Parse(bfParams[1]);
                            roleModel.BF_NODEID = bfParams[2];
                            roleModel.BF_OPERATIONTYPE = operateType;
                        }
                        roleModel.BF_ROLENAME = jt[0];
                        roleModel.BF_ROLETYPE = 1;
                        roleModel.BF_CLSID = jt[1];
                        roleModel.DB_Option_Action = WebKeys.InsertOrUpdateAction;
                        isOk = nodeRoleSrv.Execute(roleModel);
                    }
                }
                //动态角色
                if (string.IsNullOrEmpty(rolesStrs[2]))
                {
                    //删除原有的角色类型
                    BfNoderolesModel roleModel = new BfNoderolesModel();
                    roleModel.BF_ID = bfParams[0];
                    roleModel.BF_VERSION = int.Parse(bfParams[1]);
                    roleModel.BF_NODEID = bfParams[2];
                    roleModel.BF_OPERATIONTYPE = operateType;
                    roleModel.BF_ROLETYPE = 2;
                    roleModel.DB_Option_Action = "DeleteByRoleType";
                    isOk = nodeRoleSrv.Execute(roleModel);
                }
                else
                {
                    string[] dtjss = rolesStrs[2].Split(',');
                    foreach (string dtjs in dtjss)
                    {
                        if (string.IsNullOrEmpty(dtjs)) continue;
                        string[] dt = dtjs.TrimEnd(',').Split('_');
                        if (dt == null || dt.Length < 2) continue;
                        BfNoderolesModel roleModel = nodeRoleList.
                            Find(p => p.BF_ROLENAME == dt[0] && p.BF_ROLETYPE == 2);
                        if (roleModel == null)
                        {
                            roleModel = new BfNoderolesModel();
                            roleModel.BF_ROLEID = CommonTool.GetPkId();
                            roleModel.BF_ID = bfParams[0];
                            roleModel.BF_VERSION = int.Parse(bfParams[1]);
                            roleModel.BF_NODEID = bfParams[2];
                            roleModel.BF_OPERATIONTYPE = operateType;
                        }
                        roleModel.BF_ROLENAME = dt[0];
                        roleModel.BF_ROLETYPE = 2;
                        roleModel.BF_CLSID = dt[1];
                        roleModel.DB_Option_Action = WebKeys.InsertOrUpdateAction;
                        isOk = nodeRoleSrv.Execute(roleModel);
                    }
                }
            }
            return isOk.ToString();
        }


        #endregion


        #region 对应表单--模块路径

        /// <summary>
        /// 获取系统的所有模块路径
        /// </summary>
        /// <param name="bfParams"></param>
        /// <returns></returns>
        private string loadFormPath(string[] bfParams)
        {
            StringBuilder sb = new StringBuilder();
            List<SysModuleModel> moduleList = moduleSrv.GetList().OrderBy(p=>p.MCODE).ToList();
            List<SysModuleModel> parentModuleList = moduleList.Where(p => p.MCODE.Length == 3).ToList();
            foreach (SysModuleModel model in parentModuleList)
            {
                sb.Append("{\"code\":\"" + model.MCODE + "\",\"name\":\"" + toUni(model.MNAME) + "\",\"addr\":\"" + model.MURL + "\"");
                if (string.IsNullOrEmpty(model.MURL))
                {
                    sb.Append(",\"state\":\"closed\",\"children\":[" + getModulesJSON(moduleList, model) + "]");
                }
                sb.Append("},");
            }
            //sb.Append("[{\"id\":1,\"code\":\"01\",\"name\":\"name1\",\"addr\":\"address1\",\"children\":[{\"id\":2,\"code\":\"S04M09N04\",\"name\":\"井位设计书通知书\",\"addr\":\"/Modules/Basis/Module/ModuleIndex.aspx\"},{\"id\":3,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"},{\"id\":31,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"},{\"id\":32,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"},{\"id\":33,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"},{\"id\":34,\"code\":\"0102\",\"name\":\"name12\",\"addr\":\"address12\"}]},{\"code\":\"02\",\"name\":\"Languages abc\",\"addr\":\"address2\",\"state\":\"open\",\"children\":[{\"code\":\"0201\",\"name\":\"Java\",\"state\":\"open\",\"children\":[{\"code\":\"02013\",\"name\":\"jdk1\"},{\"code\":\"02014\",\"name\":\"jdk2\"}]},{\"code\":\"0202\",\"name\":\"C#\"}]}]");
            //sb.Append("{\"total\":31,\"rows\":[{\"id\":1,\"code\":\"code1\",\"name\":\"name1\",\"addr\":\"address1\"},{\"id\":11,\"code\":\"code2\",\"name\":\"name11\",\"addr\":\"address11\",\"_parentId\":1},{\"id\":12,\"code\":\"code3\",\"name\":\"name12\",\"addr\":\"address12\",\"_parentId\":1},{\"id\":2,\"code\":\"code4\",\"name\":\"name2\",\"addr\":\"address2\",\"state\":\"closed\"},{\"id\":21,\"code\":\"code5\",\"name\":\"name21\",\"addr\":\"address21\",\"_parentId\":2},{\"id\":22,\"code\":\"code6\",\"name\":\"name22\",\"addr\":\"address22\",\"_parentId\":2},{\"id\":3,\"code\":\"code7\",\"name\":\"name3\",\"addr\":\"address3\",\"state\":\"closed\"},{\"id\":31,\"code\":\"code8\",\"name\":\"name31\",\"addr\":\"address31\",\"_parentId\":3},{\"id\":32,\"code\":\"code9\",\"name\":\"name32\",\"addr\":\"address32\",\"_parentId\":3},{\"id\":4,\"code\":\"code10\",\"name\":\"name4\",\"addr\":\"address4\",\"state\":\"closed\"},{\"id\":41,\"code\":\"code11\",\"name\":\"name41\",\"addr\":\"address41\",\"_parentId\":4},{\"id\":42,\"code\":\"code12\",\"name\":\"name42\",\"addr\":\"address42\",\"_parentId\":4},{\"id\":5,\"code\":\"code13\",\"name\":\"name5\",\"addr\":\"address5\"},{\"id\":51,\"code\":\"code14\",\"name\":\"name51\",\"addr\":\"address51\",\"_parentId\":5},{\"id\":52,\"code\":\"code15\",\"name\":\"name52\",\"addr\":\"address52\",\"_parentId\":5},{\"id\":6,\"code\":\"code16\",\"name\":\"name6\",\"addr\":\"address6\",\"state\":\"closed\"},{\"id\":61,\"code\":\"code17\",\"name\":\"name61\",\"addr\":\"address61\",\"_parentId\":6},{\"id\":62,\"code\":\"code18\",\"name\":\"name62\",\"addr\":\"address62\",\"_parentId\":6},{\"id\":7,\"code\":\"code19\",\"name\":\"name7\",\"addr\":\"address7\",\"state\":\"closed\"},{\"id\":71,\"code\":\"code20\",\"name\":\"name71\",\"addr\":\"address71\",\"_parentId\":7},{\"id\":72,\"code\":\"code21\",\"name\":\"name72\",\"addr\":\"address72\",\"_parentId\":7},{\"id\":8,\"code\":\"code22\",\"name\":\"name8\",\"addr\":\"address8\",\"state\":\"closed\"},{\"id\":81,\"code\":\"code23\",\"name\":\"name81\",\"addr\":\"address81\",\"_parentId\":8},{\"id\":82,\"code\":\"code24\",\"name\":\"name82\",\"addr\":\"address82\",\"_parentId\":8},{\"id\":9,\"code\":\"code25\",\"name\":\"name9\",\"addr\":\"address9\",\"state\":\"closed\"},{\"id\":91,\"code\":\"code26\",\"name\":\"name91\",\"addr\":\"address91\",\"_parentId\":9},{\"id\":92,\"code\":\"code27\",\"name\":\"name92\",\"addr\":\"address92\",\"_parentId\":9},{\"id\":10,\"code\":\"code28\",\"name\":\"name10\",\"addr\":\"address10\",\"state\":\"closed\"},{\"id\":110,\"code\":\"code29\",\"name\":\"name110\",\"addr\":\"address110\",\"_parentId\":10},{\"id\":120,\"code\":\"code30\",\"name\":\"name120\",\"addr\":\"address120\",\"_parentId\":10}]}");
            return "[" + sb.ToString().TrimEnd(',') + "]";
        }

        #endregion

        #region 子流程

        /// <summary>
        /// 获取系统目前已经发布的所有业务流程
        /// </summary>
        /// <param name="bfParams"></param>
        /// <returns></returns>
        private string loadSubFlowpath(string[] bfParams)
        {
            StringBuilder sb = new StringBuilder();
            List<BfPublishModel> publishList = publishSrv.GetList().Where(p => p.BF_PUBSIGN == 1).
                OrderByDescending(p=>p.BF_PUBDATE).ToList();
            List<BfPublishModel> showLst = new List<BfPublishModel>();
            if (!string.IsNullOrEmpty(bfParams[6]) && !string.IsNullOrEmpty(bfParams[7]))
            {
                int p = bfParams[6].ToInt();//当前页码
                int rows = bfParams[7].ToInt();//每页条数
                if (p > 0 && rows > 0)
                {
                    //提取分页数据
                    showLst = publishList.Skip((p - 1) * rows).Take(rows).ToList();
                }
                else
                {
                    //缺省第1页10条
                    showLst = publishList.Skip(0).Take(10).ToList();
                }
            }
            else
            {
                //缺省第1页10条
                showLst = publishList.Skip(0).Take(10).ToList();
            }
            sb.Append("{\"total\":" + publishList.Count + ",\"rows\":[");
            foreach (BfPublishModel pubModel in showLst)
            {
                sb.Append("{\"code\":\"" + pubModel.BF_ID + "\",\"name\":\""
                    + toUni(pubModel.BfBase.BF_NAME) + "\",\"addr\":\"" + pubModel.BF_VERSION + "\",\"col4\":\"" 
                    + pubModel.BF_PUBDATE.Value.ToString("yyyy-MM-dd") + "\"},");
            }
            //sb.Append("{\"total\":239,\"rows\":[{\"code\":\"001\",\"name\":\"Name1\",\"addr\":\"Address11\",\"col4\":\"col4data\"},{\"code\":\"002\",\"name\":\"Name2\",\"addr\":\"Address13\",\"col4\":\"col4data\"},{\"code\":\"003\",\"name\":\"Name3\",\"addr\":\"Address87\",\"col4\":\"col4data\"},{\"code\":\"004\",\"name\":\"Name4\",\"addr\":\"Address63\",\"col4\":\"col4data\"},{\"code\":\"005\",\"name\":\"Name5\",\"addr\":\"Address45\",\"col4\":\"col4data\"},{\"code\":\"006\",\"name\":\"Name6\",\"addr\":\"Address16\",\"col4\":\"col4data\"},{\"code\":\"007\",\"name\":\"Name7\",\"addr\":\"Address27\",\"col4\":\"col4data\"},{\"code\":\"008\",\"name\":\"Name8\",\"addr\":\"Address81\",\"col4\":\"col4data\"},{\"code\":\"009\",\"name\":\"Name9\",\"addr\":\"Address69\",\"col4\":\"col4data\"},{\"code\":\"010\",\"name\":\"Name10\",\"addr\":\"Address78\",\"col4\":\"col4data\"}]}");
            return sb.ToString().TrimEnd(',') + "]}";
        }

        #endregion

        #region 私有方法区

        /// <summary>
        /// 转UNICODE码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string toUni(string s)
        {
            return CharsetConverter.ToUnicode(s);
        }

        /// <summary>
        /// 转GB2312码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string toGBK(string s)
        {
            return CharsetConverter.ToGB2312(s);
        }

        /// <summary>
        /// 递归生成系统模块的JSON脚本
        /// </summary>
        /// <param name="moduleList"></param>
        /// <param name="parentModel"></param>
        /// <returns></returns>
        private string getModulesJSON(List<SysModuleModel> moduleList, SysModuleModel parentModel)
        {
            StringBuilder sb = new StringBuilder();
            List<SysModuleModel> tempModuleList = moduleList.
                Where(p => p.MCODE.Length == parentModel.MCODE.Length + 3 && p.MCODE.StartsWith(parentModel.MCODE)).ToList();
            foreach (SysModuleModel model in tempModuleList)
            {
                sb.Append("{\"code\":\"" + model.MCODE + "\",\"name\":\"" + toUni(model.MNAME) + "\",\"addr\":\"" + model.MURL + "\"");
                if (string.IsNullOrEmpty(model.MURL))
                {
                    sb.Append(",\"state\":\"closed\",\"children\":[" + getModulesJSON(moduleList, model) + "]");
                }
                sb.Append("},");
            }

            return sb.ToString().TrimEnd(',');
        }

        /// <summary>
        /// 获取指定单位下的所有用户并返回JSON脚本
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="deptModel"></param>
        /// <returns></returns>
        private string getPersonsJSON(List<SysUserModel> userList, SysDepartMentModel deptModel)
        {
            StringBuilder sb = new StringBuilder();
            //得到本部门下的所有用户
            List<SysUserModel> tempUserList = userList.Where(p => p.DEPTID == deptModel.DEPTID).ToList();
            foreach (SysUserModel user in tempUserList)
            {
                sb.Append("{\"id\":\"" + user.USERID + "\",\"text\":\"" + toUni(user.UNAME) + "\"},");
            }

            return sb.ToString().TrimEnd(',');
        }


        #endregion


    }
}