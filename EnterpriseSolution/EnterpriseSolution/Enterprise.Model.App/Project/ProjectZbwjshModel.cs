using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 招标文件审核
	/// 创建人:代码生成器
	/// 创建时间:	2015/7/24 21:48:45
    /// </summary>
    [Serializable]
    public class ProjectZbwjshModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string RPTID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///申请人
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SUBMITDATE
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
			///审核状态 0=未审核 1=审核通过 2=审核不通过
			/// </summary>
			public virtual int? CHECKSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///项目运行状态: -1=临时保存；0提交审核  1 ：审核通过 2：审核不通过 7:准备评标 8 评标结束
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///审核人
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///附件文件名称
			/// </summary>
			public virtual string FNAMES
			{
				get;
				set;
			}

			/// <summary>
			///附件保存名称
			/// </summary>
			public virtual string FVIEWNAMES
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? PRTSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string RPTNAME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string ATTACHMENT
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SPR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SHBM
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPBM
			{
				get;
				set;
			}

        #endregion
    }

}
