using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 竣工资料表
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/19 10:25:27
    /// </summary>
    [Serializable]
    public class ProjectCompletionModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///资料表ID
			/// </summary>
			public virtual string DATAID
			{
				get;
				set;
			}

			/// <summary>
			///质量得分
			/// </summary>
			public virtual decimal? QUALITYSCORE
			{
				get;
				set;
			}

			/// <summary>
			///版本号
			/// </summary>
			public virtual string VERSION
			{
				get;
				set;
			}

			/// <summary>
			///编写人
			/// </summary>
			public virtual int? WRITER
			{
				get;
				set;
			}

			/// <summary>
			///签发人
			/// </summary>
			public virtual int? SIGNER
			{
				get;
				set;
			}

			/// <summary>
			///校对人
			/// </summary>
			public virtual int? PROOFREADER
			{
				get;
				set;
			}

			/// <summary>
			///备注
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///审核人
			/// </summary>
			public virtual int? APPROVER
			{
				get;
				set;
			}

			/// <summary>
			///附件
			/// </summary>
			public virtual string ATTMENT
			{
				get;
				set;
			}

			/// <summary>
			///资料名称
			/// </summary>
			public virtual string DATANAME
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
			///审状态： 0审核中 1审核同意 2审核不同意
			/// </summary>
			public virtual string CSTATUS
			{
				get;
				set;
			}

            /// <summary>
            /// 资料提交人
            /// </summary>
            public virtual int SUBMITTER
            {
                get;
                set;
            }

        #endregion
    }

}
