using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Component.BF
{
    /// <summary>
    /// 业务流节点事件定义
    /// </summary>
    public abstract class BFNodeEvent<T>
    {
        /// <summary>
        /// 初始化-事件委托
        /// </summary>
        /// <param name="e"></param>
        public delegate void BFInitEventHandler(BFNodeEventArgs<T> e);
        /// <summary>
        /// 开始节点-事件委托
        /// </summary>
        /// <param name="e"></param>
        public delegate void StartNodeEventHandler(BFNodeEventArgs<T> e);
        /// <summary>
        /// 完成节点-事件委托
        /// </summary>
        /// <param name="e"></param>
        public delegate void EndNodeEventHandler(BFNodeEventArgs<T> e);
        /// <summary>
        /// 业务节点-事件委托
        /// </summary>
        /// <param name="e"></param>
        public delegate void ProcessNodeEventHandler(BFNodeEventArgs<T> e);
        /// <summary>
        /// 汇合节点-事件委托
        /// </summary>
        /// <param name="e"></param>
        public delegate void JoinNodeEventHandler(BFNodeEventArgs<T> e);
        /// <summary>
        /// 子流程节点-事件委托
        /// </summary>
        /// <param name="e"></param>
        public delegate void SubflowNodeEventHandler(BFNodeEventArgs<T> e);

    }
}
