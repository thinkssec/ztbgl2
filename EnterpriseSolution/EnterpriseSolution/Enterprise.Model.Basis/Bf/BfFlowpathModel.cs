using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 节点流转表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:51
    /// </summary>
    [Serializable]
    public class BfFlowpathModel : BasisSuperModel
    {
        
			/// <summary>
			///流转路径表ID
			/// </summary>
			public virtual string BF_PATHID
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
			///开始节点编号
			/// </summary>
			public virtual string BF_STARTNODE
			{
				get;
				set;
			}

			/// <summary>
			///流转路径名称
			/// </summary>
			public virtual string BF_PATHNAME
			{
				get;
				set;
			}

			/// <summary>
			///缺省流转路径
			/// </summary>
			public virtual string BF_DEFAULTPATH
			{
				get;
				set;
			}

			/// <summary>
			///上一节点编号
			/// </summary>
			public virtual string BF_PREVNODE
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
			///结束节点编号
			/// </summary>
			public virtual string BF_ENDNODE
			{
				get;
				set;
			}

			/// <summary>
			///下一节点编号
			/// </summary>
			public virtual string BF_NEXTNODE
			{
				get;
				set;
			}

    }

}
