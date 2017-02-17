using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// 异常等级表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:19:24
    /// </summary>
    [Serializable]
    public class ExcGradeModel : BasisSuperModel
    {
        
			/// <summary>
			///异常等级标识
			/// </summary>
			public virtual string EXC_MARKER
			{
				get;
				set;
			}

			/// <summary>
			///异常等级名称
			/// </summary>
			public virtual string EXC_GADE
			{
				get;
				set;
			}

			/// <summary>
			///异常等级描述
			/// </summary>
			public virtual string EXC_GADEDESC
			{
				get;
				set;
			}

    }

}
