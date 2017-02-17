using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 个性化设置表
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:14
    /// </summary>
    [Serializable]
    public class SysUserindividModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///用户ID
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///签名图片路径
			/// </summary>
			public virtual string SIGNPIC
			{
				get;
				set;
			}

			/// <summary>
			///首页图表订制
			/// </summary>
			public virtual string INDEXCHART
			{
				get;
				set;
			}

			/// <summary>
			///首页图表权限值
			/// </summary>
			public virtual int? CHARTPOWER
			{
				get;
				set;
			}

			/// <summary>
			///个性化1
			/// </summary>
			public virtual string SPECIAL1
			{
				get;
				set;
			}

			/// <summary>
			///个性化2
			/// </summary>
			public virtual string SPECIAL2
			{
				get;
				set;
			}

			/// <summary>
			///个性化3
			/// </summary>
			public virtual string SPECIAL3
			{
				get;
				set;
			}

			/// <summary>
			///个性化4
			/// </summary>
			public virtual string SPECIAL4
			{
				get;
				set;
			}

			/// <summary>
			///个性化5
			/// </summary>
			public virtual string SPECIAL5
			{
				get;
				set;
			}

        #endregion
    }

}
