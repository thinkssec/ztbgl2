using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Enterprise.Component.BF;
using Enterprise.Model.Basis.Bf;
using Enterprise.Model.Basis.Sys;
using Enterprise.Model.Basis.Message;
using Enterprise.Service.Basis.Message;
using Enterprise.Service.Basis.Rtx;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Infrastructure;

namespace Enterprise.Service.Basis.Bf
{

    /// <summary>
    /// 文件名:  BFController.cs
    /// 功能描述: 业务流--流转控制器
    /// 创建人：qw
    /// 创建日期: 2013.2.5
    /// </summary>
    public class BFController : IBFController<BfInstancesModel>
    {

        #region 变量定义

        /// <summary>
        /// 业务流节点服务类
        /// </summary>
        private static readonly BfNodesService nodeSrv = new BfNodesService();
        /// <summary>
        /// 节点流转路径服务类
        /// </summary>
        private static readonly BfFlowpathService flowpathSrv = new BfFlowpathService();
        /// <summary>
        /// 业务流实例节点运行服务类
        /// </summary>
        private static readonly BfRunningService runningSrv = new BfRunningService();
        /// <summary>
        /// 业务流实例服务类
        /// </summary>
        private static readonly BfInstancesService instanceSrv = new BfInstancesService();
        /// <summary>
        /// 节点角色服务类
        /// </summary>
        private static readonly BfNoderolesService noderolesSrv = new BfNoderolesService();
        /// <summary>
        /// 业务流实例角色服务类
        /// </summary>
        private static readonly BfInstancerolesService instanceRolesSrv = new BfInstancerolesService();
        /// <summary>
        /// 消息服务类
        /// </summary>
        private static readonly BfMsgService msgSrv = new BfMsgService();
        /// <summary>
        /// 事务代办服务类
        /// </summary>
        private static readonly BfTrustusersService trustuserSrv = new BfTrustusersService();

        #endregion


        #region 接口方法实现


        /// <summary>
        /// 初始化执行方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool BFInitialize(BFNodeEventArgs<BfInstancesModel> e)
        {
            bool isResult = false;

            //节点集合
            List<BfNodesModel> nodeList = nodeSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();

            //开始节点
            BfNodesModel startNode = nodeList.Find(p => p.BF_NODETYPE == BFNodeType.startNode.ToString());
            if (startNode != null)
            {
                //1=向业务流实例表中添加一条数据
                e.Model.DB_Option_Action = WebKeys.InsertAction;
                isResult = instanceSrv.Execute(e.Model);

                //2=完成指定人员和静态角色的提取
                isResult = isResult && GetRolesIdentity(e, BFRoleType.指定人员);
                isResult = isResult && GetRolesIdentity(e, BFRoleType.静态角色);

                //3=提取开始节点的动态角色
                e.SetNextNodeID(BFPathName.PATH1.ToString(), startNode.BF_NODEID);
                isResult = isResult && GetRolesIdentity(e, BFRoleType.动态角色);
            }

            return isResult;
        }

        /// <summary>
        /// 运行起始节点
        /// </summary>
        /// <param name="e"></param>
        /// <param name="bfPath"></param>
        /// <returns></returns>
        public bool RunStartStep(BFNodeEventArgs<BfInstancesModel> e, BFPathName bfPath)
        {
            bool isResult = false;

            //节点集合
            List<BfNodesModel> nodeList = nodeSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();
            //节点流转集合
            List<BfFlowpathModel> flowpathList = flowpathSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();

            //开始节点
            BfNodesModel startNode = nodeList.Find(p => p.BF_NODETYPE == BFNodeType.startNode.ToString());
            //开始节点流转路径
            List<BfFlowpathModel> startNodePaths = flowpathList.Where(p => p.BF_NODEID == startNode.BF_NODEID).ToList();
            if (startNodePaths != null && startNodePaths.Count > 0)
            {
                //判断开始节点后的执行路径
                BfFlowpathModel startNodePath;
                if (bfPath == BFPathName.NONE)
                {
                    startNodePath = startNodePaths[0];
                }
                else
                {
                    startNodePath = startNodePaths.Find(p => p.BF_PATHNAME == bfPath.ToString());
                }

                //由于开始节点以后要运行下一节点，所以要人为添加一条开始节点的运行记录
                BfRunningModel runningModel = new BfRunningModel();
                runningModel.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                runningModel.BF_PATHID = startNodePath.BF_PATHID;
                runningModel.BF_RUNID = WebKeys.BF_RUN_PERFIX + CommonTool.GetPkId();
                runningModel.BF_RUNSTATUS = 1;//状态置为已运行
                runningModel.BF_RUNDESC = startNode.BF_NODENAME;
                runningModel.BF_RUNDATE = DateTime.Now;
                runningModel.PARENT_BF_RUNID = e.ParentRunID;//上一级运行节点，只有开始节点保存一次
                runningModel.DB_Option_Action = WebKeys.InsertAction;
                isResult = runningSrv.Execute(runningModel);

                //下一运行节点
                BfNodesModel processNode = nodeList.Find(p => p.BF_NODEID == startNodePath.BF_NEXTNODE);
                //将下一节点添加到运行表
                runningModel = new BfRunningModel();
                runningModel.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                runningModel.BF_PATHID = startNodePath.BF_PATHID;
                runningModel.BF_RUNID = WebKeys.BF_RUN_PERFIX + CommonTool.GetPkId();
                runningModel.BF_RUNSTATUS = 0;
                runningModel.BF_RUNDESC = processNode.BF_NODENAME;
                runningModel.BF_RUNDATE = DateTime.Now;
                runningModel.DB_Option_Action = WebKeys.InsertAction;
                isResult = runningSrv.Execute(runningModel);

                //保存下一运行节点ID
                e.SetRunID(startNodePath.BF_PATHNAME, runningModel.BF_RUNID);
                e.SetNextNodeID(startNodePath.BF_PATHNAME, processNode.BF_NODEID);
                //提取下一运行节点的角色用户身份
                isResult = GetRolesIdentity(e, BFRoleType.动态角色);
                if (isResult)
                {
                    //发送待办和提醒消息
                    SendNotificationMessage(e);
                }
            }
            
            return isResult;
        }

        /// <summary>
        /// 运行结束节点
        /// </summary>
        /// <param name="e"></param>
        /// <param name="bfPath"></param>
        /// <returns></returns>
        public bool RunFinishStep(BFNodeEventArgs<BfInstancesModel> e, BFPathName bfPath)
        {
            bool isResult = false;

            if (!string.IsNullOrEmpty(e.RunID))
            {
                //最后的节点状态设为已运行
                BfRunningModel runningModel = runningSrv.GetListByInstanceId(e.Model.BF_INSTANCEID).FirstOrDefault(p => p.BF_RUNID == e.RunID);
                runningModel.BF_RUNSTATUS = (int)BFRunStatus.已运行;
                runningModel.DB_Option_Action = WebKeys.UpdateAction;
                runningSrv.Execute(runningModel);
                //业务流实例状态设为结束
                //BfInstancesModel instanceModel = instanceSrv.GetList().FirstOrDefault(p => p.BF_INSTANCEID == runningModel.BF_INSTANCEID);
                BfInstancesModel instanceModel = runningModel.BfInstance;
                instanceModel.BF_STATUSVALUE = (int)BFStatus.结束;
                instanceModel.DB_Option_Action = WebKeys.UpdateAction;
                isResult = instanceSrv.Execute(instanceModel);

                //判断当前的流程中有无父级节点
                BfRunningModel tempRunningModel = runningSrv.GetListByInstanceId(e.Model.BF_INSTANCEID).
                    FirstOrDefault(p => p.BF_INSTANCEID == runningModel.BF_INSTANCEID && !string.IsNullOrEmpty(p.PARENT_BF_RUNID));
                if (tempRunningModel != null)
                {
                    BfRunningModel parentRunningModel = runningSrv.GetListByInstanceId(e.Model.BF_INSTANCEID).FirstOrDefault(p => p.BF_RUNID == tempRunningModel.PARENT_BF_RUNID);
                    //BfInstancesModel parentInstanceModel = instanceSrv.GetList().FirstOrDefault(p => p.BF_INSTANCEID == parentRunningModel.BF_INSTANCEID);
                    BfInstancesModel parentInstanceModel = parentRunningModel.BfInstance;
                    BFNodeEventArgs<BfInstancesModel> bfArgs =
                        new BFNodeEventArgs<BfInstancesModel>(parentInstanceModel, parentRunningModel.BF_RUNID, e.User);
                    //该节点为子流程节点且为锁定模式，运行状态为 运行中
                    if (IsSubFlowNodeAndLock(bfArgs) &&
                        parentRunningModel.BF_RUNSTATUS == (int)BFRunStatus.运行中)
                    {
                        //更新为已运行，同时运行下一节点，子流程后不要有多分支!!!!
                        isResult = RunNextStep(bfArgs, bfPath);//PATH1
                        e.ParentModel = parentInstanceModel;
                        e.ParentRunID = bfArgs.RunID;
                    }
                }
            }

            return isResult;
        }

        /// <summary>
        /// 运行下一节点
        /// </summary>
        /// <param name="e"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool RunNextStep(BFNodeEventArgs<BfInstancesModel> e, BFPathName bfPath)
        {
            bool isResult = false;

            //业务流实例当前运行节点集合
            List<BfRunningModel> runningList = runningSrv.GetListByInstanceId(e.Model.BF_INSTANCEID)
                .Where(p => p.BF_INSTANCEID == e.Model.BF_INSTANCEID).ToList();
            //节点集合
            List<BfNodesModel> nodesList = nodeSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();
            //节点流转集合
            List<BfFlowpathModel> flowpathList = flowpathSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();

            //运行表对应的记录
            BfRunningModel currRunningModel = runningList.Find(p => p.BF_RUNID == e.RunID);
            //当前运行的流转路径
            BfFlowpathModel processPath = currRunningModel.BfFlowpath;
            // flowpathList.Find(p => p.BF_PATHID == currRunningModel.BF_PATHID);
            //流转路径的终点==下一节点（即为当前节点）
            BfNodesModel processNode = nodesList.Find(p => p.BF_NODEID == processPath.BF_NEXTNODE);
            if (processPath != null && processNode != null)
            {
                //更新本节点的状态
                currRunningModel.BF_RUNDATE = DateTime.Now;
                currRunningModel.BF_RUNSTATUS = (int)BFRunStatus.已运行;
                currRunningModel.DB_Option_Action = WebKeys.UpdateAction;
                isResult = runningSrv.Execute(currRunningModel);

                //下一节点的所有流转路径
                List<BfFlowpathModel> nextPaths = flowpathList.Where(p => p.BF_NODEID == processNode.BF_NODEID).ToList();
                //增加对分支节点--并行流程的处理
                if (bfPath == BFPathName.ALL &&
                    processNode.BF_FLOWTYPE1 == (int)BFProcessNodeType.并行)
                {
                    foreach (BfFlowpathModel pathModel in nextPaths)
                    {
                        BfNodesModel nextNode = nodesList.Find(p => p.BF_NODEID == pathModel.BF_NEXTNODE);
                        BfRunningModel runningModel = new BfRunningModel();
                        runningModel.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                        runningModel.BF_PATHID = pathModel.BF_PATHID;
                        runningModel.BF_RUNID = WebKeys.BF_RUN_PERFIX + CommonTool.GetPkId();
                        runningModel.BF_RUNSTATUS = (int)BFRunStatus.未运行;
                        runningModel.BF_RUNDESC = nextNode.BF_NODENAME;
                        runningModel.BF_RUNDATE = DateTime.Now;
                        runningModel.DB_Option_Action = WebKeys.InsertAction;
                        runningSrv.Execute(runningModel);
                        //保存下一节点，由于并行分支有多个，这里用哈希表保存
                        e.SetRunID(pathModel.BF_PATHNAME, runningModel.BF_RUNID);
                        e.SetNextNodeID(pathModel.BF_PATHNAME, nextNode.BF_NODEID);
                        //提取下一运行节点的角色用户身份
                        isResult = GetRolesIdentity(e, BFRoleType.动态角色);
                        if (isResult)
                        {
                            //发送待办和提醒消息
                            SendNotificationMessage(e);
                        }
                    }
                }
                else
                {
                    BfFlowpathModel path1 = nextPaths.Find(p => p.BF_PATHNAME == bfPath.ToString());
                    BfNodesModel node1 = nodesList.Find(p => p.BF_NODEID == path1.BF_NEXTNODE);
                    BfRunningModel runningModel = new BfRunningModel();
                    runningModel.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                    runningModel.BF_PATHID = path1.BF_PATHID;
                    runningModel.BF_RUNID = WebKeys.BF_RUN_PERFIX + CommonTool.GetPkId();
                    runningModel.BF_RUNSTATUS = (int)BFRunStatus.未运行;
                    runningModel.BF_RUNDESC = node1.BF_NODENAME;
                    runningModel.BF_RUNDATE = DateTime.Now;
                    runningModel.DB_Option_Action = WebKeys.InsertAction;
                    runningSrv.Execute(runningModel);
                    //保存下一节点ID
                    e.SetRunID(path1.BF_PATHNAME, runningModel.BF_RUNID);
                    e.SetNextNodeID(path1.BF_PATHNAME, node1.BF_NODEID);
                    //提取下一运行节点的角色用户身份
                    isResult = GetRolesIdentity(e, BFRoleType.动态角色);
                    if (isResult)
                    {
                        //发送待办和提醒消息
                        SendNotificationMessage(e);
                    }
                }
            }

            return isResult;
        }

        /// <summary>
        /// 运行到上一节点
        /// </summary>
        /// <returns></returns>
        public bool RunPrevStep(BFNodeEventArgs<BfInstancesModel> e)
        {
            bool isResult = false;

            //业务流实例当前运行节点集合
            List<BfRunningModel> runningList = runningSrv.GetListByInstanceId(e.Model.BF_INSTANCEID).
                Where(p => p.BF_INSTANCEID == e.Model.BF_INSTANCEID).ToList();
            //节点集合
            List<BfNodesModel> nodesList = nodeSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();
            //节点流转集合
            List<BfFlowpathModel> flowpathList = flowpathSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();

            //运行表对应的记录
            BfRunningModel currRunningModel = runningList.Find(p => p.BF_RUNID == e.RunID);
            //当前运行的流转路径
            BfFlowpathModel processPath = currRunningModel.BfFlowpath;
            // flowpathList.Find(p => p.BF_PATHID == currRunningModel.BF_PATHID);
            //流转路径的终点==下一节点（即为当前节点）
            BfNodesModel processNode = nodesList.Find(p => p.BF_NODEID == processPath.BF_NEXTNODE);

            //回退只支持普通业务节点
            if (processPath != null && processNode != null && 
                processNode.BF_NODETYPE == BFNodeType.processNode.ToString())
            {
                //允许回退
                if (processNode.BF_FORWARD != null && processNode.BF_FORWARD.Value == 1)
                {
                    //更新本节点的状态
                    currRunningModel.BF_RUNDATE = DateTime.Now;
                    currRunningModel.BF_RUNSTATUS = (int)BFRunStatus.已运行;
                    currRunningModel.DB_Option_Action = WebKeys.UpdateAction;
                    isResult = runningSrv.Execute(currRunningModel);

                    //回退操作
                    BfNodesModel node1 = nodesList.Find(p => p.BF_NODEID == processPath.BF_NODEID);//上一节点(流转路径起点)
                    BfFlowpathModel path1 = flowpathList.Find(p => p.BF_PATHNAME == BFPathName.PATH1.ToString());//缺省为PATH1
                    BfRunningModel runningModel = new BfRunningModel();
                    runningModel.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                    runningModel.BF_PATHID = path1.BF_PATHID;
                    runningModel.BF_RUNID = WebKeys.BF_RUN_PERFIX + CommonTool.GetPkId();
                    runningModel.BF_RUNSTATUS = (int)BFRunStatus.未运行;
                    runningModel.BF_RUNDESC = node1.BF_NODENAME + "(回退)";
                    runningModel.BF_RUNDATE = DateTime.Now;
                    runningModel.DB_Option_Action = WebKeys.InsertAction;
                    isResult = runningSrv.Execute(runningModel);
                    //保存下一节点ID
                    e.SetRunID(path1.BF_PATHNAME, runningModel.BF_RUNID);
                    e.SetNextNodeID(path1.BF_PATHNAME, node1.BF_NODEID);
                    //由于是回退，所以无需再提取角色
                    if (isResult)
                    {
                        //发送待办和提醒消息
                        SendNotificationMessage(e);
                    }
                }


            }


            return isResult;
        }

        /// <summary>
        /// 根据运行ID改变业务流运行状态
        /// </summary>
        /// <param name="runId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool ChangeBFStatus(string runId, BFStatus status)
        {
            bool isResult = false;

            if (!string.IsNullOrEmpty(runId))
            {
                BfRunningModel runningModel = runningSrv.GetModelById(runId);
                runningModel.BF_RUNSTATUS = (int)BFRunStatus.已运行;
                runningModel.DB_Option_Action = WebKeys.UpdateAction;
                isResult = runningSrv.Execute(runningModel);

                BfInstancesModel instanceModel = instanceSrv.GetList().FirstOrDefault(p => p.BF_INSTANCEID == runningModel.BF_INSTANCEID);
                instanceModel.BF_STATUSVALUE = (int)status;
                instanceModel.DB_Option_Action = WebKeys.UpdateAction;
                isResult = instanceSrv.Execute(instanceModel);
            }

            return isResult;
        }


        /// <summary>
        /// 关闭当前业务流
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public bool CloseBF(string instanceId)
        {
            bool isResult = false;

            if (!string.IsNullOrEmpty(instanceId))
            {
                List<BfRunningModel> runningList = runningSrv.GetListByInstanceId(instanceId).ToList();
                foreach (BfRunningModel runModel in runningList)
                {
                    if (runModel.BF_RUNSTATUS != (int)BFRunStatus.已运行)
                    {
                        runModel.BF_RUNSTATUS = (int)BFRunStatus.已运行;
                        runModel.DB_Option_Action = WebKeys.UpdateAction;
                        isResult = runningSrv.Execute(runModel);
                    }
                }

                BfInstancesModel instanceModel = instanceSrv.GetList().FirstOrDefault(p => p.BF_INSTANCEID == instanceId);
                if (instanceModel != null)
                {
                    instanceModel.BF_STATUSVALUE = (int)BFStatus.结束;
                    instanceModel.DB_Option_Action = WebKeys.UpdateAction;
                    isResult = instanceSrv.Execute(instanceModel);
                }
            }

            return isResult;
        }

        /// <summary>
        /// 只更新当前运行节点的状态
        /// </summary>
        /// <param name="runId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateRunStatus(string runId, BFRunStatus status)
        {
            bool isResult = false;

            if (!string.IsNullOrEmpty(runId))
            {
                BfRunningModel runningModel = runningSrv.GetModelById(runId);
                runningModel.BF_RUNSTATUS = (int)status;
                runningModel.DB_Option_Action = WebKeys.UpdateAction;
                isResult = runningSrv.Execute(runningModel);
            }

            return isResult;
        }

        /// <summary>
        /// 判断是否子流程节点且为锁定模式
        /// </summary>
        /// <param name="e"></param>
        /// <param name="bfPath"></param>
        /// <returns></returns>
        public bool IsSubFlowNodeAndLock(BFNodeEventArgs<BfInstancesModel> e)
        {
            bool isResult = false;

            //业务流实例当前运行节点集合
            List<BfRunningModel> runningList = runningSrv.GetListByInstanceId(e.Model.BF_INSTANCEID).Where(p => p.BF_INSTANCEID == e.Model.BF_INSTANCEID).ToList();
            //节点集合
            List<BfNodesModel> nodesList = nodeSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();
            ////节点流转集合
            //List<BfFlowpathModel> flowpathList = flowpathSrv.GetList().
            //    Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();

            //运行表对应的记录
            BfRunningModel currRunningModel = runningList.Find(p => p.BF_RUNID == e.RunID);
            //当前运行的流转路径
            BfFlowpathModel processPath = currRunningModel.BfFlowpath;
            // flowpathList.Find(p => p.BF_PATHID == currRunningModel.BF_PATHID);
            //流转路径的终点==下一节点(即为当前节点)
            BfNodesModel processCurrNode = nodesList.Find(p => p.BF_NODEID == processPath.BF_NEXTNODE);

            //判断当前节点是否是子流程节点
            if (processCurrNode != null && processCurrNode.BF_NODETYPE == BFNodeType.subflowNode.ToString())
            {
                if (processCurrNode.BF_FLOWTYPE2 == (int)BFSubflowNodeType.锁定模式)
                {
                    isResult = true;
                }
                else
                {
                    isResult = false;
                }
            }

            return isResult;
        }

        /// <summary>
        /// 检测汇合节点是否所有分支已运行完成
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool IsJoinNodeOver(BFNodeEventArgs<BfInstancesModel> e)
        {
            bool isResult = false;

            //业务流实例当前运行节点集合
            List<BfRunningModel> runningList = runningSrv.GetListByInstanceId(e.Model.BF_INSTANCEID).
                Where(p => p.BF_INSTANCEID == e.Model.BF_INSTANCEID).ToList();
            //节点集合
            List<BfNodesModel> nodesList = nodeSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();
            //节点流转集合
            List<BfFlowpathModel> flowpathList = flowpathSrv.GetList().
                Where(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION).ToList();

            //运行表对应的记录
            BfRunningModel currRunningModel = runningList.Find(p => p.BF_RUNID == e.RunID);
            //当前运行的流转路径
            BfFlowpathModel processPath = currRunningModel.BfFlowpath;
            // flowpathList.Find(p => p.BF_PATHID == currRunningModel.BF_PATHID);
            //流转路径的终点==下一节点(即为当前节点)
            BfNodesModel processCurrNode = nodesList.Find(p => p.BF_NODEID == processPath.BF_NEXTNODE);

            //判断当前节点是否是汇合节点
            if (processCurrNode != null && processCurrNode.BF_NODETYPE == BFNodeType.joinNode.ToString())
            {
                //提取流转表中所有以本节点为下一节点的流转路径
                List<BfFlowpathModel> paths = flowpathList.Where(p => p.BF_NEXTNODE == processCurrNode.BF_NODEID).ToList();
                //所有分支必须全部运行，才表示通过
                foreach (BfFlowpathModel path in paths)
                {
                    //提取上一节点的所有对应路径，以判断其运行是否完成
                    List<BfFlowpathModel> prevPaths = flowpathList.Where(p => p.BF_NEXTNODE == path.BF_NODEID).ToList();
                    foreach (BfFlowpathModel prevPath in prevPaths)
                    {
                        int count = runningList.Count(p => p.BF_PATHID == prevPath.BF_PATHID && p.BF_RUNSTATUS == (int)BFRunStatus.已运行);
                        if (processCurrNode.BF_FLOWTYPE3 == (int)BFJoinNodeType.等待所有分支)
                        {
                            if (count == 0)
                                return false;
                            else
                                isResult = true;
                        }
                        else
                        {
                            //只要有一条已运行，则表示通过
                            if (count > 0) return true;
                        }
                    }
                }

            }

            return isResult;
        }


        /// <summary>
        /// 检测当前是否已运行到完成节点
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <returns></returns>
        public bool IsRunOver(BFNodeEventArgs<BfInstancesModel> e)
        {
            bool isOver = false;

            if (!string.IsNullOrEmpty(e.RunID))
            {
                BfRunningModel runningModel = runningSrv.GetListByInstanceId(e.Model.BF_INSTANCEID).Where(p => p.BF_RUNID == e.RunID).FirstOrDefault();
                BfFlowpathModel currFlowpath = flowpathSrv.GetList().
                    Where(p => p.BF_PATHID == runningModel.BF_PATHID).FirstOrDefault();
                //最后节点==完成
                if ((currFlowpath.BF_NEXTNODE == currFlowpath.BF_ENDNODE) && 
                    runningModel.BF_RUNSTATUS != (int)BFRunStatus.已运行)
                {
                    isOver = true;
                }
            }

            return isOver;
        }

        #endregion


        #region 角色身份获取

        /// <summary>
        /// 获取节点角色的实际身份
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <param name="roleType">角色类型</param>
        /// <returns></returns>
        public bool GetRolesIdentity(BFNodeEventArgs<BfInstancesModel> e, BFRoleType roleType)
        {
            bool isOK = true;

            List<BfNoderolesModel> nodeRolesList = noderolesSrv.GetListById_Version(e.Model.BF_ID,e.Model.BF_VERSION).
                Where(p => p.BF_ROLETYPE == (int)roleType).ToList();
            
            if (roleType == BFRoleType.指定人员)
            {
                //提取用户身份进入业务流实例角色表
                nodeRolesList = nodeRolesList.Where(p => p.BF_ROLETYPE == (int)roleType).ToList();
                foreach (BfNoderolesModel model in nodeRolesList)
                {
                    BfInstancerolesModel insRoleModel = new BfInstancerolesModel();
                    insRoleModel.BF_INSTANCEROLEID = CommonTool.GetPkId();
                    insRoleModel.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                    insRoleModel.BF_NODEID = model.BF_NODEID;
                    insRoleModel.BF_OPERATIONTYPE = model.BF_OPERATIONTYPE;
                    insRoleModel.BF_ROLENAME = model.BF_ROLENAME;
                    insRoleModel.BF_ROLETYPE = model.BF_ROLETYPE;
                    insRoleModel.USERIDS = "," + model.USERID + ",";
                    insRoleModel.DB_Option_Action = WebKeys.InsertAction;
                    isOK = instanceRolesSrv.Execute(insRoleModel);
                }
            }
            else if (roleType == BFRoleType.静态角色)
            {
                //提取用户身份进入业务流实例角色表
                nodeRolesList = nodeRolesList.Where(p => p.BF_ROLETYPE == (int)roleType).ToList();
                foreach (BfNoderolesModel model in nodeRolesList)
                {
                    BfInstancerolesModel insRoleModel = new BfInstancerolesModel();
                    insRoleModel.BF_INSTANCEROLEID = CommonTool.GetPkId();
                    insRoleModel.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                    insRoleModel.BF_NODEID = model.BF_NODEID;
                    insRoleModel.BF_OPERATIONTYPE = model.BF_OPERATIONTYPE;
                    insRoleModel.BF_ROLENAME = model.BF_ROLENAME;
                    insRoleModel.BF_ROLETYPE = model.BF_ROLETYPE;
                    insRoleModel.USERIDS = GetRoleUserId(e, model.BfClsmethod);
                    insRoleModel.DB_Option_Action = WebKeys.InsertAction;
                    isOK = instanceRolesSrv.Execute(insRoleModel);
                }
            }
            else if (roleType == BFRoleType.动态角色)
            {
                //动态角色在节点执行前完成用户身份的提取，并存入到业务流实例角色表
                foreach (DictionaryEntry need in e.NextNodeIdHash)
                {
                    IList<BfNoderolesModel> dynamicRoleLst = nodeRolesList.Where(p => p.BF_NODEID == need.Value.ToString()).ToList();
                    foreach (BfNoderolesModel model in dynamicRoleLst)
                    {
                        BfInstancerolesModel insRoleModel = new BfInstancerolesModel();
                        insRoleModel.BF_INSTANCEROLEID = CommonTool.GetPkId();
                        insRoleModel.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                        insRoleModel.BF_NODEID = model.BF_NODEID;
                        insRoleModel.BF_OPERATIONTYPE = model.BF_OPERATIONTYPE;
                        insRoleModel.BF_ROLENAME = model.BF_ROLENAME;
                        insRoleModel.BF_ROLETYPE = model.BF_ROLETYPE;
                        insRoleModel.USERIDS = GetRoleUserId(e, model.BfClsmethod);
                        insRoleModel.DB_Option_Action = WebKeys.InsertAction;
                        isOK = instanceRolesSrv.Execute(insRoleModel);
                    }
                }
                
            }

            return isOK;
        }

        /// <summary>
        /// 获取业务流节点上操作角色的真实身份（用户ID）
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <param name="clsmethodModel">角色获取方法类实例</param>
        /// <returns></returns>
        public string GetRoleUserId(BFNodeEventArgs<BfInstancesModel> e, BfClsmethodsModel clsmethodModel)
        {
            StringBuilder userIds = new StringBuilder();
            try
            {
                //根据类型创建对象
                string[] classStrs = clsmethodModel.BF_CLSNAME.Split('.');
                if (classStrs != null && classStrs.Length >= 3)
                {
                    string assemblyPath = string.Format("{0}.{1}.{2}", classStrs[0], classStrs[1], classStrs[2]);
                    object dObj = Assembly.Load(assemblyPath).CreateInstance(clsmethodModel.BF_CLSNAME);
                    Type attr_t = dObj.GetType();//Type.GetType(clsmethodModel.BF_CLSNAME);
                    //object dObj = Activator.CreateInstance(attr_t);
                    //获取方法的信息
                    MethodInfo method = attr_t.GetMethod(clsmethodModel.BF_METHOD);
                    //调用方法的一些标志位，这里的含义是Public并且是实例方法，这也是默认的值
                    BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
                    //调用方法
                    object[] attr_parameters = new object[] { e };
                    userIds.Append(method.Invoke(dObj, flag, Type.DefaultBinder, attr_parameters, null));
                }
            }
            catch (Exception ex)
            {
                Debuger.GetInstance().log(this, "执行GetRoleUserId方法出错!", ex);
            }

            return userIds.ToString();
        }

        #endregion


        #region 待办消息==========================================================

        /// <summary>
        /// 发送通知消息给接收者（非流程性质的待办事务）
        /// </summary>
        /// <param name="instanceId">实例ID</param>
        /// <param name="receiveUserId">接收用户ID</param>
        /// <param name="user">当前用户MODEL</param>
        /// <param name="title">标题</param>
        /// <param name="msgText">内容</param>
        /// <param name="remindWay">提醒方式 SMS MSG EMAIL</param>
        /// <param name="isTrust">是否启用代办</param>
        /// <returns></returns>
        public bool SendNotificationMessage(string instanceId, int receiveUserId, SysUserModel user,
            string title,string msgText,string remindWay, bool isTrust)
        {
            bool isOK = false;
            //代办
            BfTrustusersModel trustModel = null;
            if (isTrust)
            {
                //所有人员的事务代办信息(只取有效状态的记录)
                IList<BfTrustusersModel> trustuserList = trustuserSrv.GetList();
                //提取代办信息
                trustModel = trustuserList.
                                FirstOrDefault(p => p.BF_FROMUSER == receiveUserId &&
                                    (p.BF_TRUSTSTART <= DateTime.Now && p.BF_TRUSTEND >= DateTime.Now) && p.BF_TRUSTSTATUS == 1);
            }
            //1==待办事项---------
            BfUnhandledmsgModel msg = new BfUnhandledmsgModel();
            msg.BF_MSGID = WebKeys.BF_MESSAGE_PREFIX + CommonTool.GetPkId();
            msg.BF_INSTANCEID = instanceId;
            msg.BF_ISREAD = 0;
            msg.BF_RECIPIENTSNAME = (trustModel != null && trustModel.BF_FROMUSER != null) ? trustModel.BF_FROMUSER.ToString() : receiveUserId.ToString();
            msg.BF_RECIPIENTS = (trustModel != null && trustModel.BF_TOUSER != null) ? trustModel.BF_TOUSER : receiveUserId;
            msg.BF_SENDER = user.USERID;
            msg.BF_SENDERNAME = user.UNAME;
            msg.BF_SENDTIME = DateTime.Now;
            msg.BF_MSGTITLE = string.Format("{0}{1}", title,
                (trustModel != null && trustModel.BF_TOUSER != null) ? "[代办]" : "");//标题
            msg.BF_MSGTEXT = string.Format("{0}MsgID={1}",
                            (msgText.Contains("?") ? msgText + "&" : msgText + "?"), msg.BF_MSGID);
            msg.DB_Option_Action = WebKeys.InsertAction;

            //add by qw 2015.5.6 清除相同的未处理消息 start
            msgSrv.ClearUnhandleMsgIsSame(receiveUserId, user.USERID, title, msgText);
            //end

            isOK = msgSrv.ExecuteUnhandle(msg);

            //2==根据节点的消息提醒方式发送消息（RTX消息要根据用户缺省语言类型转为相应的语言）
            if (!string.IsNullOrEmpty(remindWay))
            {
                //创建消息
                Messages messageModel = new Messages();
                messageModel.MSG_OBJECTID = msg.BF_MSGID;
                messageModel.MSG_TITLE = "待办事务提醒";
                messageModel.MSG_TEXT = msg.BF_MSGTITLE;

                if (remindWay.Contains(BFRemindWay.MSG.ToString()))
                {
                    IMService messageService = MessageFactory.Creator(MessageType.即时消息);
                    messageModel.MSG_TYPE = MessageType.即时消息;
                    messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                    messageModel.MSG_RECEIVER = SysUserService.GetUserLoginName(msg.BF_RECIPIENTS.Value);
                    messageService.SendMessage(messageModel);
                }
                if (remindWay.Contains(BFRemindWay.EMAIL.ToString()))
                {
                    //邮件
                    IMService messageService = MessageFactory.Creator(MessageType.电子邮件);
                    messageModel.MSG_TYPE = MessageType.电子邮件;
                    messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                    messageModel.MSG_RECEIVER = SysUserService.GetUserModelByUserId(msg.BF_RECIPIENTS.Value).OTHEREMAIL;
                    messageModel.MSG_SENDER = user.ULOGINNAME;
                    messageService.SendMessage(messageModel);
                }
                if (remindWay.Contains(BFRemindWay.SMS.ToString()))
                {
                    //短信
                    IMService messageService = MessageFactory.Creator(MessageType.手机短信);
                    messageModel.MSG_TYPE = MessageType.手机短信;
                    messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                    messageModel.MSG_RECEIVER = SysUserService.GetUserModelByUserId(msg.BF_RECIPIENTS.Value).UHWPHONE;
                    messageModel.MSG_SENDER = user.ULOGINNAME;
                    messageService.SendMessage(messageModel);
                }
            }

            return isOK;
        }

        public bool SendNotificationMessage(string instanceId, int receiveUserId, SysUserModel user,
            string title, string msgText, string remindWay, bool isTrust,string msguid)
        {
            bool isOK = false;
            //代办
            BfTrustusersModel trustModel = null;
            if (isTrust)
            {
                //所有人员的事务代办信息(只取有效状态的记录)
                IList<BfTrustusersModel> trustuserList = trustuserSrv.GetList();
                //提取代办信息
                trustModel = trustuserList.
                                FirstOrDefault(p => p.BF_FROMUSER == receiveUserId &&
                                    (p.BF_TRUSTSTART <= DateTime.Now && p.BF_TRUSTEND >= DateTime.Now) && p.BF_TRUSTSTATUS == 1);
            }
            //1==待办事项---------
            BfUnhandledmsgModel msg = new BfUnhandledmsgModel();
            //msg.BF_MSGID = WebKeys.BF_MESSAGE_PREFIX + CommonTool.GetPkId();
            msg.BF_MSGID = msguid;
            msg.BF_INSTANCEID = instanceId;
            msg.BF_ISREAD = 0;
            msg.BF_RECIPIENTSNAME = (trustModel != null && trustModel.BF_FROMUSER != null) ? trustModel.BF_FROMUSER.ToString() : receiveUserId.ToString();
            msg.BF_RECIPIENTS = (trustModel != null && trustModel.BF_TOUSER != null) ? trustModel.BF_TOUSER : receiveUserId;
            msg.BF_SENDER = user.USERID;
            msg.BF_SENDERNAME = user.UNAME;
            msg.BF_SENDTIME = DateTime.Now;
            msg.BF_MSGTITLE = string.Format("{0}{1}", title,
                (trustModel != null && trustModel.BF_TOUSER != null) ? "[代办]" : "");//标题
            msg.BF_MSGTEXT = string.Format("{0}MsgID={1}",
                            (msgText.Contains("?") ? msgText + "&" : msgText + "?"), msg.BF_MSGID);
            msg.DB_Option_Action = WebKeys.InsertAction;

            //add by qw 2015.5.6 清除相同的未处理消息 start
            msgSrv.ClearUnhandleMsgIsSame(receiveUserId, user.USERID, title, msgText);
            //end

            isOK = msgSrv.ExecuteUnhandle(msg);

            //2==根据节点的消息提醒方式发送消息（RTX消息要根据用户缺省语言类型转为相应的语言）
            if (!string.IsNullOrEmpty(remindWay))
            {
                //创建消息
                Messages messageModel = new Messages();
                messageModel.MSG_OBJECTID = msg.BF_MSGID;
                messageModel.MSG_TITLE = "待办事务提醒";
                messageModel.MSG_TEXT = msg.BF_MSGTITLE;

                if (remindWay.Contains(BFRemindWay.MSG.ToString()))
                {
                    IMService messageService = MessageFactory.Creator(MessageType.即时消息);
                    messageModel.MSG_TYPE = MessageType.即时消息;
                    messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                    messageModel.MSG_RECEIVER = SysUserService.GetUserLoginName(msg.BF_RECIPIENTS.Value);
                    messageService.SendMessage(messageModel);
                }
                if (remindWay.Contains(BFRemindWay.EMAIL.ToString()))
                {
                    //邮件
                    IMService messageService = MessageFactory.Creator(MessageType.电子邮件);
                    messageModel.MSG_TYPE = MessageType.电子邮件;
                    messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                    messageModel.MSG_RECEIVER = SysUserService.GetUserModelByUserId(msg.BF_RECIPIENTS.Value).OTHEREMAIL;
                    messageModel.MSG_SENDER = user.ULOGINNAME;
                    messageService.SendMessage(messageModel);
                }
                if (remindWay.Contains(BFRemindWay.SMS.ToString()))
                {
                    //短信
                    IMService messageService = MessageFactory.Creator(MessageType.手机短信);
                    messageModel.MSG_TYPE = MessageType.手机短信;
                    messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                    messageModel.MSG_RECEIVER = SysUserService.GetUserModelByUserId(msg.BF_RECIPIENTS.Value).UHWPHONE;
                    messageModel.MSG_SENDER = user.ULOGINNAME;
                    messageService.SendMessage(messageModel);
                }
            }

            return isOK;
        }

        /// <summary>
        /// 发送通知消息给节点操作人
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <returns></returns>
        public bool SendNotificationMessage(BFNodeEventArgs<BfInstancesModel> e)
        {
            bool isOK = false;

            //所有人员的事务代办信息(只取有效状态的记录)
            IList<BfTrustusersModel> trustuserList = trustuserSrv.GetList();

            //实例对应的角色用户
            IList<BfInstancerolesModel> instanceRolesList = instanceRolesSrv.GetListByInstanceId(e.Model.BF_INSTANCEID).ToList();

            foreach (DictionaryEntry need in e.NextNodeIdHash)
            {
                //节点信息
                BfNodesModel nodeModel = nodeSrv.GetList().
                    FirstOrDefault(p => p.BF_ID == e.Model.BF_ID && p.BF_VERSION == e.Model.BF_VERSION && p.BF_NODEID == need.Value.ToString());
                //提取下一运行节点的所有操作人
                IList<BfInstancerolesModel> roles = instanceRolesList.Where(p=>p.BF_NODEID == need.Value.ToString()).ToList();
                foreach (BfInstancerolesModel role in roles)
                {
                    foreach (string uid in role.USERIDS.Split(','))
                    {
                        if (string.IsNullOrEmpty(uid)) continue;

                        int userId = 0;
                        int.TryParse(uid, out userId);
                        if (userId == 0) continue;

                        BfTrustusersModel trustModel = trustuserList.
                            FirstOrDefault(p => p.BF_FROMUSER == userId && 
                                (p.BF_TRUSTSTART <= DateTime.Now && p.BF_TRUSTEND >= DateTime.Now) && p.BF_TRUSTSTATUS == 1);
                        //1==待办事项----------
                        BfUnhandledmsgModel msg = new BfUnhandledmsgModel();
                        msg.BF_MSGID = WebKeys.BF_MESSAGE_PREFIX + CommonTool.GetPkId();
                        msg.BF_INSTANCEID = e.Model.BF_INSTANCEID;
                        msg.BF_INSTANCEROLEID = role.BF_INSTANCEROLEID;
                        msg.BF_ISREAD = 0;
                        msg.BF_RECIPIENTSNAME = (trustModel != null && trustModel.BF_FROMUSER != null) ? trustModel.BF_FROMUSER.ToString() : uid;
                        msg.BF_RECIPIENTS = (trustModel != null && trustModel.BF_TOUSER != null) ? trustModel.BF_TOUSER : userId;
                        msg.BF_RUNID = e.GetRunID(need.Key.ToString());
                        msg.BF_SENDER = ((SysUserModel)e.User).USERID;
                        msg.BF_SENDERNAME = ((SysUserModel)e.User).UNAME;
                        msg.BF_SENDTIME = DateTime.Now;
                        msg.BF_MSGTITLE = string.Format("{0}{1}", e.Model.BF_DESCRIBE,
                            (trustModel != null && trustModel.BF_TOUSER != null) ? "[代办]" : "");//标题
                        //string.Format("{0}的{1}环节需要您进行操作！", e.Model.BF_DESCRIBE, nodeModel.BF_NODENAME);
                        msg.BF_MSGTEXT = string.Format("{0}RunID={1}&MsgID={2}",
                            (nodeModel.BF_FORM.Contains("?") ? nodeModel.BF_FORM + "&" : nodeModel.BF_FORM + "?"),
                            msg.BF_RUNID, msg.BF_MSGID);
                        //string.Format("<a href='{0}?RunID={1}&MsgID={2}'>{3}</a>", nodeModel.BF_FORM, msg.BF_RUNID, msg.BF_MSGID, "【我要处理】");
                        msg.DB_Option_Action = WebKeys.InsertAction;

                        //add by qw 2015.5.6 清除相同的未处理消息 start
                        string msgText = string.Format("{0}RunID={1}",
                            (nodeModel.BF_FORM.Contains("?") ? nodeModel.BF_FORM + "&" : nodeModel.BF_FORM + "?"),
                            msg.BF_RUNID);
                        msgSrv.ClearUnhandleMsgIsSame(msg.BF_RECIPIENTS.Value, msg.BF_SENDER.Value, msg.BF_MSGTITLE, msgText);
                        //end

                        isOK = msgSrv.ExecuteUnhandle(msg);

                        //2==根据节点的消息提醒方式发送消息（RTX消息要根据用户缺省语言类型转为相应的语言）
                        if (!string.IsNullOrEmpty(nodeModel.BF_REMINDWAY))
                        {
                            //创建消息
                            Messages messageModel = new Messages();
                            messageModel.MSG_OBJECTID = msg.BF_MSGID;
                            messageModel.MSG_TITLE = "待办事务提醒";
                            SysUserModel user = SysUserService.GetUserModelByLoginName(e.Model.BF_FOUNDER);
                            messageModel.MSG_TEXT = string.Format("申请人【{0}】事由【{1}】,请您登录办公平台操作!", user.UNAME, msg.BF_MSGTITLE);

                            if (nodeModel.BF_REMINDWAY.Contains(BFRemindWay.MSG.ToString()))
                            {
                                IMService messageService = MessageFactory.Creator(MessageType.即时消息);
                                messageModel.MSG_TYPE = MessageType.即时消息;
                                messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                                messageModel.MSG_RECEIVER = SysUserService.GetUserLoginName(msg.BF_RECIPIENTS.Value);
                                messageService.SendMessage(messageModel);
                            }
                            if (nodeModel.BF_REMINDWAY.Contains(BFRemindWay.EMAIL.ToString()))
                            {
                                //邮件
                                IMService messageService = MessageFactory.Creator(MessageType.电子邮件);
                                messageModel.MSG_TYPE = MessageType.电子邮件;
                                messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                                messageModel.MSG_RECEIVER = SysUserService.GetUserModelByUserId(msg.BF_RECIPIENTS.Value).OTHEREMAIL;
                                messageModel.MSG_SENDER = user.ULOGINNAME;
                                messageService.SendMessage(messageModel);
                            }
                            if (nodeModel.BF_REMINDWAY.Contains(BFRemindWay.SMS.ToString()))
                            {
                                //短信
                                IMService messageService = MessageFactory.Creator(MessageType.手机短信);
                                messageModel.MSG_TYPE = MessageType.手机短信;
                                messageModel.MSG_ID = CommonTool.NewGuid().ToString();
                                messageModel.MSG_RECEIVER = SysUserService.GetUserModelByUserId(msg.BF_RECIPIENTS.Value).UHWPHONE;
                                messageModel.MSG_SENDER = user.ULOGINNAME;
                                messageService.SendMessage(messageModel);
                            }
                        }
                    }

                }
            }

            return isOK;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取运行表当前实例
        /// </summary>
        /// <param name="runId"></param>
        /// <returns></returns>
        public BfRunningModel GetRunningModel(string runId)
        {
            return runningSrv.GetModelById(runId);
        }

        /// <summary>
        /// 检测当前用户是否为该节点操作人(支持代办)
        /// </summary>
        /// <param name="runId"></param>
        /// <param name="msgId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CheckUserPermission(string runId, string msgId, int userId)
        {
            BfRunningModel running = GetRunningModel(runId);
            if (running != null)
            {
                //获取该节点的所有操作人的真实身份
                List<BfInstancerolesModel> roleList = instanceRolesSrv.GetListByInstanceId(running.BF_INSTANCEID).
                    Where(p => p.BF_NODEID == running.BfFlowpath.BF_NEXTNODE && p.BF_OPERATIONTYPE == 0).ToList();
                if (roleList.Count == 0) return true;

                //加入对代办的验证
                BfUnhandledmsgModel msgModel = msgSrv.GetModelById(msgId);
                if (msgModel != null &&
                    !msgModel.BF_RECIPIENTSNAME.Equals(msgModel.BF_RECIPIENTS.ToString()))
                {
                    //表示当前人员为待办者，切换到原用户
                    userId = msgModel.BF_RECIPIENTSNAME.ToInt();
                }
                //检测用户是否合法
                BfInstancerolesModel role = roleList.Find(p=>p.USERIDS.Contains("," + userId + ","));
                if (role != null)
                    return true;
            }
            return false;
        }

        #endregion
    }

}