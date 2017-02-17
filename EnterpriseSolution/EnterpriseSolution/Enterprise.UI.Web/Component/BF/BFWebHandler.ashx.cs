using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using System.Collections;
using System.Xml;

using Enterprise.Service.Basis.Bf;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.UI.Web.Component.BF
{
    /// <summary>
    /// 文件名称：BFWebHandler.ashx
    /// 功能描述：业务流设计器前端与数据库交互服务类，支持AJAX
    /// 创建人：qw
    /// 创建日期：2013.2.16
    /// </summary>
    public class BFWebHandler : IHttpHandler, IRequiresSessionState
    {

        #region 变量定义

        /// <summary>
        /// 客户端业务流节点集合
        /// </summary>
        private List<BFMode> _BFClientLst = new List<BFMode>();
        /// <summary>
        /// SESSION KEY
        /// </summary>
        private string sessionKey = string.Empty;
        /// <summary>
        /// 业务流发布管理--服务类
        /// </summary>
        private BfPublishService publishSrv = new BfPublishService();
        /// <summary>
        /// 业务流节点表--服务类
        /// </summary>
        private BfNodesService nodeSrv = new BfNodesService();
        /// <summary>
        /// 业务流节点流转表--服务类
        /// </summary>
        private BfFlowpathService flowpathSrv = new BfFlowpathService();
        /// <summary>
        /// 业务流节点角色--服务类
        /// </summary>
        private BfNoderolesService nodeRoleSrv = new BfNoderolesService();

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
                string[] bfParams = new string[6];//基础参数
                bfParams[0] = context.Request["bfid"];//业务流ID
                bfParams[1] = context.Request["bfversion"];//业务流版本
                bfParams[2] = context.Request["nodeid"];//节点编号
                bfParams[3] = HttpUtility.UrlDecode(context.Request["nodename"]);//节点名称
                bfParams[4] = context.Request["nodetype"];//节点类型
                bfParams[5] = context.Request["nodedesc"];//节点描述
                sessionKey = WebKeys.SSEC_BF_SESSION_KEY + "," + bfParams[0] + "," + bfParams[1];

                //提取保存在Session中的数据
                if (context.Session[sessionKey] != null)
                {
                    _BFClientLst = context.Session[sessionKey] as List<BFMode>;
                }
                else
                {
                    //提取数据表中的数据，并转存到SESSION中
                    List<BfNodesModel> processNodesList = nodeSrv.GetList().
                        Where(p => p.BF_ID == bfParams[0] && p.BF_VERSION == int.Parse(bfParams[1])).ToList();
                    _BFClientLst = toJS_BFModel(processNodesList);
                    context.Session[sessionKey] = _BFClientLst;
                }

                if (!string.IsNullOrEmpty(cmd))
                {
                    //保存每个节点的属性
                    if (cmd.Equals("save"))
                    {
                        string rowData = HttpUtility.UrlDecode(context.Request["rowdata"]);//数据结果
                        if (!string.IsNullOrEmpty(rowData))
                        {
                            Hashtable dataHash = getDataHash(rowData);
                            dataHash["BF_ID"] = bfParams[0];
                            dataHash["BF_VERSION"] = bfParams[1];
                            dataHash["NODEID"] = bfParams[2];
                            dataHash["NODENAME"] = bfParams[3];
                            dataHash["NODETYPE"] = bfParams[4];
                            dataHash["NODEDESC"] = bfParams[5];
                            //保存数据，把MODEL保存到集合中，集合保存入SESSION,以后考虑存入数据库
                            BFMode updModel = (BFMode)CommonTool.InitialiModelBean(typeof(BFMode), dataHash);
                            _BFClientLst.RemoveAll(p => p.BF_ID == updModel.BF_ID && p.BF_VERSION == updModel.BF_VERSION && p.NODEID == updModel.NODEID);
                            _BFClientLst.Add(updModel);
                            try
                            {
                                //针对单个节点的属性可以同步更新,当为新节点时此处会出异常
                                BfNodesModel pm = toData_BfNodesModel(updModel);
                                pm.DB_Option_Action = WebKeys.InsertOrUpdateAction;
                                nodeSrv.Execute(pm);
                            }
                            catch { }
                            context.Session[sessionKey] = _BFClientLst;
                        }
                    }
                    //删除指点的节点
                    else if (cmd.Equals("delete"))
                    {
                        Hashtable dataHash = new Hashtable();
                        dataHash["BF_ID"] = bfParams[0];
                        dataHash["BF_VERSION"] = bfParams[1];
                        dataHash["NODEID"] = bfParams[2];
                        dataHash["NODENAME"] = bfParams[3];
                        dataHash["NODETYPE"] = bfParams[4];
                        dataHash["NODEDESC"] = bfParams[5];

                        //保存数据，把MODEL保存到集合中，集合保存入SESSION,以后考虑存入数据库
                        BFMode updModel = (BFMode)CommonTool.InitialiModelBean(typeof(BFMode), dataHash);
                        _BFClientLst.RemoveAll(p => p.BF_ID == updModel.BF_ID && p.BF_VERSION == updModel.BF_VERSION && p.NODEID == updModel.NODEID);
                        context.Session[sessionKey] = _BFClientLst;
                    }
                    //只保存布局
                    else if (cmd.Equals("savelayout"))
                    {
                        string xmlData = HttpUtility.UrlDecode(context.Request["xmldata"]);
                        if (!string.IsNullOrEmpty(xmlData))
                        {
                            //1==字符替换
                            xmlData = xmlData.Replace("@", "#");
                            //2==读取XML字符串
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(xmlData);
                            //3==保存布局脚本
                            responseResult = saveLayoutXml(bfParams[0], int.Parse(bfParams[1]), xmlData).ToString();
                            //4==清空SESSION对象
                            context.Session[sessionKey] = null;
                        }
                    }
                    //保存整个XML，同时分析后存入节点表中
                    else if (cmd.Equals("savexmldata"))
                    {
                        string xmlData = HttpUtility.UrlDecode(context.Request["xmldata"]);
                        if (!string.IsNullOrEmpty(xmlData))
                        {
                            //1==字符替换
                            xmlData = xmlData.Replace("@", "#");
                            //2==读取XML字符串
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(xmlData);
                            //过滤节点集合中的数据,只保留最后提交的数据
                            XmlNodeList nodeLst1 = doc.SelectNodes("modes/mode");
                            List<BFMode> tempModeLst = new List<BFMode>();
                            foreach (XmlNode node in nodeLst1)
                            {
                                string modeId = node.Attributes["class"].Value + node.Attributes["id"].Value;
                                BFMode mode = _BFClientLst.Find(p => p.BF_ID == bfParams[0] &&
                                    p.BF_VERSION == int.Parse(bfParams[1]) && p.NODEID == modeId);
                                if (mode != null)
                                {
                                    tempModeLst.Add(mode);
                                }
                            }
                            _BFClientLst = tempModeLst;

                            //处理连接线
                            List<BFLine> _LineLst = new List<BFLine>();
                            XmlNodeList nodeLst2 = doc.SelectNodes("modes/line");
                            foreach (XmlNode node in nodeLst2)
                            {
                                Hashtable dataHash = new Hashtable();
                                dataHash["ID"] = node.Attributes["id"].Value;
                                dataHash["XBASEMODE"] = node.Attributes["xBaseMode"].Value;
                                dataHash["SNODEID"] = node.Attributes["sNodeId"].Value;
                                dataHash["XINDEX"] = node.Attributes["xIndex"].Value;
                                dataHash["WBASEMODE"] = node.Attributes["wBaseMode"].Value;
                                dataHash["ENODEID"] = node.Attributes["eNodeId"].Value;
                                dataHash["ATTR_PROP_XH"] = node.Attributes["attr_prop_XH"].Value;
                                BFLine line = (BFLine)CommonTool.InitialiModelBean(typeof(BFLine), dataHash);
                                _LineLst.Add(line);
                            }
                            //3=数据表操作,保存当前的XML串和节点信息
                            responseResult = saveBFProcessAndNodes(_BFClientLst, _LineLst, xmlData).ToString();
                            //4==清空SESSION对象
                            context.Session[sessionKey] = null;
                        }
                    }
                }
                else
                {
                    BFMode model = _BFClientLst.Find(p => p.BF_ID == bfParams[0] &&
                        p.BF_VERSION == int.Parse(bfParams[1]) && p.NODEID == bfParams[2]);
                    //根据节点类型返回数据
                    responseResult = getJSONForNodeType(bfParams, model);
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


        #region 专用方法区#######################


        #region 数据操作方法----------

        /// <summary>
        /// 保存布局脚本
        /// </summary>
        /// <param name="bfId"></param>
        /// <param name="bfVersion"></param>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        private bool saveLayoutXml(string bfId, int bfVersion, string xmlData)
        {
            bool isOk = false;

            try
            {
                //==保存当前业务流的XML字符串
                BfPublishModel publishModel = publishSrv.GetList().FirstOrDefault(p => p.BF_ID == bfId && p.BF_VERSION == bfVersion);
                if (publishModel != null)
                {
                    publishModel.BF_SCRIPT = xmlData;
                    publishModel.DB_Option_Action = WebKeys.UpdateAction;
                    isOk = publishSrv.Execute(publishModel);
                }
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(this, "保存布局数据出错", ex);
                isOk = false;
            }

            return isOk;
        }


        /// <summary>
        /// 正式保存数据
        /// </summary>
        /// <param name="modeLst"></param>
        /// <param name="lineLst"></param>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        private bool saveBFProcessAndNodes(List<BFMode> modeLst, List<BFLine> lineLst, string xmlData)
        {
            bool isOk = false;

            try
            {
                //转为节点数据表类型
                List<BfNodesModel> BfNodesModelLst = toData_BfNodesModel(modeLst);
                if (BfNodesModelLst.Count == 0) return isOk;

                //startNode
                BfNodesModel startProcModel = BfNodesModelLst.Find(p => p.BF_NODETYPE == "startNode");
                //endNode
                BfNodesModel endProcModel = BfNodesModelLst.Find(p => p.BF_NODETYPE == "endNode");

                //1==删除节点流转表和节点表中的已有数据
                BfFlowpathModel flowpathModel = new BfFlowpathModel();
                flowpathModel.BF_ID = startProcModel.BF_ID;
                flowpathModel.BF_VERSION = startProcModel.BF_VERSION;
                flowpathModel.DB_Option_Action = "DeleteByBF_ID_VERSION";
                isOk = flowpathSrv.Execute(flowpathModel);

                BfNodesModel nodeModel = new BfNodesModel();
                nodeModel.BF_ID = startProcModel.BF_ID;
                nodeModel.BF_VERSION = startProcModel.BF_VERSION;
                nodeModel.DB_Option_Action = "DeleteByBF_ID_VERSION";
                isOk = nodeSrv.Execute(nodeModel);

                //2==添加节点表
                foreach (BfNodesModel pm in BfNodesModelLst)
                {
                    pm.DB_Option_Action = WebKeys.InsertAction;
                    isOk = nodeSrv.Execute(pm);
                }

                //3==添加流转表
                foreach (BFLine line in lineLst)
                {
                    BfFlowpathModel pathModel = new BfFlowpathModel();
                    pathModel.BF_PATHID = WebKeys.BF_NODE_PREFIX + CommonTool.GetPkId();
                    pathModel.BF_ID = startProcModel.BF_ID;
                    pathModel.BF_VERSION = startProcModel.BF_VERSION;
                    pathModel.BF_NODEID = line.XBaseMode;
                    pathModel.BF_STARTNODE = startProcModel.BF_NODEID;
                    pathModel.BF_PREVNODE = null;
                    pathModel.BF_NEXTNODE = line.WBaseMode;
                    pathModel.BF_ENDNODE = endProcModel.BF_NODEID;
                    pathModel.BF_PATHNAME = "PATH" + line.Attr_prop_XH;
                    pathModel.BF_DEFAULTPATH = null;
                    pathModel.DB_Option_Action = WebKeys.InsertAction;
                    isOk = flowpathSrv.Execute(pathModel);
                }

                //4==保存当前业务流的XML字符串
                BfPublishModel publishModel = publishSrv.GetList().
                    FirstOrDefault(p => p.BF_ID == startProcModel.BF_ID && p.BF_VERSION == startProcModel.BF_VERSION);
                if (publishModel != null)
                {
                    publishModel.BF_SCRIPT = xmlData;
                    publishModel.DB_Option_Action = WebKeys.UpdateAction;
                    isOk = publishSrv.Execute(publishModel);
                }

            }
            catch (Exception ex) 
            {
                Debuger.GetInstance().log(this, "保存设计器数据出错", ex);
                isOk = false;
            }

            return isOk;
        }


        /// <summary>
        /// 完成数据表中数据到前端MODEL的转换
        /// </summary>
        /// <param name="procModelLst"></param>
        /// <returns></returns>
        private List<BFMode> toJS_BFModel(List<BfNodesModel> procModelLst)
        {
            List<BFMode> bfModelLst = new List<BFMode>();

            foreach (BfNodesModel pm in procModelLst)
            {
                BFMode mode = new BFMode();
                mode.NODEID = pm.BF_NODEID;
                mode.BF_ID = pm.BF_ID;
                mode.BF_VERSION = pm.BF_VERSION;
                mode.NODENAME = pm.BF_NODENAME;
                mode.NODETYPE = pm.BF_NODETYPE;
                mode.NODEDESC = pm.BF_NODEDESC;
                mode.FORM = pm.BF_FORM;
                mode.FORWARD = (pm.BF_FORWARD != null && pm.BF_FORWARD.Value == 1) ? "是" : "否";
                mode.COMMISSION = (pm.BF_COMMISSION != null && pm.BF_COMMISSION.Value == 1) ? "是" : "否";
                mode.TIMELIMIT = (pm.BF_TIMELIMIT != null) ? pm.BF_TIMELIMIT.Value : 0;
                mode.PROGRESSVALUE = (pm.BF_PROGRESSVALUE != null) ? pm.BF_PROGRESSVALUE.Value : 0;
                mode.DUTYOFFICER = pm.BF_DUTYOFFICER;
                mode.NOTIFIER = pm.BF_NOTIFIER;
                mode.REMINDWAY = pm.BF_REMINDWAY;
                mode.AUDITOPINION = pm.BF_AUDITOPINION;
                if (pm.BF_EXTENDEDTREATMENT != null)
                {
                    switch (pm.BF_EXTENDEDTREATMENT.Value)
                    {
                        case 0:
                            mode.EXTENDEDTREATMENT = "不处理";
                            break;
                        case 1:
                            mode.EXTENDEDTREATMENT = "运行下一节点";
                            break;
                        case 2:
                            mode.EXTENDEDTREATMENT = "转代理人处理";
                            break;
                    }
                }
                mode.KEYPOINT = (pm.BF_KEYPOINT != null && pm.BF_KEYPOINT.Value == 1) ? "是" : "否";
                mode.CONTROLPOINT = (pm.BF_CONTROLPOINT != null && pm.BF_CONTROLPOINT.Value == 1) ? "是" : "否";
                if (pm.BF_FLOWTYPE1 != null)
                {
                    mode.FLOWTYPE1 = (pm.BF_FLOWTYPE1.Value == 1) ? "多选一" : "并行";
                }
                if (pm.BF_FLOWTYPE2 != null)
                {
                    mode.FLOWTYPE2 = (pm.BF_FLOWTYPE2.Value == 1) ? "独立模式" : "锁定模式";
                }
                if (pm.BF_FLOWTYPE3 != null)
                {
                    mode.FLOWTYPE3 = (pm.BF_FLOWTYPE3.Value == 1) ? "等待一条分支" : "等待所有分支";
                }
                if (!string.IsNullOrEmpty(pm.SUB_BF_ID) && pm.SUB_BF_VERSION != null)
                {
                    mode.SUBBF = pm.SUB_BF_ID + "-" + pm.SUB_BF_VERSION;
                }
                
                bfModelLst.Add(mode);
            }

            return bfModelLst;
        }


        /// <summary>
        /// 完成数前端MODEL到数据表MODEL的转换
        /// </summary>
        /// <param name="bfModelLst"></param>
        /// <returns></returns>
        private List<BfNodesModel> toData_BfNodesModel(List<BFMode> bfModelLst)
        {
            List<BfNodesModel> procModelLst = new List<BfNodesModel>();

            foreach (BFMode mode in bfModelLst)
            {
                BfNodesModel pm = new BfNodesModel();
                pm.BF_NODEID = mode.NODEID;
                pm.BF_ID = mode.BF_ID;
                pm.BF_VERSION = mode.BF_VERSION;
                pm.BF_NODENAME = mode.NODENAME;
                pm.BF_NODETYPE = mode.NODETYPE;
                pm.BF_NODEDESC = mode.NODEDESC;
                pm.BF_FORM = mode.FORM;
                pm.BF_DUTYOFFICER = mode.DUTYOFFICER;
                pm.BF_NOTIFIER = mode.NOTIFIER;
                pm.BF_REMINDWAY = mode.REMINDWAY;
                pm.BF_AUDITOPINION = mode.AUDITOPINION;
                if (!string.IsNullOrEmpty(mode.FORWARD))
                    pm.BF_FORWARD = ("是".Equals(mode.FORWARD)) ? 1 : 0;
                if (!string.IsNullOrEmpty(mode.FORWARD))
                    pm.BF_COMMISSION = ("是".Equals(mode.COMMISSION)) ? 1 : 0;
                pm.BF_TIMELIMIT = mode.TIMELIMIT;
                pm.BF_PROGRESSVALUE = mode.PROGRESSVALUE;
                if (!string.IsNullOrEmpty(mode.KEYPOINT))
                    pm.BF_KEYPOINT = ("是".Equals(mode.KEYPOINT)) ? 1 : 0;
                if (!string.IsNullOrEmpty(mode.CONTROLPOINT))
                    pm.BF_CONTROLPOINT = ("是".Equals(mode.CONTROLPOINT)) ? 1 : 0;
                if (!string.IsNullOrEmpty(mode.EXTENDEDTREATMENT))
                {
                    switch (mode.EXTENDEDTREATMENT)
                    {
                        case "不处理":
                            pm.BF_EXTENDEDTREATMENT = 0;
                            break;
                        case "运行下一节点":
                            pm.BF_EXTENDEDTREATMENT = 1;
                            break;
                        case "转代理人处理":
                            pm.BF_EXTENDEDTREATMENT = 2;
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(mode.FLOWTYPE1))
                    pm.BF_FLOWTYPE1 = ("并行".Equals(mode.FLOWTYPE1)) ? 0 : 1;
                if (!string.IsNullOrEmpty(mode.FLOWTYPE2))
                    pm.BF_FLOWTYPE2 = ("独立模式".Equals(mode.FLOWTYPE2)) ? 1 : 0;
                if (!string.IsNullOrEmpty(mode.FLOWTYPE3))
                    pm.BF_FLOWTYPE3 = ("等待所有分支".Equals(mode.FLOWTYPE3)) ? 0 : 1;
                if (!string.IsNullOrEmpty(mode.SUBBF))
                {
                    string[] ss = mode.SUBBF.Split('-');
                    if (ss != null && ss.Length == 2)
                    {
                        pm.SUB_BF_ID = ss[0];
                        pm.SUB_BF_VERSION = int.Parse(ss[1]);
                    }
                }

                procModelLst.Add(pm);
            }


            return procModelLst;
        }

        /// <summary>
        /// 完成数前端MODEL到数据表MODEL的转换
        /// </summary>
        /// <param name="bfModelLst"></param>
        /// <returns></returns>
        private BfNodesModel toData_BfNodesModel(BFMode mode)
        {
            BfNodesModel pm = new BfNodesModel();
            pm.BF_NODEID = mode.NODEID;
            pm.BF_ID = mode.BF_ID;
            pm.BF_VERSION = mode.BF_VERSION;
            pm.BF_NODENAME = mode.NODENAME;
            pm.BF_NODETYPE = mode.NODETYPE;
            pm.BF_NODEDESC = mode.NODEDESC;
            pm.BF_FORM = mode.FORM;
            pm.BF_DUTYOFFICER = mode.DUTYOFFICER;
            pm.BF_NOTIFIER = mode.NOTIFIER;
            pm.BF_REMINDWAY = mode.REMINDWAY;
            pm.BF_AUDITOPINION = mode.AUDITOPINION;
            if (!string.IsNullOrEmpty(mode.FORWARD))
                pm.BF_FORWARD = ("是".Equals(mode.FORWARD)) ? 1 : 0;
            if (!string.IsNullOrEmpty(mode.FORWARD))
                pm.BF_COMMISSION = ("是".Equals(mode.COMMISSION)) ? 1 : 0;
            pm.BF_TIMELIMIT = mode.TIMELIMIT;
            pm.BF_PROGRESSVALUE = mode.PROGRESSVALUE;
            if (!string.IsNullOrEmpty(mode.KEYPOINT))
                pm.BF_KEYPOINT = ("是".Equals(mode.KEYPOINT)) ? 1 : 0;
            if (!string.IsNullOrEmpty(mode.CONTROLPOINT))
                pm.BF_CONTROLPOINT = ("是".Equals(mode.CONTROLPOINT)) ? 1 : 0;
            if (!string.IsNullOrEmpty(mode.EXTENDEDTREATMENT))
            {
                switch (mode.EXTENDEDTREATMENT)
                {
                    case "不处理":
                        pm.BF_EXTENDEDTREATMENT = 0;
                        break;
                    case "运行下一节点":
                        pm.BF_EXTENDEDTREATMENT = 1;
                        break;
                    case "转代理人处理":
                        pm.BF_EXTENDEDTREATMENT = 2;
                        break;
                }
            }
            if (!string.IsNullOrEmpty(mode.FLOWTYPE1))
                pm.BF_FLOWTYPE1 = ("并行".Equals(mode.FLOWTYPE1)) ? 0 : 1;
            if (!string.IsNullOrEmpty(mode.FLOWTYPE2))
                pm.BF_FLOWTYPE2 = ("独立模式".Equals(mode.FLOWTYPE2)) ? 1 : 0;
            if (!string.IsNullOrEmpty(mode.FLOWTYPE3))
                pm.BF_FLOWTYPE3 = ("等待所有分支".Equals(mode.FLOWTYPE3)) ? 0 : 1;
            if (!string.IsNullOrEmpty(mode.SUBBF))
            {
                string[] ss = mode.SUBBF.Split('-');
                if (ss != null && ss.Length == 2)
                {
                    pm.SUB_BF_ID = ss[0];
                    pm.SUB_BF_VERSION = int.Parse(ss[1]);
                }
            }

            return pm;
        }

        #endregion


        /// <summary>
        /// 将提交的数据串分解后转为哈希表
        /// </summary>
        /// <param name="rowData"></param>
        /// <returns></returns>
        private Hashtable getDataHash(string rowData)
        {
            Hashtable hash = new Hashtable();
            try
            {
                //NODEID,1|NODENAME,22
                string[] rows = rowData.Split('|');
                foreach (var r in rows)
                {
                    string[] fields = r.Split(',');
                    if (fields != null && fields.Length >= 2)
                    {
                        string v = r.Substring(r.IndexOf(',') + 1);
                        hash[fields[0]] = v;
                    }
                }
            }
            catch { }
            return hash;
        }


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
        /// 返回节点类型名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string getNodeTypeName(string type)
        {
            string tName = string.Empty;

            switch (type)
            {
                case "startNode":
                    tName = "开始节点";
                    break;
                case "endNode":
                    tName = "完成节点";
                    break;
                case "subflowNode":
                    tName = "子流程节点";
                    break;
                case "joinNode":
                    tName = "汇合节点";
                    break;
                case "processNode":
                    tName = "业务节点";
                    break;
            }

            return tName;
        }

        /// <summary>
        /// 根据节点类型返回初始参数
        /// </summary>
        /// <param name="bfParams"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private string getJSONForNodeType(string[] bfParams, BFMode model)
        {
            string result = string.Empty;
            /*
            bfParams[0] = context.Request["bfid"];//业务流ID
            bfParams[1] = context.Request["bfversion"];//业务流版本
            bfParams[2] = context.Request["nodeid"];//节点编号
            bfParams[3] = context.Request["nodename"];//节点名称
            bfParams[4] = context.Request["nodetype"];//节点类型
            bfParams[5] = context.Request["nodedesc"];//节点描述
            */

            string nodeType = bfParams[4];
            switch (nodeType)
            {
                case "startNode"://开始节点
                    result = getStartNode_JSON(bfParams, model);
                    break;
                case "endNode"://完成节点
                    result = getEndNode_JSON(bfParams, model);
                    break;
                case "subflowNode"://子流程节点
                    result = getSubflowNode_JSON(bfParams, model);
                    break;
                case "joinNode"://汇合节点
                    result = getJoinNode_JSON(bfParams, model);
                    break;
                case "processNode"://业务节点
                    result = getProcessNode_JSON(bfParams, model);
                    break;
            }

            return result;

        }


        #region 开始节点------------

        private string getStartNode_JSON(string[] bfParams, BFMode model)
        {
            StringBuilder nodeSB = new StringBuilder();
            nodeSB.Append("{\"total\":7,\"rows\":[");
            nodeSB.Append("{\"name\":\"" + toUni("节点编号") + "\",\"value\":\"" + toUni(bfParams[2]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEID\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点名称") + "\",\"value\":\"" + toUni(bfParams[3]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODENAME\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点描述") + "\",\"value\":\"" + toUni(bfParams[5]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEDESC\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点类型") + "\",\"value\":\"" + bfParams[4] + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODETYPE\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点对应表单△") + "\",\"value\":\"" + ((model != null) ? model.FORM : "") + "\",\"group\":\"" + toUni("表单设置") + "\",\"editor\":\"false\",\"field\":\"FORM\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点操作人△") + "\",\"value\":\"" + ((model != null) ? model.DUTYOFFICER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"DUTYOFFICER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点通知人△") + "\",\"value\":\"" + ((model != null) ? model.NOTIFIER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"NOTIFIER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("消息提醒方式△") + "\",\"value\":\"" + ((model != null) ? model.REMINDWAY : "") + "\",\"group\":\"" + toUni("提醒设置") + "\",\"editor\":\"false\",\"field\":\"REMINDWAY\"}");
            nodeSB.Append("]}");

            return nodeSB.ToString();
        }

        #endregion


        #region 完成节点------------


        private string getEndNode_JSON(string[] bfParams, BFMode model)
        {
            StringBuilder nodeSB = new StringBuilder();
            nodeSB.Append("{\"total\":7,\"rows\":[");
            nodeSB.Append("{\"name\":\"" + toUni("节点编号") + "\",\"value\":\"" + toUni(bfParams[2]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEID\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点名称") + "\",\"value\":\"" + toUni(bfParams[3]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODENAME\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点描述") + "\",\"value\":\"" + toUni(bfParams[5]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEDESC\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点类型") + "\",\"value\":\"" + bfParams[4] + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODETYPE\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点对应表单△") + "\",\"value\":\"" + ((model != null) ? model.FORM : "") + "\",\"group\":\"" + toUni("表单设置") + "\",\"editor\":\"false\",\"field\":\"FORM\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点操作人△") + "\",\"value\":\"" + ((model != null) ? model.DUTYOFFICER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"DUTYOFFICER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点通知人△") + "\",\"value\":\"" + ((model != null) ? model.NOTIFIER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"NOTIFIER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("消息提醒方式△") + "\",\"value\":\"" + ((model != null) ? model.REMINDWAY : "") + "\",\"group\":\"" + toUni("提醒设置") + "\",\"editor\":\"false\",\"field\":\"REMINDWAY\"}");
            nodeSB.Append("]}");

            return nodeSB.ToString();
        }

        #endregion

        #region 业务节点--------------

        private string getProcessNode_JSON(string[] bfParams, BFMode model)
        {
            StringBuilder nodeSB = new StringBuilder();
            nodeSB.Append("{\"total\":16,\"rows\":[");
            nodeSB.Append("{\"name\":\"" + toUni("节点编号") + "\",\"value\":\"" + toUni(bfParams[2]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEID\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点名称") + "\",\"value\":\"" + toUni(bfParams[3]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODENAME\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点描述") + "\",\"value\":\"" + toUni(bfParams[5]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEDESC\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点类型") + "\",\"value\":\"" + bfParams[4] + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODETYPE\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点对应表单△") + "\",\"value\":\"" + ((model != null) ? model.FORM : "") + "\",\"group\":\"" + toUni("表单设置") + "\",\"editor\":\"false\",\"field\":\"FORM\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点操作人△") + "\",\"value\":\"" + ((model != null) ? model.DUTYOFFICER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"DUTYOFFICER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点通知人△") + "\",\"value\":\"" + ((model != null) ? model.NOTIFIER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"NOTIFIER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("消息提醒方式△") + "\",\"value\":\"" + ((model != null) ? model.REMINDWAY : "") + "\",\"group\":\"" + toUni("提醒设置") + "\",\"editor\":\"false\",\"field\":\"REMINDWAY\"},");

            nodeSB.Append("{\"name\":\"" + toUni("是否支持回退") + "\",\"value\":\"" + ((model != null) ? model.FORWARD : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"FORWARD\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否允许代办") + "\",\"value\":\"" + ((model != null) ? model.COMMISSION : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"COMMISSION\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否为关键节点") + "\",\"value\":\"" + ((model != null) ? model.KEYPOINT : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"KEYPOINT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否为进度异常点") + "\",\"value\":\"" + ((model != null) ? model.CONTROLPOINT : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"CONTROLPOINT\"},");
           
            nodeSB.Append("{\"name\":\"" + toUni("节点进度值") + "\",\"value\":\"" + ((model != null) ? model.PROGRESSVALUE.ToString() : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":\"numberbox\",\"field\":\"PROGRESSVALUE\"},");
            nodeSB.Append("{\"name\":\"" + toUni("办理时限") + "\",\"value\":\"" + ((model != null) ? model.TIMELIMIT.ToString() : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":\"numberbox\",\"field\":\"TIMELIMIT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("缺省意见或结果") + "\",\"value\":\"" + ((model != null) ? model.AUDITOPINION : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":\"text\",\"field\":\"AUDITOPINION\"},");
            nodeSB.Append("{\"name\":\"" + toUni("超期处理方式") + "\",\"value\":\"" + ((model != null) ? model.EXTENDEDTREATMENT : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("不处理") + "\",\"text\":\"" + toUni("不处理") + "\"},{\"value\":\"" + toUni("运行下一节点") + "\",\"text\":\"" + toUni("运行下一节点") + "\"},{\"value\":\"" + toUni("转代理人处理") + "\",\"text\":\"" + toUni("转代理人处理") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"EXTENDEDTREATMENT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("分支节点流转类型") + "\",\"value\":\"" + ((model != null) ? model.FLOWTYPE1 : "") + "\",\"group\":\"" + toUni("流转设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("并行") + "\",\"text\":\"" + toUni("并行") + "\"},{\"value\":\"" + toUni("多选一") + "\",\"text\":\"" + toUni("多选一") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"FLOWTYPE1\"}");
            nodeSB.Append("]}");
            return nodeSB.ToString();
        }

        #endregion

        #region 子流程节点-----------

        private string getSubflowNode_JSON(string[] bfParams, BFMode model)
        {
            StringBuilder nodeSB = new StringBuilder();
            nodeSB.Append("{\"total\":16,\"rows\":[");
            nodeSB.Append("{\"name\":\"" + toUni("节点编号") + "\",\"value\":\"" + toUni(bfParams[2]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEID\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点名称") + "\",\"value\":\"" + toUni(bfParams[3]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODENAME\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点描述") + "\",\"value\":\"" + toUni(bfParams[5]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEDESC\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点类型") + "\",\"value\":\"" + bfParams[4] + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODETYPE\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点对应表单△") + "\",\"value\":\"" + ((model != null) ? model.FORM : "") + "\",\"group\":\"" + toUni("表单设置") + "\",\"editor\":\"false\",\"field\":\"FORM\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点操作人△") + "\",\"value\":\"" + ((model != null) ? model.DUTYOFFICER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"DUTYOFFICER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点通知人△") + "\",\"value\":\"" + ((model != null) ? model.NOTIFIER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"NOTIFIER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("消息提醒方式△") + "\",\"value\":\"" + ((model != null) ? model.REMINDWAY : "") + "\",\"group\":\"" + toUni("提醒设置") + "\",\"editor\":\"false\",\"field\":\"REMINDWAY\"},");

            nodeSB.Append("{\"name\":\"" + toUni("是否支持回退") + "\",\"value\":\"" + ((model != null) ? model.FORWARD : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"FORWARD\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否允许代办") + "\",\"value\":\"" + ((model != null) ? model.COMMISSION : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"COMMISSION\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否为关键节点") + "\",\"value\":\"" + ((model != null) ? model.KEYPOINT : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"KEYPOINT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否为进度异常点") + "\",\"value\":\"" + ((model != null) ? model.CONTROLPOINT : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"CONTROLPOINT\"},");
           
            nodeSB.Append("{\"name\":\"" + toUni("节点进度值") + "\",\"value\":\"" + ((model != null) ? model.PROGRESSVALUE.ToString() : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":\"numberbox\",\"field\":\"PROGRESSVALUE\"},");
            nodeSB.Append("{\"name\":\"" + toUni("办理时限") + "\",\"value\":\"" + ((model != null) ? model.TIMELIMIT.ToString() : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":\"numberbox\",\"field\":\"TIMELIMIT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("缺省意见或结果") + "\",\"value\":\"" + ((model != null) ? model.AUDITOPINION : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":\"text\",\"field\":\"AUDITOPINION\"},");
            nodeSB.Append("{\"name\":\"" + toUni("超期处理方式") + "\",\"value\":\"" + ((model != null) ? model.EXTENDEDTREATMENT : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("不处理") + "\",\"text\":\"" + toUni("不处理") + "\"},{\"value\":\"" + toUni("运行下一节点") + "\",\"text\":\"" + toUni("运行下一节点") + "\"},{\"value\":\"" + toUni("转代理人处理") + "\",\"text\":\"" + toUni("转代理人处理") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"EXTENDEDTREATMENT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("子流程节点流转类型") + "\",\"value\":\"" + ((model != null) ? model.FLOWTYPE2 : "") + "\",\"group\":\"" + toUni("流转设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("独立模式") + "\",\"text\":\"" + toUni("独立模式") + "\"},{\"value\":\"" + toUni("锁定模式") + "\",\"text\":\"" + toUni("锁定模式") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"FLOWTYPE2\"},");
            nodeSB.Append("{\"name\":\"" + toUni("子流程名称△") + "\",\"value\":\"" + ((model != null) ? model.SUBBF : "") + "\",\"group\":\"" + toUni("流转设置") + "\",\"editor\":\"false\",\"field\":\"SUBBF\"}");
            nodeSB.Append("]}");
            return nodeSB.ToString();
        }

        #endregion


        #region 汇合节点-------------

        private string getJoinNode_JSON(string[] bfParams, BFMode model)
        {
            StringBuilder nodeSB = new StringBuilder();
            nodeSB.Append("{\"total\":16,\"rows\":[");
            nodeSB.Append("{\"name\":\"" + toUni("节点编号") + "\",\"value\":\"" + toUni(bfParams[2]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEID\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点名称") + "\",\"value\":\"" + toUni(bfParams[3]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODENAME\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点描述") + "\",\"value\":\"" + toUni(bfParams[5]) + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODEDESC\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点类型") + "\",\"value\":\"" + bfParams[4] + "\",\"group\":\"" + toUni("节点信息") + "\",\"editor\":\"false\",\"field\":\"NODETYPE\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点对应表单△") + "\",\"value\":\"" + ((model != null) ? model.FORM : "") + "\",\"group\":\"" + toUni("表单设置") + "\",\"editor\":\"false\",\"field\":\"FORM\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点操作人△") + "\",\"value\":\"" + ((model != null) ? model.DUTYOFFICER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"DUTYOFFICER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("节点通知人△") + "\",\"value\":\"" + ((model != null) ? model.NOTIFIER : "") + "\",\"group\":\"" + toUni("权限设置") + "\",\"editor\":\"false\",\"field\":\"NOTIFIER\"},");
            nodeSB.Append("{\"name\":\"" + toUni("消息提醒方式△") + "\",\"value\":\"" + ((model != null) ? model.REMINDWAY : "") + "\",\"group\":\"" + toUni("提醒设置") + "\",\"editor\":\"false\",\"field\":\"REMINDWAY\"},");

            nodeSB.Append("{\"name\":\"" + toUni("是否支持回退") + "\",\"value\":\"" + ((model != null) ? model.FORWARD : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"FORWARD\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否允许代办") + "\",\"value\":\"" + ((model != null) ? model.COMMISSION : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"COMMISSION\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否为关键节点") + "\",\"value\":\"" + ((model != null) ? model.KEYPOINT : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"KEYPOINT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("是否为进度异常点") + "\",\"value\":\"" + ((model != null) ? model.CONTROLPOINT : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("是") + "\",\"text\":\"" + toUni("是") + "\"},{\"value\":\"" + toUni("否") + "\",\"text\":\"" + toUni("否") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"CONTROLPOINT\"},");
           
            nodeSB.Append("{\"name\":\"" + toUni("节点进度值") + "\",\"value\":\"" + ((model != null) ? model.PROGRESSVALUE.ToString() : "") + "\",\"group\":\"" + toUni("节点属性设置") + "\",\"editor\":\"numberbox\",\"field\":\"PROGRESSVALUE\"},");
            nodeSB.Append("{\"name\":\"" + toUni("办理时限") + "\",\"value\":\"" + ((model != null) ? model.TIMELIMIT.ToString() : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":\"numberbox\",\"field\":\"TIMELIMIT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("缺省意见或结果") + "\",\"value\":\"" + ((model != null) ? model.AUDITOPINION : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":\"text\",\"field\":\"AUDITOPINION\"},");
            nodeSB.Append("{\"name\":\"" + toUni("超期处理方式") + "\",\"value\":\"" + ((model != null) ? model.EXTENDEDTREATMENT : "") + "\",\"group\":\"" + toUni("时限设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("不处理") + "\",\"text\":\"" + toUni("不处理") + "\"},{\"value\":\"" + toUni("运行下一节点") + "\",\"text\":\"" + toUni("运行下一节点") + "\"},{\"value\":\"" + toUni("转代理人处理") + "\",\"text\":\"" + toUni("转代理人处理") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"EXTENDEDTREATMENT\"},");
            nodeSB.Append("{\"name\":\"" + toUni("汇合节点流转类型") + "\",\"value\":\"" + ((model != null) ? model.FLOWTYPE3 : "") + "\",\"group\":\"" + toUni("流转设置") + "\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":\"" + toUni("等待所有分支") + "\",\"text\":\"" + toUni("等待所有分支") + "\"},{\"value\":\"" + toUni("等待一条分支") + "\",\"text\":\"" + toUni("等待一条分支") + "\"}],\"panelHeight\":\"auto\"}},\"field\":\"FLOWTYPE3\"}");
            nodeSB.Append("]}");
            return nodeSB.ToString();
        }

        #endregion



        #endregion
    }

    //resultSB.Append("{\"total\":2,\"rows\":[{\"name\":\"Name\",\"value\":\"BillSmith\",\"group\":\"IDSettings\",\"editor\":\"text\"},{\"name\":\"" + CharsetConverter.ToUnicode("类型") + "\",\"value\":\"1\",\"group\":\"\u65b0\u5efa\u56fe\u5c42\",\"editor\":{\"type\":\"combobox\",\"options\":{\"data\":[{\"value\":1,\"text\":\"一\"},{\"value\":2,\"text\":\"二\"}],\"panelHeight\":\"auto\"}}}]}");

}