using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// 异常检查记录表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:19:22
    /// </summary>
    [Serializable]
    public class ExcCheckrecordModel : BasisSuperModel
    {
        
			/// <summary>
			///记录ID
			/// </summary>
			public virtual string EXC_RECORDID
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
			///业务流关联表ID
			/// </summary>
			public virtual string BF_INSTANCEID
			{
				get;
				set;
			}

			/// <summary>
			///异常状态:已处理 未处理 运行中 已失效 已完成  
			/// </summary>
			public virtual string EXC_STATUS
			{
				get;
				set;
			}

			/// <summary>
			///计划完成时间
			/// </summary>
			public virtual DateTime? EXC_FINISHTIME
			{
				get;
				set;
			}

			/// <summary>
			///异常检查时间
			/// </summary>
			public virtual DateTime? EXC_CHECKTIME
			{
				get;
				set;
			}

    }

}
