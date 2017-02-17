using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// 出差申请审批记录表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-25 8:12:13
    /// </summary>
    [Serializable]
    public class BusitravelWfprocessModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///流程授权审核人员
			/// </summary>
			public virtual int? PUSERID
			{
				get;
				set;
			}

			/// <summary>
			///自动编号
			/// </summary>
			public virtual string PID
			{
				get;
				set;
			}

			/// <summary>
			///是否审核
			/// </summary>
			public virtual int? PISCHECK
			{
				get;
				set;
			}

			/// <summary>
			///运行表ID
			/// </summary>
			public virtual string RUNID
			{
				get;
				set;
			}

			/// <summary>
			///审核时间
			/// </summary>
			public virtual DateTime? PTIME
			{
				get;
				set;
			}

			/// <summary>
			///流程类型
			/// </summary>
			public virtual string PWFTYPE
			{
				get;
				set;
			}

			/// <summary>
			///审核结论
			/// </summary>
			public virtual int? PRESULT
			{
				get;
				set;
			}

			/// <summary>
			///实例ID
			/// </summary>
			public virtual string WFID
			{
				get;
				set;
			}

			/// <summary>
			///审核排序
			/// </summary>
			public virtual int? PUSERORDERBY
			{
				get;
				set;
			}

			/// <summary>
			///流程审核人员
			/// </summary>
			public virtual int? PUSERID_REAL
			{
				get;
				set;
			}

			/// <summary>
			///审核说明
			/// </summary>
			public virtual string PREMARK
			{
				get;
				set;
			}

        #endregion
    }

}
