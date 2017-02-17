using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 业务流运行表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:57
    /// </summary>
    [Serializable]
    public class BfRunningModel : BasisSuperModel
    {
        
			/// <summary>
			///运行表ID
			/// </summary>
			public virtual string BF_RUNID
			{
				get;
				set;
			}

			/// <summary>
			///流转路径表ID
			/// </summary>
			public virtual string BF_PATHID
			{
				get;
				set;
			}

			/// <summary>
			///运行时间
			/// </summary>
			public virtual DateTime? BF_RUNDATE
			{
				get;
				set;
			}

			/// <summary>
			///业务流关联表ID
			/// </summary>
			public virtual string BF_INSTANCEID
			{
				get;
				set;
			}

			/// <summary>
			///运行状态:0=未运行 1=已运行
			/// </summary>
			public virtual int? BF_RUNSTATUS
			{
				get;
				set;
			}

			/// <summary>
            ///上一级运行表ID
			/// </summary>
			public virtual string PARENT_BF_RUNID
			{
				get;
				set;
			}

			/// <summary>
			///运行描述
			/// </summary>
			public virtual string BF_RUNDESC
			{
				get;
				set;
			}


            #region 外键关联对象

            /// <summary>
            /// 业务流实例对象  
            /// </summary>
            public virtual BfInstancesModel BfInstance { get; set; }

            /// <summary>
            /// 流转路径--对象  
            /// </summary>
            public virtual BfFlowpathModel BfFlowpath { get; set; }

            #endregion

    }

}
