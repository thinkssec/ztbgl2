using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Zygl
{
    /// <summary>
    /// 作业管理开工申请
	/// 创建人:代码生成器
	/// 创建时间:	2015/5/19 17:09:28
    /// </summary>
    [Serializable]
    public class ZyglPlanModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string ZID
			{
				get;
				set;
			}

			/// <summary>
			///井号
			/// </summary>
			public virtual string JH
			{
				get;
				set;
			}

			/// <summary>
			///单元区块
			/// </summary>
			public virtual string DYQK
			{
				get;
				set;
			}

			/// <summary>
			///层位
			/// </summary>
			public virtual string CW
			{
				get;
				set;
			}

			/// <summary>
			///上次作业时间
			/// </summary>
			public virtual DateTime? LASTDATE
			{
				get;
				set;
			}

			/// <summary>
			///上次施工内容
			/// </summary>
			public virtual string LSGNR
			{
				get;
				set;
			}

			/// <summary>
			///生产周期
			/// </summary>
			public virtual decimal? SCZQ
			{
				get;
				set;
			}

			/// <summary>
			///本次作业原因
			/// </summary>
			public virtual string ZYYY
			{
				get;
				set;
			}

			/// <summary>
			///施工内容
			/// </summary>
			public virtual string SGNR
			{
				get;
				set;
			}

			/// <summary>
			///作业分类
			/// </summary>
			public virtual string ZYFL
			{
				get;
				set;
			}

			/// <summary>
			///措施类别
			/// </summary>
			public virtual string CSLB
			{
				get;
				set;
			}

			/// <summary>
			///申请开工日期
			/// </summary>
			public virtual DateTime? PSTARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///计划完工日期
			/// </summary>
			public virtual DateTime? PENDDATE
			{
				get;
				set;
			}

			/// <summary>
			///预算额
			/// </summary>
			public virtual decimal? YSE
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
			///
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SHSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SHTIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SHCONTENT
			{
				get;
				set;
			}

			/// <summary>
			///-1:临时保存     0：提交审核  1：通过 2：不通过 3：完工4：完工验收 5：结算
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? STARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? ENDDATE
			{
				get;
				set;
			}

        #endregion
    }

}
