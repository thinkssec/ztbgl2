using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 审核信息表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:14
    /// </summary>
    [Serializable]
    public class ProjectCheckModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///审核信息表ID
			/// </summary>
			public virtual string CHECKID
			{
				get;
				set;
			}

			/// <summary>
			///审核人
			/// </summary>
			public virtual int? CHECKER
			{
				get;
				set;
			}

			/// <summary>
			///审核意见
			/// </summary>
			public virtual string CHECKOPINION
			{
				get;
				set;
			}

			/// <summary>
			///关联ID
			/// </summary>
			public virtual string ASSOCIATEDID
			{
				get;
				set;
			}

			/// <summary>
			///审核状态
            ///0=未审核 1=已审核
			/// </summary>
			public virtual int? CHECKSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///审核日期
			/// </summary>
			public virtual DateTime? CHECKDATE
			{
				get;
				set;
			}

			/// <summary>
			///发送日期
			/// </summary>
			public virtual DateTime? SENDDATE
			{
				get;
				set;
			}

			/// <summary>
			///审核结果
            ///0=不同意 1=同意 2=修改后同意
			/// </summary>
			public virtual int? CHECKRESULT
			{
				get;
				set;
			}

			/// <summary>
			///项目ID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///发送人
			/// </summary>
			public virtual int? SENDER
			{
				get;
				set;
			}

			/// <summary>
			///审核次序
			/// </summary>
			public virtual int? CHECKORDER
			{
				get;
				set;
			}

            /// <summary>
            /// 审核附件
            /// </summary>
            public virtual string CHECKATTCH
            {
                get;
                set;
            }
            /// <summary>
            /// 打分
            /// </summary>
            public virtual int? CHECKSCORE
            {
                get;
                set;
            }

        #endregion
    }


    /// <summary>
    /// 审核结果
    /// 0=不同意 1=同意 2=修改后同意
    /// </summary>
    public enum CheckResultType
    {
        不同意 = 0,
        同意 = 1,
        修改后同意 = 2
    }

}
