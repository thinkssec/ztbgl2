using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Component.BF
{

    /// <summary>
    /// 文件功能：业务流各节点激活方法回调(抽象类)
    /// 文件描述：继承自System.Web.UI.Page，它是业务流所有执行页面的超类。
    /// </summary>
    public abstract class BFNodeMethodCallback<T> : System.Web.UI.Page
    {

        #region 业务流相关

        /// <summary>
        /// 运行表记录ID
        /// </summary>
        public string RunID = string.Empty;
        /// <summary>
        /// 待办消息ID
        /// </summary>
        public string MsgID = string.Empty;
        /// <summary>
        /// 业务流初始化事件处理
        /// </summary>
        public event BFNodeEvent<T>.BFInitEventHandler BFInitHandler;
        /// <summary>
        /// 起始节点事件处理
        /// </summary>
        public event BFNodeEvent<T>.StartNodeEventHandler StartNodeHandler;
        /// <summary>
        /// 终止节点事件处理
        /// </summary>
        public event BFNodeEvent<T>.EndNodeEventHandler EndNodeHandler;
        /// <summary>
        /// 业务节点事件处理
        /// </summary>
        public event BFNodeEvent<T>.ProcessNodeEventHandler ProcessNodeHandler;
        /// <summary>
        /// 汇合节点事件处理
        /// </summary>
        public event BFNodeEvent<T>.JoinNodeEventHandler JoinNodeHandler;
        /// <summary>
        /// 子流程节点事件处理
        /// </summary>
        public event BFNodeEvent<T>.SubflowNodeEventHandler SubflowNodeHandler;

        /// <summary>
        /// 业务流实例初始化方法
        /// </summary>
        /// <param name="e"></param>
        public void BFInitializingMethod(BFNodeEventArgs<T> e)
        {
            if (BFInitHandler != null)
            {
                BFInitHandler(e);
            }
        }

        /// <summary>
        /// 起始节点激活方法
        /// </summary>
        /// <param name="e"></param>
        public void StartNode_ActivatedMethod(BFNodeEventArgs<T> e)
        {
            if (StartNodeHandler != null)
            {
                StartNodeHandler(e);
            }
        }

        /// <summary>
        /// 终止节点激活方法
        /// </summary>
        /// <param name="e"></param>
        public void EndNode_ActivatedMethod(BFNodeEventArgs<T> e)
        {
            if (EndNodeHandler != null)
            {
                EndNodeHandler(e);
            }
        }

        /// <summary>
        /// 业务节点激活方法
        /// </summary>
        /// <param name="e"></param>
        public void ProcessNode_ActivatedMethod(BFNodeEventArgs<T> e)
        {
            if (ProcessNodeHandler != null)
            {
                ProcessNodeHandler(e);
            }
        }

        /// <summary>
        /// 汇合节点激活方法
        /// </summary>
        /// <param name="e"></param>
        public void JoinNode_ActivatedMethod(BFNodeEventArgs<T> e)
        {
            if (JoinNodeHandler != null)
            {
                JoinNodeHandler(e);
            }
        }

        /// <summary>
        /// 子流程节点激活方法
        /// </summary>
        /// <param name="e"></param>
        public void SubflowNode_ActivatedMethod(BFNodeEventArgs<T> e)
        {
            if (SubflowNodeHandler != null)
            {
                SubflowNodeHandler(e);
            }
        }

        #endregion
    }
}
