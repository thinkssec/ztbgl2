using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Component.BF
{

    /// <summary>
    /// 节点类型
    /// </summary>
    public enum BFNodeType
    {
        startNode,
        endNode,
        processNode,
        subflowNode,
        joinNode
    }

    /// <summary>
    /// 业务流状态: 0=运行 1=结束 2=暂停 3=终止
    /// </summary>
    public enum BFStatus
    {
        运行 = 0,
        结束 = 1,
        暂停 = 2,
        终止 = 3
    }


    /// <summary>
    /// 当前节点运行状态：0=未运行 1=已运行 2=运行中
    /// </summary>
    public enum BFRunStatus
    {
        未运行 = 0,
        已运行 = 1,
        运行中 = 2
    }

    /// <summary>
    /// 流转的路径名称
    /// </summary>
    public enum BFPathName
    {
        NONE, ALL, PATH1, PATH2, PATH3, PATH4, PATH5, PATH6, PATH7, PATH8, PATH9
    }

    /// <summary>
    /// 子流程节点流转类型
    /// </summary>
    public enum BFSubflowNodeType
    {
        锁定模式 = 0,
        独立模式 = 1
    }


    /// <summary>
    /// 分支节点流转类型
    /// </summary>
    public enum BFProcessNodeType
    {
        并行 = 0,
        多选一 = 1
    }


    /// <summary>
    /// 汇合节点流转类型
    /// </summary>
    public enum BFJoinNodeType
    {
        等待所有分支 = 0,
        等待一条分支 = 1
    }

    /// <summary>
    /// 角色类型
    /// </summary>
    public enum BFRoleType
    {
        指定人员 = 0,
        静态角色 = 1,
        动态角色 = 2
    }

    /// <summary>
    /// 消息提醒方式
    /// </summary>
    public enum BFRemindWay
    {
        SMS,
        MSG,
        EMAIL
    }

}
