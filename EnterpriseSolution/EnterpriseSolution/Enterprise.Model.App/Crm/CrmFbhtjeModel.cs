using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 项目分包合同金额表
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/11 11:28:01
    /// </summary>
    [Serializable]
    public class CrmFbhtjeModel : AppSuperModel
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
			///分包合同ID
			/// </summary>
			public virtual string FBHTID
			{
				get;
				set;
			}

			/// <summary>
			///合同分摊金额
			/// </summary>
			public virtual decimal HTFTJE
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

        #endregion
    }

}
