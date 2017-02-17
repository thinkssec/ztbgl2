using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Dmgl
{
    /// <summary>
    /// 地面维修计划管理
	/// 创建人:代码生成器
	/// 创建时间:	2015/5/18 9:37:38
    /// </summary>
    [Serializable]
    public class DmglPlanModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string PID
			{
				get;
				set;
			}

			/// <summary>
			///项目类别1
			/// </summary>
			public virtual string PKIND1
			{
				get;
				set;
			}

			/// <summary>
			///项目类别2
			/// </summary>
			public virtual string PKIND2
			{
				get;
				set;
			}

			/// <summary>
			///明细
			/// </summary>
			public virtual string MX
			{
				get;
				set;
			}

			/// <summary>
			///描述
			/// </summary>
			public virtual string MS
			{
				get;
				set;
			}

			/// <summary>
			///计划单价
			/// </summary>
			public virtual decimal? PDJ
			{
				get;
				set;
			}

			/// <summary>
			///计划数量
			/// </summary>
			public virtual int? PSL
			{
				get;
				set;
			}

			/// <summary>
			///计划开始时间
			/// </summary>
			public virtual DateTime? PSTARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///计划结束时间
			/// </summary>
			public virtual DateTime? PENDDATE
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
			public virtual int? SPSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SPTIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPCONTENT
			{
				get;
				set;
			}

			/// <summary>
			///合同开始时间
			/// </summary>
			public virtual DateTime? CSTARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///合同结束时间
			/// </summary>
			public virtual DateTime? CENDDATE
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
			///创建时间
			/// </summary>
			public virtual DateTime? CREATETIME
			{
				get;
				set;
			}

			/// <summary>
			///计划金额
			/// </summary>
			public virtual decimal? PAMOUNT
			{
				get;
				set;
			}

			/// <summary>
			///实际结束时间
			/// </summary>
			public virtual DateTime? ENDDATE
			{
				get;
				set;
			}

			/// <summary>
			///备注
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///主要领导
			/// </summary>
			public virtual int? SPR2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP2STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SP2TIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SP2CONTENT
			{
				get;
				set;
			}

			/// <summary>
			///实际开始时间
			/// </summary>
			public virtual DateTime? STARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///施工单位
			/// </summary>
			public virtual string SGDW
			{
				get;
				set;
			}

			/// <summary>
			///施工进度名称
			/// </summary>
			public virtual string FNAMES2
			{
				get;
				set;
			}

			/// <summary>
			///施工进度附件保存名称
			/// </summary>
			public virtual string FVIEWNAMES2
			{
				get;
				set;
			}

			/// <summary>
			///工程编号
			/// </summary>
			public virtual string GCBH
			{
				get;
				set;
			}

			/// <summary>
			///工程地点
			/// </summary>
			public virtual string GCDD
			{
				get;
				set;
			}

			/// <summary>
			///工程内容
			/// </summary>
			public virtual string GCNR
			{
				get;
				set;
			}

			/// <summary>
			///工程备注
			/// </summary>
			public virtual string GCBZ
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string FNAMES3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string FVIEWNAMES3
			{
				get;
				set;
			}

			/// <summary>
			///结算金额
			/// </summary>
			public virtual decimal? JSJE
			{
				get;
				set;
			}

			/// <summary>
			///结算日期
			/// </summary>
			public virtual DateTime? JSRQ
			{
				get;
				set;
			}

			/// <summary>
			///结算人
			/// </summary>
			public virtual int? JSR
			{
				get;
				set;
			}

        #endregion
    }

}
