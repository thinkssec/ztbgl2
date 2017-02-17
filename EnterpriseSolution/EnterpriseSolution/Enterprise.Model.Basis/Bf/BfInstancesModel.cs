using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 业务流实例表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:54
    /// </summary>
    [Serializable]
    public class BfInstancesModel : BasisSuperModel
    {
        
			/// <summary>
			///业务流关联表ID
			/// </summary>
			public virtual string BF_INSTANCEID
			{
				get;
				set;
			}

			/// <summary>
			///业务流ID
			/// </summary>
			public virtual string BF_ID
			{
				get;
				set;
			}

			/// <summary>
			///创建人
			/// </summary>
			public virtual string BF_FOUNDER
			{
				get;
				set;
			}

			/// <summary>
            /// 说明
			/// </summary>
			public virtual string BF_DESCRIBE
			{
				get;
				set;
			}

			/// <summary>
			///状态值: 0=运行 3=终止 2=暂停 1=结束
			/// </summary>
			public virtual int? BF_STATUSVALUE
			{
				get;
				set;
			}

			/// <summary>
			///创建日期
			/// </summary>
			public virtual DateTime? BF_CDATE
			{
				get;
				set;
			}

			/// <summary>
			///业务流版本
			/// </summary>
			public virtual int BF_VERSION
			{
				get;
				set;
			}


            #region 外键关联对象

            /// <summary>
            /// 业务流发布表--对象实例  
            /// </summary>
            public virtual BfPublishModel BfPublish { get; set; }


            private IList<BfInstancerolesModel> _BfInstanceroles = new List<BfInstancerolesModel>();
            /// <summary>
            /// 业务流实例角色集合
            /// </summary>
            public virtual IList<BfInstancerolesModel> BfInstanceroles
            {
                get { return _BfInstanceroles; }
                set { _BfInstanceroles = value; }
            }

            #endregion

    }

}
