using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// 业务流基础表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-4 12:18:49
    /// </summary>
    [Serializable]
    public class BfBaseModel : BasisSuperModel
    {
        
			/// <summary>
			///业务流ID
			/// </summary>
			public virtual string BF_ID
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
			///当前状态:1=启用 0=废弃
			/// </summary>
			public virtual int? BF_STATUS
			{
				get;
				set;
			}

			/// <summary>
			///业务类型
			/// </summary>
			public virtual string BF_TYPE
			{
				get;
				set;
			}

			/// <summary>
			///业务流名称
			/// </summary>
			public virtual string BF_NAME
			{
				get;
				set;
			}


            //private IList<BfPublishModel> _basisBfPublishes = new List<BfPublishModel>();

            //public virtual IList<BfPublishModel> BfPublishes
            //{
            //    get { return _basisBfPublishes; }
            //    set { _basisBfPublishes = value; }
            //}

    }

}
