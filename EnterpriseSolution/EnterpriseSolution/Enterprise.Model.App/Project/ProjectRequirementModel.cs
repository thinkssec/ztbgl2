using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 资源需求计划表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:23
    /// </summary>
    [Serializable]
    public class ProjectRequirementModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///需求计划ID
			/// </summary>
			public virtual string REQID
			{
				get;
				set;
			}

			/// <summary>
			///需求类型: 0=新购 1=调拨
			/// </summary>
			public virtual int? REQTYPE
			{
				get;
				set;
			}

			/// <summary>
			///概算金额
			/// </summary>
			public virtual decimal BUDGETARY
			{
				get;
				set;
			}

			/// <summary>
			///采购价格
			/// </summary>
			public virtual decimal PRICE
			{
				get;
				set;
			}

			/// <summary>
			///供货地点
			/// </summary>
			public virtual string SUPPLYADDR
			{
				get;
				set;
			}

			/// <summary>
			///物资名称
			/// </summary>
			public virtual string GOODSNAME
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
			///物资类别
			/// </summary>
			public virtual string KINDID
			{
				get;
				set;
			}

			/// <summary>
			///审核批号
			/// </summary>
			public virtual string AUDITID
			{
				get;
				set;
			}

			/// <summary>
			///审核日期
			/// </summary>
			public virtual DateTime? AUDITDATE
			{
				get;
				set;
			}

			/// <summary>
			///交付时间
			/// </summary>
			public virtual DateTime? DELIVERYDATE
			{
				get;
				set;
			}

			/// <summary>
			///审核状态:0=不通过 1=通过
			/// </summary>
			public virtual int? AUDITSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///数量
			/// </summary>
			public virtual int? GOODSCOUNT
			{
				get;
				set;
			}

			/// <summary>
			///单位
			/// </summary>
			public virtual string GOODSUNIT
			{
				get;
				set;
			}

			/// <summary>
			///交付地点
			/// </summary>
			public virtual string DELIVERYADDR
			{
				get;
				set;
			}

			/// <summary>
			///供货时间
			/// </summary>
			public virtual DateTime? SUPPLYDATE
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
			///规格
			/// </summary>
			public virtual string GOODSTYPE
			{
				get;
				set;
			}

        #endregion
    }

}
