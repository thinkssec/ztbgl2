using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hr
{
    /// <summary>
    /// 人员资格表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:12
    /// </summary>
    [Serializable]
    public class HrZigeModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string ZGID
			{
				get;
				set;
			}

			/// <summary>
			///报告审核人
			/// </summary>
			public virtual int? BGSHR
			{
				get;
				set;
			}

			/// <summary>
			///项目负责人
			/// </summary>
			public virtual int? XMFZR
			{
				get;
				set;
			}

			/// <summary>
			///其它资质1
			/// </summary>
			public virtual int? QTZZ1
			{
				get;
				set;
			}

			/// <summary>
			///用户ID
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///其它资质2
			/// </summary>
			public virtual int? QTZZ2
			{
				get;
				set;
			}

			/// <summary>
			///审图负责人
			/// </summary>
			public virtual int? STFZR
			{
				get;
				set;
			}

			/// <summary>
			///检验类型ID
			/// </summary>
			public virtual int KINDID
			{
				get;
				set;
			}

			/// <summary>
			///报告批准人
			/// </summary>
			public virtual int? BGPZR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SDRQ
			{
				get;
				set;
			}
            /// <summary>
            ///报告编写人
            /// </summary>
            public virtual int? BGBXR
            {
                get;
                set;
            }
            /// <summary>
            ///报告校对人
            /// </summary>
            public virtual int? BGJDR
            {
                get;
                set;
            }
            /// <summary>
            ///设计审查人
            /// </summary>
            public virtual int? SJSCR
            {
                get;
                set;
            }

        #endregion

            public virtual Model.Basis.Sys.SysUserModel SysUserModel { get; set; }
    }

}
