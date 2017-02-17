using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 角色获取方法表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:51
    /// </summary>
    [Serializable]
    public class BfClsmethodsModel : BasisSuperModel
    {
        
			/// <summary>
			///方法表ID
			/// </summary>
			public virtual string BF_CLSID
			{
				get;
				set;
			}

			/// <summary>
			///类名称
			/// </summary>
			public virtual string BF_CLSNAME
			{
				get;
				set;
			}

			/// <summary>
			///方法说明
			/// </summary>
			public virtual string BF_METHODDESC
			{
				get;
				set;
			}

			/// <summary>
			///方法名称
			/// </summary>
			public virtual string BF_METHOD
			{
				get;
				set;
			}

    }

}
