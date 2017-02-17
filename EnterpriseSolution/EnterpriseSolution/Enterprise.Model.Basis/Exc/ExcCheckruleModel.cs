using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// 异常检查规则表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:19:23
    /// </summary>
    [Serializable]
    public class ExcCheckruleModel : BasisSuperModel
    {
        
			/// <summary>
			///规则ID
			/// </summary>
			public virtual string EXC_RULEID
			{
				get;
				set;
			}

			/// <summary>
			///备注说明
			/// </summary>
			public virtual string EXC_REMARK
			{
				get;
				set;
			}

			/// <summary>
			///节点ID
			/// </summary>
			public virtual string EXC_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///运行条件
			/// </summary>
			public virtual string EXC_CONDITION
			{
				get;
				set;
			}

			/// <summary>
			///异常通知对象
			/// </summary>
			public virtual string EXC_TOROLE
			{
				get;
				set;
			}

			/// <summary>
			///异常等级标识
			/// </summary>
			public virtual string EXC_MARKER
			{
				get;
				set;
			}

			/// <summary>
			///标准值
			/// </summary>
			public virtual decimal? EXC_STANDARDVALUE
			{
				get;
				set;
			}

			/// <summary>
			///操作符
			/// </summary>
			public virtual string EXC_OPERATOR
			{
				get;
				set;
			}

			/// <summary>
			///异常通知方式
			/// </summary>
			public virtual string EXC_BYMODE
			{
				get;
				set;
			}

    }

}
