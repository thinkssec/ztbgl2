using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 分包申请单表
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/11 11:28:02
    /// </summary>
    [Serializable]
    public class CrmFbreqformModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///分包申请单ID
			/// </summary>
			public virtual string REQID
			{
				get;
				set;
			}

			/// <summary>
			///分包金额
			/// </summary>
			public virtual decimal FBJE
			{
				get;
				set;
			}

			/// <summary>
			///分包编号
			/// </summary>
			public virtual string FBBH
			{
				get;
				set;
			}

			/// <summary>
			///拟分包工作
			/// </summary>
			public virtual string FBGZ
			{
				get;
				set;
			}

			/// <summary>
			///是否报批
			/// </summary>
			public virtual int? BP
			{
				get;
				set;
			}

			/// <summary>
			///申请人
			/// </summary>
			public virtual int? SQR
			{
				get;
				set;
			}

			/// <summary>
			///分包方案
			/// </summary>
			public virtual string FBFA
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
			///附件
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///申请日期
			/// </summary>
			public virtual DateTime? SQRQ
			{
				get;
				set;
			}

			/// <summary>
			///审核状态 0:未审核 1：审核通过 2：审核未通过
			/// </summary>
			public virtual int? SHZT
			{
				get;
				set;
			}

			/// <summary>
			///审核日期
			/// </summary>
			public virtual DateTime? SHRQ
			{
				get;
				set;
			}

			/// <summary>
			///估算工作量
			/// </summary>
			public virtual string GZL
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
			///申请单位
			/// </summary>
			public virtual int SQDW
			{
				get;
				set;
			}

            /// <summary>
            ///选择分包商ID
            /// </summary>
            public virtual string FBSID
            {
                get;
                set;
            }
        #endregion
    }

}
