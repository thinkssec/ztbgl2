using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{

    /// <summary>
    /// 客户端基础类
    /// </summary>
    [Serializable]
    public class BFClientBase
    {
        /// <summary>
        /// 业务流ID
        /// </summary>
        public string BF_ID { get; set; }
        /// <summary>
        /// 业务流ID
        /// </summary>
        public string BF_NAME { get; set; }
        /// <summary>
        /// 业务流版本
        /// </summary>
        public int BF_VERSION { get; set; }
    }


    /// <summary>
    /// 模型-节点MODEL
    /// </summary>
    [Serializable]
    public class BFMode : BFClientBase
    {
        /// <summary>
        /// 节点编号
        /// </summary>
        public string NODEID { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public string NODETYPE { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string NODENAME { get; set; }
        /// <summary>
        /// 节点描述
        /// </summary>
        public string NODEDESC { get; set; }
        /// <summary>
        /// 节点对应表单
        /// </summary>
        public string FORM { get; set; }
        /// <summary>
        /// 是否支持回退 是 否
        /// </summary>
        public string FORWARD { get; set; }
        /// <summary>
        /// 是否允许代办 是 否
        /// </summary>
        public string COMMISSION { get; set; }
        /// <summary>
        /// 办理时限 天
        /// </summary>
        public int TIMELIMIT { get; set; }
        /// <summary>
        /// 节点进度值
        /// </summary>
        public int PROGRESSVALUE { get; set; }
        /// <summary>
        /// 节点操作人(角色|人员ID)
        /// administrator,manager|123,34
        /// </summary>
        public string DUTYOFFICER { get; set; }
        /// <summary>
        /// 节点通知人(角色|人员ID)
        /// administrator,manager|123,34
        /// </summary>
        public string NOTIFIER { get; set; }
        /// <summary>
        /// 消息提醒方式:SMS,MSG,EMAIL
        /// </summary>
        public string REMINDWAY { get; set; }
        /// <summary>
        /// 缺省意见或结果
        /// </summary>
        public string AUDITOPINION { get; set; }
        /// <summary>
        /// 超期处理方式:0=不处理  1=运行下一节点  2=转代理人处理
        /// </summary>
        public string EXTENDEDTREATMENT { get; set; }
        /// <summary>
        /// 是否为关键节点:是 否
        /// </summary>
        public string KEYPOINT { get; set; }
        /// <summary>
        /// 是否为进度异常控制点:是 否
        /// </summary>
        public string CONTROLPOINT { get; set; }
        /// <summary>
        /// 分支节点流转类型:0=并行 1=多选一
        /// </summary>
        public string FLOWTYPE1 { get; set; }
        /// <summary>
        /// 子流程节点流转类型:1=独立模式 0=锁定模式
        /// </summary>
        public string FLOWTYPE2 { get; set; }
        /// <summary>
        /// 汇合节点流转类型:0=等待所有分支流转到此 1=等待一条分支流转到此
        /// </summary>
        public string FLOWTYPE3 { get; set; }
        /// <summary>
        /// 子流程  ID,版本号
        /// </summary>
        public string SUBBF { get; set; }

    }

    /// <summary>
    /// 连接线MODEL
    /// </summary>
    [Serializable]
    public class BFLine : BFClientBase
    {
        /// <summary>
        /// 线ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 起始点模型ID
        /// </summary>
        public string XBaseMode { get; set; }
        /// <summary>
        /// 起始点模型ID2（类型+序号）
        /// </summary>
        public string SNodeId { get; set; }
        /// <summary>
        /// DIV层显示索引
        /// </summary>
        public string XIndex { get; set; }
        /// <summary>
        /// 终止点模型ID
        /// </summary>
        public string WBaseMode { get; set; }
        /// <summary>
        /// 终止点模型ID2（类型+序号）
        /// </summary>
        public string ENodeId { get; set; }
        /// <summary>
        /// 路径序号
        /// </summary>
        public string Attr_prop_XH { get; set; }
    }

}
