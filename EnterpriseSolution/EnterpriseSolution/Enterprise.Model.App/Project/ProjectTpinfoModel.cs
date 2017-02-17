using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 立项
	/// 创建人:代码生成器
	/// 创建时间:	2015/9/8 23:25:12
    /// </summary>
    [Serializable]
    public class ProjectTpinfoModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///1:综合 2：物资 3：工程
			/// </summary>
			public virtual int? KINDID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJNUMBER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJNAME
			{
				get;
				set;
			}

			/// <summary>
			///计划金额
			/// </summary>
			public virtual decimal? PROJINCOME
			{
				get;
				set;
			}

			/// <summary>
			///资金来源
			/// </summary>
			public virtual string ZJLY
			{
				get;
				set;
			}

			/// <summary>
			///拟开标时间
			/// </summary>
			public virtual DateTime? NKBSJ
			{
				get;
				set;
			}

			/// <summary>
			///拟开标地点
			/// </summary>
			public virtual string NKBDD
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
			public virtual string PHONE
			{
				get;
				set;
			}

			/// <summary>
			///内容
			/// </summary>
			public virtual string PROJCONTENT
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
			///项目运行状态: -1=临时保存；0提交审核  1 ：审核通过 2：审核不通过 3:招标文件通过7:准备评标 8 评标结束  12：招标结束
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///招标方式  1:公开招标 2.邀请招标
			/// </summary>
			public virtual int? ZBFS
			{
				get;
				set;
			}

			/// <summary>
			///部门审核人
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///申请部门
			/// </summary>
			public virtual int? DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///项目类型名称
			/// </summary>
			public virtual string KINDNAME
			{
				get;
				set;
			}

			/// <summary>
			///经营管理部审批
			/// </summary>
			public virtual int? SPR
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
			///返回人
			/// </summary>
			public virtual int? RTN
			{
				get;
				set;
			}

			/// <summary>
			///返回状态
			/// </summary>
			public virtual string RTNSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///资金来源备注
			/// </summary>
			public virtual string ZJBZ
			{
				get;
				set;
			}

			/// <summary>
			///申请理由
			/// </summary>
			public virtual string SQLY
			{
				get;
				set;
			}

			/// <summary>
			///审核意见
			/// </summary>
			public virtual string SHYJ
			{
				get;
				set;
			}

			/// <summary>
			///审批意见
			/// </summary>
			public virtual string SPYJ
			{
				get;
				set;
			}

			/// <summary>
			///专业部门审核人
			/// </summary>
			public virtual int? SPR2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ2
			{
				get;
				set;
			}

			/// <summary>
			///财务/计划部门审核
			/// </summary>
			public virtual int? SPR3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ3
			{
				get;
				set;
			}

			/// <summary>
			///招投标管理办公室审核
			/// </summary>
			public virtual int? SPR4
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ4
			{
				get;
				set;
			}

			/// <summary>
			///分管领导审批
			/// </summary>
			public virtual int? SPR5
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ5
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SPR6
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ6
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SHS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SPS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP4
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP5
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP6
			{
				get;
				set;
			}

			/// <summary>
			///业务部门
			/// </summary>
			public virtual int? YWBM
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string NKBSJSTR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

        #endregion
    }

}
