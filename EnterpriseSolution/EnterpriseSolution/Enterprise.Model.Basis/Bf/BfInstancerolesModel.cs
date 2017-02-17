using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 业务流实例角色表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:53
    /// </summary>
    [Serializable]
    public class BfInstancerolesModel : BasisSuperModel
    {
        
			/// <summary>
			///实例角色表ID
			/// </summary>
			public virtual string BF_INSTANCEROLEID
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
			///角色名称
			/// </summary>
			public virtual string BF_ROLENAME
			{
				get;
				set;
			}

			/// <summary>
			///角色类型:0=指定人员 1=静态角色 2=动态角色 
			/// </summary>
			public virtual int? BF_ROLETYPE
			{
				get;
				set;
			}

			/// <summary>
			///操作类型:0=操作人 1=通知人
			/// </summary>
			public virtual int? BF_OPERATIONTYPE
			{
				get;
				set;
			}

			/// <summary>
			///用户编号串
            ///格式：",12,23,"
			/// </summary>
            public virtual string USERIDS
			{
				get;
				set;
			}

			/// <summary>
			///业务流关联表ID
			/// </summary>
			public virtual string BF_INSTANCEID
			{
				get;
				set;
			}

    }

}
