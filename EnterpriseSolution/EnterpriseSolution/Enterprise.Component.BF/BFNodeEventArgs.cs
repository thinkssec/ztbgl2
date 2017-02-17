using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Enterprise.Component.BF
{

    /// <summary>
    /// 委托传递的事件参数
    /// </summary>
    public class BFNodeEventArgs<T> : EventArgs
    {

        /// <summary>
        /// 构造方法1
        /// 初始化事件专用
        /// </summary>
        public BFNodeEventArgs(T model, object user)
        {
            this._InstanceModel = model;
            this._User = user;
            this._RunIdHash = new Hashtable();
            this._NextNodeIdHash = new Hashtable();
        }

        /// <summary>
        /// 构造方法2
        /// 节点事件专用
        /// </summary>
        public BFNodeEventArgs(T model, string runId, object user)
        {
            this._InstanceModel = model;
            this._RunID = runId;
            this._User = user;
            this._RunIdHash = new Hashtable();
            this._NextNodeIdHash = new Hashtable();
        }

        #region 属性定义

        /// <summary>
        /// 业务流下一节点运行记录ID集合
        /// 以路径名为KEY，只保存RUNID
        /// </summary>
        private Hashtable _RunIdHash;
        /// <summary>
        /// 业务流下一节点ID集合
        /// 以路径名为KEY，保存节点ID
        /// </summary>
        private Hashtable _NextNodeIdHash;
        /// <summary>
        /// 当前业务流运行表ID
        /// </summary>
        private string _RunID;
        /// <summary>
        /// 当前用户实例
        /// </summary>
        private object _User;
        /// <summary>
        /// 上一级业务流运行表ID
        /// </summary>
        private string _ParentRunID;
        /// <summary>
        /// 当前业务流实例
        /// </summary>
        private T _InstanceModel;
        /// <summary>
        /// 上一级业务流实例
        /// </summary>
        private T _ParentInstanceModel;

        /// <summary>
        /// 业务流运行表ID
        /// </summary>
        public string RunID
        {
            get
            {
                return this._RunID;
            }
            set
            {
                this._RunID = value;
            }
        }

        /// <summary>
        /// 当前用户实例
        /// </summary>
        public object User
        {
            get
            {
                return this._User;
            }
            set
            {
                this._User = value;
            }
        }

        /// <summary>
        /// 业务流运行表--上一级ID
        /// </summary>
        public string ParentRunID
        {
            get
            {
                return this._ParentRunID;
            }
            set
            {
                this._ParentRunID = value;
            }
        }

        /// <summary>
        /// 当前业务流实例
        /// </summary>
        public T Model
        {
            get
            {
                return this._InstanceModel;
            }
            set
            {
                this._InstanceModel = value;
            }
        }

        /// <summary>
        /// 上一级业务流实例
        /// </summary>
        public T ParentModel
        {
            get
            {
                return this._ParentInstanceModel;
            }
            set
            {
                this._ParentInstanceModel = value;
            }
        }


        /// <summary>
        /// 业务流下一节点运行记录ID集合
        /// 以路径名为KEY，只保存RUNID
        /// </summary>
        public Hashtable RunIdHash
        {
            get
            {
                return this._RunIdHash;
            }
        }

        /// <summary>
        /// 业务流下一节点ID集合
        /// 以路径名为KEY，保存节点ID
        /// </summary>
        public Hashtable NextNodeIdHash
        {
            get
            {
                return this._NextNodeIdHash;
            }
        }

        #endregion


        #region 公共方法


        /// <summary>
        /// 获取业务流实例的运行表ID
        /// </summary>
        /// <param name="key">流转路径名称</param>
        /// <returns>string</returns>
        public string GetRunID(string key)
        {
            return (_RunIdHash.ContainsKey(key) ? _RunIdHash[key].ToString() : "");
        }

        /// <summary>
        /// 保存业务流实例的运行表ID
        /// </summary>
        /// <param name="key">流转路径名称</param>
        /// <param name="v">运行ID</param>
        public void SetRunID(string key, string v)
        {
            this._RunIdHash[key] = v;
        }


        /// <summary>
        /// 获取业务流下一运行节点ID
        /// </summary>
        /// <param name="key">流转路径名称</param>
        /// <returns>string</returns>
        public string GetNextNodeID(string key)
        {
            return (_NextNodeIdHash.ContainsKey(key) ? _NextNodeIdHash[key].ToString() : "");
        }

        /// <summary>
        /// 保存业务流下一运行节点ID
        /// </summary>
        /// <param name="key">流转路径名称</param>
        /// <param name="v">节点ID</param>
        public void SetNextNodeID(string key, string v)
        {
            this._NextNodeIdHash[key] = v;
        }

        #endregion

    }
}
