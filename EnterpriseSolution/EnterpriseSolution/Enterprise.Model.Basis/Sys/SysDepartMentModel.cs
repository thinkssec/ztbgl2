using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 组织机构
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:12
    /// </summary>
    [Serializable]
    public class SysDepartMentModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual int DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///组织机构名称
			/// </summary>
			public virtual string DNAME
			{
				get;
				set;
			}

            public virtual string DNO
            {
                get;
                set;
            }
            public virtual string DTYPE
            {
                get;
                set;
            }

			/// <summary>
			///父级编号
			/// </summary>
			public virtual int DPARENTID
			{
				get;
				set;
			}

			/// <summary>
			///层级深度
			/// </summary>
			public virtual int? DDEPTH
			{
				get;
				set;
			}

			/// <summary>
			///根节点
			/// </summary>
			public virtual int? DROOTID
			{
				get;
				set;
			}

			/// <summary>
			///排序
			/// </summary>
			public virtual int? DORDERBY
			{
				get;
				set;
			}

			/// <summary>
			///部门主任
			/// </summary>
			public virtual int DMANAGER
			{
				get;
				set;
			}

			/// <summary>
			///分管经理
			/// </summary>
			public virtual int DHEADERMANAGER
			{
				get;
				set;
			}

        #endregion
    }

}
