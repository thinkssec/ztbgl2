using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// 异常检查节点表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:19:21
    /// </summary>
    [Serializable]
    public class ExcChecknodesModel : BasisSuperModel
    {
        
			/// <summary>
			///节点ID
			/// </summary>
			public virtual string EXC_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///节点顺序号
			/// </summary>
			public virtual int? EXC_NODEORDER
			{
				get;
				set;
			}

			/// <summary>
			///节点建立日期
			/// </summary>
			public virtual DateTime? EXC_CREATEDATE
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
			///当前节点编号
			/// </summary>
			public virtual string BF_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///节点描述
			/// </summary>
			public virtual string EXC_NODEDESC
			{
				get;
				set;
			}

			/// <summary>
			///异常临界时间:3,1
			/// </summary>
			public virtual string EXC_CRITICALTIME
			{
				get;
				set;
			}

			/// <summary>
			///节点检查者
			/// </summary>
			public virtual string EXC_NODECHECKER
			{
				get;
				set;
			}

			/// <summary>
			///节点名称
			/// </summary>
			public virtual string EXC_NODENAME
			{
				get;
				set;
			}

			/// <summary>
			///节点编码
			/// </summary>
			public virtual string EXC_NODECODE
			{
				get;
				set;
			}

			/// <summary>
			///业务流版本
			/// </summary>
			public virtual int? BF_VERSION
			{
				get;
				set;
			}

			/// <summary>
			///节点责任者
			/// </summary>
			public virtual string EXC_NODEPRINCIPAL
			{
				get;
				set;
			}

    }

}
