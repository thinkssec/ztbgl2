using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 业务流节点表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:56
    /// </summary>
    [Serializable]
    public class BfNodesModel : BasisSuperModel
    {
        
			/// <summary>
			///当前节点编号
			/// </summary>
			public virtual string BF_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///业务流ID
			/// </summary>
			public virtual string BF_ID
			{
				get;
				set;
			}

			/// <summary>
			///业务流版本
			/// </summary>
			public virtual int BF_VERSION
			{
				get;
				set;
			}

			/// <summary>
			///节点名称
			/// </summary>
			public virtual string BF_NODENAME
			{
				get;
				set;
			}

			/// <summary>
			///缺省意见或结果
			/// </summary>
			public virtual string BF_AUDITOPINION
			{
				get;
				set;
			}

			/// <summary>
			///节点描述
			/// </summary>
			public virtual string BF_NODEDESC
			{
				get;
				set;
			}

			/// <summary>
			///分支节点流转类型:0=并行 1=多选一
			/// </summary>
			public virtual int? BF_FLOWTYPE1
			{
				get;
				set;
			}

			/// <summary>
			///子流程节点流转类型:1=独立模式 0=锁定模式
			/// </summary>
			public virtual int? BF_FLOWTYPE2
			{
				get;
				set;
			}

			/// <summary>
			///子流程业务流ID
			/// </summary>
			public virtual string SUB_BF_ID
			{
				get;
				set;
			}

			/// <summary>
			///汇合节点流转类型:0=等待所有分支流转到此 1=等待一条分支流转到此
			/// </summary>
			public virtual int? BF_FLOWTYPE3
			{
				get;
				set;
			}

			/// <summary>
			///节点对应表单
            ///从Modules起始的全路径
			/// </summary>
			public virtual string BF_FORM
			{
				get;
				set;
			}

			/// <summary>
			///超期处理方式:0=不处理  1=运行下一节点  2=转代理人处理
			/// </summary>
			public virtual int? BF_EXTENDEDTREATMENT
			{
				get;
				set;
			}

			/// <summary>
			///节点类型
			/// </summary>
			public virtual string BF_NODETYPE
			{
				get;
				set;
			}

			/// <summary>
			///子流程业务流版本
			/// </summary>
			public virtual int? SUB_BF_VERSION
			{
				get;
				set;
			}

			/// <summary>
			///节点进度值
			/// </summary>
			public virtual int? BF_PROGRESSVALUE
			{
				get;
				set;
			}

			/// <summary>
			///是否允许代办
			/// </summary>
			public virtual int? BF_COMMISSION
			{
				get;
				set;
			}

			/// <summary>
			///是否支持回退
			/// </summary>
			public virtual int? BF_FORWARD
			{
				get;
				set;
			}

			/// <summary>
			///节点操作人
			/// </summary>
			public virtual string BF_DUTYOFFICER
			{
				get;
				set;
			}

			/// <summary>
			///是否为关键节点
			/// </summary>
			public virtual int? BF_KEYPOINT
			{
				get;
				set;
			}

			/// <summary>
			///办理时限
			/// </summary>
			public virtual int? BF_TIMELIMIT
			{
				get;
				set;
			}

			/// <summary>
			///节点通知人
			/// </summary>
			public virtual string BF_NOTIFIER
			{
				get;
				set;
			}

			/// <summary>
			///是否为进度异常控制点
			/// </summary>
			public virtual int? BF_CONTROLPOINT
			{
				get;
				set;
			}

			/// <summary>
			///消息提醒方式:SMS MSG EMAIL
			/// </summary>
			public virtual string BF_REMINDWAY
			{
				get;
				set;
            }


            #region 外键关联对象

            /// <summary>
            /// 业务流发布表--对象实例  
            /// </summary>
            public virtual BfPublishModel BfPublish { get; set; }

            ///// <summary>
            ///// 业务流节点角色集合
            ///// </summary>
            //public virtual IList<BfNoderolesModel> BfNoderoles
            //{
            //    get;
            //    set;
            //}

            #endregion

    }

}
