using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 检测报告表
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/22 16:48:39
    /// </summary>
    [Serializable]
    public class ProjectReportModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///报告表ID
			/// </summary>
			public virtual string RPTID
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
			///当前状态：0=未审核 1=审核通过  2=审核不通过  3=打印完成
			/// </summary>
			public virtual int? PRTSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///提交人
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///审核人
			/// </summary>
			public virtual int? AUDITOR
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
			///报告内容
			/// </summary>
			public virtual string RPTCONTS
			{
				get;
				set;
			}

			/// <summary>
			///附件
			/// </summary>
			public virtual string ATTACHMENT
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
			///批准人
			/// </summary>
			public virtual int? APPROVER
			{
				get;
				set;
			}

			/// <summary>
			///报告类型
			/// </summary>
			public virtual string RPTTYPE
			{
				get;
				set;
			}

			/// <summary>
			///报告名称
			/// </summary>
			public virtual string RPTNAME
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
			///报告日期
			/// </summary>
			public virtual DateTime? RPTDATE
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
			///报告编号
			/// </summary>
			public virtual string RPTBH
			{
				get;
				set;
			}

        #endregion
    }

}
