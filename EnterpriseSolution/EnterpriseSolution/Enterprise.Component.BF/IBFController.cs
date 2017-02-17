using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Enterprise.Component.BF
{
    /// <summary>
    /// 业务流动作控制接口
    /// </summary>
    public interface IBFController<T> where T : class
    {

        /// <summary>
        /// 初始化执行方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        bool BFInitialize(BFNodeEventArgs<T> e);

        /// <summary>
        /// 运行起始节点
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <param name="bfPath">流转路径</param>
        /// <returns></returns>
        bool RunStartStep(BFNodeEventArgs<T> e, BFPathName bfPath);

        /// <summary>
        /// 运行结束节点
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <param name="bfPath">流转路径</param>
        /// <returns></returns>
        bool RunFinishStep(BFNodeEventArgs<T> e, BFPathName bfPath);

        /// <summary>
        /// 运行下一节点
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <param name="path">流转路径</param>
        /// <returns></returns>
        bool RunNextStep(BFNodeEventArgs<T> e, BFPathName bfPath);

        /// <summary>
        /// 运行到上一节点
        /// </summary>
        /// <returns></returns>
        bool RunPrevStep(BFNodeEventArgs<T> e);

        /// <summary>
        /// 根据运行ID改变业务流运行状态
        /// </summary>
        /// <param name="runId">运行表ID</param>
        /// <param name="status">运行状态</param>
        /// <returns></returns>
        bool ChangeBFStatus(string runId, BFStatus status);

        /// <summary>
        /// 关闭当前业务流
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        bool CloseBF(string instanceId);

        /// <summary>
        /// 只更新当前运行节点的状态
        /// </summary>
        /// <param name="runId">运行表ID</param>
        /// <param name="status">运行状态</param>
        /// <returns></returns>
        bool UpdateRunStatus(string runId, BFRunStatus status);

        /// <summary>
        /// 判断是否子流程节点且为锁定模式
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <param name="bfPath">流转路径</param>
        /// <returns></returns>
        bool IsSubFlowNodeAndLock(BFNodeEventArgs<T> e);

        /// <summary>
        /// 检测汇合节点是否所有分支已运行完成
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <returns></returns>
        bool IsJoinNodeOver(BFNodeEventArgs<T> e);

        /// <summary>
        /// 检测当前是否已运行到完成节点
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <returns></returns>
        bool IsRunOver(BFNodeEventArgs<T> e);

        /// <summary>
        /// 发送通知消息给节点操作人
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <returns></returns>
        bool SendNotificationMessage(BFNodeEventArgs<T> e);

        /// <summary>
        /// 获取节点角色的实际身份
        /// </summary>
        /// <param name="e">事件参数</param>
        /// <param name="roleType">角色类型</param>
        /// <returns></returns>
        bool GetRolesIdentity(BFNodeEventArgs<T> e, BFRoleType roleType);

    }
}
