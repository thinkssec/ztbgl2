using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// 检验类型表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-8 14:53:57
    /// </summary>
    [Serializable]
    public class ExamineKindModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///检验类型ID
			/// </summary>
			public virtual int KINDID
			{
				get;
				set;
			}

			/// <summary>
			///业务归属部门
			/// </summary>
			public virtual int? DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///上级类型ID
			/// </summary>
			public virtual int? PARENTID
			{
				get;
				set;
			}

			/// <summary>
			///层级顺序
			/// </summary>
			public virtual string KINDORDER
			{
				get;
				set;
			}

			/// <summary>
			///类型名称
			/// </summary>
			public virtual string KINDNAME
			{
				get;
				set;
			}

        #endregion
    }

}
